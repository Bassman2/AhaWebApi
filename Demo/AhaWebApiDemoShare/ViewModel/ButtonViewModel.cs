namespace AVMHomeAutomationDemo.ViewModel;

public class ButtonViewModel : ObservableObject
{
    private Button button;

    public ButtonViewModel(Button button)
    {
        this.button = button;
    }

    public string? Identifier => this.button.Identifier;

    public string? Id => this.button.Id;

    public string? Name => this.button.Name;

    public DateTime? LastPressedTimestamp => this.button.LastPressedTimestamp;
}
