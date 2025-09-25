using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations;

public class FluentPrintingConfiguration : IEntityTypeConfiguration<PrintJob>
{
    public void Configure(EntityTypeBuilder<PrintJob> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.HasOne(x => x.Student)
            .WithMany(s => s.PrintJobs)
            .HasForeignKey(x => x.Id); 

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}