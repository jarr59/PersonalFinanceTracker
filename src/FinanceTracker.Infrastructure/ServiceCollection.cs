using FinanceTracker.Domain.Interfaces.Repositories;
using FinanceTracker.Infrastructure.Persistence;
using FinanceTracker.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.Infrastructure;

/// <summary>
/// Provides extension methods for registering infrastructure-related services with an <see cref="IServiceCollection"/>
/// instance.
/// </summary>
/// <remarks>This class is intended to be used during application startup to configure dependency injection for
/// infrastructure components such as database contexts and repositories. All methods are static and extend <see
/// cref="IServiceCollection"/> to simplify service registration.</remarks>
public static class ServiceCollection
{
    /// <summary>
    /// Adds infrastructure-related services, including the database context and repositories, to the specified service
    /// collection.
    /// </summary>
    /// <remarks>This method registers the database context and repository services with scoped lifetimes. It
    /// should be called during application startup to ensure that required infrastructure dependencies are available
    /// for dependency injection.</remarks>
    /// <param name="services">The service collection to which the infrastructure services will be added.</param>
    /// <param name="configuration">The application configuration used to retrieve connection strings and other settings required for infrastructure
    /// services.</param>
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinanceTrackerDbContext>(options =>
        {
            options.UseSqlServer(connectionString: configuration.GetConnectionString("Default"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}
