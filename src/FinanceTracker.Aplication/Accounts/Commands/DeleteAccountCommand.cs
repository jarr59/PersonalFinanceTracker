using System.Threading.Tasks;
using CustomMediator.CQRS.Commands;
using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Aplication.Accounts.Commands;

public sealed record DeleteAccountCommand(Guid Id) : ICustomCommand<bool>;

public class DeleteAccountCommandHandler(IAccountRepository _repository, IUnitOfWork _unitOfWork)
    : ICustomCommandHandler<DeleteAccountCommand, bool>
{
    public async Task<bool> HandleAsync(DeleteAccountCommand command)
    {
        Account? existing = await _repository.GetById(command.Id);
        if (existing is null)
        {
            throw new InvalidOperationException($"Account with Id {command.Id} not found");
        }

        await _repository.Delete(existing);
        await _unitOfWork.SaveChanges();
        return true;
    }
}