using DotNetEnv;
using JwtBearer.Config;
using JwtBearer.Models;
using JwtBearer.Service;

Env.Load(".env");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<AuthenticationService>();     

var app = builder.Build();

app.MapGet("/", (AuthenticationService service) => service.Generater(
    new User(1, "test@gmail.com","123", new[]
{
    "professional","premium"
}
    )));

app.Run();
