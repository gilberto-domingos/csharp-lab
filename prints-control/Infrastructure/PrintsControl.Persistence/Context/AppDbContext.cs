using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Persistence.Configurations.cs;

namespace PrintsControl.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    public DbSet<Student>Students { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new FluentStudentConfiguration());
        modelBuilder.ApplyConfiguration(new FluentPurchaseConfiguration());
        modelBuilder.ApplyConfiguration(new FluentPrintingConfiguration());
        modelBuilder.ApplyConfiguration(new FluentTransactionHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new FluentUserConfiguration());
        modelBuilder.ApplyConfiguration(new FluentTransactionConfiguration());
    }
    private static void SetSoftDeleteFilter<TEntity>(ModelBuilder builder) where TEntity : BaseEntity
    {
       // builder.Entity<TEntity>().HasQueryFilter(e => e.DeletedAt == null);
    }

    
}