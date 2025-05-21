namespace AhaWebApi;

/// <summary>
/// Device, socket, lamp, or actuator that can be switched on or off.
/// </summary>
public class SimpleOnOff : IXSerializable
{
    /// <summary>
    /// Gets or sets the current switching status.
    /// </summary>
    public bool? State { get; set; }

    /// <summary>
    /// Reads the switching status from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        State = elm.ReadElementBool("state");
    }
}
