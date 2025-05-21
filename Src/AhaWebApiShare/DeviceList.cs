namespace AhaWebApi;

/// <summary>
/// Represents a list of all devices and groups, including version information and hierarchical structure.
/// </summary>
public class DeviceList : IXSerializable
{
    /// <summary>
    /// Gets or sets the version of the device list.
    /// </summary>
    public string? Version { get; set; }

    /// <summary>
    /// Gets or sets the firmware version.
    /// </summary>
    public string? FirmwareVersion { get; set; }

    /// <summary>
    /// Gets the flat list of all devices and groups as they appear in the source XML.
    /// </summary>
    public List<Device> RowDevices { get; } = [];

    /// <summary>
    /// Gets the flat list of all devices and groups.
    /// </summary>
    public List<Device>? ItemsList { get; private set; }

    /// <summary>
    /// Gets the hierarchical tree of all devices and groups.
    /// </summary>
    public List<Device>? ItemsTree { get; private set; }

    /// <summary>
    /// Gets the flat list of all devices (excluding groups).
    /// </summary>
    public List<Device>? DevicesList { get; private set; }

    /// <summary>
    /// Gets the hierarchical tree of all devices (excluding groups).
    /// </summary>
    public List<Device>? DevicesTree { get; private set; }

    /// <summary>
    /// Gets the flat list of all groups.
    /// </summary>
    public List<Group>? GroupsList { get; private set; }

    /// <summary>
    /// Gets the hierarchical tree of all groups.
    /// </summary>
    public List<Group>? GroupsTree { get; private set; }

    /// <summary>
    /// Reads the device list and its properties from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
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

    /// <summary>
    /// Populates the various device and group lists and trees based on the flat <see cref="RowDevices"/> collection.
    /// </summary>
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
