using System;
using System.Threading.Tasks;

namespace FinanceTracker.Web.Services.Transactions;

public interface ITransactionService
{
    Task CreateTransactionAsync(string description, decimal amount, DateTime date, Guid categoryId, Guid accountId);

    Task UpdateTransactionAsync(Guid id, string description, decimal amount, DateTime date, Guid categoryId, Guid accountId);

    Task DeleteTransactionAsync(Guid id);

    Task LoadAllTransactionsAsync();
}
