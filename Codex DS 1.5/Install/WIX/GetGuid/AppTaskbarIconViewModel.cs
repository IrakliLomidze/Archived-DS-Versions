using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WindowsInput;
using WindowsInput.Native;
using Hardcodet.Wpf.TaskbarNotification;

namespace SoftAgility.GetGuid
{
    public class AppTaskbarIconViewModel
    {
        private readonly TaskbarIcon _taskbarIcon;

        public AppTaskbarIconViewModel(TaskbarIcon taskbarIcon)
        {
            _taskbarIcon = taskbarIcon;
        }

        /// <summary>
        /// Shuts down the application.
        /// </summary>
        public ICommand ExitApplicationCommand
        {
            get { return new DelegateCommand {CommandAction = () => Application.Current.Shutdown()}; }
        }

        public ICommand ComputeGuidCommand
        {
            get
            {
                return new DelegateCommand
                {
                    CommandAction = ComputeGuid
                };
            }
        }

        public void ComputeGuid()
        {
            Guid newGuid = Guid.NewGuid();
            string guidText = "{" + newGuid.ToString().ToUpper() + "}";
            Clipboard.SetText(guidText);

            var balloon = new ToastBalloon {BalloonText = guidText};
            _taskbarIcon.ShowCustomBalloon(balloon, PopupAnimation.Slide, 3000);

            var s = new InputSimulator();
            s.Keyboard.KeyPress(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
        }
    }
}