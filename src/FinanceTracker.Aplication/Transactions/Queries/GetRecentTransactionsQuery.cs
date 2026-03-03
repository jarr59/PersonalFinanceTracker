using System.Collections.Generic;
using System.Threading.Tasks;
using CustomMediator.CQRS.Queries;
using FinanceTracker.Domain.Interfaces.Repositories;
using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Aplication.Transactions.Queries;

public sealed record GetRecentTransactionsQuery(int Count) : ICustomQuery<List<TransactionEntity>>;

public class GetRecentTransactionsQueryHandler(ITransactionRepository _repository)
    : ICustomQueryHandler<GetRecentTransactionsQuery, List<TransactionEntity>>
{
    public async Task<List<TransactionEntity>> HandleAsync(GetRecentTransactionsQuery query)
    {
        return await _repository.GetRecent(query.Count);
    }
}
