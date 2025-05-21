namespace AhaWebApi;

/// <summary>
/// Represents a list of all triggers, including version information and associated trigger data.
/// </summary>
public class TriggerList : IXSerializable
{
    /// <summary>
    /// Gets or sets the version of the template list.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Gets or sets the collection of devices and groups as triggers.
    /// </summary>
    public List<Trigger>? Triggers { get; set; }

    /// <summary>
    /// Reads the trigger list data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Version = elm.ReadAttributeString("version");
        Triggers = elm.ReadElementList<Trigger>("trigger");    
    }
}
