using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Shell;

namespace AVMHomeAutomationDemo.View
{
    public class AppView : Window
    {
        public AppView()
        {
            ResizeMode = ResizeMode.CanResizeWithGrip;
            SetBinding(TitleProperty, new Binding("Title"));

            TaskbarItemInfo taskbarItemInfo = new TaskbarItemInfo();
            BindingOperations.SetBinding(taskbarItemInfo, TaskbarItemInfo.DescriptionProperty, new Binding("Title"));
            BindingOperations.SetBinding(taskbarItemInfo, TaskbarItemInfo.ProgressStateProperty, new Binding("ProgressState"));
            BindingOperations.SetBinding(taskbarItemInfo, TaskbarItemInfo.ProgressValueProperty, new Binding("ProgressValue"));
            TaskbarItemInfo = taskbarItemInfo;

            this.SetKeyBinding(Key.F5, "RefreshCommand");
            this.SetEventBinding("Loaded", "StartupCommand");
            this.SetEventBinding("Closing", "ClosingCommand", true);
        }

        protected void SetKeyBinding(Key key, string commandName)
        {
            KeyBinding keyBinding = new KeyBinding() { Key = key };
            BindingOperations.SetBinding(keyBinding, KeyBinding.CommandProperty, new Binding(commandName));
            this.InputBindings.Add(keyBinding);
        }

        protected void SetEventBinding(string eventName, string commandName, bool passEventArgsToCommand = false)
        {
            Microsoft.Xaml.Behaviors.EventTrigger trigger = new (eventName);
            InvokeCommandAction action = new InvokeCommandAction() { PassEventArgsToCommand = passEventArgsToCommand };
            BindingOperations.SetBinding(action, InvokeCommandAction.CommandProperty, new Binding(commandName));
            trigger.Actions.Add(action);
            Interaction.GetTriggers(this).Add(trigger);
        }
    }
}
