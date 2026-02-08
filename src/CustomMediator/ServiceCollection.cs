using System;
using System.Linq;
using System.Reflection;
using CustomMediator.CQRS;
using CustomMediator.CQRS.Commands;
using CustomMediator.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CustomMediator;

public static class ServiceCollection
{
    public static void AddCustomMediator(this IServiceCollection services)
    {
        AddCustomMediator(services, Array.Empty<Assembly>());
    }

    public static void AddCustomMediator(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddScoped<IMediator, Mediator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        if (assemblies.Length == 0)
        {
            return;
        }

        RegisterHandlers(services, assemblies);
    }

    private static void RegisterHandlers(IServiceCollection services, Assembly[] assemblies)
    {
        var handlerTypes = assemblies
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type is { IsAbstract: false, IsInterface: false })
            .ToList();

        var handlerInterfaces = handlerTypes
            .SelectMany(type => type.GetInterfaces()
                .Where(handlerInterface => handlerInterface.IsGenericType)
                .Select(handlerInterface => new { HandlerType = type, HandlerInterface = handlerInterface }))
            .Where(entry =>
            {
                var genericDefinition = entry.HandlerInterface.GetGenericTypeDefinition();
                return genericDefinition == typeof(ICustomCommandHandler<,>) ||
                       genericDefinition == typeof(ICustomQueryHandler<,>);
            })
            .ToList();

        foreach (var group in handlerInterfaces.GroupBy(x => x.HandlerInterface))
        {
            if (group.Count() > 1)
            {
                var handlerNames = string.Join(", ", group.Select(x => x.HandlerType.Name));
                throw new InvalidOperationException($"Multiple handlers registered for {group.Key.Name}: {handlerNames}");
            }

            var handler = group.Single();
            services.AddScoped(handler.HandlerInterface, handler.HandlerType);
        }
    }
}
