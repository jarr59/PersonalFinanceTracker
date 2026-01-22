namespace FinanceTracker.Web.States
{
    /// <summary>
    /// Representa un contenedor de estado base que notifica a los suscriptores cuando el estado cambia.
    /// </summary>
    public abstract class StateContainerBase : IStateContainer
    {
        /// <summary>
        /// Representa un evento que se dispara cuando el estado cambia.
        /// </summary>
        public event Action? OnChange;

        /// <summary>
        /// Envía una notificación a todos los suscriptores de que el estado ha cambiado.
        /// </summary>
        protected void NotifyStateChanged() => OnChange?.Invoke();
    }
}
