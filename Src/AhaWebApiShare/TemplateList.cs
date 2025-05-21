namespace AhaWebApi;

/// <summary>
/// Represents a list of templates, including version information and associated devices or groups.
/// </summary>
public class TemplateList : IXSerializable
{
    /// <summary>
    /// Gets or sets the version of the template list.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Gets or sets the collection of templates, which may represent devices or groups.
    /// </summary>
    public List<Template>? Templates { get; set; }

    /// <summary>
    /// Reads the template list data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Version = elm.ReadAttributeString("version");
        Templates = elm.ReadElementList<Template>("template");
    }
}
