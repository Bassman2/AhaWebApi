namespace AhaWebApi;

/// <summary>
/// Represents color data using hue, saturation, and value (HSV) components.
/// </summary>
public class Color : IXSerializable
{
    /// <summary>
    /// Gets or sets the saturation index of the color.
    /// </summary>
    public int? SatIndex { get; set; }

    /// <summary>
    /// Gets or sets the hue value of the color. (0 to 359)
    /// </summary>
    public int? Hue { get; set; }

    /// <summary>
    /// Gets or sets the saturation value of the color. (0 to 255)
    /// </summary>
    public int? Sat { get; set; }

    /// <summary>
    /// Gets or sets the value (brightness) of the color. (0 to 255)
    /// </summary>
    public int? Val { get; set; } 

    /// <summary>
    /// Reads the color data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        SatIndex = elm.ReadElementInt("sat_index");
        Hue = elm.ReadElementInt("hue");
        Sat = elm.ReadElementInt("sat");
        Val = elm.ReadElementInt("val");
    }
}
