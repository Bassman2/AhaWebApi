namespace AhaWebApi;

/// <summary>
/// Data for template.
/// </summary>
public class Template : IXSerializable
{
    /// <summary>
    /// Gets or sets the identifier of the template.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// Gets or sets the ID of the template.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the functional bitmask of the template.
    /// </summary>
    public Functions FunctionBitMask { get; set; }

    /// <summary>
    /// Gets or sets the subnodes depending on which configuration is set.
    /// </summary>
    public int? ApplyBitMask { get; set; }
        
    /// <summary>
    /// Gets or sets a value indicating whether the template was generated automatically.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public int? AutocCeate { get; set; }        

    /// <summary>
    /// Gets or sets the name of the template.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the JSON metadata.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public string? MetaData { get; set; }

    /// <summary>
    /// Gets or sets the list of devices.
    /// </summary>
    public List<ItemIdentifier>? Devices { get; set; }

    /// <summary>
    /// Gets or sets the subnodes depending on which configuration is set.
    /// </summary>
    public ApplyMask? ApplyMask { get; set; }

    /// <summary>
    /// Gets or sets the list of subtemplates.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public List<ItemIdentifier>? SubTemplates { get; set; }

    /// <summary>
    /// Gets or sets the list of sub triggers.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public List<TemplateTrigger>? Triggers { get; set; }

    /// <summary>
    /// Reads the template data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
        Id = elm.ReadAttributeString("id");
        FunctionBitMask = elm.ReadAttributeEnum<Functions>("functionbitmask");
        ApplyBitMask = elm.ReadAttributeInt("applymask");
        AutocCeate = elm.ReadAttributeInt("autocreate");
        Name = elm.ReadElementString("name");
        MetaData = elm.ReadElementString("metadata");
        Devices = elm.ReadElementList<ItemIdentifier>("devices", "device");
        ApplyMask = elm.ReadElementItem<ApplyMask>("applymask");
        SubTemplates = elm.ReadElementList<ItemIdentifier>("sub_templates", "template");
        Triggers = elm.ReadElementList<TemplateTrigger>("triggers", "trigger");
    }
}
