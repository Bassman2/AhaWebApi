namespace AhaWebApi;

/// <summary>
/// Represents a group of devices, including synchronization state and group-specific information.
/// </summary>
[DebuggerDisplay("Group: {ColorName} -  {Manufacturer} - {ProductName}")]     
public class Group : Device
{
    /// <summary>
    /// Gets or sets a value indicating whether the group is synchronized.
    /// </summary>
    public bool? Synchronized { get; set; }

    /// <summary>
    /// Gets or sets the group information, including master device and member details.
    /// </summary>
    public GroupInfo? GroupInfo { get; set; }

    /// <summary>
    /// Reads the group data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public override void ReadX(XElement elm)
    {
        base.ReadX(elm);
        Synchronized = elm.ReadAttributeBool("synchronized");
        GroupInfo = elm.ReadElementItem<GroupInfo>("groupinfo");
    }
}
