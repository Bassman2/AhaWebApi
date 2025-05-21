namespace AhaWebApi;

/// <summary>
/// Data for switch socket.
/// </summary>
public class Switch : IXSerializable
{
    /// <summary>
    /// Gets or sets the switching state (off/on).
    /// </summary>
    public bool? State { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the switch is in manual mode (true) or automatic time switching mode (false).
    /// </summary>
    public bool? Mode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the switch is locked via UI or API (no/yes).
    /// </summary>
    public bool? Lock { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the switching lock is enabled directly on the device (no/yes).
    /// </summary>
    public bool? DeviceLock { get; set; }

    /// <summary>
    /// Reads the switch data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        State = elm.ReadElementBool("state");
        Mode = elm.ReadElementBool("mode");
        Lock = elm.ReadElementBool("lock");
        DeviceLock = elm.ReadElementBool("devicelock");
    }
}
