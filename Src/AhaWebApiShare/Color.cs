namespace AVMHomeAutomation;

/// <summary>
/// Color data.
/// </summary>
public class Color : IXSerializable
{
    /// <summary>
    /// Suturation index.
    /// </summary>
    public int? SatIndex { get; set; }

    /// <summary>
    /// Hue value of the color. (0 is 359)
    /// </summary>

    public int? Hue { get; set; }

    /// <summary>
    /// Saturation value of the color. (0 - 255)
    /// </summary>
    public int? Sat { get; set; }

    /// <summary>
    /// Value (0-255)
    /// </summary>
    public int? Val { get; set; } 

    public void ReadX(XElement elm)
    {
        SatIndex = elm.ReadElementInt("sat_index");
        Hue = elm.ReadElementInt("hue");
        Sat = elm.ReadElementInt("sat");
        Val = elm.ReadElementInt("val");
    }
}
