namespace AhaWebApi;

/// <summary>
/// Represents the default color settings, including hue/saturation and temperature values.
/// </summary>
public class ColorDefaults : IXSerializable
{
    /// <summary>
    /// Gets or sets the list of default hue and saturation values.
    /// </summary>
    /// <remarks>
    /// Each entry contains hue index, color name, and a list of color values.
    /// </remarks>
    public List<ColorDefaultHS>? HSDefaults { get; set; }

    /// <summary>
    /// Gets or sets the list of default color temperature values.
    /// </summary>
    /// <remarks>
    /// Each entry contains a color temperature value in degrees Kelvin.
    /// </remarks>
    public List<ColorDefaultTemperature>? TemperatureDefaults { get; set; }

    /// <summary>
    /// Reads the color defaults from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        HSDefaults = elm.ReadElementList<ColorDefaultHS>("hsdefaults", "hs");
        TemperatureDefaults = elm.ReadElementList<ColorDefaultTemperature>("temperaturedefaults", "temp");
    }
}
