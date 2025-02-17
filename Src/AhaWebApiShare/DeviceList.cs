namespace AVMHomeAutomation;

/// <summary>
/// List of all devices.
/// </summary>
public class DeviceList : IXSerializable
{
    /// <summary>
    /// Version of the device list.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Firmware version
    /// </summary>
    public string? FirmwareVersion { get; set; }

    /// <summary>
    /// Devices and groups
    /// </summary>
    public List<Device> RowDevices { get; } = [];

    public List<Device>? ItemsList { get; private set; }

    public List<Device>? ItemsTree { get; private set; }

    public List<Device>? DevicesList { get; private set; }

    public List<Device>? DevicesTree { get; private set; }

    public List<Group>? GroupsList { get; private set; }

    public List<Group>? GroupsTree { get; private set; }

    public void ReadX(XElement elm)
    {
        Version = elm.ReadAttributeString("version");
        FirmwareVersion = elm.ReadAttributeString("fwversion");
        foreach (var item in elm?.Elements() ?? [])
        {
            if (item.Name == "device")
            {
                var device = new Device();
                device.ReadX(item);
                RowDevices.Add(device); 
            }
            else if (item.Name == "group")
            {
                var group = new Group();
                group.ReadX(item);
                RowDevices.Add(group);
            }
        }
        Fill();
    }

    private void Fill()
    {
        this.ItemsList = [];
        this.ItemsTree = [];
        this.DevicesList = [];
        this.DevicesTree = [];
        this.GroupsList = [];
        this.GroupsTree = [];

        Device? master = null;
        foreach (Device device in RowDevices!)
        {
            if (master != null && device.Identifier!.StartsWith(master.Identifier!))
            {
                master.DeviceType = device.DeviceType;
                (master.Children ??= []).Add(device);

                this.ItemsList.Add(device);
                if (device.GetType() == typeof(Group))
                {
                    this.GroupsList.Add((Group)device);
                }
                else
                {
                    this.DevicesList.Add(device);
                }
            }
            else
            {
                this.ItemsList.Add(device);
                this.ItemsTree.Add(device);
                if (device.GetType() == typeof(Group))
                {
                    this.GroupsList.Add((Group)device);
                    this.GroupsTree.Add((Group)device);
                }
                else
                {
                    this.DevicesList.Add(device);
                    this.DevicesTree.Add(device);
                }
                master = device;
            }
        }
    }
}
