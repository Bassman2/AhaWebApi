namespace AVMHomeAutomation;

/// <summary>
/// Device/socket/lamp/actuator that can be switched on/off.
/// </summary>
public class SimpleOnOff : IXSerializable
{
    /// <summary>
    /// Current switching status.
    /// </summary>
    public bool? State { get; set; }

    public void ReadX(XElement elm)
    {
        State = elm.ReadElementBool("state");
    }
}
