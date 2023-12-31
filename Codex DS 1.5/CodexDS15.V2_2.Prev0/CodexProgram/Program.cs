﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;

namespace ILG.Codex.Codex2007
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
            int ww = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int hh = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            if ((ww < 800) || (hh < 600))
            {
                ILG.Windows.Forms.ILGMessageBox.Show("კოდექს DS დოკუმენტების არქივის გასაშვებად ეკრანზე წერტილების \nრაოდენობა უნდა იყოს მინიმუმ" +
                    "800x600 ზე.\n" + "თქვენ ეკრანზე  არის " + ww.ToString() + "x" + hh.ToString());
                return;
            }

            //Xceed.Zip.Licenser.LicenseKey = "ZIN42-K7EH0-JRJRW-HYPA";// "ZIN37-G7SU0-8Y2H4-NYNA";
            //Xceed.FileSystem.Licenser.LicenseKey = "ZIN42-K7EH0-JRJRW-HYPA"; //"ZIN37-G7SU0-8Y2H4-NYNA";
            
            Application.ThreadException += new ThreadExceptionEventHandler(Application_UnhandledExecptionCatcher);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledExecptionCatcher);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1.sp = new SplashScreen();
            Form1.sp.Show();
            Form1.sp.Refresh();

            if (args.Length > 0)
            {
                if (args[0] == @"/Default") Configuration.FirstConfiguration();
                if (args[0] == @"/Reconfigure") { Configuration.load(); Configuration f2 = new Configuration(); f2.ShowDialog(); }
            }

            Configuration.load();
            Configuration f1 = new Configuration();
            if (f1.isconnecting() == false) return;

            License.LicenseAccess();
            

            Configuration.load(); // Load Current Configuration and create new

            s_Mutex1 = new Mutex(true, "CodexDSR3DOTNET");

            bool EX = false;
            if (s_Mutex1.WaitOne(0, false) == false) EX = true;


            #region NGEN
            // if Admin Mode
            //WindowsIdentity us = WindowsIdentity.GetCurrent();
            //WindowsPrincipal principal = new WindowsPrincipal(us);
            //bool isAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);
            //if (isAdministrator == true)
            //{
            //    string ss = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\cngen.747";
            //    if (System.IO.File.Exists(ss) == false)
            //    {
            //        // Run NGEN
            //        string NGEN = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\cngen.exe";
            //        string NGENPAR = "-Install";
            //        System.Diagnostics.Process proc = System.Diagnostics.Process.Start(NGEN, NGENPAR);
            //        proc.WaitForExit();
            //        if (proc.ExitCode == 0)
            //        {
            //            System.IO.File.Create(ss);
            //        }

            //    }
            //}
        #endregion
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

            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrashNew == 0)
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

            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.WhenCrashNew == 0)
                Application.Exit();
            else Application.Restart();


        }

    }
}