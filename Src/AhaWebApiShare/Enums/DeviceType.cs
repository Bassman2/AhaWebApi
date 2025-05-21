namespace AhaWebApi;

/// <summary>
/// Specifies the types of devices supported by the system.
/// </summary>
public enum DeviceType
{
    /// <summary>
    /// The device type is unknown.
    /// </summary>
    Unknown,

    /// <summary>
    /// A button device.
    /// </summary>
    Button,

    /// <summary>
    /// A control device.
    /// </summary>
    Control,

    /// <summary>
    /// A door contact sensor device.
    /// </summary>
    DoorContact,

    /// <summary>
    /// A heater device.
    /// </summary>
    Heater,

    /// <summary>
    /// A light device.
    /// </summary>
    Light,

    /// <summary>
    /// A motion detector device.
    /// </summary>
    MotionDetector,

    /// <summary>
    /// A repeater device.
    /// </summary>
    Repeater,

    /// <summary>
    /// A Rollotron device (typically a shutter or blind controller).
    /// </summary>
    Rollotron,

    /// <summary>
    /// A socket device.
    /// </summary>
    Socket,

    /// <summary>
    /// A wall button device.
    /// </summary>
    Wallbutton
}
