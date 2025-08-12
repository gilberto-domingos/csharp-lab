using DotNetEnv;
using PrintsControl.Application;
using PrintsControl.Persistence;


    var builder = WebApplication.CreateBuilder(args);

    Env.Load();

    builder.Services.ConfigurePersistenceApp(builder.Configuration);
    builder.Services.ConfigureApplicationApp();
    builder.Services.ConfigureAuthentication();
    builder.Services.ConfigureCors();
    builder.Services.ConfigureSwagger();

    builder.Services.AddControllers();
    builder.Services.AddRepositories();
    builder.Services.AddUnitOfWork();


    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

    }       

    app.UseCors("AllowAll");

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
