using System.Windows;
using Com.CurtisRutland.WpfHotkeys;
using Hardcodet.Wpf.TaskbarNotification;

namespace SoftAgility.GetGuid
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon _taskbarIcon;
        private Window _notificationWindow;

        private Hotkey _hotkey;
        private AppTaskbarIconViewModel _mainVm;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _notificationWindow = new Window
            {
                Height = 0,
                Width = 0,
                WindowStyle = WindowStyle.None,
                ShowInTaskbar = false,
                Visibility = Visibility.Hidden
            };
            _notificationWindow.Show();
            _notificationWindow.Hide();

            _taskbarIcon = (TaskbarIcon) FindResource("AppTaskbarIcon");
            _mainVm = new AppTaskbarIconViewModel(_taskbarIcon);
            _taskbarIcon.DataContext = _mainVm;

            _hotkey = new Hotkey(Modifiers.Ctrl | Modifiers.Shift, Keys.A, _notificationWindow, true);
            _hotkey.HotkeyPressed += hotkey_HotkeyPressed;
        }

        private void hotkey_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            _mainVm.ComputeGuid();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon.Dispose();
            base.OnExit(e);
        }
    }
}