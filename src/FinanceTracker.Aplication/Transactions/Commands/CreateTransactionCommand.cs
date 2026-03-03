using System;
using System.Threading.Tasks;
using CustomMediator.CQRS.Commands;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Interfaces.Repositories;
using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Aplication.Transactions.Commands;

public sealed record CreateTransactionCommand(
    Guid CategoryId,
    Guid AccountId,
    decimal Amount,
    DateTimeOffset Date,
    string Description,
    TransactionType Type)
    : ICustomCommand<TransactionEntity>;

public class CreateTransactionCommandHandler(ITransactionRepository _repository, IUnitOfWork _unitOfWork)
    : ICustomCommandHandler<CreateTransactionCommand, TransactionEntity>
{
    public async Task<TransactionEntity> HandleAsync(CreateTransactionCommand command)
    {
        TransactionEntity transaction = new(
            command.CategoryId,
            command.AccountId,
            command.Amount,
            command.Date,
            command.Description,
            command.Type);
        await _repository.Add(transaction);
        await _unitOfWork.SaveChanges();
        return transaction;
    }
}
