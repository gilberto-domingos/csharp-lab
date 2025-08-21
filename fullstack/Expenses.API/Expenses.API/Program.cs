using System.Security.Claims;
using Expenses.API.Data;
using Expenses.API.Data.Services;
using Expenses.API.Middleware;
using Expenses.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DotNetEnv; 


var builder = WebApplication.CreateBuilder(args);

Env.Load();

var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var saPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");

Console.WriteLine($"[DEBUG] DB_SERVER: {dbServer}");
Console.WriteLine($"[DEBUG] DB_NAME: {dbName}");
Console.WriteLine($"[DEBUG] SA_PASSWORD: {saPassword}");



var connectionString =
    $"Server={dbServer};Database={dbName};User Id=sa;Password={saPassword};TrustServerCertificate=True";

builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

Console.WriteLine($"[DEBUG] Connection String: {connectionString}");

builder.Services.AddCors(opt => opt.AddPolicy("AllowAll",
    opt => opt.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin())
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "dotnethow.net",
            ValidAudience = "dotnethow.net",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-secure-secret-key-32-chars-long"))
        };
    });

builder.Services.AddScoped<PasswordHasher<User>>();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddScoped<IStudentService, StudentService>();



builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "devuser@example.com")
            };
            var identity = new ClaimsIdentity(claims, "Development");
            context.User = new ClaimsPrincipal(identity);
        }
        await next();
    });
}


app.UseCors("AllowAll");
app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();

app.Run();
