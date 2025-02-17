namespace AVMHomeAutomationDemo.ViewModel;

public class HkrViewModel : ObservableObject
{
    private Hkr hkr;

    public HkrViewModel(Hkr hkr)
    {
        this.hkr = hkr;
    }

    public double? TIst => this.hkr.TIst;
    public double? TSoll => this.hkr.TSoll;
    public double? Absenk => this.hkr.Absenk;
    public double? Komfort => this.hkr.Komfort;
    public bool? Lock => this.hkr.Lock;
    public bool? DeviceLock => this.hkr.DeviceLock;
    public int? ErrorCode => this.hkr.ErrorCode;
    public bool? WindowOpenActiv => this.hkr.WindowOpenActiv;
    public DateTime? WindowOpenActivEndTime => this.hkr.WindowOpenActivEndTime;
    public bool? BoostActive => this.hkr.BoostActive;
    public DateTime? BoostActiveEndTime => this.hkr.BoostActiveEndTime;
    public bool? BatteryLow => this.hkr.BatteryLow;
    public int? Battery => this.hkr.Battery;

    public DateTime? NextChangeEndPeriod => this.hkr.NextChange?.EndPeriod;
    public double? NextChangeTChange => this.hkr.NextChange?.TChange;

    public bool? SummerActive => this.hkr.SummerActive;
    public bool? HolidayActive => this.hkr.HolidayActive;
}
