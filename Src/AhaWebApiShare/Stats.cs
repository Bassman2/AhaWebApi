namespace AhaWebApi;

/// <summary>
/// Represents status values, including a count, grid, and value data.
/// </summary>
public class Stats : IXSerializable
{
    /// <summary>
    /// Gets or sets the number of values.
    /// </summary>
    public int? Count { get; set; }

    /// <summary>
    /// Gets or sets the grid of values.
    /// </summary>
    public int? Grid { get; set; }

    /// <summary>
    /// Gets or sets the value data as a string.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Reads the status values from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Count = elm.ReadAttributeInt("count");
        Grid = elm.ReadAttributeInt("grid");
        Value = elm?.Value;
    }
}
