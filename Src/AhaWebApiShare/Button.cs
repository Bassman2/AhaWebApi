namespace AhaWebApi;

/// <summary>
/// Represents button data, including identification and last press information.
/// </summary>
public class Button : IXSerializable
{
    /// <summary>
    /// Gets or sets the unique identifier for the button.
    /// </summary>
    [XmlAttribute("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Gets or sets the internal device ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the button.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the last key press.
    /// </summary>
    public DateTime? LastPressedTimestamp { get; set; }

    /// <summary>
    /// Reads the button data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
        Id = elm.ReadAttributeString("id");
        Name = elm.ReadElementString("name");
        LastPressedTimestamp = elm.ReadElementDateTime("lastpressedtimestamp");
    }
}
