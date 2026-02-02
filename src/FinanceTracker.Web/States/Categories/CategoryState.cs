namespace FinanceTracker.Web.States.Categories;

public sealed class CategoryState : StateContainerBase
{
    public List<CategoryModel> Categories { get; private set; } = new()
    {
        new CategoryModel { Id = Guid.NewGuid(), Name = "Alimentación", Color = "#22c55e", Icon = "restaurant" },
        new CategoryModel { Id = Guid.NewGuid(), Name = "Transporte", Color = "#3b82f6", Icon = "directions_car" },
        new CategoryModel { Id = Guid.NewGuid(), Name = "Entretenimiento", Color = "#ec4899", Icon = "sports_esports" },
        new CategoryModel { Id = Guid.NewGuid(), Name = "Salud", Color = "#ef4444", Icon = "local_hospital" },
        new CategoryModel { Id = Guid.NewGuid(), Name = "Educación", Color = "#8b5cf6", Icon = "school" },
        new CategoryModel { Id = Guid.NewGuid(), Name = "Servicios", Color = "#f59e0b", Icon = "lightbulb" },
        new CategoryModel { Id = Guid.NewGuid(), Name = "Compras", Color = "#06b6d4", Icon = "shopping_cart" },
        new CategoryModel { Id = Guid.NewGuid(), Name = "Otros", Color = "#64748b", Icon = "category" }
    };

    public void AddCategory(CategoryModel category)
    {
        Categories.Add(category);
        NotifyStateChanged();
    }

    public void UpdateCategory(CategoryModel category)
    {
        var existing = Categories.FirstOrDefault(c => c.Id == category.Id);
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
        var category = Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            Categories.Remove(category);
            NotifyStateChanged();
        }
    }
}

public class CategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}
