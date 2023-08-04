using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;
using ILG.Codex.CodexR4.CodexSettings;
using ILG.Codex.CodexR4.JsonConfigurations;

namespace ILG.Codex.CodexR4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        private static Mutex s_Mutex1;

        [STAThread]
        static void Main(string[] args)
        {

            if (Properties.Settings.Default.DisplayCheck == true)
            {
                int ww = Screen.PrimaryScreen.Bounds.Width;
                int hh = Screen.PrimaryScreen.Bounds.Height;
                if ((ww < 800) || (hh < 600))
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("კოდექს DS დოკუმენტების არქივის გასაშვებად ეკრანზე წერტილების \nრაოდენობა უნდა იყოს მინიმუმ" +
                        "800x600 ზე.\n" + "თქვენ ეკრანზე  არის " + ww.ToString() + "x" + hh.ToString());
                    return;
                }
            }

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DirectoryConfiguration.LoadConfigurations();

            //CodexDSOrganizationSettings.Instance.LoadConfiguration();


            Form1.sp = new SplashScreen();
            Form1.sp.Show();
            Form1.sp.Refresh();

            StatusAttributeConfiguration.LoadConfiguraiton();

            ConfigurationUI.load();

            ConfigurationSQL.load();
            ConfigurationSQL f1 = new ConfigurationSQL();

            if (f1.isconnecting() == false) return;


            ConfigurationUI.load(); // Load Current Configuration and create new
            ConfigurationSQL.load();

            //GMLiceseManger.DSLicenseManagerClient.Instance.Initialize();
            //if (GMLiceseManger.DSLicenseManagerClient.Instance.VerifyLicense() == false)
            //{
            //    MessageBox.Show("Licence Error");
            //}

            License.LicenseAccess();
            
            s_Mutex1 = new Mutex(true, "CodexDS18");

            bool EX = false;
            if (s_Mutex1.WaitOne(0, false) == false) EX = true;


            Application.Run(new Form1(EX));
        
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