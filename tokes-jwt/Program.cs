using DotNetEnv;
using JwtBearer.Config;

Env.Load(".env");

Console.WriteLine($"Chave: {Configuration.Privatekey}"); 

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
