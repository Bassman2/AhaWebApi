namespace AhaWebApi;

/// <summary>
/// Represents the default color temperature value for a device, typically in degrees Kelvin.
/// </summary>
public class ColorDefaultTemperature : IXSerializable
{
    /// <summary>
    /// Gets or sets the color temperature value in degrees Kelvin. (2700° to 6500°)
    /// </summary>
    public int? Value { get; set; }

    /// <summary>
    /// Reads the color temperature value from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Value = elm.ReadAttributeInt("value");
    }
}
