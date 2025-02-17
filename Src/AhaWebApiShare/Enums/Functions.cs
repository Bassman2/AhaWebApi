namespace AVMHomeAutomation;

/// <summary>
/// Device functions
/// </summary>
[Flags]
public enum Functions
{
    /// <summary>
    /// HANFUN Device
    /// </summary>
    HANFUNDevice = 0x0001,          // Bit 0

    /// <summary>
    /// Light Device
    /// </summary>
    Light = 0x0004,                 // Bit 2

    /// <summary>
    /// Alarm
    /// </summary>
    Alarm = 0x0010,                 // Bit 4 

    /// <summary>
    /// AVM Button
    /// </summary>
    AVMButton = 0x0020,             // Bit 5 

    /// <summary>
    /// Heater
    /// </summary>
    AVMHeater = 0x0040,             // Bit 6

    /// <summary>
    /// Energy
    /// </summary>
    AVMEnergy = 0x0080,             // Bit 7

    /// <summary>
    /// Temperature
    /// </summary>
    Temperature = 0x0100,           // Bit 8

    /// <summary>
    /// Switch outlet
    /// </summary>
    AVMSwitchOutlet = 0x0200,       // Bit 9

    /// <summary>
    /// AVM DECT Repeater
    /// </summary>
    AVMDECTRepeater = 0x0400,       // Bit 10

    /// <summary>
    /// Microphone
    /// </summary>
    AVMMicrophone = 0x0800,        // Bit 11

    // <summary>
    // Group
    // </summary>
    //Group = 0x1000,                 // Bit 12

    /// <summary>
    /// HANFUN Unit
    /// </summary>
    HANFUNUnit = 0x2000,            // Bit 13

    /// <summary>
    /// Switch
    /// </summary>
    Switch = 0x8000,                // Bit 15    

    /// <summary>
    /// Level
    /// </summary>
    Level = 0x10000,                // Bit 16

    /// <summary>
    /// Light color
    /// </summary>
    LightColor = 0x20000,           // Bit 17

    /// <summary>
    /// Blind
    /// </summary>
    Blind = 0x40000,                // Bit 18

    /// <summary>
    /// Humidity sensor
    /// </summary>
    Humidity = 0x100000,            // Bit 20
}
