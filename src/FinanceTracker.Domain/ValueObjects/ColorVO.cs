namespace FinanceTracker.Domain.ValueObjects;

/// <summary>
/// Representa un color
/// </summary>
public sealed record ColorVO
{
    /// <summary>
    /// Representa un color exadecimal
    /// </summary>
    public string Color { get; }

    /// <summary>
    /// Constructor publico
    /// </summary>
    /// <param name="value">Color en exadecimal</param>
    public ColorVO(string value) => Color = value;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    /// <summary>
    /// Ef uso
    /// </summary>
    private ColorVO(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}