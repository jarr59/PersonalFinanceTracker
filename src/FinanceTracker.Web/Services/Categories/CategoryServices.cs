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
public class CategoryServices(IMediator mediator, CategoryState _categoryState) : ICategoryServices
{
    /// <summary>
    /// Creates a new category and updates the state.
    /// </summary>
    public async Task CreateCategoryAsync(string name, string colorHex, string iconSource)
    {
        _categoryState.SetIsAdding();

        Category result = await mediator.SendCommandAsync<CreateCategoryCommand, Category>(new CreateCategoryCommand(name, colorHex, iconSource));
        
        _categoryState.AddCategory([CategoryModel.FromDomain(result)]);

        await Task.Delay(1000);

        _categoryState.SetIsAdding();
    }

    /// <summary>
    /// Updates an existing category and updates the state.
    /// </summary>
    public async Task UpdateCategoryAsync(Guid id, string name, string colorHex, string iconSource)
    {
        _categoryState.SetIsUpdating();

        Category result = await mediator.SendCommandAsync<UpdateCategoryCommand, Category>(new UpdateCategoryCommand(id, name, colorHex, iconSource));

        _categoryState.UpdateCategory(CategoryModel.FromDomain(result));

        await Task.Delay(1000);

        _categoryState.SetIsUpdating();
    }

    /// <summary>
    /// Retrieves all categories from the repository.
    /// </summary>
    public async Task LoadAllCategories()
    {
        _categoryState.SetIsLoading();

        List<Category> result = await mediator.SendQueryAsync<GetAllCategoriesQuery, List<Category>>(new GetAllCategoriesQuery());

        _categoryState.CleanCategories();

        await Task.Delay(1000);

        _categoryState.AddCategory([.. result.Select(CategoryModel.FromDomain)]);

        _categoryState.SetIsLoading();
    }

    /// <summary>
    /// Deletes a category using application command and updates the state.
    /// </summary>
    public async Task DeleteCategoryAsync(Guid id)
    {
        _categoryState.SetIsDeleting();

        await mediator.SendCommandAsync<DeleteCategoryCommand, bool>(new DeleteCategoryCommand(id));

        _categoryState.DeleteCategory(id);

        await Task.Delay(1000);

        _categoryState.SetIsDeleting();
    }
}
