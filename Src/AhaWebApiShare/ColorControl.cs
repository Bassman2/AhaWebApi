namespace AhaWebApi;

/// <summary>
/// Represents a lamp with adjustable color and color temperature.
/// </summary>
public class ColorControl : IXSerializable
{
    /// <summary>
    /// Gets or sets the supported color modes for the lamp.
    /// </summary>
    public string? SupportedModes { get; set; }

    /// <summary>
    /// Gets or sets the current color mode of the lamp.
    /// </summary>
    public string? CurrentMode { get; set; }

    /// <summary>
    /// Gets or sets the hue value of the color (0° to 359°).
    /// </summary>
    public int? Hue { get; set; }

    /// <summary>
    /// Gets or sets the saturation value of the color (0 to 255).
    /// </summary>
    public int? Saturation { get; set; }

    /// <summary>
    /// Gets or sets the unmapped hue value.
    /// </summary>
    public int? UnmappedHue { get; set; }

    /// <summary>
    /// Gets or sets the unmapped saturation value.
    /// </summary>
    public int? UnmappedSaturation { get; set; }

    /// <summary>
    /// Gets or sets the color temperature in degrees Kelvin (2700° to 6500° Kelvin).
    /// </summary>
    public int? Temperature { get; set; }

    /// <summary>
    /// Reads the color control data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
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
