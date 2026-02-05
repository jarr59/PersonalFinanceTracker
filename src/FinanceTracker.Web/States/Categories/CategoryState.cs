using FinanceTracker.Web.States.Categories.DTOs;

namespace FinanceTracker.Web.States.Categories;

public sealed class CategoryState : StateContainerBase
{
    /// <summary>
    /// Representa las categorias disponibles
    /// </summary>
    public List<CategoryModel> Categories { get; private set; } = [];

    /// <summary>
    /// Indica si las categorias han sido cargadas
    /// </summary>
    public bool IsLoading { get; private set; } = false;

    public void AddCategory(List<CategoryModel> categories)
    {
        SetIsLoading();

        Categories.AddRange(categories);

        SetIsLoading();
    }

    public void UpdateCategory(CategoryModel category)
    {
        CategoryModel? existing = Categories.FirstOrDefault(c => c.Id == category.Id);
        if (existing != null)
        {
            SetIsLoading();
            existing.Name = category.Name;
            existing.Color = category.Color;
            existing.Icon = category.Icon;
            SetIsLoading();

        }
    }

    public void DeleteCategory(Guid id)
    {
        CategoryModel? category = Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            SetIsLoading();
            Categories.Remove(category);
            SetIsLoading();
        }
    }

    public void CleanCategories()
    {
        SetIsLoading();
        Categories.Clear();
        SetIsLoading();
    }

    private void SetIsLoading()
    {
        IsLoading = IsLoading != true;
        NotifyStateChanged();
    }
}
