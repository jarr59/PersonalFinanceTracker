using FinanceTracker.Web.States.Categories.DTOs;

namespace FinanceTracker.Web.States.Categories;

public sealed class CategoryState : StateContainerBase
{
    /// <summary>
    /// Representa las categorias disponibles
    /// </summary>
    public List<CategoryModel> Categories { get; private set; } = [];

    public void AddCategory(List<CategoryModel> categories)
    {
        Categories.AddRange(categories);
        NotifyStateChanged();
    }

    public void UpdateCategory(CategoryModel category)
    {
        CategoryModel? existing = Categories.FirstOrDefault(c => c.Id == category.Id);
        if (existing != null)
        {
            existing.Name = category.Name;
            existing.Color = category.Color;
            existing.Icon = category.Icon;
            NotifyStateChanged();
        }
    }

    public void DeleteCategory(Guid id)
    {
        CategoryModel? category = Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            Categories.Remove(category);
            NotifyStateChanged();
        }
    }

    public void CleanCategories()
    {
        Categories.Clear();
        NotifyStateChanged();
    }
}
