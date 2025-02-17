namespace AVMHomeAutomation;

/// <summary>
/// Color temperature default values
/// </summary>
public class ColorDefaultTemperature : IXSerializable
{
    /// <summary>
    /// Color temperatur value in ° Kelvin. (2700° bis 6500°)
    /// </summary>
    public int? Value { get; set; }

    public void ReadX(XElement elm)
    {
        Value = elm.ReadAttributeInt("value");
    }
}
