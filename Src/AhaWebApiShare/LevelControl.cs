namespace AhaWebApi;

/// <summary>
/// Represents a device with adjustable dimming, height, brightness, or level.
/// </summary>
public class LevelControl : IXSerializable
{
    /// <summary>
    /// Gets or sets the level value (0 - 255).
    /// </summary>
    public int? Level { get; set; }

    /// <summary>
    /// Gets or sets the percentage level (0% to 100%).
    /// </summary>
    public int? LevelPercentage { get; set; }

    /// <summary>
    /// Reads the level control data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Level = elm.ReadElementInt("level");
        LevelPercentage = elm.ReadElementInt("levelpercentage");
    }
}
