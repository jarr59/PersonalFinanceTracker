using System.Threading.Tasks;
using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;

namespace FinanceTracker.Aplication.Categories.Queries;

public sealed record GetCategoryByIdQuery(Guid Id) : ICustomQuery<Category?>;

public class GetCategoryByIdQueryHandler(ICategoryRepository _repository) : ICustomQueryHandler<GetCategoryByIdQuery, Category?>
{
    public async Task<Category?> HandleAsync(GetCategoryByIdQuery query)
    {
        return await _repository.GetById(query.Id);
    }
}
