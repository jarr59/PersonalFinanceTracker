namespace FinanceTracker.Domain.Interfaces.Repositories;

/// <summary>
/// 
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///  
    /// </summary>
    Task SaveChanges();
}
