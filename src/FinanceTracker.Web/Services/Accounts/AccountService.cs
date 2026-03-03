using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomMediator;
using FinanceTracker.Aplication.Accounts.Commands;
using FinanceTracker.Aplication.Accounts.Queries;
using FinanceTracker.Domain.ValueObjects;
using FinanceTracker.Web.States.Accounts;
using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Web.Services.Accounts;

/// <summary>
/// Service for managing account operations.
/// Encapsulates all account-related business logic.
/// </summary>
public class AccountService(IMediator mediator, AccountState accountState)
    : IAccountService
{
    /// <summary>
    /// Creates a new account.
    /// </summary>
    public async Task CreateAccountAsync(string name, decimal balance, string currency, string icon, string color)
    {
        accountState.SetIsAdding();
        Account result = await mediator.SendCommandAsync<CreateAccountCommand, Account>(
            new CreateAccountCommand(name, balance, currency, icon, color));

        AccountModel model = MapToModel(result);
        accountState.AddAccount(model);
        accountState.SetIsAdding();
    }

    /// <summary>
    /// Updates an existing account.
    /// </summary>
    public async Task UpdateAccountAsync(Guid id, string name, decimal balance, string currency, string icon, string color)
    {
        accountState.SetIsUpdating();
        Account result = await mediator.SendCommandAsync<UpdateAccountCommand, Account>(
            new UpdateAccountCommand(id, name, balance, currency, icon, color));

        AccountModel model = MapToModel(result);
        accountState.UpdateAccount(model);
        accountState.SetIsUpdating();
    }

    /// <summary>
    /// Deletes an account.
    /// </summary>
    public async Task DeleteAccountAsync(Guid id)
    {
        accountState.SetIsDeleting();
        await mediator.SendCommandAsync<DeleteAccountCommand, bool>(new DeleteAccountCommand(id));
        accountState.DeleteAccount(id);
        accountState.SetIsDeleting();
    }

    /// <summary>
    /// Retrieves all accounts.
    /// </summary>
    public async Task LoadAllAccountsAsync()
    {
        accountState.SetIsLoading();
        List<Account> result = await mediator.SendQueryAsync<GetAllAccountsQuery, List<Account>>(
            new GetAllAccountsQuery());

        List<AccountModel> models = result.Select(MapToModel).ToList();
        accountState.CleanAccounts();
        foreach (var model in models)
        {
            accountState.AddAccount(model);
        }
        accountState.SetIsLoading();
    }

    /// <summary>
    /// Transfers funds between accounts.
    /// </summary>
    public async Task TransferFundsAsync(Guid fromAccountId, Guid toAccountId, decimal amount, string description)
    {
        accountState.SetIsUpdating();
        await mediator.SendCommandAsync<TransferFundsCommand, bool>(
            new TransferFundsCommand(fromAccountId, toAccountId, amount, description));

        // Update local state
        AccountModel? fromAccount = accountState.Accounts.FirstOrDefault(a => a.Id == fromAccountId);
        AccountModel? toAccount = accountState.Accounts.FirstOrDefault(a => a.Id == toAccountId);

        if (fromAccount != null)
        {
            fromAccount.Balance -= amount;
        }

        if (toAccount != null)
        {
            toAccount.Balance += amount;
        }

        accountState.SetIsUpdating();
    }

    private AccountModel MapToModel(Account account)
    {
        return new AccountModel
        {
            Id = account.Id,
            Name = account.Name,
            Balance = account.Balance,
            Currency = account.Currency,
            Icon = account.Icon,
            Color = account.Color
        };
    }
}

public interface IAccountService
{
    Task CreateAccountAsync(string name, decimal balance, string currency, string icon, string color);

    Task UpdateAccountAsync(Guid id, string name, decimal balance, string currency, string icon, string color);

    Task DeleteAccountAsync(Guid id);

    Task LoadAllAccountsAsync();

    Task TransferFundsAsync(Guid fromAccountId, Guid toAccountId, decimal amount, string description);
}
