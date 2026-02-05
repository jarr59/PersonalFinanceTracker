using FinanceTracker.Domain.Interfaces.Repositories;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

/// <summary>
/// Provides a unit of work implementation for coordinating changes to the database context as a single transaction.
/// </summary>
/// <remarks>The unit of work pattern ensures that all changes made through the context are committed together,
/// helping to maintain data consistency. This class is intended for internal use within the data access
/// layer.</remarks>
/// <param name="dbContext">The database context used to track and persist changes to the underlying data store. Cannot be null.</param>
internal class UnitOfWork(FinanceTrackerDbContext dbContext) : IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves all changes made in the context to the underlying database.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the save operation.</param>
    /// <returns>A task that represents the asynchronous save operation.</returns>
    public async Task SaveChanges() =>
        await dbContext.SaveChangesAsync();
}
