using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

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
                .HasColumnType("TEXT");

            builder.HasOne(x => x.Student)
                .WithMany(s => s.Purchases)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasQueryFilter(x => x.DeletedAt == null);

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnType("TEXT");

            builder.Property(x => x.DeletedAt)
                .HasColumnType("TEXT")
                .IsRequired(false);
        }
    }
}