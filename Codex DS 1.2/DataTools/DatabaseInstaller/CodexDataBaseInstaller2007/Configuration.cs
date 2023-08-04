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


namespace ILG.Codex.Codex2007
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

 

        private void FillForm()
        {
            this.ultraTextEditor2.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer;
            this.ultraTextEditor1.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom;
            this.ultraTextEditor9.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            FillForm();
            
        }

        

        
        private void ultraButton4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = "c:\\";
            fd.Filter = "Codex 2007 Database (*.info)|*.info";
            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Pick a Codex 2007 Info File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.ultraTextEditor1.Text = fd.FileName;
                Form1.CopyFrom = this.ultraTextEditor1.Text;
            }


        }


        private int configurationApplySave(bool save)
        {
            
            

            try
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = this.ultraTextEditor2.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = this.ultraTextEditor1.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = this.ultraTextEditor9.Text.Trim();
           
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

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაციის მიღება ?", "",
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            if (configurationApplySave(false) == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია მიღებულია");
            }
        }

        private void DetailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ? \nდაადასტურეთ!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            Configuration.FirstConfiguration();
            FillForm();
            ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრები აღდგენილია");

        }
        
        
        // Configuration Workplace
        static public void FirstConfiguration()
        {
            // Readig Information About SQL Server 2005 Inctances
            String vs;
            try
            {
                vs = (string)Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").
                    OpenSubKey("Microsoft SQL Server").OpenSubKey("Instance Names").OpenSubKey("SQL").GetValue("Codex2007", "x");
//                    OpenSubKey("Microsoft SQL Server").OpenSubKey("Instance Names").OpenSubKey("SQL").GetValue("ZS1", "x");
            }
            catch
            { vs = "x"; }

            // Readig Information About Codex2007 DS Inctances
            String s="z"; 
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
            global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = System.Environment.MachineName + "\\" + "Codex2007";
                
            
        }

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

            // Readig Information About Codex2007 DS Inctances
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
		
            string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Codex 2007 Documents";
            if (Directory.Exists(CodexDocuments) == false)
                Directory.CreateDirectory(CodexDocuments);

            string FavoriteDocuments = CodexDocuments + @"\Favorites";
            if (Directory.Exists(FavoriteDocuments) == false)
                Directory.CreateDirectory(FavoriteDocuments);

            string CodexUpdateDirectory = CodexDocuments + @"\Codex 2007 Update";
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

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void ultraButton6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.ultraTextEditor9.Text = fd.SelectedPath.ToString();
                Form1.CopyTo = this.ultraTextEditor9.Text;
            }
        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SqlConnection test = new SqlConnection("Server=" + this.ultraTextEditor2.Text.Trim() + ";Integrated security=SSPI;database=master");

            bool SQLConnected = false;
            try
            {
                test.Open();
                SQLConnected = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ILG.Windows.Forms.ILGMessageBox.Show("კავშირი არ მყარდება: \n" + ex.ToString());
                SQLConnected = false;
            }
            finally
            {
                if (test.State == ConnectionState.Open)
                {
                    test.Close();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (SQLConnected == true)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
                 global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = this.ultraTextEditor2.Text.Trim();

            }


        }

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            string Sr = this.ultraTextEditor2.Text.Trim();
            if (Sr.IndexOf(@"\") != -1)
            {
                Sr = Sr.Substring(Sr.IndexOf(@"\")+1);
                
            }
            ReConfiguration(Sr);
            FillForm();

            
        }

        
    }
}