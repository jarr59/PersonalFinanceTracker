using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;

namespace FinanceTracker.Aplication.Categories.Queries;

public static class GetAllCategories
{
    public sealed record Query;

    public class Handler
    {
        private readonly ICategoryRepository _repository;

        public Handler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> Handle(Query query)
        {
            return await _repository.GetAll();
        }
    }
}
