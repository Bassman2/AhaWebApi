namespace AhaWebApi;

/// <summary>
/// Represents the status information for a device, including temperature, voltage, power, energy, and humidity statistics.
/// </summary>
public class DeviceStats : IXSerializable
{
    /// <summary>
    /// Gets or sets the list of temperature statistics for the device.
    /// </summary>
    public List<Stats>? Temperature { get; set; }

    /// <summary>
    /// Gets or sets the list of voltage statistics for the device.
    /// </summary>
    public List<Stats>? Voltage { get; set; }

    /// <summary>
    /// Gets or sets the list of power statistics for the device.
    /// </summary>
    public List<Stats>? Power { get; set; }

    /// <summary>
    /// Gets or sets the list of energy statistics for the device.
    /// </summary>
    public List<Stats>? Energy { get; set; }

    /// <summary>
    /// Gets or sets the list of humidity statistics for the device.
    /// </summary>
    public List<Stats>? Humidity { get; set; }

    /// <summary>
    /// Reads the device statistics from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Temperature = elm.ReadElementList<Stats>("temperature", "stats");
        Voltage = elm.ReadElementList<Stats>("voltage", "stats");
        Power = elm.ReadElementList<Stats>("power", "stats");
        Energy = elm.ReadElementList<Stats>("energy", "stats");
        Humidity = elm.ReadElementList<Stats>("humidity", "stats");
    }
}
