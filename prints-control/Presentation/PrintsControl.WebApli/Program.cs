using System.Security.Claims;
using DotNetEnv;
using PrintsControl.Persistence;


    var builder = WebApplication.CreateBuilder(args);

    Env.Load();

    builder.Services.ConfigurePersistenceApp(builder.Configuration);
    builder.Services.ConfigureAuthentication();
    builder.Services.ConfigureCors();
    builder.Services.ConfigureSwagger();

    builder.Services.AddControllers();
    builder.Services.ConfigurePersistenceApp(builder.Configuration);
    builder.Services.AddRepositories();
    builder.Services.AddUnitOfWork();


    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

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
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
