using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;
using CustomMediator.CQRS.Commands;

namespace FinanceTracker.Aplication.Categories.Commands;

public sealed record DeleteCategoryCommand(Guid Id) : ICustomCommand<bool>;

public class DeleteCategoryCommandHandler(ICategoryRepository _repository, IUnitOfWork _unitOfWork) : ICustomCommandHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> HandleAsync(DeleteCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetById(command.Id);
        if (existing is null)
            throw new InvalidOperationException($"Category with Id {command.Id} not found");

        await _repository.Delete(existing);
        await _unitOfWork.SaveChanges();

        return true;
    }
}
