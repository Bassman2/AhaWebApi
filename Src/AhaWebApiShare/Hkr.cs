namespace AVMHomeAutomation;

/// <summary>
/// Radiator regulator
/// </summary>
public class Hkr : IXSerializable
{
    /// <summary>
    /// Actual temperature in ° C. (8 to 28 ° C or ON / OFF)
    /// </summary>
    public double? TIst { get; set; }

    /// <summary>
    /// Target temperature in ° C. (8 to 28 ° C or ON / OFF)
    /// </summary>
    public double? TSoll { get; set; }

    /// <summary>
    /// Lowering temperature in ° C. (8 to 28 ° C or ON / OFF)
    /// </summary>
    public double? Absenk { get; set; }

    /// <summary>
    /// Comfort temperature in ° C. (8 to 28 ° C or ON / OFF)
    /// </summary>
    public double? Komfort { get; set; }

    /// <summary>
    /// Keylock via UI / API on no / yes 
    /// </summary>
    public bool? Lock { get; set; }

    /// <summary>
    /// Key lock directly on the device on no / yes 
    /// </summary>
    public bool? DeviceLock { get; set; }

    /// <summary>
    /// Error codes supplied by the HKR (eg if there was a problem during the installation of the HKR):
    /// 0: no error
    /// 1: No adaptation possible. Device correctly mounted on the radiator?
    /// 2: Valve lift too short or battery power too low. Open the valve lifter by hand several times and close orinsert new batteries.
    /// 3: No valve movement possible. Valve tappets free?
    /// 4: The installation is being prepared.
    /// 5: The radiator controller is in installation mode and can be mounted on the heater valve.
    /// 6: The radiator controller now adapts to the stroke of the heating valve.
    /// </summary>
    public int? ErrorCode { get; set; }

    /// <summary>
    /// Window oven detected
    /// </summary>
    public bool? WindowOpenActiv { get; set; }

    /// <summary>
    /// Window open end time
    /// </summary>
    public DateTime? WindowOpenActivEndTime { get; set; }

    /// <summary>
    ///  Boost active
    /// </summary>
    public bool? BoostActive { get; set; }

    /// <summary>
    /// Boost active end time.
    /// </summary>
    public DateTime? BoostActiveEndTime { get; set; }

    /// <summary>
    /// Battery low - please change the battery
    /// </summary>
    public bool? BatteryLow { get; set; }

    /// <summary>
    /// Battery state of charge in percent. (0 - 100)
    /// </summary>
    public int? Battery{ get; set; }

    /// <summary>
    /// Next temperature change
    /// </summary>
    public NextChange? NextChange { get; set; }

    /// <summary>
    /// Is the HKR currently in a vacation period?
    /// </summary>
    public bool? SummerActive { get; set; }

    /// <summary>
    /// Is the HKR currently in a Holiday period?
    /// </summary>
    public bool? HolidayActive { get; set; }

    public void ReadX(XElement elm)
    {
        TIst = elm.ReadElementInt("tist");
        TSoll = elm.ReadElementInt("tsoll");
        Absenk = elm.ReadElementInt("absenk");
        Komfort = elm.ReadElementInt("komfort");
        Lock = elm.ReadElementBool("lock");
        DeviceLock = elm.ReadElementBool("devicelock");
        ErrorCode = elm.ReadElementInt("errorcode");
        WindowOpenActiv = elm.ReadElementBool("windowopenactiv");
        WindowOpenActivEndTime = elm.ReadElementDateTime("windowopenactiveendtime");
        BoostActive = elm.ReadElementBool("boostactive");
        BoostActiveEndTime = elm.ReadElementDateTime("boostactiveendtime");
        BatteryLow = elm.ReadElementBool("batterylow");
        Battery = elm.ReadElementInt("battery");
        NextChange = elm.ReadElementItem<NextChange>("nextchange");
        SummerActive = elm.ReadElementBool("summeractive");
        HolidayActive = elm.ReadElementBool("holidayactive");
    }
}
