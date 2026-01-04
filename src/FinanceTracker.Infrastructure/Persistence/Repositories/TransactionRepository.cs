using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.Transaction;

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
    /// <param name="entities">The list of <see cref="Transaction"/> objects to add to the context. Cannot be null.</param>
    /// <returns>A task that represents the asynchronous add operation.</returns>
    public async Task Add(List<Transaction> entities) =>
        await dbContext.AddRangeAsync(entities);
}
