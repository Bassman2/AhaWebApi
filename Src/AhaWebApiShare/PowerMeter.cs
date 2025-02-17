namespace AVMHomeAutomation;

/// <summary>
/// Energy meter
/// </summary>
public class PowerMeter : IXSerializable
{
    /// <summary>
    /// Voltage value in Volt
    /// </summary>
    public double? Voltage { get; set; }

    /// <summary>
    /// Power value in W
    /// </summary>
    public double? Power { get; set; }
            
    /// <summary>
    /// Energy value in kWh
    /// </summary>
    public double? Energy { get; set; }

    public void ReadX(XElement elm)
    {
        Voltage = elm.ReadElementInt("voltage");
        Power = elm.ReadElementInt("power");
        Energy = elm.ReadElementInt("energy");
    }
}
