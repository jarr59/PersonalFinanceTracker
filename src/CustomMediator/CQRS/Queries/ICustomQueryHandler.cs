namespace CustomMediator.CQRS.Queries;

/// <summary>
/// Query handler interface
/// </summary>
/// <typeparam name="TQuery"></typeparam>
/// <typeparam name="TResult"></typeparam>
public interface ICustomQueryHandler<in TQuery, TResult> where TQuery : ICustomQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
