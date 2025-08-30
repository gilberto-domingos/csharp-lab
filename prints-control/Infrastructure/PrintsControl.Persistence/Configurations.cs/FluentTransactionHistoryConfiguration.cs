using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations.cs;

public class FluentTransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
{
    public void Configure(EntityTypeBuilder<TransactionHistory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.TransactionType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.BalanceBefore)
            .IsRequired();

        builder.Property(x => x.BalanceAfter)
            .IsRequired();

       /* builder.HasOne(x => x.Student)
            .WithMany(s => s.Transactions)
            .HasForeignKey(x => x.StudentId); */

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}