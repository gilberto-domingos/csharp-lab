using Application.Interfaces;
using Application.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CpfCnpjValid API",
        Version = "v1",
        Description = "API simples para validação de CPF e CNPJ (DDD básico)",
        Contact = new OpenApiContact
        {
            Name = "Gilberto Domingos",
            Email = "gilberto1domingos1@gmail.com"
        }
    });
});

builder.Services.AddOpenApi();

builder.Services.AddScoped<IDocumentoService, DocumentoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CpfCnpjValid API V1");
        c.RoutePrefix = string.Empty; 
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();