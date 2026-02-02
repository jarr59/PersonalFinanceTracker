namespace FinanceTracker.Web.States.Transactions;

public sealed class TransactionState : StateContainerBase
{
    private readonly Random _random = new();

    public List<TransactionModel> Transactions { get; private set; } = new()
    {
        new TransactionModel 
        { 
            Id = Guid.NewGuid(),
            Description = "Compra supermercado",
            Amount = -150.50m,
            Date = DateTime.Now.AddDays(-1),
            CategoryId = Guid.NewGuid(),
            CategoryName = "Alimentación",
            CategoryIcon = "restaurant",
            CategoryColor = "#22c55e",
            AccountId = Guid.NewGuid(),
            AccountName = "Cuenta Principal"
        },
        new TransactionModel 
        { 
            Id = Guid.NewGuid(),
            Description = "Salario mensual",
            Amount = 5000.00m,
            Date = DateTime.Now.AddDays(-2),
            CategoryId = Guid.NewGuid(),
            CategoryName = "Otros",
            CategoryIcon = "attach_money",
            CategoryColor = "#64748b",
            AccountId = Guid.NewGuid(),
            AccountName = "Cuenta Principal"
        },
        new TransactionModel 
        { 
            Id = Guid.NewGuid(),
            Description = "Uber viaje centro",
            Amount = -25.00m,
            Date = DateTime.Now.AddDays(-3),
            CategoryId = Guid.NewGuid(),
            CategoryName = "Transporte",
            CategoryIcon = "directions_car",
            CategoryColor = "#3b82f6",
            AccountId = Guid.NewGuid(),
            AccountName = "Cuenta Principal"
        },
        new TransactionModel 
        { 
            Id = Guid.NewGuid(),
            Description = "Netflix subscription",
            Amount = -15.99m,
            Date = DateTime.Now.AddDays(-5),
            CategoryId = Guid.NewGuid(),
            CategoryName = "Entretenimiento",
            CategoryIcon = "sports_esports",
            CategoryColor = "#ec4899",
            AccountId = Guid.NewGuid(),
            AccountName = "Cuenta Principal"
        },
        new TransactionModel 
        { 
            Id = Guid.NewGuid(),
            Description = "Consulta médica",
            Amount = -80.00m,
            Date = DateTime.Now.AddDays(-7),
            CategoryId = Guid.NewGuid(),
            CategoryName = "Salud",
            CategoryIcon = "local_hospital",
            CategoryColor = "#ef4444",
            AccountId = Guid.NewGuid(),
            AccountName = "Cuenta Principal"
        }
    };

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
}

public class TransactionModel
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryIcon { get; set; } = string.Empty;
    public string CategoryColor { get; set; } = string.Empty;
    public Guid AccountId { get; set; }
    public string AccountName { get; set; } = string.Empty;
}
