using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity 
{
    
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        entity.MarkAsCreated();
        Context.Add(entity);
        return Task.CompletedTask;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    
    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }

    public Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        entity.MarkAsUpdated();
        Context.Update(entity);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        //entity.MarkAsDeleted();
        Context.Remove(entity);
       // return Task.CompletedTask;
       
       await Context.SaveChangesAsync(cancellationToken);
    }
}