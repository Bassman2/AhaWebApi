namespace AVMHomeAutomationDemo.ViewModel;

public class ColorControlViewModel : ObservableObject
{
    private ColorControl colorControl;

    public ColorControlViewModel(ColorControl colorControl)
    {
        this.colorControl = colorControl;
    }

    public int? Hue => this.colorControl.Hue;
    public int? Saturation => this.colorControl.Saturation;
    public int? UnmappedHue => this.colorControl.UnmappedHue;
    public int? UnmappedSaturation => this.colorControl.UnmappedSaturation;
    public int? Temperature => this.colorControl.Temperature;
}
