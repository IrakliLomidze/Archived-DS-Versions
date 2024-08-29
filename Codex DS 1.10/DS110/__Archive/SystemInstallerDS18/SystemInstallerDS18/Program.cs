﻿using System;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;


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
            Mutex s_Mutex1 = new Mutex(true, "CodexDSPlatformInstaller");
            if (s_Mutex1.WaitOne(0, false) == false) return; 
           
          
            Application.ThreadException += new ThreadExceptionEventHandler(Application_UnhandledExecptionCatcher);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledExecptionCatcher);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            WindowsIdentity us2 = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal2 = new WindowsPrincipal(us2);
            bool isAdministrator2 = principal2.IsInRole(WindowsBuiltInRole.Administrator);
            if (isAdministrator2 == false)
            {
                MessageBox.Show("To Run Codex DS R3 Installer you need Administrator right");
                return;
            }


            Form1.sp = new SplashScreen();
            Form1.sp.Show();
            Form1.sp.Refresh();


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // ZXZ if (global::ILG.Codex.CodexR4.Properties.Settings.Default.WhenCrashNew == 0)
                Application.Exit();
            // ZXZ else Application.Restart();


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Application.Exit();


        }

    }
}