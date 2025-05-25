using DotNetEnv;
using RabbitMQ.Controllers;
using RabbitMQ.Extensions;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRabbitMqService();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "RabbitMQ",
        Version = "v1",
        Description = "Documentação da RabbitMQ",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Gilberto Domingos Jr",
            Email = "jrdomingosjr00@gmail.com",
        }
    });
});

var app = builder.Build();

app.AddApiEndPoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMQ v1");
    });
}

app.UseHttpsRedirection();
app.Run();