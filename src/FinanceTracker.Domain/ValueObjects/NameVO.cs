namespace FinanceTracker.Domain.ValueObjects;

/// <summary>
/// 
/// </summary>
public sealed record NameVO
{
    /// <summary>
    /// Representa el nombre
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// EF uso
    /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private NameVO(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public NameVO(string value)
    {
        Name = value;
    }
}