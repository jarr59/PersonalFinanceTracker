using FinanceTracker.Domain.ValueObjects;
using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;

namespace FinanceTracker.Aplication.Categories.Commands;

public sealed record UpdateCategoryCommand(Guid Id, string Name, string ColorHex, string IconSource) : ICustomCommand<Category>;

public class UpdateCategoryCommandHandler(ICategoryRepository _repository, IUnitOfWork _unitOfWork) : ICustomCommandHandler<UpdateCategoryCommand, Category>
{
    public async Task<Category> HandleAsync(UpdateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetById(command.Id);
        if (existing is null)
        {
            throw new InvalidOperationException($"Category with Id {command.Id} not found");
        }

        existing.UpdateName(new NameVO(command.Name));
        existing.UpdateColor(new ColorVO(command.ColorHex));
        existing.UpdateIcon(new IconVO(command.IconSource));
        await _unitOfWork.SaveChanges();
        
        return existing;
    }
}
