namespace AVMHomeAutomation;

/// <summary>
/// Group information data
/// </summary>
public class GroupInfo : IXSerializable
{
    /// <summary>
    /// Internal id of the master/boss switch, 0 for "none set".
    /// </summary>
    public string? MasterDeviceId { get; set; }

    /// <summary>
    /// Internal ids of group members
    /// </summary>
    public List<string>? Members { get; set; }

    public void ReadX(XElement elm)
    {
        MasterDeviceId = elm.ReadElementString("masterdeviceid");
        Members = elm.ReadElementStrings("members");
    }
}
