namespace FinanceTracker.Domain.ValueObjects;
public sealed record IconVO
{
    public string Source { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="value">Representa el nombre del icono con su extension</param>
    public IconVO(string value) => Source = value;
}