using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Persistence.Configurations;
using PrintsControl.Persistence.Configurations.cs;

namespace PrintsControl.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Student>Students { get; set; } 
    
    public DbSet<Purchase>Purchases { get; set; }
    
    public DbSet<PrintJob>PrintJobs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new FluentStudentConfiguration());
        modelBuilder.ApplyConfiguration(new FluentPurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new FluentPrintingConfiguration());
        modelBuilder.ApplyConfiguration(new FluentUserConfiguration());
    }
}