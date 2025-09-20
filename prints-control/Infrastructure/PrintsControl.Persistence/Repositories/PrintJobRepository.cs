using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class PrintJobRepository : BaseRepository<PrintJob>, IPrintJobRepository
{
    public PrintJobRepository(AppDbContext context) : base(context) { }

    public async Task<List<PrintJob>> GetPrintJobStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await _context.PrintJobs
            .Include(p => p.Student)
            .AsNoTracking()
            .IgnoreQueryFilters()
            .Where(p => p.StudentId == studentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<PrintJob?> GetLastPrintJobStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await _context.PrintJobs
            .Include(p => p.Student)
            .AsNoTracking()
            .IgnoreQueryFilters()
            .Where(p => p.StudentId == studentId)
            .OrderByDescending(p => p.PrintDate)
            .FirstOrDefaultAsync(cancellationToken);
    }
}