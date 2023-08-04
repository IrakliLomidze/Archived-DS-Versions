using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;


namespace ILG.Codex.Codex2011
{
    static class Program
    {
        private static Mutex s_Mutex1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            int ww = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int hh = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            if ((ww < 800) || (hh < 600))
            {
                ILG.Windows.Forms.ILGMessageBox.Show("კოდექს დოკუმენტების არქივის 2 გასაშვებად ეკრანზე წერტილების \nრაოდენობა უნდა იყოს მინიმუმ" +
                    "800x600 ზე.\n" + "თქვენ ეკრანზე  არის " + ww.ToString() + "x" + hh.ToString());
                return;
            }



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

            Configuration.load(); // Load Current Configuration and create new

            s_Mutex1 = new Mutex(true, "Codex2007DSDOTNET");

            bool EX = false;
            if (s_Mutex1.WaitOne(0, false) == false) EX = true;


            #region NGEN
            // if Admin Mode
            WindowsIdentity us = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(us);
            bool isAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (isAdministrator == true)
            {
                string ss = global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\cngen.747";
                if (System.IO.File.Exists(ss) == false)
                {
                    // Run NGEN
                    string NGEN = global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\cngen.exe";
                    string NGENPAR = "-Install";
                    System.Diagnostics.Process proc = System.Diagnostics.Process.Start(NGEN, NGENPAR);
                    proc.WaitForExit();
                    if (proc.ExitCode == 0)
                    {
                        System.IO.File.Create(ss);
                    }

                }
            }
            #endregion
            Application.Run(new Form1(EX));
        

            
            
        }


        private static void UnhandledExecptionCatcher(object sender, ThreadExceptionEventArgs s)
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
            FormClosingEventArgs e = new FormClosingEventArgs(CloseReason.FormOwnerClosing, false);
            (Application.OpenForms["Form1"] as Form1).ForceExit = true;
            if (global::ILG.Codex.Codex2011.Properties.Settings.Default.WhenCrash == 0)
                Application.Exit(e);
            else Application.Restart();


        }
   
    }
}
