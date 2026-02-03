using CustomMediator.CQRS.Commands;
using CustomMediator.CQRS.Queries;

namespace CustomMediator;

/// <summary>
/// Mediator interface
/// </summary>
public interface IMediator
{
    Task<TResult> SendCommandAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICustomCommand<TResult>;

    Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : ICustomQuery<TResult>;
}
