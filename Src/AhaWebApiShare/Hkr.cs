namespace AhaWebApi;

/// <summary>
/// Represents a radiator regulator (HKR) device, providing properties for temperature control, device state, error codes, and scheduling.
/// </summary>
public class Hkr : IXSerializable
{
    /// <summary>
    /// Gets or sets the actual temperature in °C. (8 to 28 °C or ON / OFF)
    /// </summary>
    public double? TIst { get; set; }

    /// <summary>
    /// Gets or sets the target temperature in °C. (8 to 28 °C or ON / OFF)
    /// </summary>
    public double? TSoll { get; set; }

    /// <summary>
    /// Gets or sets the lowering temperature in °C. (8 to 28 °C or ON / OFF)
    /// </summary>
    public double? Absenk { get; set; }

    /// <summary>
    /// Gets or sets the comfort temperature in °C. (8 to 28 °C or ON / OFF)
    /// </summary>
    public double? Komfort { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the keylock is enabled via UI or API.
    /// </summary>
    public bool? Lock { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the keylock is enabled directly on the device.
    /// </summary>
    public bool? DeviceLock { get; set; }

    /// <summary>
    /// Gets or sets the error code supplied by the HKR.
    /// <para>0: No error</para>
    /// <para>1: No adaptation possible. Device correctly mounted on the radiator?</para>
    /// <para>2: Valve lift too short or battery power too low. Open the valve lifter by hand several times and close or insert new batteries.</para>
    /// <para>3: No valve movement possible. Valve tappets free?</para>
    /// <para>4: The installation is being prepared.</para>
    /// <para>5: The radiator controller is in installation mode and can be mounted on the heater valve.</para>
    /// <para>6: The radiator controller now adapts to the stroke of the heating valve.</para>
    /// </summary>
    public int? ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a window open event is detected.
    /// </summary>
    public bool? WindowOpenActiv { get; set; }

    /// <summary>
    /// Gets or sets the end time for the window open event.
    /// </summary>
    public DateTime? WindowOpenActivEndTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether boost mode is active.
    /// </summary>
    public bool? BoostActive { get; set; }

    /// <summary>
    /// Gets or sets the end time for the boost mode.
    /// </summary>
    public DateTime? BoostActiveEndTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the battery is low.
    /// </summary>
    public bool? BatteryLow { get; set; }

    /// <summary>
    /// Gets or sets the battery state of charge in percent (0 - 100).
    /// </summary>
    public int? Battery{ get; set; }

    /// <summary>
    /// Gets or sets the next scheduled temperature change.
    /// </summary>
    public NextChange? NextChange { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the HKR is currently in a summer (vacation) period.
    /// </summary>
    public bool? SummerActive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the HKR is currently in a holiday period.
    /// </summary>
    public bool? HolidayActive { get; set; }

    /// <summary>
    /// Reads the HKR properties from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
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
