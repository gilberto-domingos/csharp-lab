using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using PrintsControl.Application;
using PrintsControl.Persistence;
using PrintsControl.Persistence.Context;
using PrintsControl.Persistence.Infrastructure.Seeds;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");
Console.WriteLine($"[Startup] Porta configurada: {port}");

if (builder.Environment.IsDevelopment())
{
    Env.Load();
    Console.WriteLine("[Startup] Ambiente de Desenvolvimento detectado.");
}
else
{
    Console.WriteLine($"[Startup] Ambiente: {builder.Environment.EnvironmentName}");
}

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", policy =>
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin());
});

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureCors();
builder.Services.ConfigureSwagger();

builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddUnitOfWork();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        var pending = context.Database.GetPendingMigrations();
        if (pending != null && pending.Any())
        {
            Console.WriteLine("[Startup] Aplicando migrations...");
            context.Database.Migrate();
            Console.WriteLine("[Startup] Migrations aplicadas.");
        }
        else
        {
            Console.WriteLine("[Startup] Nenhuma migration pendente.");
        }

        try
        {
            DbSeeder.Seed(context);
            Console.WriteLine("[Startup] DbSeeder executado.");
        }
        catch (Exception exSeed)
        {
            Console.WriteLine("[Startup][WARN] Seed falhou: " + exSeed.Message);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("[Startup][ERROR] Erro ao aplicar migrations: " + ex.Message);
    }
}

var enableSwagger = builder.Configuration.GetValue<bool>("EnableSwagger", true);

if (app.Environment.IsDevelopment() || enableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrintsControl API V1");
        c.RoutePrefix = string.Empty; 
    });
}

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "ok", time = DateTimeOffset.UtcNow }));

app.MapGet("/", (HttpContext http) =>
{
    http.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapControllers();

Console.WriteLine($"[Startup] Aplicação iniciada e disponível em http://localhost:{port}");
app.Run();
