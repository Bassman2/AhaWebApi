namespace AVMHomeAutomation;

/// <summary>
/// Next temperature change
/// </summary>
public class NextChange : IXSerializable
{
    /// <summary>
    /// End of the time period.
    /// </summary>
    public DateTime? EndPeriod { get; set; }

    /// <summary>
    /// Target temperatur in °C or Off.
    /// </summary>           
    public double? TChange { get; set; }

    public void ReadX(XElement elm)
    {
        EndPeriod = elm.ReadElementDateTime("endperiod");
        TChange = elm.ReadElementInt("tchange");
    }
}
