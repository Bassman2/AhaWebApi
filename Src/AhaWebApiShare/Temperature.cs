namespace AVMHomeAutomation;

/// <summary>
/// Temperature sensor data.
/// </summary>
public class Temperature : IXSerializable
{
    /// <summary>
    /// Temperatur value in ° Celsius
    /// </summary>
    public double? Celsius { get; set; }

    /// <summary>
    /// Temperatur offset value in ° Celsius
    /// </summary>
    public double? Offset { get; set; }

    public void ReadX(XElement elm)
    {
        Celsius = elm.ReadElementInt("celsius");
        Offset = elm.ReadElementInt("offset");
    }
}
