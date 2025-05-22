namespace AhaWebApi;

/// <summary>
/// Represents HAN-FUN / ETSI unit data, including device identification, unit types, and supported interfaces.
/// </summary>
public class EtsiUnitInfo : IXSerializable
{
    /// <summary>
    /// Gets or sets the internal device ID of the associated HAN-FUN device.
    /// </summary>
    public string? EtsiDeviceId { get; set; }

    /// <summary>
    /// Gets or sets the list of HAN-FUN unit types for this device.
    /// </summary>
    public List<EtsiUnitType>? UnitType { get; set; }

    /// <summary>
    /// Gets or sets the list of HAN-FUN interfaces supported by this device.
    /// </summary>
    public List<EtsiInterfaces>? Interfaces { get; set; }

    /// <summary>
    /// Reads the ETSI unit information from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        EtsiDeviceId = elm.ReadElementString("etsideviceid");
        UnitType = elm.ReadElementEnums<EtsiUnitType>("unittype");
        Interfaces = elm.ReadElementEnums<EtsiInterfaces>("interfaces"); 
    }
}
