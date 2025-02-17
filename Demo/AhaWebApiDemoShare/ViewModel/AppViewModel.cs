using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;
using System.Windows.Threading;

namespace MVVMAppBase.ViewModel;

public partial class AppViewModel : ObservableObject
{
    //private TaskbarItemProgressState progressState = TaskbarItemProgressState.None;
    //private double progressValue = 0.0;
    private string progressTime = string.Empty;

    public AppViewModel()
    {
        //UpgradeSettings();
    }

    protected ApplicationSettingsBase? GetApplicationSettings()
    {
        Type? type = Assembly.GetEntryAssembly()?.GetTypes().FirstOrDefault(t => t.FullName!.EndsWith(".Properties.Settings"));
        if (type == null)
        {
            throw new Exception("No App settings found!");
        }
        return (ApplicationSettingsBase?)type?.GetProperty("Default")?.GetValue(null);
    }

    private static void UpgradeSettings()
    {
        const string upgradeProperty = "NeedsUpgrade";

        // upgrade Application settings
        Type? type = Assembly.GetEntryAssembly()?.GetTypes().FirstOrDefault(t => t.FullName!.EndsWith(".Properties.Settings"));
        if (type != null)
        {
            ApplicationSettingsBase? settings = (ApplicationSettingsBase?)type.GetProperty("Default")?.GetValue(null);
            SettingsProperty? property = settings?.Properties.Cast<SettingsProperty>().FirstOrDefault(p => p.Name == upgradeProperty);
            if (property != null && property.PropertyType == typeof(bool))
            {
                if ((bool)settings![upgradeProperty])
                {
                    settings.Upgrade();
                    settings.Reload();
                    settings[upgradeProperty] = false;
                    settings.Save();
                }
            }
            else
            {
                throw new Exception($"No App setttings property {upgradeProperty} found");
            }
        }
        else
        {
            throw new Exception("No App settings found!");
        }
    }

    //private void OnProgressState(ProgressStateEventArgs args)
    //{
    //    this.ProgressState = args.State;
    //}

    //private void OnProgressValue(ProgressValueEventArgs args)
    //{
    //    this.ProgressValue = args.Value;
    //    this.ProgressTime = args.ElapsedTime.HasValue ? $"{args.ElapsedTime:h':'mm':'ss} / {args.RemainingTime:h':'mm':'ss}" : "";
    //}

    //private void OnProgressText(ProgressTextEventArgs args)
    //{
    //    this.StatusText = args.Text;
    //}

    #region properties

    /// <summary>
    /// The main title of the application. Displayed in the main window header and in the taskbar.
    /// </summary>
    public virtual string Title
    {
        get
        {
            Assembly? app = Assembly.GetEntryAssembly();
            string? title = app?.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
            Version? ver = app?.GetName().Version;
            string? version = ver?.Build > 0 ? ver.ToString(3) : ver?.ToString(2);
            return $"{title} {version}";
        }
    }

    [ObservableProperty]
    private TaskbarItemProgressState progressState = TaskbarItemProgressState.None;

    /// <summary>
    /// Status text in status line.
    /// </summary>
    [ObservableProperty]
    private string statusText = "Ready";

    #endregion

    #region command methods

    [RelayCommand]
    public virtual async Task OnStartup()
    {
        await Task.Run(() => { });

        //if (Application.Current == null)
        //{
        //    // for testing
        //    OnActivate();
        //}
        //else
        //{
        //    Application.Current.Dispatcher.BeginInvoke(new Action(() => OnActivate()), DispatcherPriority.ContextIdle, null);
        //}
    }

    //[RelayCommand]
    protected virtual void OnActivate()
    { }

    protected virtual bool OnCanRefresh() => true;
    
    [RelayCommand(CanExecute = nameof(OnCanRefresh))]
    protected virtual async Task OnRefresh()
    {
        await Task.Run(() => { });
    }

    protected virtual bool OnCanImport() => this.ProgressState == TaskbarItemProgressState.None;

    
    [RelayCommand(CanExecute = nameof(OnCanImport))]
    protected virtual void OnImport()
    { }

    protected virtual bool OnCanExport()
    {
        return this.ProgressState == TaskbarItemProgressState.None;
    }

    [RelayCommand(CanExecute = nameof(OnCanExport))]
    protected virtual void OnExport()
    { }

    protected virtual bool OnCanUndo => false;
    
    [RelayCommand(CanExecute = nameof(OnCanUndo))]
    protected virtual void OnUndo()
    { }


    protected virtual bool OnCanRedo => false;
    
    [RelayCommand(CanExecute = nameof(OnCanRedo))]
    protected virtual void OnRedo()
    { }

    protected virtual bool OnCanOptions => true;

    [RelayCommand(CanExecute = nameof(OnCanOptions))]
    protected virtual void OnOptions()
    { }


    [RelayCommand]
    protected virtual void OnAbout()
    { }

    [RelayCommand]
    protected virtual void OnHelp()
    {
        string path = Path.ChangeExtension(Assembly.GetEntryAssembly()?.Location ?? "", ".chm");
        if (File.Exists(path))
        {
            System.Diagnostics.Process.Start(path);
        }
        else
        {
            MessageBox.Show(string.Format("Help file \"{0}\" not found!", path), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    protected virtual bool OnCanExit => true;
    

    [RelayCommand(CanExecute = nameof(OnCanExit))]
    protected virtual void OnExit()
    {
        Application.Current.MainWindow.Close();
    }
    
    [RelayCommand]
    private void OnClosing(CancelEventArgs e)
    {
        //if (e != null)
        {
            e.Cancel = !OnClosing();
        }
    }
            
    protected virtual bool OnClosing() => true;
    
    #endregion

}
