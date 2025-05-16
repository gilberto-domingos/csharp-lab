using Microsoft.EntityFrameworkCore;
using WebAPI_Bug.Models;

namespace WebAPI_Bug.DataContext
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
