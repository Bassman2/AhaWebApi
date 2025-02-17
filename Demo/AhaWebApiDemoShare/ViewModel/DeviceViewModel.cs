namespace AVMHomeAutomationDemo.ViewModel;

public partial class DeviceViewModel : ItemViewModel
{
    private readonly Device device;        

    public DeviceViewModel(Device device, XmlDocument devicesXml)
    {
        this.device = device;
        this.IsPresent = device.IsPresent;
        this.Name = device.Name;

        
        //this.Children = this.device.Children?.Select(c => new DeviceViewModel(c, devicesXml)).ToList<ItemViewModel>();

        StringWriter strWriter = new();
        XmlTextWriter xmlWriter = new(strWriter) { Formatting = Formatting.Indented }; 
        devicesXml.SelectSingleNode($"/devicelist/*[@id='{device.Id}']")?.WriteTo(xmlWriter);
        this.Xml = strWriter.ToString();
    }

    public static DeviceViewModel Create(Device device, XmlDocument devicesXml)
    {
        return device.GetType() == typeof(Group) ? new GroupViewModel(device, devicesXml) : new DeviceViewModel(device, devicesXml);
     }

    //public List<DeviceViewModel> Children { get; }

    //[ObservableProperty]
    //public string text;

    //public DeviceType DeviceType => this.device.DeviceType;

    #region Device Attributes

    public string? Identifier => this.device.Identifier;            

    public string? Id => this.device.Id;
       
    public string? FirmwareVersion => this.device.FirmwareVersion;

    public string? Manufacturer => this.device.Manufacturer;

    public string? ProductName => this.device.ProductName;

    public Functions Functions => this.device.FunctionBitMask;

    #endregion

    #region Single Elements

    //public bool IsPresent => this.device.IsPresent.Value;

    public bool? IsTXBusy => this.device.IsTXBusy;

    //public string Name => this.device.Name;

    public bool? IsBatteryLow => this.device.IsBatteryLow;

    public int? Battery => this.device.Battery;

    #endregion

    #region Visible switches

    public bool ShowSwitch => this.device.Switch != null;
    public bool ShowPowerMeter => this.device.PowerMeter != null;
    public bool ShowTemperature => this.device.Temperature != null;
    public bool ShowAlert => this.device.Alert != null;
    public bool ShowButtons => this.device.Buttons != null && this.device.Buttons.Count > 0;
    public bool ShowETSIUnitInfo => this.device.EtsiUnitInfo != null;
    public bool ShowSimpleOnOff => this.device.SimpleOnOff != null;
    public bool ShowLevelControl => this.device.LevelControl != null;
    public bool ShowColorControl => this.device.ColorControl != null;
    public bool ShowHkr => this.device.Hkr != null;

    #endregion

    #region Class Elements

    public SwitchViewModel? Switch => this.device.Switch != null ? new SwitchViewModel(this.device.Switch) : null;
    public PowerMeterViewModel? PowerMeter => this.device.PowerMeter != null ? new PowerMeterViewModel(this.device.PowerMeter) : null;
    public TemperatureViewModel? Temperature => this.device.Temperature != null ? new TemperatureViewModel(this.device.Temperature) : null;
    public AlertViewModel? Alert => this.device.Alert != null ? new AlertViewModel(this.device.Alert) : null;
    public List<ButtonViewModel>? Buttons => this.device.Buttons != null ? this.device.Buttons.Select(b => new ButtonViewModel(b)).ToList() : null;
    public ETSIUnitInfoViewModel? EtsiUnitInfo => this.device.EtsiUnitInfo != null ? new ETSIUnitInfoViewModel(this.device.EtsiUnitInfo) : null;
    public SimpleOnOffViewModel? SimpleOnOff => this.device.SimpleOnOff != null ? new SimpleOnOffViewModel(this.device.SimpleOnOff) : null;
    public LevelControlViewModel? LevelControl => this.device.LevelControl != null ? new LevelControlViewModel(this.device.LevelControl) : null;
    public ColorControlViewModel? ColorControl => this.device.ColorControl != null ? new ColorControlViewModel(this.device.ColorControl) : null;
    public HkrViewModel? Hkr => this.device.Hkr != null ? new HkrViewModel(this.device.Hkr) : null;

    #endregion

    #region Object

    public override bool Equals(object? obj)
    {
        return (obj is DeviceViewModel device) ? this.Identifier == device?.Identifier : false;
    }

    public override int GetHashCode()
    {
        return this.Identifier!.GetHashCode();
    }

    #endregion
}
