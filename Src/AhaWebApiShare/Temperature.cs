namespace AhaWebApi;

/// <summary>
/// Temperature sensor data.
/// </summary>
public class Temperature : IXSerializable
{
    /// <summary>
    /// Gets or sets the temperature value in degrees Celsius.
    /// </summary>
    public double? Celsius { get; set; }

    /// <summary>
    /// Gets or sets the temperature offset value in degrees Celsius.
    /// </summary>
    public double? Offset { get; set; }

    /// <summary>
    /// Reads the temperature and offset values from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Celsius = elm.ReadElementInt("celsius");
        Offset = elm.ReadElementInt("offset");
    }
}
