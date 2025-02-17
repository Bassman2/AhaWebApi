namespace AVMHomeAutomation;

/// <summary>
/// List of all triggers.
/// </summary>
public class TriggerList : IXSerializable
{
    /// <summary>
    /// Version of template list
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Devices and groups
    /// </summary>
    public List<Trigger>? Triggers { get; set; }

    public void ReadX(XElement elm)
    {
        Version = elm.ReadAttributeString("version");
        Triggers = elm.ReadElementList<Trigger>("trigger");    
    }
}
