namespace AVMHomeAutomationDemo.ViewModel;

public class PowerMeterViewModel : ObservableObject
{
    private PowerMeter powerMeter;

    public PowerMeterViewModel(PowerMeter powerMeter)
    {
        this.powerMeter = powerMeter;
    }

    public double? Voltage => this.powerMeter.Voltage;
    public double? Power => this.powerMeter.Power;
    public double? Energy => this.powerMeter.Energy;

}
