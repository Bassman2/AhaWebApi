namespace AVMHomeAutomation;

/// <summary>
/// Status values
/// </summary>
public class Stats : IXSerializable
{
    /// <summary>
    /// Number of values
    /// </summary>
    public int? Count { get; set; }

    /// <summary>
    /// Grid of values
    /// </summary>
    public int? Grid { get; set; }

    /// <summary>
    /// Values
    /// </summary>
    public string? Value { get; set; }

    public void ReadX(XElement elm)
    {
        Count = elm.ReadAttributeInt("count");
        Grid = elm.ReadAttributeInt("grid");
        Value = elm?.Value;
    }
}
