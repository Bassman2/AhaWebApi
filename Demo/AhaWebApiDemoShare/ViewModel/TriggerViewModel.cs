namespace AVMHomeAutomationDemo.ViewModel;

public class TriggerViewModel : ObservableObject
{
    private readonly Trigger trigger;

    public TriggerViewModel(Trigger trigger, XmlDocument triggerXml)
    {
        this.trigger = trigger;
     
        StringWriter strWriter = new();
        XmlTextWriter xmlWriter = new(strWriter) { Formatting = Formatting.Indented };
        triggerXml.SelectSingleNode($"/triggerlist/trigger[@identifier='{trigger.Identifier}']")?.WriteTo(xmlWriter);
        this.Text = strWriter.ToString();
    }

    public string Text { get; }

    public string? Identifier => this.trigger.Identifier;

    public bool IsActive => this.trigger.Active == 1;

    public string? Name => this.trigger.Name;    
}
