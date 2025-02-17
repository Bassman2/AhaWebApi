namespace AVMHomeAutomation;

/// <summary>
/// Device status
/// </summary>
public class DeviceStats : IXSerializable
{
    /// <summary>
    /// Temeratures
    /// </summary>
    public List<Stats>? Temperature { get; set; }

    /// <summary>
    /// Voltages
    /// </summary>
    public List<Stats>? Voltage { get; set; }

    /// <summary>
    /// Power
    /// </summary>
    public List<Stats>? Power { get; set; }

    /// <summary>
    /// Energy
    /// </summary>
    public List<Stats>? Energy { get; set; }

    /// <summary>
    /// Humidity
    /// </summary>
    public List<Stats>? Humidity { get; set; }

    public void ReadX(XElement elm)
    {
        Temperature = elm.ReadElementList<Stats>("temperature", "stats");
        Voltage = elm.ReadElementList<Stats>("voltage", "stats");
        Power = elm.ReadElementList<Stats>("power", "stats");
        Energy = elm.ReadElementList<Stats>("energy", "stats");
        Humidity = elm.ReadElementList<Stats>("humidity", "stats");
    }
}
