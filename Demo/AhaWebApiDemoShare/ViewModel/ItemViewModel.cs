namespace AVMHomeAutomationDemo.ViewModel;

public partial class ItemViewModel : ObservableObject
{
    public bool? IsPresent { get; protected set; }

    public DeviceType Type { get; protected set; }

    public string? Name { get; protected set; }

    public string? Xml { get; protected set; }

    public List<ItemViewModel>? Children { get; protected set; }


}
