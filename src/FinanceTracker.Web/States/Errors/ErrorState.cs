namespace FinanceTracker.Web.States.Errors;

public sealed class ErrorState : StateContainerBase
{
    public List<string> Errors { get; private set; } = [];

    /// <summary>
    /// Agrega un error al listado de errores
    /// </summary>
    /// <param name="message"></param>
    public void Add(string message)
    {
        Errors.Add(message);
        NotifyStateChanged();
    }

    /// <summary>
    /// Limpia el listado de errores
    /// </summary>
    public void Clear()
    { 
        Errors.Clear(); 
        NotifyStateChanged();
    }
}
