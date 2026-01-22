namespace FinanceTracker.Web.States
{
    public interface IStateContainer
    {
        event Action? OnChange;
    }
}
