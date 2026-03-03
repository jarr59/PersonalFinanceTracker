using FinanceTracker.Domain.ValueObjects;

namespace FinanceTracker.Web.States.Accounts;

public sealed class AccountState : StateContainerBase
{
    public List<AccountModel> Accounts { get; private set; } = new()
    {
        new AccountModel 
        { 
            Id = Guid.NewGuid(), 
            Name = "Cuenta Principal", 
            Balance = 15000.00m, 
            Currency = "USD",
            Icon = "credit_card",
            Color = "#3b82f6"
        },
        new AccountModel 
        { 
            Id = Guid.NewGuid(), 
            Name = "Ahorros", 
            Balance = 8500.50m, 
            Currency = "USD",
            Icon = "account_balance",
            Color = "#22c55e"
        },
        new AccountModel 
        { 
            Id = Guid.NewGuid(), 
            Name = "Inversiones", 
            Balance = 25000.00m, 
            Currency = "USD",
            Icon = "trending_up",
            Color = "#8b5cf6"
        }
    };

    // Loading states
    public bool IsLoading { get; private set; }
    public bool IsAdding { get; private set; }
    public bool IsUpdating { get; private set; }
    public bool IsDeleting { get; private set; }

    /// <summary>
    /// Indica si hay alguna operación en curso
    /// </summary>
    public bool IsBusy => IsLoading || IsAdding || IsUpdating || IsDeleting;

    public void AddAccount(AccountModel account)
    {
        Accounts.Add(account);
        NotifyStateChanged();
    }

    public void UpdateAccount(AccountModel account)
    {
        var existing = Accounts.FirstOrDefault(a => a.Id == account.Id);
        if (existing != null)
        {
            existing.Name = account.Name;
            existing.Balance = account.Balance;
            existing.Currency = account.Currency;
            existing.Icon = account.Icon;
            existing.Color = account.Color;
            NotifyStateChanged();
        }
    }

    public void DeleteAccount(Guid id)
    {
        var account = Accounts.FirstOrDefault(a => a.Id == id);
        if (account != null)
        {
            Accounts.Remove(account);
            NotifyStateChanged();
        }
    }

    public void UpdateBalance(Guid accountId, decimal amount)
    {
        var account = Accounts.FirstOrDefault(a => a.Id == accountId);
        if (account != null)
        {
            account.Balance += amount;
            NotifyStateChanged();
        }
    }

    public void CleanAccounts()
    {
        Accounts.Clear();
        NotifyStateChanged();
    }

    // Loading state management
    public void SetIsLoading()
    {
        IsLoading = !IsLoading;
        NotifyStateChanged();
    }

    public void SetIsAdding()
    {
        IsAdding = !IsAdding;
        NotifyStateChanged();
    }

    public void SetIsUpdating()
    {
        IsUpdating = !IsUpdating;
        NotifyStateChanged();
    }

    public void SetIsDeleting()
    {
        IsDeleting = !IsDeleting;
        NotifyStateChanged();
    }
}

public class AccountModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "USD";
    public string Icon { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
}
