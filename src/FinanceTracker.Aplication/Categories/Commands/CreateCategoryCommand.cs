using FinanceTracker.Domain.ValueObjects;
using FinanceTracker.Domain.Categories;
using FinanceTracker.Domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceTracker.Aplication.Categories.Commands;

public sealed record CreateCategoryCommand(string Name, string ColorHex, string IconSource);


public class CreateCategoryCommandHandler
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var category = new Category(new NameVO(command.Name), new ColorVO(command.ColorHex), new IconVO(command.IconSource));
        await _repository.Add(category);
        await _unitOfWork.SaveChanges(cancellationToken);
    }
}
