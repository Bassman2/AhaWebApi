namespace AVMHomeAutomation;

/// <summary>
/// Alarm sensor data.
/// </summary>
public class Alert : IXSerializable
{
    /// <summary>
    /// Last reported alarm condition.
    /// </summary>
    public AlertState? State { get; set; }

    /// <summary>
    /// Time of last alarm status change.
    /// </summary>
    public DateTime? LastAlertChangeTimestamp { get; set;}

    public void ReadX(XElement elm)
    {
        State = elm.ReadElementEnum<AlertState>("state");
        LastAlertChangeTimestamp = elm.ReadElementDateTime("lastalertchgtimestamp");
    }
}
