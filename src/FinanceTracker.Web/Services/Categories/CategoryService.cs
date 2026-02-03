using CustomMediator.CQRS;
using FinanceTracker.Domain.ValueObjects;
using FinanceTracker.Aplication.Categories.Commands;
using FinanceTracker.Aplication.Categories.Queries;

namespace FinanceTracker.Web.Services.Categories;

/// <summary>
/// Service for managing category operations using CQRS pattern.
/// Encapsulates all category-related business logic.
/// </summary>
public class CategoryService
{
    private readonly CreateCategoryCommandHandler _createHandler;
    private readonly UpdateCategoryCommandHandler _updateHandler;
    private readonly GetAllCategoriesQueryHandler _getAllHandler;
    private readonly GetCategoryByIdQueryHandler _getByIdHandler;

    public CategoryService(
        CreateCategoryCommandHandler createHandler,
        UpdateCategoryCommandHandler updateHandler,
        GetAllCategoriesQueryHandler getAllHandler,
        GetCategoryByIdQueryHandler getByIdHandler)
    {
        _createHandler = createHandler;
        _updateHandler = updateHandler;
        _getAllHandler = getAllHandler;
        _getByIdHandler = getByIdHandler;
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    public async Task CreateCategoryAsync(string name, string colorHex, string iconSource)
    {
        var command = new CreateCategoryCommand(name, colorHex, iconSource);
        await _createHandler.HandleAsync(command);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    public async Task UpdateCategoryAsync(Guid id, string name, string colorHex, string iconSource)
    {
        var command = new UpdateCategoryCommand(id, name, colorHex, iconSource);
        await _updateHandler.HandleAsync(command);
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var query = new GetAllCategoriesQuery();
        var categories = await _getAllHandler.HandleAsync(query);
        
        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name.Name,
            Color = c.Color.Color,
            Icon = c.Icon.Source
        }).ToList();
    }

    /// <summary>
    /// Retrieves a category by ID.
    /// </summary>
    public async Task<CategoryDto?> GetCategoryByIdAsync(Guid id)
    {
        var query = new GetCategoryByIdQuery(id);
        var category = await _getByIdHandler.HandleAsync(query);
        
        if (category == null)
            return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name.Name,
            Color = category.Color.Color,
            Icon = category.Icon.Source
        };
    }
}

/// <summary>
/// DTO for transferring category data between layers.
/// </summary>
public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}
