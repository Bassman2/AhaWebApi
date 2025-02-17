namespace AVMHomeAutomation;

/// <summary>
/// Group of devices
/// </summary>
[DebuggerDisplay("Group: {ColorName} -  {Manufacturer} - {ProductName}")]     
public class Group : Device
{
    /// <summary>
    /// Is synchronized?
    /// </summary>
    public bool? Synchronized { get; set; }

    /// <summary>
    /// Group information
    /// </summary>
    public GroupInfo? GroupInfo { get; set; }

    public override void ReadX(XElement elm)
    {
        base.ReadX(elm);
        Synchronized = elm.ReadAttributeBool("synchronized");
        GroupInfo = elm.ReadElementItem<GroupInfo>("groupinfo");
    }
}
