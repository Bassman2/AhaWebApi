namespace AVMHomeAutomation;

/// <summary>
/// Data for switch socket.
/// </summary>
public class Switch : IXSerializable
{
    /// <summary>
    /// Switching state off / on 
    /// </summary>
    public bool? State { get; set; }

    /// <summary>
    /// Automatic time switching (false) or manual switching (true)
    /// </summary>
    public bool? Mode { get; set; }

    /// <summary>
    /// Switch lock via UI / API on no / yes 
    /// </summary>
    public bool? Lock { get; set; }

    /// <summary>
    /// Switching lock directly on the device on no / yes 
    /// </summary>
    public bool? DeviceLock { get; set; }

    public void ReadX(XElement elm)
    {
        State = elm.ReadElementBool("state");
        Mode = elm.ReadElementBool("mode");
        Lock = elm.ReadElementBool("lock");
        DeviceLock = elm.ReadElementBool("devicelock");
    }
}
