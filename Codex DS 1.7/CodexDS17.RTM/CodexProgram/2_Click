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
using System.Xml;
using System.Security.Principal;


namespace ILG.Codex.Codex2007
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        public Form1 MainForm;

        private void FillForm()
        {
            this.ultraTextEditor2.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer;
            this.ultraTextEditor1.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString;
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort == 0 ) this.ultraTextEditor3.Text = "";
                else this.ultraTextEditor3.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLPort.ToString();
            
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLAuthMethod == true) { this.radioButton2.Checked = false;  this.radioButton1.Checked = true; }
            else { this.radioButton1.Checked = false; this.radioButton2.Checked = true; }
            
            radioButton2_CheckedChanged(null, null);


            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SaveConnectionStringInProgramFolder == true) { this.checkBox2.Checked = true;  }
            else { this.checkBox2.Checked = false; }
            
            
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

            this.ViewDS.SelectedIndex = global::ILG.Codex.Codex2007.Properties.Settings.Default.ViewDS;
            
            this.DockDS.SelectedIndex = global::ILG.Codex.Codex2007.Properties.Settings.Default.DockDS;
            
            this.ZoomDS.Text = SetZoomValue(global::ILG.Codex.Codex2007.Properties.Settings.Default.ZoomDS);
            
        }

        private string SetZoomValue(int Zoom)
        {
            if (Zoom == -20) return "გვ.სიგანე";
            if (Zoom == -10) return "გვ.სიმაღლე";
            if ((Zoom < 10) || (Zoom > 400)) Zoom = -20;
            if (Zoom == -20) return "გვ.სიგანე";
            return Zoom.ToString() + "%";
        }

        public int GetzoomInt(String s)
        {
            s = s.Trim();
            if (s.EndsWith("%")) s = s.Remove(s.Length - 1, 1);
            s = s.Trim();
            int i;
            if (s == "გვ.სიმაღლე") i = -10;
            else
            {
                if (s == "გვ.სიგანე") i = -20;
                else
                {
                    try
                    {
                        i = Int32.Parse(s);
                    }
                    catch
                    {
                        i = -1;
                    }
                    if ((i < 10) || (i > 400)) i = -1;
                }
            }
            return i;

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




            if (this.GetzoomInt(ZoomDS.Text) == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა დოკუმენტის მაშტაბში:\nდოკუმენტის მაშტაბი უნდა იყოს 10% დან 400%მდე");
                return 21;
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
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SaveConnectionStringInProgramFolder = checkBox2.Checked;
                
                global::ILG.Codex.Codex2007.Properties.Settings.Default.UseFullTextSearch = this.ultraCheckEditor1.Checked;
                

                global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout = (uint)this.ultraComboEditor1.SelectedIndex;


                global::ILG.Codex.Codex2007.Properties.Settings.Default.ViewDS = (int)this.ViewDS.SelectedIndex;
                
                global::ILG.Codex.Codex2007.Properties.Settings.Default.DockDS = (int)this.DockDS.SelectedIndex;
                
                if (this.GetzoomInt(ZoomDS.Text) != -1) global::ILG.Codex.Codex2007.Properties.Settings.Default.ZoomDS = this.GetzoomInt(ZoomCodex.Text);

                // Update Settings
                if (MainForm != null)
                {
                    //MessageBox.Show("1");
                    MainForm.CodexZoomFactor = global::ILG.Codex.Codex2007.Properties.Settings.Default.ZoomDS;
                    MainForm.CodexViewLayout = global::ILG.Codex.Codex2007.Properties.Settings.Default.ViewDS;
                }
                

   


                if (save == true) { global::ILG.Codex.Codex2007.Properties.Settings.Default.Save();
                    if (ILG.Codex.Codex2007.Properties.Settings.Default.SaveConnectionStringInProgramFolder == true)
                    {
                        SaveXMLData();
                    }
                }
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

                global::ILG.Codex.Codex2007.Properties.Settings.Default.SaveConnectionStringInProgramFolder = false;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout = 1;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.ViewDS = 0;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.ZoomDS = -20;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.DockDS = 0;

                generateconnectionstring();
                if (ILG.Codex.Codex2007.Properties.Settings.Default.SaveConnectionStringInProgramFolder == true)
                {
                    CreateXMLData(ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
                }
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

            if ((global::ILG.Codex.Codex2007.Properties.Settings.Default.ISSaveConnectionStringInProgramFolder == true))
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SaveConnectionStringInProgramFolder = global::ILG.Codex.Codex2007.Properties.Settings.Default.AppSaveConnectionStringInProgramFolder;
            }


            if ((global::ILG.Codex.Codex2007.Properties.Settings.Default.IsKeyboard == true) &&
                (global::ILG.Codex.Codex2007.Properties.Settings.Default.AppKeyboardLayout >= 0) && (global::ILG.Codex.Codex2007.Properties.Settings.Default.AppKeyboardLayout < 5))
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.KeyboardLayout = (uint)global::ILG.Codex.Codex2007.Properties.Settings.Default.AppKeyboardLayout;
            }


            #region Document View
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.GUI2AppSetting == true) 
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.ViewDS = (int)global::ILG.Codex.Codex2007.Properties.Settings.Default.AppViewDS;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.DockDS = (int)global::ILG.Codex.Codex2007.Properties.Settings.Default.AppDockDS;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.ZoomDS = (int)global::ILG.Codex.Codex2007.Properties.Settings.Default.AppZoomDS;
            }

            #endregion Document View

            if (ILG.Codex.Codex2007.Properties.Settings.Default.IsConnectionString == false)
            {
                if (ILG.Codex.Codex2007.Properties.Settings.Default.SaveConnectionStringInProgramFolder == true)
                {
                    string s = LoadXMLData();
                    if (s.Trim() != "")
                        ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString = s;
                }
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

            string DockSettings = CodexDocuments + @"\Settings";
            if (Directory.Exists(DockSettings) == false)
                Directory.CreateDirectory(DockSettings);

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
            global::ILG.Codex.Codex2007.Properties.Settings.Default.DockSettingsPath = DockSettings;
        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ultraTabPageControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ინტერფეის -ში პირველადი პარამეტრების აღდგენა ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("ინტერფეის –ში პირველადი პარამეტრების აღდგენა ? \nდაადასტურეთ!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            global::ILG.Codex.Codex2007.Properties.Settings.Default.DockDS = 0;
            
            global::ILG.Codex.Codex2007.Properties.Settings.Default.ViewDS = 0;
            
            global::ILG.Codex.Codex2007.Properties.Settings.Default.ZoomDS = -20;
            
            FillForm();
            ILG.Windows.Forms.ILGMessageBox.Show("ინტერფეის –ში პირველადი პარამეტრები აღდგენილია");

 
        }


        // Save Cooonection String in ProgramFile Directory
        // ------------------------------------------------------------------------------------------------------------------

        // if Admin Mode
        public static bool isAdmin()
        {
            WindowsIdentity us = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(us);
            bool isAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return isAdministrator;
        }


        private void SaveXMLData()
        {
            if (Configuration.isAdmin() == false)
            {

                ILG.Windows.Forms.ILGMessageBox.Show("თქვენ მონიშნული გაქვთ ოფცია 'დამაკავშირებელი სტრიქონი ჩაიწეროს ცალკე ფაილში' \n" +
                "რაც უზრუველყოფს დამაკვშირებელის სტრიქონის ჩაწერას Program Files –ში  \n" +
                "კოდექს 2007 დოკუმენტების არქივის დირექტორიაში.(Codex2007DS.Config2) \n" +
                "\n" +
                "იმისთვის რომ ამ ფაილის შიგთავსი შეიცვალოს, პორგრამა უნდა გაეშვას ადმინისტრატორის უფლებებით \n" +
                "\n" +
                "თუ არ გსურთ მეტი ეს შეტყობინება გამოვიდეს ოფცია 'დამაკავშირებელი სტრიქონი ჩაიწეროს ცალკე ფაილში' გამორეთ");
                return; 
            }

            FileStream fs;
            try    
            {
                
                fs = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + @"\Codex2007DS.Config2", FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            }
            catch (Exception ex)
            { // can't open outfile
                String errorStr = "არ ხერხდება ფაილის გახსნა [" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
                return;
            }

            String ConnectionString = ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString;
            

            XmlDocument doc = new XmlDocument();
            XmlTextWriter writer = new XmlTextWriter(fs, System.Text.Encoding.ASCII);
            writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                    writer.WriteStartElement("Codex_DS_ConnectionString");
                        writer.WriteElementString("Connection_String", @ConnectionString);
                    writer.WriteEndElement();
                writer.WriteEndDocument();
            writer.Close();

            fs.Close();




        }

        public static void CreateXMLData(string con)
        {


            if (isAdmin() == false)
            {


                ILG.Windows.Forms.ILGMessageBox.Show("თქვენ მონიშნული გაქვთ ოფცია 'დამაკავშირებელი სტრიქონი ჩაიწეროს ცალკე ფაილში' \n" +
                "რაც უზრუველყოფს დამაკვშირებელის სტრიქონის ჩაწერას Program Files –ში  \n" +
                "კოდექს 2007 დოკუმენტების არქივის დირექტორიაში.(Codex2007DS.Config2) \n" +
                "\n" +
                "იმისთვის რომ ამ ფაილის შიგთავსი შეიცვალოს, პორგრამა უნდა გაეშვას ადმინისტრატორის უფლებებით \n" +
                "\n" +
                "თუ არ გსურთ მეტი ეს შეტყობინება გამოვიდეს ოფცია 'დამაკავშირებელი სტრიქონი ჩაიწეროს ცალკე ფაილში' გამორეთ");
                return;
            }

            FileStream fs;
            try
            {
                fs = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + @"\Codex2007DS.Config2", FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            }
            catch (Exception ex)
            { // can't open outfile
                String errorStr = "არ ხერხდება ფაილის გახსნა 2 [" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
                return;
            }


            String ConnectionString = con;


            XmlDocument doc = new XmlDocument();
            XmlTextWriter writer = new XmlTextWriter(fs, System.Text.Encoding.ASCII);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Codex_DS_ConnectionString");
            writer.WriteElementString("Connection_String", @ConnectionString);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            fs.Close();

        }

        public static string LoadXMLData()
        {
            string _connectionstring = "";

            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + @"\Codex2007DS.Config2" ) == false) 
            {
                CreateXMLData(ILG.Codex.Codex2007.Properties.Settings.Default.ConnectionString);
            }

            FileStream fs;
            try
            {
                fs = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + @"\Codex2007DS.Config2", FileMode.Open, FileAccess.Read, FileShare.Read, 1024);
            }
            catch (Exception ex)
            { // can't open outfile
                String errorStr = "არ ხერხდება ფაილის გახსნა \n[" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
                return "";
            }


            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fs);

                XmlNodeList nodes = doc.GetElementsByTagName("Codex_DS_ConnectionString");
                _connectionstring = nodes.Item(0).ChildNodes.Item(0).InnerText.ToString(); // Connection_String
            }
            catch 
            { // can't open outfile
                String errorStr = "კონფიგურაციის ფაილი დაზიანებულია  \nგთხოვთ გაასწოროთ იგი.\nან წაშალეთ იგი,და სისტემა შექმნის მას ახლიდან  ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr, "Configuration Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "";
            }

            fs.Close();
            return _connectionstring;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if ((checkBox2.Checked == true) && (Configuration.isAdmin() == false))
            {
                ILG.Windows.Forms.ILGMessageBox.Show(
                "თქვენ მონიშნეთ გაქვთ ოფცია 'დამაკავშირებელი სტრიქონი ჩაიწეროს ცალკე ფაილში' \n" +
                "რაც უზრუველყოფს დამაკვშირებელის სტრიქონის ჩაწერას Program Files –ში  \n" +
                "კოდექს DS დოკუმენტების არქივის დირექტორიაში.(Codex2007DS.Config2) \n" +
                "\n" +
                "იმისთვის რომ ამ ფაილის შიგთავსი შეიცვალოს, პორგრამა უნდა გაეშვას ადმინისტრატორის უფლებებით ");
                //checkBox2.Checked = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[1];
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "About":    // ButtonTool
                    About f = new About(); f.ShowDialog();
                    break;

                case "Manual":    // ButtonTool
                    try
                    {
                        System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Help\\CodexUpdate.XPS");
                    }
                    catch
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("დახმარების ფაილი არ მოიძებნა");
                    }
                    break;

                case "FeedBack":    // ButtonTool
                    System.Diagnostics.Process.Start("mailto:support@codexserver.com");
                    break;

                case "Web":    // ButtonTool
                    System.Diagnostics.Process.Start("http://www.codexserver.com");
                    break;

                case "TechManual":    // ButtonTool
                    try
                    {
                        System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexCurrentDirectory + "\\Help\\CodexTH.XPS");
                    }
                    catch
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("დახმარების ფაილი არ მოიძებნა");
                    }
                    break;


                case "დახურვა":    // ButtonTool
                    Close();
                    break;

                case "ჩაწერა":    // ButtonTool
                    ultraButton1_Click(null, null);
                    break;

                case "მიღება":    // ButtonTool
                    ultraButton2_Click(null, null);
                    break;

            }

        }






        
    }
}