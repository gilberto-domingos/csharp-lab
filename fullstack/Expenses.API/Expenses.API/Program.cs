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

// Caminho do SQLite dentro do container
builder.Configuration["ConnectionStrings:DefaultConnection"] = 
    builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection") 
    ?? "Data Source=/app/data/database.db";

// CORS
builder.Services.AddCors(opt => opt.AddPolicy("AllowAll",
    opt => opt.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin())
);

// JWT Authentication (estruturado, mas ainda comentado se quiser)
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

// Services
builder.Services.AddScoped<PasswordHasher<User>>();
builder.Services.AddDbContext<AppDbContext>(opt => 
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

// Swagger em qualquer ambiente
app.UseSwagger();
app.UseSwaggerUI();

// Fake user para Dev
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
// app.UseHttpsRedirection(); // opcional dentro do container
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();

// Garantir migrations SQLite
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Kestrel escutando todas interfaces
app.Urls.Add("http://0.0.0.0:5000");

app.Run();
