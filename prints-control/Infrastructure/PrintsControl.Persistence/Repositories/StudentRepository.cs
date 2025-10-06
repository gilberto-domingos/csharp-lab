using PrintsControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context) { }

    public async Task<Student> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Students
            .FirstAsync(s => s.Name == name, cancellationToken);
    }
    
    public async Task<IEnumerable<Student>> GetAllWithHistoryAsync(CancellationToken cancellationToken)
    {
        return await _context.Students
            .Include(s => s.Purchases)
            .Include(s => s.PrintJobs)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    
}
