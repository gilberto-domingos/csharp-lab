using DotNetEnv;
using RabbitMQ.Extensions;
using Microsoft.OpenApi.Models;
using RabbitMQ.Controllers;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RabbitMQ",
        Version = "v1",
        Description = "Documentação da RabbitMQ",
        Contact = new OpenApiContact
        {
            Name = "Gilberto Domingos Jr",
            Email = "jrdomingosjr00@gmail.com"
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddRabbitMqService();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.AddApiEndPoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQ v1");
    });
}

app.Run();