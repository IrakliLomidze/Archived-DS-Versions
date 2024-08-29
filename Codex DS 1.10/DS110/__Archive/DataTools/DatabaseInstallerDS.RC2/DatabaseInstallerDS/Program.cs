using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;
using System.IO;
using System.Globalization;

namespace ILG.Codex.CodexR4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //private static Mutex s_Mutex1;

        [STAThread]
        static void Main(string[] args)
        {
            if (Properties.Settings.Default.CheckDisplayResolution == true)
            {
                int ww = Screen.PrimaryScreen.Bounds.Width;
                int hh = Screen.PrimaryScreen.Bounds.Height;

                if ((ww < 989) || (hh < 720))
                {
                    if ((args.Length == 1) && (args[0].ToString().ToUpper() == "-HIDPI")) { }
                    else
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("კოდექს DS ის გასაშვებად ეკრანზე წერტილების \nრაოდენობა უნდა იყოს მინიმუმ" +
                       "1024x768 ან 1280x720 ზე \n " + "თქვენ ეკრანზე  არის " + ww.ToString() + "x" + hh.ToString());
                        return;
                    }
                }
            }



            Application.ThreadException += new ThreadExceptionEventHandler(Application_UnhandledExecptionCatcher);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledExecptionCatcher);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Application.CurrentCulture.LCID != 0x0409) Application.CurrentCulture = new CultureInfo(0x0409);



            WindowsIdentity us2 = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal2 = new WindowsPrincipal(us2);
            bool isAdministrator2 = principal2.IsInRole(WindowsBuiltInRole.Administrator);
            if (isAdministrator2 == false)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("კოდექსი DS მონაცემთა ბაზის ინსტალატორის გასაშვებად თქვენ უნდა გქონდეთ ადმინისტრატორის უფლებები");
                return;
            }


            

            Configuration.load();



            Form1.sp = new SplashScreen();
            Form1.sp.Show();
            Form1.sp.Refresh();


            
            ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew = ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrash;
            
            //s_Mutex1 = new Mutex(true, "Codex2014DataBaseInstaller");

            
     

            Application.Run(new Form1());
        }

        private static void Application_UnhandledExecptionCatcher(object sender, ThreadExceptionEventArgs s)
        {

            try
            {

                ErrorReport r = new ErrorReport();
                r._HelpLink = s.Exception.HelpLink;
                r._Message = s.Exception.Message;
                r._Source = s.Exception.Source;
                r._StackTrace = s.Exception.StackTrace;
                r._String = s.ToString();
                if (Application.OpenForms.Count > 0)
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                        Application.OpenForms[i].Hide();
                }

                r.ShowDialog();
                r.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch
            {
                MessageBox.Show("Fattal Error");
            }

            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew == 0)
                Application.Exit();
            else Application.Restart();


        }
        private static void CurrentDomain_UnhandledExecptionCatcher(object sender, UnhandledExceptionEventArgs e)
        {

            try
            {
                Exception s = (Exception)e.ExceptionObject;
                ErrorReport r = new ErrorReport();
                r._HelpLink = s.HelpLink;
                r._Message = s.Message;
                r._Source = s.Source;
                r._StackTrace = s.StackTrace;
                r._String = s.ToString();
                if (Application.OpenForms.Count > 0)
                {
                    for (int i = 0; i < Application.OpenForms.Count; i++)
                        Application.OpenForms[i].Hide();
                }

                r.ShowDialog();
                r.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch
            {
                MessageBox.Show("Fattal Error");
            }

            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew == 0)
                Application.Exit();
            else Application.Restart();


        }

    }
}