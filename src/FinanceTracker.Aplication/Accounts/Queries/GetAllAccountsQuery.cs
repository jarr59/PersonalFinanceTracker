using System.Collections.Generic;
using System.Threading.Tasks;
using CustomMediator.CQRS.Queries;
using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Aplication.Accounts.Queries;

public sealed record GetAllAccountsQuery : ICustomQuery<List<Account>>;

public class GetAllAccountsQueryHandler(IAccountRepository _repository)
    : ICustomQueryHandler<GetAllAccountsQuery, List<Account>>
{
    public async Task<List<Account>> HandleAsync(GetAllAccountsQuery query)
    {
        return await _repository.GetAll();
    }
}