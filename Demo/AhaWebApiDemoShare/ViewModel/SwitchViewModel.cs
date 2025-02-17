namespace AVMHomeAutomationDemo.ViewModel;

public class SwitchViewModel : ObservableObject
{
    private Switch sw;

    public SwitchViewModel(Switch sw)
    {
        this.sw = sw;
    }

    public bool? State => this.sw.State;
    public bool? Mode => this.sw.Mode;
    public bool? Lock => this.sw.Lock;
    public bool? DeviceLock => this.sw.DeviceLock;
}
