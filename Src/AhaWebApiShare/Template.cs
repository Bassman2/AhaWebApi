namespace AVMHomeAutomation;

/// <summary>
/// Data for template.
/// </summary>
public class Template : IXSerializable
{
    /// <summary>
    /// Identifier of the template.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// ID of the template.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Functional bitmask of the template.
    /// </summary>
    public Functions FunctionBitMask { get; set; }

    /// <summary>
    /// Subnodes depending on which configuration is set.
    /// </summary>
    public int? ApplyBitMask { get; set; }
        
    /// <summary>
    /// Was template generated automatically?
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public int? AutocCeate { get; set; }        

    /// <summary>
    /// Name of the template
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Json metadata
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public string? MetaData { get; set; }

    /// <summary>
    /// List of devices 
    /// </summary>
    public List<ItemIdentifier>? Devices { get; set; }

    /// <summary>
    /// Subnodes depending on which configuration is set.
    /// </summary>
    public ApplyMask? ApplyMask { get; set; }

    /// <summary>
    /// List of subtemplates 
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public List<ItemIdentifier>? SubTemplates { get; set; }

    /// <summary>
    /// List of sub triggers 
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public List<TemplateTrigger>? Triggers { get; set; }

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
