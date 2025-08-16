using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations.cs;

public class FluentTransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Type)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Amount)
            .IsRequired();

        builder.HasOne(t => t.User)
            .WithMany(u => u.Transactions)
            .HasForeignKey(t => t.UserId)
            .IsRequired(false);

        // Soft delete
        builder.HasQueryFilter(t => t.DeletedAt == null);
    }
}