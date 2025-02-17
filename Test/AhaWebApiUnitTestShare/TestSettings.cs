namespace AVMHomeAutomationTest;

public static class TestSettings
{
    public const string Login = "Demo";
    public const string Password = "Demo-1234";
    public static TestDevice DeviceDect100Repeater = new()          { Ain = "11657 0196837",   Name = "DECT Repeater",    Product = "FRITZ!DECT Repeater 100",    Manufacturer = "AVM", FirmwareVersion = "04.25" };
    public static TestDevice DeviceDect200Socket = new()            { Ain = "08761 0500005",   Name = "Bodhran",          Product = "FRITZ!DECT 200",             Manufacturer = "AVM", FirmwareVersion = "04.25" };
    public static TestDevice DeviceDect210Socket = new()            { Ain = "11657 0143095",   Name = "Weihnachtsbaum",   Product = "FRITZ!DECT 210",             Manufacturer = "AVM", FirmwareVersion = "04.25" };
    public static TestDevice DeviceDect301Radiator = new()          { Ain = "09995 0125605",   Name = "Arbeitszimmer",    Product = "FRITZ!DECT 301",             Manufacturer = "AVM", FirmwareVersion = "05.08" };
    public static TestDevice DeviceDect400Switch = new()            { Ain = "13096 0015206",   Name = "Taster",           Product = "FRITZ!DECT 400",             Manufacturer = "AVM", FirmwareVersion = "04.92" };
    public static TestDevice DeviceDect440Switch = new()            { Ain = "09995 0964673",   Name = "Control",          Product = "FRITZ!DECT 440",             Manufacturer = "AVM", FirmwareVersion = "05.25" };
    public static TestDevice DeviceDect500Light = new()             { Ain = "13077 0294352-1", Name = "Light",            Product = "FRITZ!DECT 500",             Manufacturer = "AVM", FirmwareVersion = "0.0" };
    public static TestDevice DeviceHanFunDoorWindowContact = new()  { Ain = "11934 0100883",   Name = "DoorContact",      Product = "HAN-FUN",                    Manufacturer = "0x0feb", FirmwareVersion = "31.20" };
    public static TestDevice DeviceHanFunMotionDetector = new()     { Ain = "11324 0770838",   Name = "MotionDetector",   Product = "HAN-FUN",                    Manufacturer = "0x2c3c", FirmwareVersion = "30.17.01.01.017" };
    public static TestDevice DeviceHanFunWallButton = new()         { Ain = "11934 0037013",   Name = "WallButton",       Product = "HAN-FUN",                    Manufacturer = "0x0feb", FirmwareVersion = "31.20" };
    public static TestDevice DeviceHanFunRollerShutter = new()      { Ain = "14276 0596303-1",   Name = "Rollotron",        Product = "Rollotron 1213",             Manufacturer = "0x37c4", FirmwareVersion = "0.0" };
    public const string UnknownDeviceAin = "111111111111";
    public const string TemplateAin = "tmp280D89-3E4719303";
    public const string TriggerAin = "trg0000000000000000";
}
