namespace FinanceTracker.Web.Components.Transactions.ViewModels;

/// <summary>
/// Representa el ViewModel para el modal de transacción
/// </summary>
public class TransactionModalVM
{
    /// <summary>
    /// Indica el Id de la transacción
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// Representa la descripción
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Representa el monto
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Representa la fecha
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>
    /// Representa la categoría asociada
    /// </summary>
    public Guid CategoryId { get; set; } = Guid.Empty;

    /// <summary>
    /// Representa la cuenta asociada
    /// </summary>
    public Guid AccountId { get; set; } = Guid.Empty;
}
