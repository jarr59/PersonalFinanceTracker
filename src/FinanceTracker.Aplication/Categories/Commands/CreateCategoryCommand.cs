using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.ValueObjects;

namespace FinanceTracker.Aplication.Categories.Commands;

public sealed record CreateCategoryCommand(string Name, string ColorHex, string IconSource) : ICustomCommand<Category>;


public class CreateCategoryCommandHandler(ICategoryRepository _repository, IUnitOfWork _unitOfWork) : ICustomCommandHandler<CreateCategoryCommand, Category>
{
    public async Task<Category> HandleAsync(CreateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var category = new Category(new NameVO(command.Name), new ColorVO(command.ColorHex), new IconVO(command.IconSource));
        await _repository.Add(category);
        await _unitOfWork.SaveChanges();
        return category;
    }
}
