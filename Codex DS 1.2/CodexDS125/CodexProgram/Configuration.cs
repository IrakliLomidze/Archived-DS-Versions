using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
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
            this.ultraTextEditor1.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString;
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort == 0 ) this.ultraTextEditor3.Text = "";
                else this.ultraTextEditor3.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort.ToString();
            
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLAuthMethod == true) { this.radioButton2.Checked = false;  this.radioButton1.Checked = true; }
            else { this.radioButton1.Checked = false; this.radioButton2.Checked = true; }
            
            radioButton2_CheckedChanged(null, null);
            
            this.ultraTextEditor5.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLUserName;
            this.ultraTextEditor4.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPassword;

            try
            {
                this.ultraComboEditor1.SelectedIndex = (int)global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout;
            }
            catch
            {
                this.ultraComboEditor1.SelectedIndex = 1;
            }

            this.ultraTextEditor6.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.MaximumDocListCodex.ToString();
            
            this.ultraCheckEditor1.Checked = global::ILG.Codex.Codex2007.Properties.Settings.Default.UseFullTextSearch;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            FillForm();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.ultraTextEditor4.Enabled = this.checkBox1.Checked;
            this.ultraTextEditor5.Enabled = this.checkBox1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == false)
            {
                this.checkBox1.Checked = false;
                this.checkBox1.Enabled = false;
                this.ultraTextEditor4.Enabled = false;
                this.ultraTextEditor5.Enabled = false;
            }
            else
            {
                this.checkBox1.Enabled = true;
            }
            
        }

        private void ultraButton5_Click(object sender, EventArgs e)
        {
            string str = "";
            string servername = this.ultraTextEditor2.Text.Trim();
            int i;
            
            string CatalogName = "Codex2007DS";
            

            if (this.ultraTextEditor3.Text.Trim() != "") 
            {
                if (Int32.TryParse(this.ultraTextEditor3.Text, out i) == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა პორტის ნომერში");
                    return;
                }
                servername = this.ultraTextEditor2.Text.Trim() + "," + this.ultraTextEditor3.Text.Trim();
            }
            
            if (this.radioButton2.Checked == true)
            {
                str = "workstation id=" + System.Environment.MachineName +
                    ";packet size=4096;integrated security=SSPI;data source="
                    + servername + ";persist security info=False;initial catalog=" + CatalogName + ";Connection Timeout=30";
            }
            else
            {
                str = "workstation id=" + System.Environment.MachineName + ";packet size=4096;" +
                     "user id=" + this.ultraTextEditor5.Text.Trim() + ";" +
                     "password=" + this.ultraTextEditor4.Text.Trim() + "; data source=" +
                     servername + ";persist security info=False;initial catalog="+CatalogName+";Connection Timeout=30";
            }
            this.ultraTextEditor1.Text = str;
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SqlConnection test = new SqlConnection(this.ultraTextEditor1.Text);

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
                ILG.Windows.Forms.ILGMessageBox.ShowE("სერვერთან კავშირი არ მყარდება ",ex.ToString());
                SQLConnected = false;
            }
            finally
            {
                if (test.State == System.Data.ConnectionState.Open)
                {
                    test.Close();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (SQLConnected == true)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
            }

        }


        private int configurationApplySave(bool save)
        {
            int portnumber = 0;
            if (this.ultraTextEditor3.Text.Trim() != "")
            {
                if (Int32.TryParse(this.ultraTextEditor3.Text.Trim(), out portnumber) == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა პორტის ნომერში");
                    return 1;
                }
            }

            int codexdocmaxnumber = 0;
            if (this.ultraTextEditor6.Text.Trim() != "")
            {
                if (Int32.TryParse(this.ultraTextEditor6.Text.Trim(), out codexdocmaxnumber) == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა დოკუმენტების რაოდენობაში");
                    return 2;
                }
            }

           
          





            bool sqlauthmethod = false;
            if (this.radioButton1.Checked == true) sqlauthmethod = true;

            try
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = this.ultraTextEditor2.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString = this.ultraTextEditor1.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort = (UInt32)portnumber;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLAuthMethod = sqlauthmethod;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLUserName = this.ultraTextEditor5.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPassword = this.ultraTextEditor4.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.MaximumDocListCodex = (uint)codexdocmaxnumber;
                
                
                global::ILG.Codex.Codex2007.Properties.Settings.Default.UseFullTextSearch = this.ultraCheckEditor1.Checked;
                

                global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout = (uint)this.ultraComboEditor1.SelectedIndex;
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
            if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაციის ჩაწერა ?", "", 
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

            if (configurationApplySave(true) == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            }

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი კონფიგურაციის მიღება ?", "",
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.Yes) return;

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
             
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = "Codex\\Codex2007";
                
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort = 1433;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLAuthMethod = true;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLUserName = "CodexDSUser";
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPassword = "CodexDS2007";
                
                
                global::ILG.Codex.Codex2007.Properties.Settings.Default.MaximumDocListCodex = 500;
                
                
                global::ILG.Codex.Codex2007.Properties.Settings.Default.UseFullTextSearch = true;
                

                global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout = 1;
                generateconnectionstring();
            }
        }

        static public void generateconnectionstring()
        {
            string str = "";
            string CatalogName = "Codex2007DS";
            
            string servername = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer;
           
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort != 0) 
            {
                servername = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer +"," + global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort.ToString();
            }
            
            {
                str = "workstation id=" + System.Environment.MachineName + ";packet size=4096;" +
                     "user id=" + global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLUserName + ";" +
                     "password=" + global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPassword + "; data source=" +
                     servername + ";persist security info=False;initial catalog="+CatalogName+";Connection Timeout=20";
            }
            global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString = str;
        }

        public bool isconnecting()
        {
            t:
            
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SqlConnection test = new SqlConnection(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
            //MessageBox.Show(global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);

            //bool SQLConnected = false;
            try
            {
                test.Open();
              //  SQLConnected = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch (System.Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                if (ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ბაზასთან დაკავშირება \nგსურთ კოფიგურაციის ცვლილება", "Connection Error", ex.ToString(), System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error) != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }
                else
                {
                //    SQLConnected = false;
                    test.Close();
                    Configuration cf = new Configuration();
                    cf.ShowDialog();
                    goto t;
                }
            }
            finally
            {
                if (test.State == System.Data.ConnectionState.Open)
                {
                    test.Close();
                }
            }
            this.Cursor = System.Windows.Forms.Cursors.Default;
            return true;
            
        }

        static public void load()
        {
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString == "") 
            {
                FirstConfiguration();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.Save();

            }
            
            #region Policy Settings
            // Pick String From Application Settings
            if ((global::ILG.Codex.Codex2007.Properties.Settings.Default.IsConnectionString == true) &&
                (global::ILG.Codex.Codex2007.Properties.Settings.Default.AppConnectionString.Trim() != "" ))
            {

                global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString = global::ILG.Codex.Codex2007.Properties.Settings.Default.AppConnectionString;
            }

            // Pick String From Application Settings
            if ((global::ILG.Codex.Codex2007.Properties.Settings.Default.IsLimitation == true) &&
                            ((int)global::ILG.Codex.Codex2007.Properties.Settings.Default.AppMaxCodList > 1 ) 
                             )
            {

                global::ILG.Codex.Codex2007.Properties.Settings.Default.MaximumDocListCodex = (uint)global::ILG.Codex.Codex2007.Properties.Settings.Default.AppMaxCodList;
                
                
            }


            if ((global::ILG.Codex.Codex2007.Properties.Settings.Default.IsFullText == true))
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.UseFullTextSearch = global::ILG.Codex.Codex2007.Properties.Settings.Default.AppUseFullTextSearch;
            }


            if ((global::ILG.Codex.Codex2007.Properties.Settings.Default.IsKeyboard == true) &&
                (global::ILG.Codex.Codex2007.Properties.Settings.Default.AppKeyboardLayout >= 0) && (global::ILG.Codex.Codex2007.Properties.Settings.Default.AppKeyboardLayout < 5))
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout = (uint)global::ILG.Codex.Codex2007.Properties.Settings.Default.AppKeyboardLayout;
            }


            
            #endregion Policy Settings
            
            #region declarce directoryes
            string CurrentDirCodex = System.Environment.CurrentDirectory;
		
            string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Codex 2007 DS Documents";
            if (Directory.Exists(CodexDocuments) == false)
                Directory.CreateDirectory(CodexDocuments);

            string FavoriteDocuments = CodexDocuments + @"\Favorites";
            if (Directory.Exists(FavoriteDocuments) == false)
                Directory.CreateDirectory(FavoriteDocuments);


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
            global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDocumentDir = CodexDocuments;
            global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexFavoritesDir = FavoriteDocuments;
            global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory = Environment.CurrentDirectory;
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ultraTabPageControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}