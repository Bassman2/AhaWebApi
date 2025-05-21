namespace AhaWebApi;

/// <summary>
/// Represents the name and numeric identifier of a color.
/// </summary>
public class ColorName : IXSerializable
{
    /// <summary>
    /// Gets or sets the numeric identifier of the color.
    /// </summary>
    public int? Enum { get; set; }

    /// <summary>
    /// Gets or sets the name of the color.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Reads the color information from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Enum = elm.ReadAttributeInt("enum");
        Value = elm.Value;
    }
}
