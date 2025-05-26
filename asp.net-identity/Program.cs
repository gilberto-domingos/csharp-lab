using ApiIdentityEndpoint.Data;
using ApiIdentityEndpoint.Models;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();
    
var builder = WebApplication.CreateBuilder(args);

var connectionString = Env.GetString("CONNECTION_STRING");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapIdentityApi<User>();

app.Run();
