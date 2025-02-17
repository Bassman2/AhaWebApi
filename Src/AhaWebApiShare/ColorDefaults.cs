namespace AVMHomeAutomation;

/// <summary>
/// Color defaults.
/// </summary>
public class ColorDefaults : IXSerializable
{
    /// <summary>
    /// Hue and saturation values
    /// </summary>
    public List<ColorDefaultHS>? HSDefaults { get; set; }

    /// <summary>
    /// Temperature values
    /// </summary>
    public List<ColorDefaultTemperature>? TemperatureDefaults { get; set; }

    public void ReadX(XElement elm)
    {
        HSDefaults = elm.ReadElementList<ColorDefaultHS>("hsdefaults", "hs");
        TemperatureDefaults = elm.ReadElementList<ColorDefaultTemperature>("temperaturedefaults", "temp");
    }
}
