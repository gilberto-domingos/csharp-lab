using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Infrastructure;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}
    
    public DbSet<User>Users { get; set; }
    public DbSet<Transaction>Transactions { get; set; }

}
