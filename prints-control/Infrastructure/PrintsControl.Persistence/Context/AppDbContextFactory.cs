using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            Env.Load(); 

            var connectionString = Env.GetString("CONNECTION_STRING"); 

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("A variável de ambiente CONNECTION_STRING não foi encontrada ou está vazia.");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}