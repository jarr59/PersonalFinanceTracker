using FinanceTracker.Web.States.Categories.DTOs;

namespace FinanceTracker.Web.States.Categories;

public sealed class CategoryState : StateContainerBase
{
    /// <summary>
    /// Representa las categorias disponibles
    /// </summary>
    public List<CategoryModel> Categories { get; private set; } = [];

    /// <summary>
    /// Indica si las categorias están siendo cargadas
    /// </summary>
    public bool IsLoading { get; private set; } = false;

    /// <summary>
    /// Indica si se está agregando una categoría
    /// </summary>
    public bool IsAdding { get; private set; } = false;

    /// <summary>
    /// Indica si se está actualizando una categoría
    /// </summary>
    public bool IsUpdating { get; private set; } = false;

    /// <summary>
    /// Indica si se está eliminando una categoría
    /// </summary>
    public bool IsDeleting { get; private set; } = false;

    /// <summary>
    /// Indica si hay alguna operación en curso
    /// </summary>
    public bool IsBusy => IsLoading || IsAdding || IsUpdating || IsDeleting;

    public void AddCategory(List<CategoryModel> categories)
    {
        Categories.AddRange(categories);
    }

    public void UpdateCategory(CategoryModel category)
    {
        CategoryModel? existing = Categories.FirstOrDefault(c => c.Id == category.Id);
        if (existing != null)
        {
            existing.Name = category.Name;
            existing.Color = category.Color;
            existing.Icon = category.Icon;
        }
    }

    public void DeleteCategory(Guid id)
    {
        CategoryModel? category = Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            Categories.Remove(category);
        }
    }

    public void CleanCategories()
    {
        Categories.Clear();
    }

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

    public void SetIsBusy()
    {
        IsLoading = !IsLoading;
        NotifyStateChanged();
    }
}
