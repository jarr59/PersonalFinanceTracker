using FinanceTracker.Web.Services.Errors;
using Microsoft.AspNetCore.Components.Web;

namespace FinanceTracker.Web.Components.Shared;

public class AppErrorBoundary(IErrorServices _errorServices) : ErrorBoundary
{
    protected override async Task OnErrorAsync(Exception exception)
    {
        Recover();
        await _errorServices.AddError(exception);
        await base.OnErrorAsync(exception);
    }
}
