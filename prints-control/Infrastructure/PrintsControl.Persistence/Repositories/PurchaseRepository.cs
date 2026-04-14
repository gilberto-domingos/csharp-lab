using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(AppDbContext context) : base(context) { }


    public async Task<Purchase?> GetByIdWidthStudent(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Purchases
            .Include(p => p.Student)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Purchase>> GetPurchaseByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await _context.Purchases
            .Include(p => p.Student)
            .AsNoTracking()
            .IgnoreQueryFilters()
            .Where(p => p.StudentId == studentId)
            .ToListAsync(cancellationToken);
    }
}