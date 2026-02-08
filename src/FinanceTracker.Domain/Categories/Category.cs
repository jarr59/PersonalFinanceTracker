using FinanceTracker.Domain.ValueObjects;

namespace FinanceTracker.Domain.Categories;

/// <summary>
/// Representa una categoria
/// </summary>
public class Category
{
    /// <summary>
    /// Constructor protegido para uso del ORM
    /// </summary>
    protected Category() { }

    /// <summary>
    /// Representa el id de la categoria
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Representa el nombre de la categoria
    /// </summary>
    public NameVO Name { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public ColorVO Color { get; private set; }

    /// <summary>
    /// Icono asociado a la categoria
    /// </summary>
    public IconVO Icon { get; private set; }

    /// <summary>
    /// Constructor público para crear una nueva categoría
    /// </summary>
    public Category(NameVO name, ColorVO color, IconVO icon)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Color = color ?? throw new ArgumentNullException(nameof(color));
        Icon = icon ?? throw new ArgumentNullException(nameof(icon));
    }

    /// <summary>
    /// Actualiza el nombre de la categoría
    /// </summary>
    public void UpdateName(NameVO name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    /// <summary>
    /// Actualiza el color de la categoría
    /// </summary>
    public void UpdateColor(ColorVO color)
    {
        Color = color ?? throw new ArgumentNullException(nameof(color));
    }

    /// <summary>
    /// Actualiza el icono de la categoría
    /// </summary>
    public void UpdateIcon(IconVO icon)
    {
        Icon = icon ?? throw new ArgumentNullException(nameof(icon));
    }
}