namespace AVMHomeAutomation;

/// <summary>
/// Device with adjustable dimming, height, brightness or level
/// </summary>
public class LevelControl : IXSerializable
{
    /// <summary>
    /// Level (0 - 255)
    /// </summary>
    public int? Level { get; set; }

    /// <summary>
    /// Percentage level (0% to 100%)
    /// </summary>
    public int? LevelPercentage { get; set; }

    public void ReadX(XElement elm)
    {
        Level = elm.ReadElementInt("level");
        LevelPercentage = elm.ReadElementInt("levelpercentage");
    }
}
