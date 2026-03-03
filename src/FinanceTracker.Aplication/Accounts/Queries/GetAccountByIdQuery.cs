using System.Threading.Tasks;
using CustomMediator.CQRS.Queries;
using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Aplication.Accounts.Queries;

public sealed record GetAccountByIdQuery(Guid Id) : ICustomQuery<Account?>;

public class GetAccountByIdQueryHandler(IAccountRepository _repository)
    : ICustomQueryHandler<GetAccountByIdQuery, Account?>
{
    public async Task<Account?> HandleAsync(GetAccountByIdQuery query)
    {
        return await _repository.GetById(query.Id);
    }
}