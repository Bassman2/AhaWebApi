namespace AhaWebApi;

/// <summary>
/// Represents the next scheduled temperature change, including the end of the current period and the target temperature.
/// </summary>
public class NextChange : IXSerializable
{
    /// <summary>
    /// Gets or sets the end of the current time period for the temperature setting.
    /// </summary>
    public DateTime? EndPeriod { get; set; }

    /// <summary>
    /// Gets or sets the target temperature in degrees Celsius, or <c>null</c> if the device is set to "Off".
    /// </summary>           
    public double? TChange { get; set; }

    /// <summary>
    /// Reads the next change data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        EndPeriod = elm.ReadElementDateTime("endperiod");
        TChange = elm.ReadElementInt("tchange");
    }
}
