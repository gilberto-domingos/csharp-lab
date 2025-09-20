using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity 
{
    
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        entity.MarkAsUpdated();
        _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        entity.MarkAsDeleted();
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}