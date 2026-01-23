using FinanceTracker.Domain.ValueObjects;

namespace FinanceTracker.Domain.Categories;

/// <summary>
/// Representa una categoria
/// </summary>
public class Category
{
    /// <summary>
    /// Representa el id de la categoria
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Representa el nombre de la categoria
    /// </summary>
    public NameVO Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ColorVO Color { get; set; }
}