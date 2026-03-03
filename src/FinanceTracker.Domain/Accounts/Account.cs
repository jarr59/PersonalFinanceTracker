using FinanceTracker.Domain.ValueObjects;

namespace FinanceTracker.Domain.Accounts;

/// <summary>
/// Represents a financial account in the domain model.
/// </summary>
public class Account
{
    /// <summary>
    /// Only for ORM use.
    /// </summary>
    protected Account() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="Account"/> class with the specified properties.
    /// </summary>
    public Account(string name, decimal balance, string currency, string icon, string color)
    {
        Id = Guid.NewGuid();
        Name = name;
        Balance = balance;
        Currency = currency;
        Icon = icon;
        Color = color;
    }

    /// <summary>
    /// Gets or sets the unique identifier for the account.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the account.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current balance of the account.
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Gets or sets the currency of the account.
    /// </summary>
    public string Currency { get; private set; } = "USD";

    /// <summary>
    /// Gets or sets the icon associated with the account.
    /// </summary>
    public string Icon { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the color associated with the account.
    /// </summary>
    public string Color { get; private set; } = string.Empty;

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateBalance(decimal balance)
    {
        Balance = balance;
    }

    public void UpdateCurrency(string currency)
    {
        Currency = currency;
    }

    public void UpdateIcon(string icon)
    {
        Icon = icon;
    }

    public void UpdateColor(string color)
    {
        Color = color;
    }
}