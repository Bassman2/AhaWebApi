namespace AVMHomeAutomation;

/// <summary>
/// HAN-FUN / ETSI unit data
/// </summary>
public class EtsiUnitInfo : IXSerializable
{
    /// <summary>
    /// Internal device ID of the associated HAN-FUN device.
    /// </summary>
    public string? EtsiDeviceId { get; set; }

    /// <summary>
    /// HAN-FUN unit typ
    /// </summary>
    public List<EtsiUnitType>? UnitType { get; set; }

    /// <summary>
    /// HAN-FUN interfaces
    /// </summary>
    public List<EtsiInterfaces>? Interfaces { get; set; }

    public void ReadX(XElement elm)
    {
        EtsiDeviceId = elm.ReadElementString("etsideviceid");
        UnitType = elm.ReadElementEnums<EtsiUnitType>("unittype");
        Interfaces = elm.ReadElementEnums<EtsiInterfaces>("interfaces"); 
    }
}
