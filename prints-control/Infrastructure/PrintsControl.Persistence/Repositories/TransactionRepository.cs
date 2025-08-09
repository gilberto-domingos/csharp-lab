using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrintsControl.Domain.Entities;
using PrintsControl.Domain.Interfaces;
using PrintsControl.Persistence.Context;

namespace PrintsControl.Persistence.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context){}
    
    public async Task<Transaction> GetByUserIdAsync(Guid userId)
    {
        return await Context.Transactions
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.UserId == userId);
    }

    public async Task<List<Transaction>> GetAllAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context.Transactions
            .Where(t => t.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}