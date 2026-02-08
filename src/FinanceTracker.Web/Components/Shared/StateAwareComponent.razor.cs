using FinanceTracker.Web.States;
using Microsoft.AspNetCore.Components;

namespace FinanceTracker.Web.Components.Shared;

public abstract class StateAwareComponent : ComponentBase, IDisposable
{
    private readonly List<(IStateContainer State, Action Handler)> _subscriptions = [];
    private bool _disposed;

    protected async Task Subscribe(IStateContainer state, Func<Task>? onChangeCallback = null)
    {
        // Handler que garantiza ejecución en el contexto de UI
        void Handler() => _ = InvokeAsync(async () =>
        {
            StateHasChanged();

            ///Notifico al metodo del suscriptor que el estado cambio
            if (onChangeCallback is not null)
                await onChangeCallback();

            ///Notifico al metodo por defecto que el estado cambio
            if (onChangeCallback is null)
                await OnChangeState();
        });

        state.OnChange += Handler;
        _subscriptions.Add((state, Handler));
    }
    protected virtual Task OnChangeState() => Task.CompletedTask;

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            foreach (var (state, handler) in _subscriptions)
                state.OnChange -= handler;

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