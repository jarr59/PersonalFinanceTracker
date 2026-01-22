using FinanceTracker.Web.States;
using Microsoft.AspNetCore.Components;

namespace FinanceTracker.Web.Components.Shared;

public abstract class StateAwareComponent : ComponentBase, IDisposable
{
    private readonly List<IStateContainer> _subscriptions = new();
    private bool _disposed;

    protected void Subscribe(IStateContainer state)
    {
        state.OnChange += StateHasChanged;
        _subscriptions.Add(state);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            foreach (var state in _subscriptions)
                state.OnChange -= StateHasChanged;

            _subscriptions.Clear();
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}