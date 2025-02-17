namespace AVMHomeAutomation;

/// <summary>
/// Lamp with adjustable colour/colour temperature.
/// </summary>
public class ColorControl : IXSerializable
{
    /// <summary>
    /// Supported color modes
    /// </summary>
    public string? SupportedModes { get; set; }

    /// <summary>
    /// Current color mode
    /// </summary>
    public string? CurrentMode { get; set; }

    /// <summary>
    /// Hue value of the color. (0° bis 359°)
    /// </summary>
    public int? Hue { get; set; }

    /// <summary>
    /// Saturation value of the color. (0 bis 255)
    /// </summary>
    public int? Saturation { get; set; }

    /// <summary>
    /// Unmapped hue value.
    /// </summary>
    public int? UnmappedHue { get; set; }

    /// <summary>
    ///  Unmapped Saturation value
    /// </summary>
    public int? UnmappedSaturation { get; set; }

    /// <summary>
    /// Color temperature in ° Kelvin. (2700° bis 6500° Kelvin)
    /// </summary>
    public int? Temperature { get; set; }

    public void ReadX(XElement elm)
    {
        SupportedModes = elm.ReadAttributeString("supported_modes");
        CurrentMode = elm.ReadAttributeString("current_mode");
        Hue = elm.ReadElementInt("hue");
        Saturation = elm.ReadElementInt("saturation");
        UnmappedHue = elm.ReadElementInt("unmapped_hue");
        UnmappedSaturation = elm.ReadElementInt("unmapped_saturation");
        Temperature = elm.ReadElementInt("temperature");
    }
}
