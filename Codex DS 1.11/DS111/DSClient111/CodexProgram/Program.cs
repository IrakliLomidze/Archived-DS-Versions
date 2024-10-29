using System;
using System.Windows.Forms;
using System.Threading;
using DS.Configurations;
using System.IO;
using ILG.DS.Profile;
using ILG.DS.AppStateManagement;
using System.Globalization;
using ILG.DS.Controls;
using ILG.DS.Configurations;
using ILG.DS.Configurations.Dialogs;
using ILG.DS.Dialogs;

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
            DirectoryConfiguration.Instance.load();

            Application.ThreadException += new ThreadExceptionEventHandler(Application_UnhandledExecptionCatcher);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledExecptionCatcher);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Application.CurrentCulture.LCID != 0x0409) Application.CurrentCulture = new CultureInfo(0x0409);


         
            // Read Profiles and Allow to select


            var data = DSProfileHelper.ReadProfileList(Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory + @"\PROFILES"));
            if (data.Count == 0)
            {
                ILGMessageBox.Show("DS დოკუმენტების არქივის არცერთი პროფილი არ მოიძებნა", "No Profile Informaiton", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (data.Count > 1)
            {
                DSProfileSelector ds = new DSProfileSelector(data);
                ds.ShowDialog();
                if (ds.DialogResult != DialogResult.OK) { return; }
                app.state.SetProfileInformation(ds._DS_Profile_Name, ds._DS_Porfile_DisplayName ?? "");
                app.state.Show_DS_Profile_Info = true;
            }
            else
            {
                app.state.SetProfileInformation(data[0].DS_Profile_Name, data[0].DS_Porfile_DisplayName ?? "");
                app.state.Show_DS_Profile_Info = true;
            }
            //MessageBox.Show(app.state.DS_Profile_Id);
            string TheProfile = app.state.DS_Profile_Id;

            DSDocumentConfiguration.configure_profile(TheProfile);
            DSBehaviorConfiguration.configure_profile(TheProfile);

            string message = "";
            
            if (DSStaticDataConfiguration.Instance.ReadConfiguraiton() != 0)
                message += $"არ ხერხდება კონფიგურაციის ფაილის წაკითხვა {DSStaticDataConfiguration.Instance.configFilename} " + Environment.NewLine ;

            if (DSDocumentConfiguration.Instance.ReadConfiguraiton() != 0)
                message += $"არ ხერხდება კონფიგურაციის ფაილის წაკითხვა {DSDocumentConfiguration.Instance.configFilename} " + Environment.NewLine;

            if (DSBehaviorConfiguration.Instance.ReadConfiguraiton() != 0)
                message += $"არ ხერხდება კონფიგურაციის ფაილის წაკითხვა {DSBehaviorConfiguration.Instance.configFilename} " + Environment.NewLine;

            if (message != "") message += "მონაცემები ჩაიტვირთება სტანდარტული პარამეტრებით";

            if (message != "")
            {
                ILGMessageBox.Show(message);
            }


            if (DSBehaviorConfiguration.Instance.content.General.DisplayCheck == true)
            {
                int ww = Screen.PrimaryScreen.Bounds.Width;
                int hh = Screen.PrimaryScreen.Bounds.Height;
                if ((ww < 800) || (hh < 600))
                {
                    ILGMessageBox.Show("DS დოკუმენტების არქივის გასაშვებად ეკრანზე წერტილების \nრაოდენობა უნდა იყოს მინიმუმ" +
                        "800x600 ზე.\n" + "თქვენ ეკრანზე  არის " + ww.ToString() + "x" + hh.ToString());
                    return;
                }
            }



            //CodexDSOrganizationSettings.Instance.LoadConfiguration();
            app.state.UISettingsManager.ReadConfiguraiton();

            Form1.sp = new SplashScreen();
            Form1.sp.Show();
            Form1.sp.Refresh();

            


            StatusAttributeConfiguration.LoadConfiguraiton();
            ConfigurationUI.load();

            UserSQLConfigurationManager userconfig = new UserSQLConfigurationManager(TheProfile);
            
            if  (!Form1.sp.Visible) Form1.sp.Show();
            userconfig.ReadConfiguraiton();
            bool donotneedconfiguration = true;
            try
            {
                donotneedconfiguration = app.state.isconnecting(userconfig.content.db_connectionstring ?? "");
            }
            catch (Exception e)
            {
                Form1.sp.Hide();
                donotneedconfiguration = false;
                ILGMessageBox.ShowE("სერვერთან კავშირი არ მყარდება ", e.ToString());
            }

            if (!donotneedconfiguration)
            {
                DSProfileSQLServerConfiguration dssql = new DSProfileSQLServerConfiguration(ShowInTaskBar: false);
                dssql.ShowDialog();
                try
                {
                    userconfig.ReadConfiguraiton();
                    var r = app.state.isconnecting(userconfig.content.db_connectionstring ?? "");
                }
                catch
                {
                    return;
                }
            }

            
            

            app.state.ConnectionString = userconfig.content.db_connectionstring;
            app.state.UseFullTextSearch = ((userconfig.content.db_usefulltext ?? "").ToUpper().Trim() == "TRUE");
            //    ConfigurationSQL.load();
            //ConfigurationSQL f1 = new ConfigurationSQL();

            //if (f1.isconnecting() == false) return;


            ConfigurationUI.load(); // Load Current Configuration and create new
            
            
            bool EX = false;
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
                r.Cursor = Cursors.Default;
            }
            catch
            {
                Application.UseWaitCursor = false;
                MessageBox.Show("Fattal Error");
            }

            if (DSBehaviorConfiguration.Instance.content.General.WhenCrash == 0)
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
                r.Cursor = Cursors.Default;
            }
            catch
            {
                Application.UseWaitCursor = false;
                MessageBox.Show("Fattal Error");
            }

            if (DSBehaviorConfiguration.Instance.content.General.WhenCrash == 0)
                Application.Exit();
            else Application.Restart();


        }

    }
}