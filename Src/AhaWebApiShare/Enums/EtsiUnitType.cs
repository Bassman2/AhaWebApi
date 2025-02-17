namespace AVMHomeAutomation;

/// <summary>
/// HAN-FUN unit typ
/// </summary>
public enum EtsiUnitType
{
    /// <summary>
    /// Simple button
    /// </summary>
    [EnumMember(Value = "SIMPLE_BUTTON")]
    SimpleButton = 273,

    /// <summary>
    /// Simple on off switchable
    /// </summary>
    [EnumMember(Value = "SIMPLE_ON_OFF_SWITCHABLE")]
    SimpleOnOffSwitchable = 256,

    /// <summary>
    /// Simple on off switch
    /// </summary>
    [EnumMember(Value = "SIMPLE_ON_OFF_SWITCH")] 
    SimpleOnOffSwitch = 257,

    /// <summary>
    /// AC outlet
    /// </summary>
    [EnumMember(Value = "AC_OUTLET")] 
    ACOutlet = 262,

    /// <summary>
    /// AC outlet simple power metering
    /// </summary>
    [EnumMember(Value = "AC_OUTLET_SIMPLE_POWER_METERING")] 
    ACOutletSimplePowerMetering = 263,

    /// <summary>
    /// Simple light
    /// </summary>
    [EnumMember(Value = "SIMPLE_LIGHT")] 
    SimpleLight = 264,

    /// <summary>
    /// Dimmable light
    /// </summary>
    [EnumMember(Value = "DIMMABLE_LIGHT")] 
    DimmableLight = 265,

    /// <summary>
    /// Dimmer switch
    /// </summary>
    [EnumMember(Value = "DIMMER_SWITCH")] 
    DimmerSwitch = 266,

    /// <summary>
    /// Color bulb
    /// </summary>
    [EnumMember(Value = "COLOR_BULB")] 
    ColorBulb = 277,

    /// <summary>
    /// Dimmable color bulb
    /// </summary>
    [EnumMember(Value = "DIMMABLE_COLOR_BULB")]
    DimmableColorBulb = 278,

    /// <summary>
    /// Blind
    /// </summary>
    [EnumMember(Value = "BLIND")] 
    Blind = 281,

    /// <summary>
    /// Lamellar
    /// </summary>
    [EnumMember(Value = "LAMELLAR")] 
    Lamellar = 282,

    /// <summary>
    /// Simple detector
    /// </summary>
    [EnumMember(Value = "SIMPLE_DETECTOR")] 
    SimpleDetector = 512,

    /// <summary>
    /// Door open close detector
    /// </summary>
    [EnumMember(Value = "DOOR_OPEN_CLOSE_DETECTOR")] 
    DoorOpenCloseDetector = 513,

    /// <summary>
    /// Window open close detector
    /// </summary>
    [EnumMember(Value = "WINDOW_OPEN_CLOSE_DETECTOR")] 
    WindowOpenCloseDetector = 514,

    /// <summary>
    /// Motion detector
    /// </summary>
    [EnumMember(Value = "MOTION_DETECTOR")] 
    MotionDetector = 515,

    /// <summary>
    /// Flood detector
    /// </summary>
    [EnumMember(Value = "FLOOD_DETECTOR")] 
    FloodDetector = 518,

    /// <summary>
    /// Flas break detector
    /// </summary>
    [EnumMember(Value = "GLAS_BREAK_DETECTOR")] 
    GlasBreakDetector = 519,

    /// <summary>
    /// Vibration detector
    /// </summary>
    [EnumMember(Value = "VIBRATION_DETECTOR")] 
    VibrationDetector = 520,

    /// <summary>
    /// Siren
    /// </summary>
    [EnumMember(Value = "SIREN")] 
    Siren = 640,
}
