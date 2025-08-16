using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations.cs;

public class FluentPrintingConfiguration : IEntityTypeConfiguration<Printing>
{
    public void Configure(EntityTypeBuilder<Printing> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.QuantityPrinted)
            .IsRequired();

        builder.HasOne(x => x.Student)
            .WithMany(s => s.Printings)
            .HasForeignKey(x => x.StudentId);

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}