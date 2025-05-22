namespace AhaWebApi;

/// <summary>
/// Represents group information for a set of devices, including the master device and its members.
/// </summary>
public class GroupInfo : IXSerializable
{
    /// <summary>
    /// Gets or sets the internal ID of the master (boss) switch for the group. A value of "0" indicates that no master device is set.
    /// </summary>
    public string? MasterDeviceId { get; set; }

    /// <summary>
    /// Gets or sets the list of internal IDs for the group member devices.
    /// </summary>
    public List<string>? Members { get; set; }

    /// <summary>
    /// Reads the group information from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        MasterDeviceId = elm.ReadElementString("masterdeviceid");
        Members = elm.ReadElementStrings("members");
    }
}
