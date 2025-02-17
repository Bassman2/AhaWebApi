namespace AVMHomeAutomation;

/// <summary>
/// Button data.
/// </summary>
public class Button : IXSerializable
{
    /// <summary>
    /// Unique ID.
    [XmlAttribute("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Internal device ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// ColorName
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Time of the last key press.
    /// </summary>
    public DateTime? LastPressedTimestamp { get; set; }

    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
        Id = elm.ReadAttributeString("id");
        Name = elm.ReadElementString("name");
        LastPressedTimestamp = elm.ReadElementDateTime("lastpressedtimestamp");
    }
}
