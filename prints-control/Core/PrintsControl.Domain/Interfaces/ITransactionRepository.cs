using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetByUserIdAsync(Guid userId);
}