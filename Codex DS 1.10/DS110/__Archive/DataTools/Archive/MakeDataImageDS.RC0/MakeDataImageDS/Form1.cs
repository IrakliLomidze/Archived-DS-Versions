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
using System.Threading;
using System.Security.Principal;
using Microsoft.SqlServer.Management.Smo;

namespace ILG.Codex.Codex2007
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SplashScreen sp;

        int pagenumber;

        private int showdetails()
        {
            DataBaseInfo f = new DataBaseInfo();
            
            int c = f.GetInfo(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom);
            if (c == 0)
            {
                try
                {
                    label3.Text = f.ds.Tables["Information"].Rows[0]["DisplayString"].ToString();
                }
                catch
                {
                    label3.Text = "No Database Info";
                    return 1;
                }
            }
            else
            {
                label3.Text = "Error in Reading Info File";
                return 2;
            }

            return c;

        }
		

        
        private void ultraButton3_Click(object sender, EventArgs e)
        {
            pagenumber++;
            if (pagenumber == 2)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.ultraCombo1.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer;
                this.ultraTextEditor_Distrib.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo; 
                this.ultraTextEditor_Source.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom;
                this.ultraButton_Back.Enabled = true;

                try
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    Microsoft.SqlServer.Management.Smo.Server srv = new Server(this.ultraCombo1.Text);
                    string s = srv.Edition;
                    this.SQLInfo.Text = s + " " + srv.Information.VersionString;
                }
                catch 
                {
                    this.SQLInfo.Text = "";
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                finally
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

            if (pagenumber == 3)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = this.ultraTextEditor_Distrib.Text;
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = this.ultraTextEditor_Source.Text;
                if (showdetails() == 0) this.ultraButton_Process.Enabled = true; else this.ultraButton_Process.Enabled = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.ultraButton_Next.Enabled = false;
                this.ultraButton_Back.Enabled = true;
            }

            if (pagenumber == 4)
            {
                pagenumber--;
                return;
            }

            this.ultraTabControl1.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectNextTab);

        }




        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            pagenumber = 1;
            Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir
             + "\\Styles\\Windows7.isl"
            );

            CheckForIllegalCrossThreadCalls = false;
            ResumeLayout();

            if (Form1.sp.Visible == true) Form1.sp.Hide();
            this.ultraButton_Back.Enabled = false;
        }

     

   


        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("პროგრამიდან გამოსვლა \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) Close();
        }


        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (pagenumber == 0) return;
            if (pagenumber == 1) return;
            pagenumber--;
            
            
            if (pagenumber == 2)
            {
                
                this.ultraButton_Next.Enabled = true;
                this.ultraButton_Back.Enabled = true; 
            }

            if (pagenumber == 1)
            {
                this.ultraButton_Next.Enabled = true;
                this.ultraButton_Back.Enabled = false; 
            }


            this.ultraTabControl1.PerformAction(Infragistics.Win.UltraWinTabControl.UltraTabControlAction.SelectPreviousTab);
        }



        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "About":    // ButtonTool
                    About f = new About(); f.ShowDialog();
                    break;

                case "Manual":    // ButtonTool
                    try { System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom + "\\Help\\CodexUpdate.XPS"); }
                    catch (Exception x) { ILG.Windows.Forms.ILGMessageBox.ShowE("დახმარების ფაილი არ მოიძებნა", x.Message.ToString()); }
                    break;

                case "FeedBack":    // ButtonTool
                    try { System.Diagnostics.Process.Start("mailto:support@codexserver.com"); }
                    catch (Exception x)  { ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება წერილის გაგზავნა", x.Message.ToString()); }
                    break;

                case "Web":    // ButtonTool
                    try { System.Diagnostics.Process.Start("http://www.codexserver.com"); }
                    catch (Exception x) { ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ვებ გვერდის გახსნა", x.Message.ToString()); }
                    break;

                case "Config":    // ButtonTool
                    //Configuration fc = new Configuration(); fc.ShowDialog(); 
                    break;

                case "TechManual":    // ButtonTool
                    try { System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom + "\\Help\\CodexTH.XPS"); }
                    catch (Exception x) { ILG.Windows.Forms.ILGMessageBox.ShowE("დახმარების ფაილი არ მოიძებნა", x.Message.ToString()); }
                    break;

                case "Exit":    // ButtonTool
                    if (ILG.Windows.Forms.ILGMessageBox.Show("პროგრამიდან გამოსვლა \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) Close();
                    break;


            }

        }


        private void ultraButton7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            this.ultraTextEditor_Distrib.Text = fd.SelectedPath.ToString();
            ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = this.ultraTextEditor_Distrib.Text;
        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = "c:\\";
            fd.Filter = "Codex 2007 Database File (*.info)|*.info";
            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Open Codex 2007 Databse Info File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.ultraTextEditor_Source.Text = fd.FileName;
                ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = ultraTextEditor_Source.Text;
            }
        }

 
        

        // ახალი ფუნქიონალი
        private void ultraButton6_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true);
                this.ultraCombo1.DataSource = dataTable;
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ვერ ხერხდება ინფორმაციის მოძიება");
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ultraButton18_Click(object sender, EventArgs e)
        {
            if (ultraCombo1.Text.Trim() == "") {ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ SQL სერვერის სახელი"); return;}
            if ((ultraCombo1.Text.Trim().Contains(",") == true) || (ultraCombo1.Text.Trim().Contains(";") == true) ||
                (ultraCombo1.Text.Trim().Contains(":") == true) || (ultraCombo1.Text.Trim().Contains("'") == true) ||
                (ultraCombo1.Text.Trim().Contains("@") == true) || (ultraCombo1.Text.Trim().Contains("@") == true) ||
                (ultraCombo1.Text.Trim().Contains("&") == true)) { ILG.Windows.Forms.ILGMessageBox.Show("მიუთითეთ SQL სერვერის სახელი შეიცავს დაუშვებელ სიმბოლოებს"); return; }

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SqlConnection test = new SqlConnection("Server=" + ultraCombo1.Text.Trim() + ";Integrated security=SSPI;database=master");

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
                ILG.Windows.Forms.ILGMessageBox.ShowE("კავშირი არ მყარდება: \n" , ex.ToString());
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
                ReConfiguration2(ultraCombo1.Text);
                FillForm();
                ILG.Windows.Forms.ILGMessageBox.Show("კავშირი წარმატებულად დამყარდა");
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = this.ultraCombo1.Text.Trim();

            }

        }

        private void FillForm()
        {
            this.ultraCombo1.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer;
            
            this.ultraTextEditor_Source.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom;
            this.ultraTextEditor_Distrib.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo;

        }
        public void ReConfiguration2(string SQLServerName)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                // Readig Information About SQL Server 2005/2008/R2 Inctances
                Microsoft.SqlServer.Management.Smo.Server srv = new Server(SQLServerName);

                string s = srv.Edition;
                
                //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = srv.RootDirectory.ToString();
                //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = srv.Databases["codex2007"].PrimaryFilePath.ToString();
                //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = "";
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = SQLServerName;
                this.SQLInfo.Text = s + " " + srv.Information.VersionString;
            }
            catch (Exception x)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SQLInfo.Text = " ";
                
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება SQL Server ის იდენფიცირება",x.Message.ToString());
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

        }


        private void ultraCombo1_BeforeDropDown(object sender, CancelEventArgs e)
        {
            if (ultraCombo1.DataSource == null) ultraButton6_Click_1(null, null);
        }

        
        private void ultraCombo1_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {
            if (ultraCombo1.Text.Trim() == "") return;
            ReConfiguration2(ultraCombo1.Text);
            FillForm();
        }

        
        private void ultraButton20_Click(object sender, EventArgs e)
        {
            // Save Settings
            if (ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაციის ჩაწერა კონფიგურაციის ფაილში ?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            try
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = this.ultraCombo1.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = this.ultraTextEditor_Source.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = this.ultraTextEditor_Distrib.Text.Trim();

                global::ILG.Codex.Codex2007.Properties.Settings.Default.Save();
                Configuration.SaveXMLData(global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo, global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom, global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer);
            }
            catch (Exception ex)
            {
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის ჩაწერა კონფიგურაციის ფაილში", ex.Message.ToString());
                return;
            }

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაციის ჩაწერილია");
        }

        private void ultraButton19_Click(object sender, EventArgs e)
        {
            // About
            About f = new About(); f.ShowDialog();
        }

        private void ultraButton_Process_Click(object sender, EventArgs e)
        {
            ProcessDelegate proc = new ProcessDelegate(Process);
            proc.BeginInvoke(null, null);
            //this.Process();
            return;
        }



  	


    }
}
