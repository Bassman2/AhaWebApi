namespace AVMHomeAutomation;

/// <summary>
/// Data for template trigger.
/// </summary>
public class TemplateTrigger: IXSerializable
{
    /// <summary>
    /// Identifier of the trigger.
    /// </summary>
    public string? Identifier { get; set; }

    public void ReadX(XElement elm)
    {
        Identifier = elm.ReadAttributeString("identifier");
    }
}
