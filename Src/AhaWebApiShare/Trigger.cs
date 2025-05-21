namespace AhaWebApi;

/// <summary>
/// Represents data for a trigger, including its identifier, active status, and name.
/// </summary>
public class Trigger : IXSerializable
{
    /// <summary>
    /// Gets or sets the identifier of the trigger.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the trigger is active (typically 1 for active, 0 for inactive).
    /// </summary>
    public int? Active { get; set; }

    /// <summary>
    /// Gets or sets the name of the trigger.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Reads the trigger data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
        Active = elm.ReadAttributeInt("active");            
        Name = elm.ReadElementString("name");
    }
}
