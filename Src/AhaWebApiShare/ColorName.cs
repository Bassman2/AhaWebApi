namespace AVMHomeAutomation;

/// <summary>
/// ColorName of a color
/// </summary>
public class ColorName : IXSerializable
{
    /// <summary>
    /// Number of the color
    /// </summary>
    public int? Enum { get; set; }

    /// <summary>
    /// ColorName of the color
    /// </summary>
    public string? Value { get; set; }

    public void ReadX(XElement elm)
    {
        Enum = elm.ReadAttributeInt("enum");
        Value = elm.Value;
    }
}
