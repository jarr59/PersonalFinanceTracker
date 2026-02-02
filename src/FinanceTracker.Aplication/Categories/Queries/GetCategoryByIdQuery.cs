using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;

namespace FinanceTracker.Aplication.Categories.Queries;

public static class GetCategoryById
{
    public sealed record Query(Guid Id);

    public class Handler
    {
        private readonly ICategoryRepository _repository;

        public Handler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category?> Handle(Query query)
        {
            return await _repository.GetById(query.Id);
        }
    }
}
