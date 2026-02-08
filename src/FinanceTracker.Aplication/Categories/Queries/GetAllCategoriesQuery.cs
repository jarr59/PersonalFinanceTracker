using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;

namespace FinanceTracker.Aplication.Categories.Queries;

public sealed record GetAllCategoriesQuery : ICustomQuery<List<Category>>;

public class GetAllCategoriesQueryHandler(ICategoryRepository _repository) : ICustomQueryHandler<GetAllCategoriesQuery, List<Category>>
{
    public async Task<List<Category>> HandleAsync(GetAllCategoriesQuery query, CancellationToken cancellationToken = default)
    {
        return await _repository.GetAll();
    }
}
