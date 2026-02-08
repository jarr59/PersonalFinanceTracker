namespace FinanceTracker.Web.Components.Categories.ViewModels;

/// <summary>
/// Representa el ViewModel para el modal de categoria
/// </summary>
public class CategoryModalVM
{
    /// <summary>
    /// Indica el Id de la categoria
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// Representa el nombre
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Representa un color exadecimal
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Recurso
    /// </summary>
    public string Icon { get; set; } = string.Empty;
}
