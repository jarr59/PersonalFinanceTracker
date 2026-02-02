namespace FinanceTracker.Domain.Interfaces.Repositories;

using FinanceTracker.Domain.Categories;

public interface ICategoryRepository
{
    Task Add(Category category);
    Task Update(Category category);
    Task<Category?> GetById(Guid id);
    Task<List<Category>> GetAll();
}
