using System;
using System.Threading.Tasks;
using CustomMediator.CQRS.Queries;
using FinanceTracker.Domain.Interfaces.Repositories;
using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Aplication.Transactions.Queries;

public sealed record GetTransactionByIdQuery(Guid Id) : ICustomQuery<TransactionEntity?>;

public class GetTransactionByIdQueryHandler(ITransactionRepository _repository)
    : ICustomQueryHandler<GetTransactionByIdQuery, TransactionEntity?>
{
    public async Task<TransactionEntity?> HandleAsync(GetTransactionByIdQuery query)
    {
        return await _repository.GetById(query.Id);
    }
}
