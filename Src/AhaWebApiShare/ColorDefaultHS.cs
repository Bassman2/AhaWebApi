namespace AVMHomeAutomation;

/// <summary>
/// Hue and saturation color default values
/// </summary>
public class ColorDefaultHS : IXSerializable
{
    /// <summary>
    /// Hue index.
    /// </summary>
    public int? HueIndex { get; set; }

    /// <summary>
    /// ColorName of the color
    /// </summary>
    public ColorName? Name {  get; set;}

    /// <summary>
    /// Colors
    /// </summary>
    public List<Color>? Colors { get; set; }

    public void ReadX(XElement elm)
    {
        HueIndex = elm.ReadAttributeInt("hue_index");
        Name = elm.ReadElementItem<ColorName>("name");
        Colors = elm.ReadElementList<Color>("color");
    }
}
