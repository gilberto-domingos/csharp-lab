using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;
using System;

namespace PrintsControl.Persistence.Configurations
{
    public class FluentPurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.PurchaseDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()"); // Para SQL Server, ajusta para UTC

            builder.HasOne(x => x.Student)
                .WithMany(s => s.Purchases)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Protege integridade referencial

            builder.HasQueryFilter(x => x.DeletedAt == null);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.DeletedAt)
                .HasColumnType("datetime2")
                .IsRequired(false);
        }
    }
}