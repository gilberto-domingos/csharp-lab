using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}