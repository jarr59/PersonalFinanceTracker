using System.Threading.Tasks;
using CustomMediator.CQRS.Commands;
using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Aplication.Accounts.Commands;

public sealed record CreateAccountCommand(
    string Name,
    decimal Balance,
    string Currency,
    string Icon,
    string Color)
    : ICustomCommand<Account>;

public class CreateAccountCommandHandler(IAccountRepository _repository, IUnitOfWork _unitOfWork)
    : ICustomCommandHandler<CreateAccountCommand, Account>
{
    public async Task<Account> HandleAsync(CreateAccountCommand command)
    {
        Account account = new(
            command.Name,
            command.Balance,
            command.Currency,
            command.Icon,
            command.Color);
        await _repository.Add(account);
        await _unitOfWork.SaveChanges();
        return account;
    }
}