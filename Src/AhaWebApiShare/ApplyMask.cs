namespace AhaWebApi;

/// <summary>
/// Represents subnodes that are available depending on which configuration is set.
/// </summary>
public class ApplyMask : IXSerializable
{
    /// <summary>
    /// Gets or sets a value indicating whether HKR heating switch-off (in summer) is available.
    /// </summary>
    public bool? HkrSummer { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether HKR target temperature is available.
    /// </summary>
    public bool? HkrTemperature { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether HKR holiday bookings are available.
    /// </summary>
    public bool? HkrHolidays { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether HKR time switch is available.
    /// </summary>
    public bool? HkrTimeTable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a switchable socket, lamp, or actuator can be manually switched ON/OFF.
    /// </summary>
    public bool? RelayManual { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a switchable socket, lamp, or roller shutter time switch is available.
    /// </summary>
    public bool? RelayAutomatic { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether level or brightness control for lamp or roller shutter is available.
    /// </summary>
    public bool? Level { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether color or color temperature control is available.
    /// </summary>
    public bool? Color { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether announcement is available.
    /// </summary>
    public bool? Dialhelper { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether light sunrise and sunset simulation is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? SunSimulation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether grouped templates or scenarios are available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? SubTemplates { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether main WIFI on/off is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? MainWifi { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether guest WIFI on/off is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? GuestWifi { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether answering machine control is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? TamControl { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether sending any HTTP request is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? HttpRequest { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether HKR Boost, window open, or temperature override is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? TimerControl { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether switching devices to the state of other devices is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? SwitchMaster { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether TemplateTrigger pushmail or app notification is available.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? CustomNotification { get; set; }

    /// <summary>
    /// Reads the configuration mask data from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        HkrSummer = elm.ReadElementBool("hkr_summer");
        HkrTemperature = elm.ReadElementBool("hkr_temperature");
        HkrHolidays = elm.ReadElementBool("hkr_holidays");
        HkrTimeTable = elm.ReadElementBool("hkr_time_table");
        RelayManual = elm.ReadElementBool("relay_manual");
        RelayAutomatic = elm.ReadElementBool("relay_automatic");
        Level = elm.ReadElementBool("level");
        Color = elm.ReadElementBool("color");
        Dialhelper = elm.ReadElementBool("dialhelper");
        SunSimulation = elm.ReadElementBool("sun_simulation");
        SubTemplates = elm.ReadElementBool("sub_templates");
        MainWifi = elm.ReadElementBool("main_wifi");
        GuestWifi = elm.ReadElementBool("guest_wifi");
        TamControl = elm.ReadElementBool("tam_control");
        HttpRequest = elm.ReadElementBool("http_request");
        TimerControl = elm.ReadElementBool("timer_control");
        SwitchMaster = elm.ReadElementBool("switch_master");
        CustomNotification = elm.ReadElementBool("custom_notification");
    }
}
