using System.Threading.Tasks;
using CustomMediator.CQRS.Commands;
using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.ValueObjects;
using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Aplication.Accounts.Commands;

public sealed record UpdateAccountCommand(
    Guid Id,
    string Name,
    decimal Balance,
    string Currency,
    string Icon,
    string Color)
    : ICustomCommand<Account>;

public class UpdateAccountCommandHandler(IAccountRepository _repository, IUnitOfWork _unitOfWork)
    : ICustomCommandHandler<UpdateAccountCommand, Account>
{
    public async Task<Account> HandleAsync(UpdateAccountCommand command)
    {
        Account? existing = await _repository.GetById(command.Id);
        if (existing is null)
        {
            throw new InvalidOperationException($"Account with Id {command.Id} not found");
        }

        existing.UpdateName(command.Name);
        existing.UpdateBalance(command.Balance);
        existing.UpdateCurrency(command.Currency);
        existing.UpdateIcon(command.Icon);
        existing.UpdateColor(command.Color);

        await _unitOfWork.SaveChanges();
        return existing;
    }
}