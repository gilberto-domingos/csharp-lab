using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PrintsControl.Domain.Entities;

namespace PrintsControl.Domain.Interfaces;

public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<Transaction> GetByUserIdAsync(Guid userId);
    Task<List<Transaction>> GetAllAsync(Guid userId, CancellationToken cancellationToken);
}