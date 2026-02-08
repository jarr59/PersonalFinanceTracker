namespace FinanceTracker.Web.Services.Errors
{
    /// <summary>
    /// Representa los servicios relacionados con la gestión de errores en la aplicación.
    /// </summary>
    public interface IErrorServices
    {
        Task AddError(Exception exception);
    }
}
