using FinanceTracker.Domain.ValueObjects;
using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Aplication.Categories.Commands;

public sealed record UpdateCategoryCommand(System.Guid Id, string Name, string ColorHex, string IconSource);


public class UpdateCategoryCommandHandler
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var existing = await _repository.GetById(command.Id);
        if (existing is null)
        {
            return; // for MVP
        }

        existing.UpdateName(new NameVO(command.Name));
        existing.UpdateColor(new ColorVO(command.ColorHex));
        existing.UpdateIcon(new IconVO(command.IconSource));

        await _repository.Update(existing);
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}
