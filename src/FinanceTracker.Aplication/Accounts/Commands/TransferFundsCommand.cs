using System.Threading.Tasks;
using CustomMediator.CQRS.Commands;
using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.Accounts;
using FinanceTracker.Domain.Transaction;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Aplication.Accounts.Commands;

public sealed record TransferFundsCommand(
    Guid FromAccountId,
    Guid ToAccountId,
    decimal Amount,
    string Description)
    : ICustomCommand<bool>;

public class TransferFundsCommandHandler(
    IAccountRepository accountRepository,
    ITransactionRepository transactionRepository,
    IUnitOfWork unitOfWork)
    : ICustomCommandHandler<TransferFundsCommand, bool>
{
    public async Task<bool> HandleAsync(TransferFundsCommand command)
    {
        // Get accounts
        Account? fromAccount = await accountRepository.GetById(command.FromAccountId);
        Account? toAccount = await accountRepository.GetById(command.ToAccountId);

        if (fromAccount is null || toAccount is null)
        {
            throw new InvalidOperationException("One or both accounts not found");
        }

        if (fromAccount.Balance < command.Amount)
        {
            throw new InvalidOperationException("Insufficient funds in source account");
        }

        if (command.FromAccountId == command.ToAccountId)
        {
            throw new InvalidOperationException("Cannot transfer to the same account");
        }

        // Update balances
        fromAccount.UpdateBalance(fromAccount.Balance - command.Amount);
        toAccount.UpdateBalance(toAccount.Balance + command.Amount);

        // Create transactions
        Transaction outgoingTransaction = new(
            Guid.NewGuid(), // CategoryId - transfer category
            command.FromAccountId,
            -command.Amount, // Negative for outgoing
            DateTimeOffset.Now,
            $"Transfer to {toAccount.Name}: {command.Description}",
            TransactionType.Outgoing);

        Transaction incomingTransaction = new(
            Guid.NewGuid(), // CategoryId
            command.ToAccountId,
            command.Amount, // Positive for incoming
            DateTimeOffset.Now,
            $"Transfer from {fromAccount.Name}: {command.Description}",
            TransactionType.Incoming);

        await transactionRepository.Add(outgoingTransaction);
        await transactionRepository.Add(incomingTransaction);

        await unitOfWork.SaveChanges();

        return true;
    }
}