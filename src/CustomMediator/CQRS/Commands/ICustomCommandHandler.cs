namespace CustomMediator.CQRS.Commands;

/// <summary>
/// Command handler interface
/// </summary>
public interface ICustomCommandHandler<in TCommand, TResult> where TCommand : ICustomCommand<TResult>
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
