namespace AVMHomeAutomationDemo.ViewModel;

public class AlertViewModel : ObservableObject
{
    private Alert alert;

    public AlertViewModel(Alert alert)
    {
        this.alert = alert;
    }

    public AlertState? State => this.alert.State;

    public DateTime? LastAlertChangeTimestamp => this.alert.LastAlertChangeTimestamp;
}
