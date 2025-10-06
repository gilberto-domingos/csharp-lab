using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using PrintsControl.Application;
using PrintsControl.Persistence;
using PrintsControl.Persistence.Context;
using PrintsControl.Persistence.Infrastructure.Seeds;


var builder = WebApplication.CreateBuilder(args);

    Env.Load();
    
    builder.Services.AddCors(opt => opt.AddPolicy("AllowAll",
        opt => opt.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin())
    );
    
    
    builder.Services.ConfigurePersistenceApp(builder.Configuration);
    builder.Services.ConfigureApplicationApp();
    builder.Services.ConfigureAuthentication();
    builder.Services.ConfigureCors();
    builder.Services.ConfigureSwagger();
    builder.Services.AddSwaggerGen();
    

    builder.Services.AddControllers();
    builder.Services.AddRepositories();
    builder.Services.AddUnitOfWork();


    var app = builder.Build();
    
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
        DbSeeder.Seed(context);           
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrintsControl API V1");
            c.RoutePrefix = string.Empty; 
        });

    }       

    app.UseCors("AllowAll");

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
