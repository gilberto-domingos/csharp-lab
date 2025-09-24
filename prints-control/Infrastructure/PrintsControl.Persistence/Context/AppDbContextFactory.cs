using System;
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

            var databaseFile = Env.GetString("File.Env") ?? "default.db";

            if (string.IsNullOrEmpty(databaseFile))
                throw new InvalidOperationException("A variável de ambiente File.Env não foi encontrada ou está vazia.");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite($"Data Source={databaseFile}");

            Console.WriteLine($"[AppDbContextFactory] Banco conectado: {databaseFile}");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}