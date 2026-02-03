using CustomMediator.CQRS;
using Microsoft.Extensions.DependencyInjection;

namespace CustomMediator;

public static class ServiceCollection
{
    public static void AddCustomMediator(this IServiceCollection services)
    {
        // Register mediator
        services.AddSingleton<IMediator, Mediator>();

        // Register pipeline behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    }
}
