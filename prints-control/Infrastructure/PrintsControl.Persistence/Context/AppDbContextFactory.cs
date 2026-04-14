using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PrintsControl.Persistence.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=printscontrol.db",
            x => x.MigrationsAssembly("PrintsControl.Persistence"));

        return new AppDbContext(optionsBuilder.Options);
    }
}