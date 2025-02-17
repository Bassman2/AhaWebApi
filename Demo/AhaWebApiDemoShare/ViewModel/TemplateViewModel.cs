namespace AVMHomeAutomationDemo.ViewModel;

public class TemplateViewModel : ObservableObject
{
    private readonly Template template;

    //public TemplateViewModel(Template template, XmlDocument templatesXml)
    //{
    //    this.template = template;
    //    //this.Devices = template.Devices.Select(i => devices.Single(d => d.Identifier == i.Identifier)).ToList();

    //    StringWriter strWriter = new();
    //    XmlTextWriter xmlWriter = new(strWriter) { Formatting = Formatting.Indented };
    //    templatesXml.SelectSingleNode($"/templatelist/template[@id='{template.Id}']")?.WriteTo(xmlWriter);
    //    this.Text = strWriter.ToString();
    //}

    public TemplateViewModel(Template template, List<DeviceViewModel> devices, List<TemplateViewModel> templates, List<TriggerViewModel> triggers, XmlDocument templatesXml)
    {
        this.template = template;
        //this.Devices = template.Devices?.Select(i => 
        //devices.SingleOrDefault(d => d.Identifier == i.Identifier
        //)).ToList();
        //this.SubTemplates = template.SubTemplates.Select(i => templates.Single(d => d.Identifier == i.Identifier)).ToList();
        //this.Triggers = template.Triggers.Select(i => triggers.Single(d => d.Identifier == i.Identifier)).ToList();

        StringWriter strWriter = new();
        XmlTextWriter xmlWriter = new(strWriter) { Formatting = Formatting.Indented };
        templatesXml.SelectSingleNode($"/templatelist/template[@id='{template.Id}']")?.WriteTo(xmlWriter);
        this.Text = strWriter.ToString();
    }

    public string? Text { get; }

    public string? Identifier => this.template.Identifier;

    public string? Id => this.template.Id;

    public Functions? Functions => this.template.FunctionBitMask;


    public string? Name => this.template.Name;

    
    public List<DeviceViewModel>? Devices { get; }

    public List<TemplateViewModel>? SubTemplates { get; }

    public List<TriggerViewModel>? Triggers { get; }
}
