namespace AVMHomeAutomationDemo.ViewModel;

public class TemperatureViewModel : ObservableObject
{
    private Temperature temperature;

    public TemperatureViewModel(Temperature temperature)
    {
        this.temperature = temperature;
    }

    public double? Celsius => this.temperature.Celsius;
    public double? Offset => this.temperature.Offset;
    

}
