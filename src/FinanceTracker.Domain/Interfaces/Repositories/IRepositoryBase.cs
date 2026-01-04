namespace FinanceTracker.Domain.Interfaces.Repositories;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepositoryBase<T>
{
    /// <summary>
    ///  
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task Add(List<T> entities);
}
