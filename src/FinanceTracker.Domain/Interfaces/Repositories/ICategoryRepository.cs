namespace FinanceTracker.Domain.Interfaces.Repositories;

using FinanceTracker.Domain.Categories;

public interface ICategoryRepository
{
    /// <summary>
    /// Crea una nueva categoría en el contexto (no persiste los cambios).
    /// </summary>
    /// <param name="category"></param>
    /// <returns></returns>
    Task Add(Category category);

    /// <summary>
    /// Obtiene una categoría por su identificador del contexto (no persiste los cambios).
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Category?> GetById(Guid id);

    /// <summary>
    /// Obtiene todas las categorías del contexto
    /// </summary>
    /// <returns></returns>
    Task<List<Category>> GetAll();

    /// <summary>
    /// Elimina una categoría del contexto (no persiste los cambios).
    /// </summary>
    Task Delete(Category category);
}
