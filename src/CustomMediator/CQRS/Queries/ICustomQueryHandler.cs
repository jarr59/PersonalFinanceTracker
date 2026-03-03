namespace CustomMediator.CQRS.Queries;

/// <summary>
/// Query handler interface
/// </summary>
public interface ICustomQueryHandler<in TQuery, TResult> where TQuery : ICustomQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}
