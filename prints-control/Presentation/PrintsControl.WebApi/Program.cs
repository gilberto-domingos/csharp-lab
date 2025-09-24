using DotNetEnv;
using PrintsControl.Application;
using PrintsControl.Persistence;


    var builder = WebApplication.CreateBuilder(args);

    Env.Load();
    
    builder.Services.AddCors(opt => opt.AddPolicy("AllowAll",
        opt => opt.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin())
    );
    
    
    builder.Services.ConfigurePersistenceApp(builder.Configuration);
    builder.Services.ConfigureApplicationApp();
    builder.Services.ConfigureAuthentication();
    builder.Services.ConfigureCors();
    builder.Services.ConfigureSwagger();
    builder.Services.AddSwaggerGen();
    

    builder.Services.AddControllers();
    builder.Services.AddRepositories();
    builder.Services.AddUnitOfWork();


    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrintsControl API V1");
            c.RoutePrefix = string.Empty; 
        });

    }       

    app.UseCors("AllowAll");

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
