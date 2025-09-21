using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations.cs;

public class FluentPurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        /*builder.HasOne(x => x.Student)
            .WithMany(s => s.Purchases)
            .HasForeignKey(x => x.StudentId);*/

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}