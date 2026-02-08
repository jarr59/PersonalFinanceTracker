using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.ValueObjects;

namespace FinanceTracker.Web.States.Categories.DTOs;

/// <summary>
/// Representa una categoria
/// </summary>
public class CategoryModel(Guid id,
                           NameVO name,
                           ColorVO color,
                           IconVO icon)
{
    /// <summary>
    /// Representa el id de la categoria
    /// </summary>
    public Guid Id { get; set; } = id;

    /// <summary>
    /// Representa el nombre de la categoria
    /// </summary>
    public NameVO Name { get; set; } = name;

    /// <summary>
    /// 
    /// </summary>
    public ColorVO Color { get; set; } = color;

    /// <summary>
    /// Icono asociado a la categoria
    /// </summary>
    public IconVO Icon { get; set; } = icon;

    /// <summary>
    /// Crea un CategoryModel a partir de una entidad de dominio Category
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    public static CategoryModel FromDomain(Category category) =>
        new(category.Id, category.Name, category.Color, category.Icon);
}
