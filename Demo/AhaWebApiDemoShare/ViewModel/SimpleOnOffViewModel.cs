namespace AVMHomeAutomationDemo.ViewModel;

public class SimpleOnOffViewModel : ObservableObject
{
    private SimpleOnOff simpleOnOff;

    public SimpleOnOffViewModel(SimpleOnOff simpleOnOff)
    {
        this.simpleOnOff = simpleOnOff;
    }

    public bool? State => this.simpleOnOff.State;
}
