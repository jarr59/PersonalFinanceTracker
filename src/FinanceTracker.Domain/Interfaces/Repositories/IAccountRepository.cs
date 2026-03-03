using FinanceTracker.Domain.Accounts;

namespace FinanceTracker.Domain.Interfaces.Repositories;

public interface IAccountRepository : IRepositoryBase<Account>
{
    Task Add(Account account);

    Task Update(Account account);

    Task Delete(Account account);

    Task<Account?> GetById(Guid id);

    Task<List<Account>> GetAll();
}