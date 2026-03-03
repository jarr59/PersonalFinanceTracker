using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceTracker.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

/// <summary>
/// Provides data access methods for managing transaction entities in the finance tracker database.
/// </summary>
/// <param name="dbContext">The database context used to access and manage transaction data.</param>
internal class TransactionRepository(FinanceTrackerDbContext dbContext) : ITransactionRepository
{
    /// <summary>
    /// Asynchronously adds a collection of transactions to the database context.
    /// </summary>
    /// <param name="entities">The list of <see cref="TransactionEntity"/> objects to add to the context. Cannot be null.</param>
    /// <returns>A task that represents the asynchronous add operation.</returns>
    public async Task Add(List<TransactionEntity> entities) =>
        await dbContext.AddRangeAsync(entities);

    public async Task Add(TransactionEntity transaction)
    {
        await dbContext.Transactions.AddAsync(transaction);
    }

    public async Task Update(TransactionEntity transaction)
    {
        dbContext.Transactions.Update(transaction);
        await Task.CompletedTask;
    }

    public async Task Delete(TransactionEntity transaction)
    {
        dbContext.Transactions.Remove(transaction);
        await Task.CompletedTask;
    }

    public async Task<TransactionEntity?> GetById(Guid id)
    {
        return await dbContext.Transactions.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<TransactionEntity>> GetAll()
    {
        return await dbContext.Transactions.ToListAsync();
    }

    public async Task<List<TransactionEntity>> GetRecent(int count)
    {
        return await dbContext.Transactions
            .OrderByDescending(t => t.Date)
            .Take(count)
            .ToListAsync();
    }
}
