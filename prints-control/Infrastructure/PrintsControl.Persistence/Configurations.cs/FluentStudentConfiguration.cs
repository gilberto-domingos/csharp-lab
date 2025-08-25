using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Persistence.Configurations.cs;

public class FluentStudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.StudentId);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Balance)
            .IsRequired();

        builder.HasMany(x => x.Purchases)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);

        builder.HasMany(x => x.PrintJobs)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);

        builder.HasMany(x => x.Transactions)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId);

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}