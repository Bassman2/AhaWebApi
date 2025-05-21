namespace AhaWebApi;

/// <summary>
/// Represents default color values using hue and saturation.
/// </summary>
public class ColorDefaultHS : IXSerializable
{
    /// <summary>
    /// Gets or sets the hue index for the default color.
    /// </summary>
    public int? HueIndex { get; set; }

    /// <summary>
    /// Gets or sets the name of the color.
    /// </summary>
    public ColorName? Name { get; set; }

    /// <summary>
    /// Gets or sets the list of color values associated with this default.
    /// </summary>
    public List<Color>? Colors { get; set; }

    /// <summary>
    /// Reads the default color data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        HueIndex = elm.ReadAttributeInt("hue_index");
        Name = elm.ReadElementItem<ColorName>("name");
        Colors = elm.ReadElementList<Color>("color");
    }
}
