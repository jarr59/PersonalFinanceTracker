using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

/// <summary>
/// Provides data access methods for managing category entities in the finance tracker database.
/// </summary>
/// <param name="dbContext">The database context used to access and manage category data.</param>
internal class CategoryRepository(FinanceTrackerDbContext dbContext) : ICategoryRepository
{
    /// <summary>
    /// Asynchronously adds a category to the database context.
    /// </summary>
    /// <param name="category">The category to add to the context.</param>
    public async Task Add(Category category)
    {
        await dbContext.Categories.AddAsync(category);
    }

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>The category if found; otherwise, null.</returns>
    public async Task<Category?> GetById(Guid id)
    {
        return await dbContext.Categories.FindAsync(id);
    }

    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <returns>A list of all categories.</returns>
    public async Task<List<Category>> GetAll()
    {
        return await dbContext.Categories.ToListAsync();
    }

    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <returns>A list of all categories.</returns>
    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Elimina una categoría del contexto (no persiste los cambios).
    /// </summary>
    public async Task Delete(Category category)
    {
        dbContext.Categories.Remove(category);
        await Task.CompletedTask;
    }
}
