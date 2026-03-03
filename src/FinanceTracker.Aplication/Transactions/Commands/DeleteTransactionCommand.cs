using System;
using System.Threading.Tasks;
using CustomMediator.CQRS.Commands;
using FinanceTracker.Domain.Interfaces.Repositories;
using TransactionEntity = FinanceTracker.Domain.Transaction.Transaction;

namespace FinanceTracker.Aplication.Transactions.Commands;

public sealed record DeleteTransactionCommand(Guid Id) : ICustomCommand<bool>;

public class DeleteTransactionCommandHandler(ITransactionRepository _repository, IUnitOfWork _unitOfWork)
    : ICustomCommandHandler<DeleteTransactionCommand, bool>
{
    public async Task<bool> HandleAsync(DeleteTransactionCommand command)
    {
        TransactionEntity? existing = await _repository.GetById(command.Id);
        if (existing is null)
        {
            throw new InvalidOperationException($"Transaction with Id {command.Id} not found");
        }

        await _repository.Delete(existing);
        await _unitOfWork.SaveChanges();
        return true;
    }
}
