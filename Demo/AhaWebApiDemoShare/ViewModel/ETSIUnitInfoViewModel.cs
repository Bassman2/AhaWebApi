namespace AVMHomeAutomationDemo.ViewModel;

public class ETSIUnitInfoViewModel : ObservableObject
{
    private EtsiUnitInfo etsiUnitInfo;

    public ETSIUnitInfoViewModel(EtsiUnitInfo etsiUnitInfo)
    {
        this.etsiUnitInfo = etsiUnitInfo;
    }

    public string? EtsiDeviceId => this.etsiUnitInfo.EtsiDeviceId;
    public EtsiUnitType? UnitType => null; //this.etsiUnitInfo.UnitType;
    public List<EtsiInterfaces>? Interfaces => this.etsiUnitInfo.Interfaces; 
}
