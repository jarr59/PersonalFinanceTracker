namespace FinanceTracker.Domain.Enums;

/// <summary>
/// Specifies the type of a financial transaction.
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// Represents an expense (outgoing) transaction.
    /// </summary>
    Outgoing = 0,

    /// <summary>
    /// Represents an income (incoming) transaction.
    /// </summary>
    Incoming = 1
}
