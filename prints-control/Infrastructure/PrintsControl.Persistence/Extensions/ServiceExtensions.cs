using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;
using PrintsControl.Persistence.Repositories;

namespace PrintsControl.Persistence
    {
    public static class ServiceExtensions
    {
        
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IPurchaseRepository,PurchaseRepository>();
            services.AddScoped<IPrintJobRepository, PrintJobRepository>();
            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var saPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");

            var connectionString =
                $"Server={dbServer};Database={dbName};User Id=sa;Password={saPassword};TrustServerCertificate=True";

            configuration["ConnectionStrings:DefaultConnection"] = connectionString;

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

             services.AddScoped<IUserRepository, UserRepository>();
             services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-secure-secret-key-32-chars-long"))
                    };
                });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt => opt.AddPolicy("AllowAll",
                builder => builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddOpenApi(); 
        }
    }
}
