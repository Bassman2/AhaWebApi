namespace AVMHomeAutomation;

/// <summary>
/// HAN-FUN interfaces
/// </summary>
public enum EtsiInterfaces
{
    /// <summary>
    /// Keep alive
    /// </summary>
    [EnumMember(Value = "KEEP_ALIVE")] 
    KeepAlive = 277,

    /// <summary>
    /// Alert
    /// </summary>
    [EnumMember(Value = "ALERT")] 
    Alert = 256,

    /// <summary>
    /// On off
    /// </summary>
    [EnumMember(Value = "ON_OFF")] 
    OnOff = 512,

    /// <summary>
    /// Level control
    /// </summary>
    [EnumMember(Value = "LEVEL_CTRL")] 
    LevelCtrl = 513,

    /// <summary>
    /// Color control
    /// </summary>
    [EnumMember(Value = "COLOR_CTRL")] 
    ColorCtrl = 514,

    /// <summary>
    /// Open close
    /// </summary>
    [EnumMember(Value = "OPEN_CLOSE")] 
    OpenClose = 516,

    /// <summary>
    /// Open close configuration
    /// </summary>
    [EnumMember(Value = "OPEN_CLOSE_CONFIG")] 
    OpenCloseConfig = 517,

    /// <summary>
    /// Simple button
    /// </summary>
    [EnumMember(Value = "SIMPLE_BUTTON")] 
    SimpleButton = 772,

    /// <summary>
    /// SUOTA Update
    /// </summary>
    [EnumMember(Value = "SUOTA_Update")] 
    SUOTAUpdate = 1024,
}
