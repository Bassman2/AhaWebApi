namespace AhaWebApi;

/// <summary>
/// Represents alarm sensor data, including the current state and the timestamp of the last status change.
/// </summary>
public class Alert : IXSerializable
{
    /// <summary>
    /// Gets or sets the last reported alarm condition.
    /// </summary>
    public AlertState? State { get; set; }

    /// <summary>
    /// Gets or sets the time of the last alarm status change.
    /// </summary>
    public DateTime? LastAlertChangeTimestamp { get; set; }

    /// <summary>
    /// Reads the alarm sensor data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        State = elm.ReadElementEnum<AlertState>("state");
        LastAlertChangeTimestamp = elm.ReadElementDateTime("lastalertchgtimestamp");
    }
}
