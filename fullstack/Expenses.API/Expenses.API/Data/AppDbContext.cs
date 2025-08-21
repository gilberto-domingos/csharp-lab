using Expenses.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PrintJob> PrintJobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrintJob>(entity =>
            {
                entity.HasKey(p => p.PrintJobId); 

                entity.HasOne(p => p.Student)
                    .WithMany(s => s.PrintJobs)   
                    .HasForeignKey(p => p.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                
            });
            
            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(p => p.PurchaseId);

                entity.HasOne(p => p.Student)
                    .WithMany(s => s.Purchases)
                    .HasForeignKey(p => p.StudentId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            base.OnModelCreating(modelBuilder);
        }
        
    }
    
}
