using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
{
    public PurchaseRepository(AppDbContext context) : base(context) { }


    public async Task<List<Purchase>> GetPurchaseByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await _context.Purchases
            .Include(p => p.Student)
            .AsNoTracking()
            .IgnoreQueryFilters()
            .Where(p => p.StudentId == studentId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Purchase?> GelLastPurchaseByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        return await _context.Purchases
            .Include(p => p.Student)
            .AsNoTracking()
            .IgnoreQueryFilters()
            .Where(p => p.StudentId == studentId)
            .OrderByDescending(p => p.PurchaseDate)
            .FirstOrDefaultAsync(cancellationToken);
    }
}