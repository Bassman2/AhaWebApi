namespace AVMHomeAutomationDemo.ViewModel;

public class LevelControlViewModel : ObservableObject
{
    private LevelControl levelControl;

    public LevelControlViewModel(LevelControl levelControl)
    {
        this.levelControl = levelControl;
    }

    public int? Level => this.levelControl.Level;
    
    public int? LevelPercentage => this.levelControl.LevelPercentage;
}
