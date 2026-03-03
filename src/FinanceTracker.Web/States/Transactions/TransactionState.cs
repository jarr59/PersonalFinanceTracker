namespace FinanceTracker.Web.States.Transactions;

public sealed class TransactionState : StateContainerBase
{
    private readonly Random _random = new();

    public List<TransactionModel> Transactions { get; private set; } = new();

    // Loading states
    public bool IsLoading { get; private set; }
    public bool IsSaving { get; private set; }
    public bool IsDeleting { get; private set; }

    /// <summary>
    /// Indica si hay alguna operación en curso
    /// </summary>
    public bool IsBusy => IsLoading || IsSaving || IsDeleting;

    public void SetTransactions(List<TransactionModel> transactions)
    {
        Transactions = transactions;
        NotifyStateChanged();
    }

    public void AddTransaction(TransactionModel transaction)
    {
        Transactions.Insert(0, transaction); // Add to beginning for most recent first
        NotifyStateChanged();
    }

    public void UpdateTransaction(TransactionModel transaction)
    {
        var existing = Transactions.FirstOrDefault(t => t.Id == transaction.Id);
        if (existing != null)
        {
            existing.Description = transaction.Description;
            existing.Amount = transaction.Amount;
            existing.Date = transaction.Date;
            existing.CategoryId = transaction.CategoryId;
            existing.CategoryName = transaction.CategoryName;
            existing.CategoryIcon = transaction.CategoryIcon;
            existing.CategoryColor = transaction.CategoryColor;
            existing.AccountId = transaction.AccountId;
            existing.AccountName = transaction.AccountName;
            NotifyStateChanged();
        }
    }

    public void DeleteTransaction(Guid id)
    {
        var transaction = Transactions.FirstOrDefault(t => t.Id == id);
        if (transaction != null)
        {
            Transactions.Remove(transaction);
            NotifyStateChanged();
        }
    }

    public List<TransactionModel> GetRecentTransactions(int count = 5)
    {
        return Transactions.OrderByDescending(t => t.Date).Take(count).ToList();
    }

    public decimal GetTotalIncome()
    {
        return Transactions.Where(t => t.Amount > 0).Sum(t => t.Amount);
    }

    public decimal GetTotalExpenses()
    {
        return Math.Abs(Transactions.Where(t => t.Amount < 0).Sum(t => t.Amount));
    }

    // Loading state management
    public void SetIsLoading()
    {
        IsLoading = !IsLoading;
        NotifyStateChanged();
    }

    public void SetIsSaving()
    {
        IsSaving = !IsSaving;
        NotifyStateChanged();
    }

    public void SetIsDeleting()
    {
        IsDeleting = !IsDeleting;
        NotifyStateChanged();
    }
}
