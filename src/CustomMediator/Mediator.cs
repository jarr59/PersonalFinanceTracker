using CustomMediator.CQRS;
using CustomMediator.CQRS.Commands;
using CustomMediator.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CustomMediator;

/// <summary>
/// Implementación personalizada del patrón Mediador para manejar Commands y Queries
/// El patrón Mediador actúa como intermediario entre los controladores y los handlers,
/// promoviendo el desacoplamiento y la separación de responsabilidades.
/// </summary>
/// <param name="provider">ServiceProvider para resolver dependencias de handlers y behaviors</param>
public class Mediator(IServiceProvider provider) : IMediator
{
    /// <summary>
    /// Ejecuta un Command a través del patrón mediador con soporte para pipeline behaviors
    /// FLUJO DE EJECUCIÓN:
    /// 1. Resuelve el handler específico para el command usando DI
    /// 2. Obtiene todos los behaviors registrados para crear un pipeline
    /// 3. Construye una cadena de responsabilidad con los behaviors
    /// 4. Ejecuta el pipeline completo que termina llamando al handler
    /// </summary>
    /// <typeparam name="TCommand">Tipo del command a ejecutar</typeparam>
    /// <typeparam name="TResult">Tipo del resultado esperado</typeparam>
    /// <param name="command">Instancia del command con los datos</param>
    /// <param name="cancellationToken">Token para cancelación de operaciones asíncronas</param>
    /// <returns>Resultado de la ejecución del command</returns>
    public async Task<TResult> SendCommandAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICustomCommand<TResult>
    {
        var handlers = provider.GetServices<ICustomCommandHandler<TCommand, TResult>>().ToList();
        if (handlers.Count == 0)
        {
            throw new InvalidOperationException($"No handler registered for {typeof(TCommand).Name}");
        }

        if (handlers.Count > 1)
        {
            throw new InvalidOperationException($"Multiple handlers registered for {typeof(TCommand).Name}");
        }

        var handler = handlers[0];

        var behaviors = provider.GetServices<IPipelineBehavior<TCommand, TResult>>().Reverse();

        Func<Task<TResult>> handlerDelegate = () => handler.HandleAsync(command, cancellationToken);

        foreach (var behavior in behaviors)
        {
            var next = handlerDelegate;
            handlerDelegate = () => behavior.HandleAsync(command, next, cancellationToken);
        }

        return await handlerDelegate();
    }

    /// <summary>
    /// Ejecuta una Query a través del patrón mediador con soporte para pipeline behaviors
    /// DIFERENCIA CON COMMANDS: Las queries son para lectura (no modifican estado)
    /// FLUJO DE EJECUCIÓN (idéntico a commands):
    /// 1. Resuelve el handler específico para la query usando DI
    /// 2. Obtiene todos los behaviors registrados para crear un pipeline
    /// 3. Construye una cadena de responsabilidad con los behaviors
    /// 4. Ejecuta el pipeline completo que termina llamando al handler
    /// </summary>
    /// <typeparam name="TQuery">Tipo de la query a ejecutar</typeparam>
    /// <typeparam name="TResult">Tipo del resultado esperado</typeparam>
    /// <param name="query">Instancia de la query con los parámetros de búsqueda</param>
    /// <param name="cancellationToken">Token para cancelación de operaciones asíncronas</param>
    /// <returns>Resultado de la ejecución de la query</returns>
    public async Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : ICustomQuery<TResult>
    {
        var handlers = provider.GetServices<ICustomQueryHandler<TQuery, TResult>>().ToList();
        if (handlers.Count == 0)
        {
            throw new InvalidOperationException($"No handler registered for {typeof(TQuery).Name}");
        }

        if (handlers.Count > 1)
        {
            throw new InvalidOperationException($"Multiple handlers registered for {typeof(TQuery).Name}");
        }

        var handler = handlers[0];

        var behaviors = provider.GetServices<IPipelineBehavior<TQuery, TResult>>().Reverse();

        Func<Task<TResult>> handlerDelegate = () => handler.HandleAsync(query, cancellationToken);

        foreach (var behavior in behaviors)
        {
            var next = handlerDelegate;
            handlerDelegate = () => behavior.HandleAsync(query, next, cancellationToken);
        }

        return await handlerDelegate();
    }
}
