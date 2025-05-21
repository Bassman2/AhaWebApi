namespace AhaWebApi;

/// <summary>
/// Represents an energy meter device.
/// </summary>
public class PowerMeter : IXSerializable
{
    /// <summary>
    /// Gets or sets the voltage value in volts.
    /// </summary>
    public double? Voltage { get; set; }

    /// <summary>
    /// Gets or sets the power value in watts.
    /// </summary>
    public double? Power { get; set; }
            
    /// <summary>
    /// Gets or sets the energy value in kilowatt-hours (kWh).
    /// </summary>
    public double? Energy { get; set; }

    /// <summary>
    /// Reads the power meter data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Voltage = elm.ReadElementInt("voltage");
        Power = elm.ReadElementInt("power");
        Energy = elm.ReadElementInt("energy");
    }
}
