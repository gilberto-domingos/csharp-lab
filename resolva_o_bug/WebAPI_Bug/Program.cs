using Microsoft.EntityFrameworkCore;
using WebAPI_Bug.DataContext;
using WebAPI_Bug.Service.FuncionarioService;
using WebAPI_Bug.Service.FuncionarioService;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var saPassword = Environment.GetEnvironmentVariable("SA_PASSWORD");

var connectionString =
    $"Server={dbServer};Database={dbName};User Id=sa;Password={saPassword};TrustServerCertificate=True";

builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5016); 
    serverOptions.ListenAnyIP(7016, listenOptions =>
    {
        listenOptions.UseHttps(); 
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("SwaggerPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5016")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SwaggerPolicy");
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();