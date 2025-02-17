namespace AVMHomeAutomation;

/// <summary>
/// Template device
/// </summary>
public class ItemIdentifier : IXSerializable
{
    /// <summary>
    /// Identifier
    /// </summary>
    public string? Identifier { get; set; }

    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
    }
}
