using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomMediator;
using FinanceTracker.Aplication.Transactions.Commands;
using FinanceTracker.Aplication.Transactions.Queries;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Transaction;
using FinanceTracker.Web.States.Accounts;
using FinanceTracker.Web.States.Categories;
using FinanceTracker.Web.States.Categories.DTOs;
using FinanceTracker.Web.States.Transactions;

namespace FinanceTracker.Web.Services.Transactions;

/// <summary>
/// Service for managing transaction operations.
/// Encapsulates all transaction-related business logic.
/// </summary>
public class TransactionService(IMediator mediator, TransactionState transactionState, CategoryState categoryState, AccountState accountState)
    : ITransactionService
{
    /// <summary>
    /// Creates a new transaction.
    /// </summary>
    public async Task CreateTransactionAsync(string description, decimal amount, DateTime date, Guid categoryId, Guid accountId)
    {
        transactionState.SetIsSaving();
        TransactionType type = amount >= 0 ? TransactionType.Incoming : TransactionType.Outgoing;
        DateTimeOffset transactionDate = new(date);

        Transaction result = await mediator.SendCommandAsync<CreateTransactionCommand, Transaction>(
            new CreateTransactionCommand(categoryId, accountId, amount, transactionDate, description, type));

        TransactionModel model = MapToModel(result);
        transactionState.AddTransaction(model);
        transactionState.SetIsSaving();
    }

    /// <summary>
    /// Updates an existing transaction.
    /// </summary>
    public async Task UpdateTransactionAsync(Guid id, string description, decimal amount, DateTime date, Guid categoryId, Guid accountId)
    {
        transactionState.SetIsSaving();
        TransactionType type = amount >= 0 ? TransactionType.Incoming : TransactionType.Outgoing;
        DateTimeOffset transactionDate = new(date);

        Transaction result = await mediator.SendCommandAsync<UpdateTransactionCommand, Transaction>(
            new UpdateTransactionCommand(id, categoryId, accountId, amount, transactionDate, description, type));

        TransactionModel model = MapToModel(result);
        transactionState.UpdateTransaction(model);
        transactionState.SetIsSaving();
    }

    /// <summary>
    /// Deletes a transaction.
    /// </summary>
    public async Task DeleteTransactionAsync(Guid id)
    {
        transactionState.SetIsDeleting();
        await mediator.SendCommandAsync<DeleteTransactionCommand, bool>(new DeleteTransactionCommand(id));
        transactionState.DeleteTransaction(id);
        transactionState.SetIsDeleting();
    }

    /// <summary>
    /// Retrieves all transactions.
    /// </summary>
    public async Task LoadAllTransactionsAsync()
    {
        transactionState.SetIsLoading();
        List<Transaction> result = await mediator.SendQueryAsync<GetAllTransactionsQuery, List<Transaction>>(
            new GetAllTransactionsQuery());

        List<TransactionModel> models = result.Select(MapToModel).ToList();
        transactionState.SetTransactions(models);
        transactionState.SetIsLoading();
    }

    private TransactionModel MapToModel(Transaction transaction)
    {
        CategoryModel? category = categoryState.Categories.FirstOrDefault(c => c.Id == transaction.CategoryId);
        AccountModel? account = accountState.Accounts.FirstOrDefault(a => a.Id == transaction.AccountId);

        return new TransactionModel
        {
            Id = transaction.Id,
            Description = transaction.Description,
            Amount = transaction.Amount,
            Date = transaction.Date.DateTime,
            CategoryId = transaction.CategoryId,
            CategoryName = category?.Name.Name ?? string.Empty,
            CategoryIcon = category?.Icon.Source ?? string.Empty,
            CategoryColor = category?.Color.Color ?? "#64748b",
            AccountId = transaction.AccountId,
            AccountName = account?.Name ?? string.Empty
        };
    }
}
