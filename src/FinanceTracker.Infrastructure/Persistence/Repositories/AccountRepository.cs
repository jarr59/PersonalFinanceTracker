using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceTracker.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Account = FinanceTracker.Domain.Accounts.Account;

namespace FinanceTracker.Infrastructure.Persistence.Repositories;

/// <summary>
/// Provides data access methods for managing account entities in the finance tracker database.
/// </summary>
internal class AccountRepository(FinanceTrackerDbContext dbContext) : IAccountRepository
{
    /// <summary>
    /// Asynchronously adds a collection of accounts to the database context.
    /// </summary>
    public async Task Add(List<Account> entities) =>
        await dbContext.AddRangeAsync(entities);

    public async Task Add(Account account)
    {
        await dbContext.Accounts.AddAsync(account);
    }

    public async Task Update(Account account)
    {
        dbContext.Accounts.Update(account);
        await Task.CompletedTask;
    }

    public async Task Delete(Account account)
    {
        dbContext.Accounts.Remove(account);
        await Task.CompletedTask;
    }

    public async Task<Account?> GetById(Guid id)
    {
        return await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Account>> GetAll()
    {
        return await dbContext.Accounts.ToListAsync();
    }
}