namespace FinanceTracker.Domain.ValueObjects;
public sealed record IconVO
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    /// <summary>
    /// Ef uso
    /// </summary>
    private IconVO() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    /// <summary>
    /// Recurso
    /// </summary>
    public string Source { get; }
    /// <summary>
    ///
    /// </summary>
    /// <param name="value">Representa el nombre del icono con su extension</param>
    public IconVO(string value) => Source = value;
}