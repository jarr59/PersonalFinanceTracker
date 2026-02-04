using CustomMediator;
using FinanceTracker.Aplication.Categories.Commands;
using FinanceTracker.Aplication.Categories.Queries;
using FinanceTracker.Domain.Categories;
using FinanceTracker.Web.States.Categories;
using FinanceTracker.Web.States.Categories.DTOs;

namespace FinanceTracker.Web.Services.Categories;

/// <summary>
/// Service for managing category operations using CQRS pattern.
/// Encapsulates all category-related business logic and state management.
/// </summary>
public class CategoryService(IMediator mediator, CategoryState _categoryState)
{
    /// <summary>
    /// Creates a new category and updates the state.
    /// </summary>
    public async Task CreateCategoryAsync(string name, string colorHex, string iconSource)
    {
        Category result = await mediator.SendCommandAsync<CreateCategoryCommand, Category>(new CreateCategoryCommand(name, colorHex, iconSource));
        
        _categoryState.AddCategory([CategoryModel.FromDomain(result)]);
    }

    /// <summary>
    /// Updates an existing category and updates the state.
    /// </summary>
    public async Task UpdateCategoryAsync(Guid id, string name, string colorHex, string iconSource)
    {
        Category result = await mediator.SendCommandAsync<UpdateCategoryCommand, Category>(new UpdateCategoryCommand(id, name, colorHex, iconSource));

        _categoryState.UpdateCategory(CategoryModel.FromDomain(result));
    }

    /// <summary>
    /// Retrieves all categories from the repository.
    /// </summary>
    public async Task LoadAllCategories()
    {
        List<Category> result = await mediator.SendQueryAsync<GetAllCategoriesQuery, List<Category>>(new GetAllCategoriesQuery());

        _categoryState.CleanCategories();
        _categoryState.AddCategory([.. result.Select(CategoryModel.FromDomain)]);
    }

    /// <summary>
    /// Deletes a category from the state.
    /// Note: Implement delete command in Application layer for repository deletion.
    /// </summary>
    public void DeleteCategory(Guid id)
    {
        _categoryState.DeleteCategory(id);
    }
}
