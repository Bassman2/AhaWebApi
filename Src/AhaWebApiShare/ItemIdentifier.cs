namespace AhaWebApi;

/// <summary>
/// Represents a template device identifier for XML serialization.
/// </summary>
public class ItemIdentifier : IXSerializable
{
    /// <summary>
    /// Gets or sets the unique identifier for the item.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// Reads the <see cref="Identifier"/> property from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element containing the identifier attribute.</param>
    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
    }
}
