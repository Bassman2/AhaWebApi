namespace AVMHomeAutomationDemo.ViewModel;

public partial class GroupViewModel(Device device, XmlDocument devicesXml) : DeviceViewModel(device, devicesXml)
{
    private readonly Group group = (Group)device;
}
