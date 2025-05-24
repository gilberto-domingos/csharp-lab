<<<<<<< HEAD
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
            Name = "gilberto domingos jr",
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
=======
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
>>>>>>> ff8958a (feat: initial project)
