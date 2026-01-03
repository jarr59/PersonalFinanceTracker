using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Transaction;

/// <summary>
/// Represents a financial transaction in the domain model.
/// </summary>
/// <remarks>
/// Instances of this type represent a single recorded movement of funds.
/// Use the <see cref="Type"/> property to determine how <see cref="Amount"/> should be interpreted.
/// </remarks>
public class Transaction
{
    /// <summary>
    /// Only for ORM use.
    /// </summary>
    protected Transaction(){ }

    /// <summary>
    /// Constructs a new instance of the <see cref="Transaction"/> class with the specified properties.
    /// </summary>
    public Transaction(decimal amount, DateTime date, string description, TransactionType type)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Date = date;
        Description = description;
        Type = type;
    }

    /// <summary>
    /// Gets or sets the unique identifier for the transaction.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Represents the identifier of the user associated with this transaction.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the monetary amount for the transaction.
    /// </summary>
    /// <remarks>
    /// The interpretation of the value (credit/debit) should be determined in conjunction with the <see cref="Type"/> property.
    /// Store amounts using the smallest required unit to avoid precision issues where appropriate.
    /// </remarks>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the transaction occurred.
    /// </summary>
    /// <remarks>
    /// It is recommended to store times in UTC to avoid ambiguity across time zones.
    /// </remarks>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets an optional human-readable description or memo for the transaction.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the type of the transaction (for example, Income, Expense, Transfer).
    /// </summary>
    /// <seealso cref="FinanceTracker.Domain.Enums.TransactionType"/>
    public TransactionType Type { get; set; }
}
