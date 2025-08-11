using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
        {
            modelBuilder.Entity(entityType.ClrType)
                .Property<DateTimeOffset>("CreatedAt")
                .IsRequired();

            modelBuilder.Entity(entityType.ClrType)
                .Property<DateTimeOffset>("UpdatedAt")
                .IsRequired();

            modelBuilder.Entity(entityType.ClrType)
                .Property<DateTimeOffset?>("DeletedAt")
                .IsRequired(false);

            var method = typeof(AppDbContext)
                .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
                .MakeGenericMethod(entityType.ClrType);

            method.Invoke(null, new object[] { modelBuilder });
        }
    }

    modelBuilder.Entity<Transaction>()
        .HasOne(t => t.User)
        .WithMany(u => u.Transactions)
        .HasForeignKey(t => t.UserId)
        .IsRequired(false);

    modelBuilder.Entity<User>()
        .Property(u => u.Email)
        .HasMaxLength(150)
        .IsRequired();

    modelBuilder.Entity<User>()
        .Property(u => u.Password)
        .HasMaxLength(100)
        .IsRequired();

    modelBuilder.Entity<Transaction>()
        .Property(t => t.Type)
        .HasMaxLength(50)
        .IsRequired();

    modelBuilder.Entity<Transaction>()
        .Property(t => t.Category)
        .HasMaxLength(100)
        .IsRequired();
}

private static void SetSoftDeleteFilter<TEntity>(ModelBuilder builder) where TEntity : BaseEntity
{
    builder.Entity<TEntity>().HasQueryFilter(e => e.DeletedAt == null);
}

    
}