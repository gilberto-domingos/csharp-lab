using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations
{
    public class FluentPrintingConfiguration : IEntityTypeConfiguration<PrintJob>
    {
        public void Configure(EntityTypeBuilder<PrintJob> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.PrintDate)
                .IsRequired()
                .HasColumnType("TEXT"); 

            builder.HasOne(x => x.Student)
                .WithMany(s => s.PrintJobs)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.DeletedAt)
                .HasColumnType("TEXT")
                .IsRequired(false);

            builder.HasQueryFilter(x => x.DeletedAt == null);
        }
    }
}