using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Domain.Interfaces.Repositories;

public interface ITransactionRepository : IRepositoryBase<TransactionEntity>
{
    Task Add(TransactionEntity transaction);

    Task Update(TransactionEntity transaction);

    Task Delete(TransactionEntity transaction);

    Task<TransactionEntity?> GetById(Guid id);

    Task<List<TransactionEntity>> GetAll();

    Task<List<TransactionEntity>> GetRecent(int count);
}
