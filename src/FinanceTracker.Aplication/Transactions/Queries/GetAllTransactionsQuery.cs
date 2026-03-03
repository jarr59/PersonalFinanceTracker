using System.Collections.Generic;
using System.Threading.Tasks;
using CustomMediator.CQRS.Queries;
using FinanceTracker.Domain.Interfaces.Repositories;
using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Aplication.Transactions.Queries;

public sealed record GetAllTransactionsQuery : ICustomQuery<List<TransactionEntity>>;

public class GetAllTransactionsQueryHandler(ITransactionRepository _repository)
    : ICustomQueryHandler<GetAllTransactionsQuery, List<TransactionEntity>>
{
    public async Task<List<TransactionEntity>> HandleAsync(GetAllTransactionsQuery query)
    {
        return await _repository.GetAll();
    }
}
