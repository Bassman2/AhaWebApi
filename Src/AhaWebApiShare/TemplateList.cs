namespace AVMHomeAutomation;

/// <summary>
/// Template list
/// </summary>
public class TemplateList : IXSerializable
{
    /// <summary>
    /// Version of template list
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Devices and groups
    /// </summary>
    public List<Template>? Templates { get; set; }

    public void ReadX(XElement elm)
    {
        Version = elm.ReadAttributeString("version");
        Templates = elm.ReadElementList<Template>("template");
    }
}
