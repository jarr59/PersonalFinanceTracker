using System;
using System.Threading.Tasks;
using CustomMediator.CQRS.Commands;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Interfaces.Repositories;
using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Aplication.Transactions.Commands;

public sealed record UpdateTransactionCommand(
    Guid Id,
    Guid CategoryId,
    Guid AccountId,
    decimal Amount,
    DateTimeOffset Date,
    string Description,
    TransactionType Type)
    : ICustomCommand<TransactionEntity>;

public class UpdateTransactionCommandHandler(ITransactionRepository _repository, IUnitOfWork _unitOfWork)
    : ICustomCommandHandler<UpdateTransactionCommand, TransactionEntity>
{
    public async Task<TransactionEntity> HandleAsync(UpdateTransactionCommand command)
    {
        TransactionEntity? existing = await _repository.GetById(command.Id);
        if (existing is null)
        {
            throw new InvalidOperationException($"Transaction with Id {command.Id} not found");
        }

        existing.UpdateDescription(command.Description);
        existing.UpdateAmount(command.Amount);
        existing.UpdateDate(command.Date);
        existing.UpdateCategory(command.CategoryId);
        existing.UpdateAccount(command.AccountId);
        existing.UpdateType(command.Type);

        await _unitOfWork.SaveChanges();
        return existing;
    }
}
