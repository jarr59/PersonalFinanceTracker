
using FinanceTracker.Web.States.Errors;

namespace FinanceTracker.Web.Services.Errors
{
    public class ErrorServices(ErrorState _errorState) : IErrorServices
    {
        public async Task AddError(Exception exception)
        {
            _errorState.Add(exception.Message);

            await Task.CompletedTask;
        }
    }
}
