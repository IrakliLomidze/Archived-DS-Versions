using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILG.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer;



namespace ILG.Codex.Codex2007
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

 
 
        private int configurationApplySave(bool save)
        {
            
            try
            {
                //global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = this.ultraTextEditor2.Text.Trim();
                //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = this.ultraTextEditor1.Text.Trim();
                //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = this.ultraTextEditor9.Text.Trim();
           
                if (save == true) { global::ILG.Codex.Codex2007.Properties.Settings.Default.Save(); }
            }
            catch (Exception ex)
            {
                if (save == true) ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის ჩაწერა კონფიგურაციის ფაილში", ex.Message.ToString());
                else ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის მიღება კონფიგურაციის ფაილში", ex.Message.ToString());
                return 3;
            }
            //ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            return 0;
        }

        
        
        
        // Configuration Workplace
        static public void FirstConfiguration()
        {
            
            try
            {
                Application.UseWaitCursor = true;
                // Readig Information About SQL Server 2005/2008/R2 Inctances
                Microsoft.SqlServer.Management.Smo.Server srv = new Server(System.Environment.MachineName + "\\" + "Codex2007");


                //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = srv.RootDirectory.ToString();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = srv.Databases["master"].PrimaryFilePath.ToString();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = "";
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = System.Environment.MachineName + "\\" + "Codex2007";
                
            }
            catch
            {
                Application.UseWaitCursor = false;
                
            }
            finally
            {
                Application.UseWaitCursor = false;
               
            }


        }

        /*
        // Legacy Code
        static public void ReConfiguration(string SQLServerName)
        {
            // Readig Information About SQL Server 2005 Inctances

            String vs;
            try
            {
                vs = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").
                    OpenSubKey("Microsoft SQL Server").OpenSubKey("Instance Names").OpenSubKey("SQL").GetValue(SQLServerName, "x");
                //                    OpenSubKey("Microsoft SQL Server").OpenSubKey("Instance Names").OpenSubKey("SQL").GetValue("ZS1", "x");
            }
            catch
            { vs = "x"; }

            // Readig Information About Codex2007 Inctances
            String s = "z";
            if (vs != "x")
            {
                try
                {

                    s = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").
                             OpenSubKey("Microsoft SQL Server").OpenSubKey(vs).OpenSubKey("Setup").GetValue("SQLDataRoot", "x");
                }
                catch
                {
                    s = "x";
                }
            }
            if (s == "x")
            {
                try
                {
                    s = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").
                                 OpenSubKey("Microsoft SQL Server").OpenSubKey("MSSQLSERVER").OpenSubKey("Setup").GetValue("SQLDataRoot", "x");
                }
                catch
                {
                    s = "";
                }

            }



            global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = s;
            global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = "";
            global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = System.Environment.MachineName + "\\" + SQLServerName;


        }
        */
        public void ReConfiguration2(string SQLServerName)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                // Readig Information About SQL Server 2005/2008/R2 Inctances
                Microsoft.SqlServer.Management.Smo.Server srv = new Server(SQLServerName);


                //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = srv.RootDirectory.ToString();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = srv.Databases["master"].PrimaryFilePath.ToString();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = "";
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = SQLServerName;
            }
            catch
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება დირექტორიის მოძებნა");
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }


        }

  
        static public void load()
        {
            FirstConfiguration();
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer == "") 
                
            {
                FirstConfiguration();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.Save();

            }

            FirstConfiguration();
            #region declarce directoryes
            string CurrentDirCodex = System.Environment.CurrentDirectory;
		
            string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Codex R3 Documents";
            if (Directory.Exists(CodexDocuments) == false)
                Directory.CreateDirectory(CodexDocuments);

            string FavoriteDocuments = CodexDocuments + @"\Favorites";
            if (Directory.Exists(FavoriteDocuments) == false)
                Directory.CreateDirectory(FavoriteDocuments);

            string CodexUpdateDirectory = CodexDocuments + @"\Codex R3 Update";
            if (Directory.Exists(CodexUpdateDirectory) == false)
                Directory.CreateDirectory(CodexUpdateDirectory);




            string TempDirCodex = Environment.GetEnvironmentVariable("TEMP");
            if (Directory.Exists(TempDirCodex) == false)
            {
                TempDirCodex = CodexDocuments + @"\Temp";
                if (Directory.Exists(TempDirCodex) == false)
                    Directory.CreateDirectory(TempDirCodex);
            }

            // Creating Temp Direcotry
            TempDirCodex = TempDirCodex + @"\" + DateTime.Now.Ticks.ToString();
            if (Directory.Exists(TempDirCodex) == false)
                Directory.CreateDirectory(TempDirCodex);

            string HelpDir = CurrentDirCodex + @"\Help";
            if (Directory.Exists(HelpDir) == false)
                Directory.CreateDirectory(HelpDir);

            Directory.SetCurrentDirectory(CurrentDirCodex);


            #endregion declarce directoryes


            global::ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir = TempDirCodex;
            //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = CodexDocuments;
            global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir = Environment.CurrentDirectory;
          
        }

        
        

  
        
        
        
    }
}