using Microsoft.Extensions.Logging;

namespace CustomMediator.CQRS;

// Pipeline behavior
public class LoggingBehavior<TInput, TOutput>(ILogger<LoggingBehavior<TInput, TOutput>> logger) : IPipelineBehavior<TInput, TOutput>
{
    public async Task<TOutput> HandleAsync(TInput input, Func<Task<TOutput>> next, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Starting: {typeof(TInput).Name}");
        var result = await next();
        logger.LogInformation($"Finished: {typeof(TOutput).Name}");
        return result;
    }
}
