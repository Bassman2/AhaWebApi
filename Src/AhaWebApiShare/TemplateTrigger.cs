namespace AhaWebApi;

/// <summary>
/// Data for template trigger.
/// </summary>
public class TemplateTrigger : IXSerializable
{
    /// <summary>
    /// Gets or sets the identifier of the trigger.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// Reads the <see cref="Identifier"/> property from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
    }
}
