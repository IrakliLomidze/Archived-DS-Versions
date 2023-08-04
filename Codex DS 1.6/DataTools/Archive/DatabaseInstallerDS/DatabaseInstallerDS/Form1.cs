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
        int way = -1;
        public static string CopyFrom;
        public static string CopyTo;
        public static bool   Copying;
        

        private int showdetails()
        {
            DataBaseInfo f = new DataBaseInfo();
            int c = f.GetInfo(Form1.CopyFrom);
            if (c == 0)
            {
                try
                {
                    this.ultraGroupBox6.Text = f.ds.Tables["Information"].Rows[0]["DisplayString"].ToString();
                }
                catch
                {
                    this.ultraGroupBox6.Text = "No Database Info";
                    return 1;
                }
            }
            else
            {
                this.ultraGroupBox6.Text = "Error in Reading Info File";
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
                Form1.CopyFrom = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom;
                Form1.CopyTo = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo;
                this.ultraCombo1.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer;
                this.ultraTextEditor2.Text = Form1.CopyTo ;  // textBox1.Text = Form1.CopyFrom;
                this.ultraTextEditor3.Text = Form1.CopyFrom;// this.textBox10.Text = Common.FromPath;

                try
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    Microsoft.SqlServer.Management.Smo.Server srv = new Server(this.ultraCombo1.Text);
                    string s = srv.Edition;
                    this.SQLInfo.Text = s + " " + srv.Information.VersionString + " Collcation " + srv.Collation;
                    this.ultraLabel_S0.Text = "SQL Server";
                    this.ultraLabel_S1.Text = s;
                    this.ultraLabel_S2.Text = "Version";
                    this.ultraLabel_S3.Text = srv.Information.VersionString;
                    this.ultraLabel_S4.Text = "FullText";
                    if (srv.Information.IsFullTextInstalled == true) this.ultraLabel_S5.Text = "Installed"; else this.ultraLabel_S5.Text = "Not Installed";
                    this.ultraLabel_S6.Text = "Collcation";
                    this.ultraLabel_S7.Text = srv.Collation;
                }
                catch 
                {
                    this.ultraLabel_S0.Text = "";
                    this.ultraLabel_S1.Text = "";
                    this.ultraLabel_S2.Text = "";
                    this.ultraLabel_S3.Text = "";
                    this.ultraLabel_S4.Text = "";
                    this.ultraLabel_S5.Text = "";
                    this.ultraLabel_S6.Text = "";
                    this.ultraLabel_S7.Text = "";
                    this.SQLInfo.Text = "";
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    //ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დირექტორიის მოძებნა", x.Message.ToString());
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
                Form1.CopyTo = this.ultraTextEditor2.Text;
                Form1.CopyFrom = this.ultraTextEditor3.Text;
                Form1.Copying = ! this.ultraCheckEditor2.Checked; 
                if (showdetails() == 0) this.ultraButton4.Enabled = true; else this.ultraButton4.Enabled = false;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.ultraButton3.Enabled = false;
            }



            if (pagenumber == 4)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                int r = this.getsqldatabasesinfo();
                this.Cursor = System.Windows.Forms.Cursors.Default;
                if (r == 0)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    this.getdatabasestates();
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }


            }

            if (pagenumber == 5)
            {

                if ((act1 != true) )
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("გაგრძელებისთვის კოდექს DS–ის ბაზები უნდა იყოს აქტიური");
                    return;
                }
                if (this.ultraOptionSet1.CheckedIndex == 0) //Items[0].ultraburadioButton3.Checked == true)
                    way = 1; // worksation
                else way = 2; // server

                if (way == 1)
                { // Worksation
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[4];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[4];
                    return;

                }
                else
                { // Server
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[5];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[5];
                    return;
                }

            }


            if (pagenumber == 6)
            {
             /*   if (way == 1)
                { // Worksation
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[7];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[7];
                    FinalInfo();
                    this.button17.Enabled = false;
                    return;

                }
                else*/
                { // Server
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[6];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[6];
                    return;
                }

            
            }


            if (pagenumber == 7)
            {
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[7];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[7];
                    FinalInfo();
                    this.ultraButton3.Enabled = false;
                    return;
            }



            if (pagenumber == 8)
            {
                this.ultraButton3.Enabled = false;
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

            this.ultraLabel_S0.Text = "";
            this.ultraLabel_S1.Text = "";
            this.ultraLabel_S2.Text = "";
            this.ultraLabel_S3.Text = "";
            this.ultraLabel_S4.Text = "";
            this.ultraLabel_S5.Text = "";
            this.ultraLabel_S6.Text = "";
            this.ultraLabel_S7.Text = "";


            //Infragistics.Win.Office2007ColorTable.ColorScheme = Infragistics.Win.Office2007ColorScheme.Black;
            //Infragistics.Win.AppStyling.StyleManager.Load("c:\\1\\Office2007Blue.isl");
            
            //if (global::ILG.Codex.Codex2007.Properties.Settings.Default.DefaTheme == 0)
            //    switch (Infragistics.Win.Office2007ColorTable.ColorScheme)
            //    {
            //        case Infragistics.Win.Office2007ColorScheme.Black: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Styles\\Office2007Black.isl"); break;
            //        case Infragistics.Win.Office2007ColorScheme.Blue: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Styles\\Office2007Blue.isl"); break;
            //        case Infragistics.Win.Office2007ColorScheme.Silver: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Styles\\Office2007silver.isl"); break;
            //    }
            //else
           // {
            //    switch (global::ILG.Codex.Codex2007.Properties.Settings.Default.DefaTheme)
            //    {
            //        case 1: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Styles\\Office2007Black.isl"); break;
            //        case 2: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Styles\\Office2007Blue.isl"); break;
            //        case 3: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Styles\\Office2007silver.isl"); break;
            //    }
           // }
            
            CheckForIllegalCrossThreadCalls = false;
            ResumeLayout();

            if (Form1.sp.Visible == true) Form1.sp.Hide();
            Form1.CopyFrom = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom;
            Form1.CopyTo = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo;

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
            if (pagenumber == 8)
            {
                this.ultraButton3.Enabled = false;

            }
            else this.ultraButton3.Enabled = true;

            if (pagenumber == 4)
            {

                if (way == 1)
                { // Worksation
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[3];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[3];
                    return;

                }
                else
                { // Server
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[3];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[3];
                    return;
                }

            }

            if (pagenumber == 5)
            {

                if (way == 1)
                { // Worksation
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[4];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[4];
                    return;

                }
                else
                { // Server
                    ultraTabControl1.SelectedTab = ultraTabControl1.Tabs[5];
                    ultraTabControl1.ActiveTab = ultraTabControl1.Tabs[5];
                    return;
                }

            }

            if (pagenumber == 6)
            {
                FinalInfo();
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

        private void ultraGroupBox6_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            this.ultraTextEditor2.Text = fd.SelectedPath.ToString();
            Form1.CopyTo = this.ultraTextEditor2.Text;
        }

        private void ultraButton8_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = "c:\\";
            fd.Filter = "Codex DS Database File (*.info)|*.info";
            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            
            fd.Title = "Open Codex DS Databse Info File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                this.ultraTextEditor3.Text = fd.FileName;
                Form1.CopyFrom = this.ultraTextEditor3.Text;

            }
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            ProcessDelegate proc = new ProcessDelegate(Process);
            proc.BeginInvoke(null, null);
            //this.Process();
            return;
        }

        private void ultraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ultraCheckEditor1.Checked == true)
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ბაზების რეგისტრაციის გამოტოვება ?\n" + "დარწმუნდით, რომ ბაზები უკვე ინსტალირებულია სერვერზე.", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    if (ILG.Windows.Forms.ILGMessageBox.Show("დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        this.ultraButton1.Enabled = true;
                        this.ultraButton4.Enabled = false;
                        this.ultraButton3.Enabled = true;
                    }
                }
            }
            else
            {
                this.ultraButton1.Enabled = false;
                this.ultraButton4.Enabled = true;
                this.ultraButton3.Enabled = false;
                
            }
        }


        #region Page 4
        #region takeoffonline

        #region takeoffline
        int takeofflinecodex2007()
        {
            if (res1 == true)
            {
                try
                {
                    srv.Databases["Codex2007DS"].SetOffline();
                }

                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("შეცდომა \n" +
                        "არ ხერხდება Codex2007DS-ზე ოპერირება, ბაზაზე მუშობს მომხმარებელი \n" +
                        "დახურეთ ყველა კოდექს პროგრამა");
                    return 1;
                }
            }
            else
                return 2;

            return 0;

        }

 
        #endregion takeoffline

        #region takeonline
        int takeonlinecodex2007()
        {
            if (res1 == true)
            {
                try
                {
                    srv.Databases["Codex2007DS"].SetOnline();
                }

                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("შეცდომა \n" +
                        "არ ხერხდება Codex2007DS აქტივიზაცია");

                    return 1;
                }
            }
            else
                return 2;

            return 0;

        }


        #endregion takeoffline
        private void RefreshPage4()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            int r = this.getsqldatabasesinfo();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (r == 0)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.getdatabasestates();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ultraButton11_Click(object sender, EventArgs e)
        {
            if ((this.ultraCheckEditor3.Checked == true) && (this.act1 == true))
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ბაზა უკვე აქტივიზირებულია");
                RefreshPage4();
                return;
            }
            if ((this.ultraCheckEditor3.Checked == false) && (this.act1 == false))
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ბაზა უკვე დეაქტივიზირებულია");
                RefreshPage4();
                return;
            }

            if (this.ultraCheckEditor3.Checked == false)
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ბაზა codex DS აქტიურია, გსურთ მისი დეაქტივიზაცია ?", "", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.takeofflinecodex2007();
                }
                RefreshPage4();
            }
            else
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ბაზა codex2007 დეაქტივიზირებულია, გსურთ მისი აქტივიზაცია  ?", "", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.takeonlinecodex2007();
                }
                RefreshPage4();
            }
        }

    
        #endregion takeoffonline

        #region DropAtachDatabases
        DataBaseInfo df;
        string maindatabasefile;
        


        public int GetInfoFrom(string fname)
        {
            df = new DataBaseInfo();
            int i = df.GetInfo(fname);
            if (i != 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("შეცდომა \n" +
                    "არ ხერხდება  [" + System.IO.Path.GetFileName(fname) + "] ფაილის წაკითხვა) \n" +
                    "ფაილი ან დაზიანებულია ან არ არის info ფორმატის ", "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 1;
            }

            maindatabasefile = Path.GetDirectoryName(fname) + "\\" + df.ds.Tables["MainDataBase"].Rows[0]["FILE"];
            return 0;

        }


        public int AttachCodex2007Database()
        {

            
            System.Collections.Specialized.StringCollection strx = new System.Collections.Specialized.StringCollection();
            

            for (int i = 0; i <= df.ds.Tables["MainDataBase"].Rows.Count - 1; i++)
                strx.Add(Path.GetDirectoryName(this.maindatabasefile) + @"\" + df.ds.Tables["MainDataBase"].Rows[i]["FILE"].ToString());

            try
            {
                srv.AttachDatabase("Codex2007DS", strx);

            }
            catch (Exception e)
            {
                ILG.Windows.Forms.ILGMessageBox.ShowE("შეცდომა\n" +
                    "არ ხერხდება Codex2007DS ბაზის რეგისტრაცია ",e.ToString());

                return 8;
            }


            return 0;

        }


        

        public int dropCodex2007Database()
        {
            try
            {
                srv.DetachDatabase("Codex2007DS", true);
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("შეცდომა: " +
                    "\nარ ხერხდება Codex2007DS ბაზის გადაწერა, ბაზაზე მუშობს მომხმარებელი  " +
                    "\nდახურეთ ყველა კოდექს პროგრამა");
                return 1;
            }
            return 0;
        }


  

        private void ultraButton9_Click(object sender, EventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("codex2007 მონაცემთა ბაზის წაშლა,\n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ადასტურებთ codex2007DS ბაზის წაშლას?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    int i = this.dropCodex2007Database();
                    if (i == 0)
                        ILG.Windows.Forms.ILGMessageBox.Show("ბაზა codex2007DS წაშლილია");
                    RefreshPage4();


                }

            }
        }


        private void ultraButton10_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = this.ultraTextEditor1.Text;
            fd.Filter = "Codex 2007DS Database Info File (*.info)|*.info";
            fd.FilterIndex = 0;
            fd.RestoreDirectory = true;
            fd.Multiselect = false;
            fd.Title = "Pick a Codex Info File";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (GetInfoFrom(fd.FileName) == 0)
                    if (this.AttachCodex2007Database() == 0)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("ბაზა codex2007DS რეგისტრირებულია");
                        RefreshPage4();

                    }

            }

        }

    
        
#endregion DropAtachDatabases

        private void ultraTabPageControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion Page 4

        #region Page 5

        private int DropDatabaseUserX(bool englishmode)
        {

            bool xres1 = false;
            String BuiltinUsers = @"BUILTIN\USERS";
            if (ILG.Codex.Codex2007.Properties.Settings.Default.NewLogic == true)
            {
                string account = new SecurityIdentifier("S-1-5-32-545").Translate(typeof(NTAccount)).ToString().ToUpper();
                BuiltinUsers = account;
            }

            if (englishmode == true) BuiltinUsers = @"BUILTIN\USERS";

            #region codex2007
            for (int i = 0; i < srv.Databases["Codex2007DS"].Users.Count; i++)
            {
                if (srv.Databases["Codex2007DS"].Users[i].Name.ToString().ToUpper() == BuiltinUsers) xres1 = true;
            }
            if (xres1 == true)
            {
                try
                {

                    bool aax = false;
                    for (int i = 0; i < srv.Databases["Codex2007DS"].Schemas.Count; i++)
                    {
                        if (srv.Databases["Codex2007DS"].Schemas[i].Name.ToString().ToUpper() == BuiltinUsers) aax = true;
                    }
                    if (aax == true)
                    {
                        try
                        {
                            srv.Databases["Codex2007DS"].Schemas[BuiltinUsers].Drop();
                        }
                        catch
                        {
                            return 111;
                        }
                    }

                    srv.Databases["Codex2007DS"].Users[BuiltinUsers].Drop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return 1;
                }
            }
            #endregion codex2007

            #region master
            xres1 = false;
            for (int i = 0; i < srv.Databases["master"].Users.Count; i++)
            {
                if (srv.Databases["master"].Users[i].Name.Trim().ToString().ToUpper() == BuiltinUsers) xres1 = true;
            }

            if (xres1 == true)
            {
                try
                {
                    bool aax = false;
                    for (int i = 0; i < srv.Databases["master"].Schemas.Count; i++)
                    {
                        if (srv.Databases["master"].Schemas[i].Name.ToString().ToUpper() == BuiltinUsers) aax = true;
                    }
                    if (aax == true)
                    {
                        try
                        {
                            srv.Databases["master"].Schemas[BuiltinUsers].Drop();
                        }
                        catch
                        {
                            return 311;
                        }
                    }
                    srv.Databases["master"].Users[BuiltinUsers].Drop();
                }
                catch
                {
                    return 3;
                }
            }
            #endregion master

            #region model
            xres1 = false;
            for (int i = 0; i < srv.Databases["model"].Users.Count; i++)
            {
                if (srv.Databases["model"].Users[i].Name.Trim().ToString().ToUpper() == BuiltinUsers) xres1 = true;
            }

            if (xres1 == true)
            {
                try
                {

                    bool aax = false;
                    for (int i = 0; i < srv.Databases["model"].Schemas.Count; i++)
                    {
                        if (srv.Databases["model"].Schemas[i].Name.ToString().ToUpper() == BuiltinUsers) aax = true;
                    }
                    if (aax == true)
                    {
                        try
                        {
                            srv.Databases["model"].Schemas[BuiltinUsers].Drop();
                        }
                        catch
                        {
                            return 411;
                        }
                    }

                    srv.Databases["model"].Users[BuiltinUsers].Drop();
                }
                catch
                {
                    return 4;
                }
            }
            #endregion model

            #region msdb
            xres1 = false;
            for (int i = 0; i < srv.Databases["msdb"].Users.Count; i++)
            {
                if (srv.Databases["msdb"].Users[i].Name.Trim().ToString().ToUpper() == BuiltinUsers) xres1 = true;
            }

            if (xres1 == true)
            {
                try
                {

                    bool aax = false;
                    for (int i = 0; i < srv.Databases["msdb"].Schemas.Count; i++)
                    {
                        if (srv.Databases["msdb"].Schemas[i].Name.ToString().ToUpper() == BuiltinUsers) aax = true;
                    }
                    if (aax == true)
                    {
                        try
                        {
                            srv.Databases["msdb"].Schemas[BuiltinUsers].Drop();
                        }
                        catch
                        {
                            return 411;
                        }
                    }

                    srv.Databases["msdb"].Users[BuiltinUsers].Drop();
                }
                catch
                {
                    return 4;
                }
            }
            #endregion msdb

            #region tempdb
            xres1 = false;
            for (int i = 0; i < srv.Databases["tempdb"].Users.Count; i++)
            {
                if (srv.Databases["tempdb"].Users[i].Name.Trim().ToString().ToUpper() == BuiltinUsers) xres1 = true;
            }

            if (xres1 == true)
            {
                try
                {

                    bool aax = false;
                    for (int i = 0; i < srv.Databases["tempdb"].Schemas.Count; i++)
                    {
                        if (srv.Databases["tempdb"].Schemas[i].Name.ToString().ToUpper() == BuiltinUsers) aax = true;
                    }
                    if (aax == true)
                    {
                        try
                        {
                            srv.Databases["tempdb"].Schemas[BuiltinUsers].Drop();
                        }
                        catch
                        {
                            return 411;
                        }
                    }

                    srv.Databases["tempdb"].Users[BuiltinUsers].Drop();
                }
                catch
                {
                    return 4;
                }
            }
            #endregion tempdb
            return 0;

        }
    

        private int regusersX()
        {

            string filename = "BuiltInUsersDS.txt";
            if (ILG.Codex.Codex2007.Properties.Settings.Default.NewLogic == true)
            {
                filename = "BuiltInUsersDSR3.txt";
            }

            
            System.IO.StreamReader fs = null;
            String Str =  global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\"+filename;
            fs = System.IO.File.OpenText(Str);

            try
            {
                srv.Databases["master"].ExecuteNonQuery(fs.ReadToEnd(),Microsoft.SqlServer.Management.Common.ExecutionTypes.Default);
            }
            catch
            {
                return 1;
            }
            finally
            {
                fs.Close();
            }

            return 0;

        }

        private void ultraButton5_Click_1(object sender, EventArgs e)
        {
            if ((this.res1 == false) ||  (this.act1 == false) )
                ILG.Windows.Forms.ILGMessageBox.Show("პროცესის გაშვებამდე ბაზები უნდა იყოს რეგისტრიებული და აქტიური");
            else
            {
                if (ultraCheckEditor14.Checked == true)
                {
                    if (ILG.Windows.Forms.ILGMessageBox.Show("თქვენ მონიშნული გაქვთ რეგისტრაციის ძველი მეთოდი, დარწმუნებული ხართ ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    if (ILG.Windows.Forms.ILGMessageBox.Show("თქვენ მონიშნული გაქვთ რეგისტრაციის ძველი მეთოდი, დარწმუნებული ხართ ? დაადასტურეთ ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                    ILG.Codex.Codex2007.Properties.Settings.Default.NewLogic = false;
                }
                else
                {
                    ILG.Codex.Codex2007.Properties.Settings.Default.NewLogic = true;
                }

                
                if (ILG.Windows.Forms.ILGMessageBox.Show("BUILTIN\\USERS მომხმარებლების რეგისტრაცია \nპროცესის დაწყება ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    int inf = this.DropDatabaseUserX(true);
                    int inf2 = this.DropDatabaseUserX(false);
                    if ((inf != 0) || (inf2 != 0)) 
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება BUILTIN\\USERS მომხმარებლების რეგისტრაცია კოდი:" + inf.ToString());
                        return;
                    }


                    if (this.regusersX() != 0)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება BUILTIN\\USERS მომხმარებლის რეგისტრაცია");
                        return;
                    }


                    ILG.Windows.Forms.ILGMessageBox.Show("მომხმარებელი  BUILTIN\\USERS დარეგისტრირდა SQL სერვერზე");


                }
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filename = "BuiltInUsersDS.txt";
            if (ILG.Codex.Codex2007.Properties.Settings.Default.NewLogic == true)
            {
                filename = "BuiltInUsersDSR3.txt";
            }

            String Str = global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\" + filename;
            System.Diagnostics.Process.Start("Notepad", Str);
        }

	
        #endregion Page 5

        #region Page 6
        private int regusers2007()
		{
			System.IO.StreamReader fs = null;
			String Str = global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\CodexDS.txt";
			fs = System.IO.File.OpenText(Str);
			

			try
			{
                   srv.Databases["codex2007DS"].ExecuteNonQuery(fs.ReadToEnd(),Microsoft.SqlServer.Management.Common.ExecutionTypes.Default);
			}
			catch 
			{
				return 1;
			}
			finally
			{
				fs.Close();
			}

			return 0;

		}

	
		
		private int DropDatabaseUsers()
		{
			
			bool xres1 = false;
		
			for(int i=0;i<srv.Databases["Codex2007DS"].Users.Count;i++)
			{
				if (srv.Databases["Codex2007DS"].Users[i].Name.Trim().ToString().ToUpper() == "CODEXDSUSER") xres1 = true;
			}

			
			if (xres1 == true)
			{
				try
				{
                    bool aax = false;
                    for (int i = 0; i < srv.Databases["Codex2007DS"].Schemas.Count; i++)
                    {
                        if (srv.Databases["Codex2007DS"].Schemas[i].Name.ToString().ToUpper() == @"CODEXDSUSER") aax = true;
                    }
                    if (aax == true)
                    {
                        try
                        {
                            srv.Databases["Codex2007DS"].Schemas["CodexDSUser"].Drop();
                        }
                        catch
                        {
                            return 111;
                        }
                    }
                    srv.Databases["Codex2007DS"].Users["CodexDSUser"].Drop();
				}
				catch 
				{
					return 1;
				}
			}

			
			return 0;

				
			
		}

        private void ultraButton15_Click(object sender, EventArgs e)
        {
            if ((this.res1 == false)  || (this.act1 == false) )
                ILG.Windows.Forms.ILGMessageBox.Show("პროცესის გაშვებამდე ბაზები უნდა იყოს რეგისტრიებული და აქტიური");
            else
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("მომხმარებლების რეგისტრაცია \nპროცესის დაწყება ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    int inf = this.DropDatabaseUsers();
                    if (inf != 0)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება codexdsuser მომხმარებლების რეგისტრაცია კოდი:" + inf.ToString());
                        return;
                    }


                    if (this.regusers2007() != 0)
                    {
                        ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება codexdsuser მომხმარებლის რეგისტრაცია");
                        return;
                    }
                    

                    ILG.Windows.Forms.ILGMessageBox.Show("მომხმარებელი  და codexdsuser \nმომხმარებელი დარეგისტრირდა SQL სერვერზე");


                }
            }




        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Str = global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\CodexDS.txt";
            System.Diagnostics.Process.Start("Notepad", Str);
        }

        
		
        #endregion Page 6

        #region page 7

        private bool isFullText()
        {
            
            return srv.Information.IsFullTextInstalled;
        }

        private bool isFullTextEnabled()
        {
            return srv.Databases["codex2007DS"].IsFullTextEnabled;
        }

        private void SetFullTextEnabled()
        {
            srv.Databases["codex2007DS"].IsFullTextEnabled = true;
        }

        private int createcatalog2007()
        {
            System.IO.StreamReader fs = null;
            String Str = global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\fulltextindexDS.txt";
            fs = System.IO.File.OpenText(Str);


            try
            {
                //srv.Databases.Item("codex2005", "dbo").ExecuteImmediate(fs.ReadToEnd(), SQLDMO.SQLDMO_EXEC_TYPE.SQLDMOExec_Default, null);
                srv.Databases["codex2007DS"].ExecuteNonQuery(fs.ReadToEnd(), Microsoft.SqlServer.Management.Common.ExecutionTypes.Default);
            }
            catch
            {
                return 1;
            }
            finally
            {
                fs.Close();
            }

            return 0;

        }


        private int createUpdateIndex2007()
        {
            System.IO.StreamReader fs = null;
            String Str = global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\UpdateIndexDS.txt";
            fs = System.IO.File.OpenText(Str);


            try
            {
                srv.Databases["codex2007DS"].ExecuteNonQuery(fs.ReadToEnd(), Microsoft.SqlServer.Management.Common.ExecutionTypes.Default);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message.ToString());
                return 1;
            }
            finally
            {
                fs.Close();
            }

            return 0;

        }


        private void ultraButton16_Click(object sender, EventArgs e)
        {
            if ((this.res1 == false) ||(this.act1 == false) )
            {
                ILG.Windows.Forms.ILGMessageBox.Show("პროცესის გაშვებამდე ბაზები უნდა იყოს რეგისტრიებული და აქტიური");
                return;
            }

            if (isFullText() == false)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("სრულტექსტოვანი სერვისი არ არის გაინსტალირებული");
                return;
            }

            if (this.isFullTextEnabled() == false)
            {
                this.SetFullTextEnabled();
                //ILG.Windows.Forms.ILGMessageBox.Show("სრულტექსტოვანი სერვისი არ არის დაშვებული codex2005 ში");
                //return;
            }

            if (srv.Databases["codex2007DS"].FullTextCatalogs.Count >= 1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("კატალოგი უკვე შექმნილია");
                return;
            }

            if (this.createcatalog2007() != 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება სრულტექსტოვანი კატალოგის შქმნა");
                return;
            }

            ILG.Windows.Forms.ILGMessageBox.Show("სრულტექსტოვანი კატალოგი შექმნილია");


        }

        private void ultraButton17_Click(object sender, EventArgs e)
        {
            if ((this.res1 == false) || (this.act1 == false) )
            {
                ILG.Windows.Forms.ILGMessageBox.Show("პროცესის გაშვებამდე ბაზები უნდა იყოს რეგისტრიებული და აქტიური");
                return;
            }

            if (isFullText() == false)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("სრულტექსტოვანი სერვისი არ არის გაინსტალირებული");
                return;
            }

            if (this.isFullTextEnabled() == false)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("სრულტექსტოვანი სერვისი არ არის დაშვებული codex DS–ში");
                return;
            }

            srv.Databases["codex2007DS"].FullTextCatalogs.Refresh();
            if (srv.Databases["codex2007DS"].FullTextCatalogs.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("კატალოგი არ არის შექმნილი");
                return;
            }

            if (this.createUpdateIndex2007() != 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება სრულტექსტოვანი კატალოგის ინდექსირება");
                return;
            }

            ILG.Windows.Forms.ILGMessageBox.Show("ინდექსირების პროცედურა გადაცემულია სერვერზე\n" +
                "ეს პროცედურა დაიკავებს დაახლოებით 5–10 წუთამდე");
        }

        
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Str = global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\UpdateIndexDS.txt";
            System.Diagnostics.Process.Start("Notepad", Str);
        }


        #endregion Page 7

        #region Page 8
          private void FinalInfo()
		{

            String BuiltinUsers = @"BUILTIN\USERS";
            if (ILG.Codex.Codex2007.Properties.Settings.Default.NewLogic == true)
            {
                string account = new SecurityIdentifier("S-1-5-32-545").Translate(typeof(NTAccount)).ToString().ToUpper();
                BuiltinUsers = account;
            }



			#region Info1

            srv = new Server(global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer);
            srv.ConnectionContext.LoginSecure = true; // LoginSecure = true;
            try
            {
                srv.ConnectionContext.ConnectTimeout = 30;
                srv.ConnectionContext.Connect();

            }
			catch (System.Exception ex)
			{
				ILG.Windows.Forms.ILGMessageBox.Show("შეცდომა: \n"+
					"არ ხერხდება " +
                    "SQL Server [" + global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer + "] დაკავშირება \n" + ex.Message.ToString());
			 	 this.ultraTextEditor9.Text = "შეცდომაა რეგისტრაციაში"; return;
			}
            this.ultraTextEditor9.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer;
			#endregion Info1

			#region Info2
			res1 = false;
			
			for(int i=0;i<srv.Databases.Count;i++)
			{
				//srv.Databases.Item(i).Name
				if (srv.Databases[i].Name.ToString().Trim().ToUpper() == "CODEX2007DS") res1 = true;
			}
			if (res1 == false) 
			{
				this.ultraTextEditor12.Text = "ბაზა არ არის რეგისტირებული"; 
			}
			else
			{
                this.ultraCheckEditor10.Checked = !((srv.Databases["Codex2007DS"].Status & DatabaseStatus.Offline) == DatabaseStatus.Offline);
                this.act1 = this.ultraCheckEditor10.Checked;
                if (this.act1 == true) this.ultraTextEditor12.Text = srv.Databases["codex2007DS"].PrimaryFilePath;
                else this.ultraTextEditor12.Text = "ბაზა დეაქტივიზირებულია, შეუძლებელია მისი ადგილმდებარეობის განსაზღვრა";
			}


			#endregion Info2

			#region Info3

			bool xr1 = false;
            for (int i = 0; i < srv.Databases["Codex2007DS"].Users.Count; i++)
			{
                if (srv.Databases["Codex2007DS"].Users[i].Name.Trim().ToString().ToUpper() == BuiltinUsers) { xr1 = true; }//MessageBox.Show("YES");}
			}
            if (xr1 == true) this.ultraCheckEditor12.Checked = true;
			

			//bool 
			xr1=false;
			bool xr3=false;

			for(int i=0;i<srv.Databases["Codex2007DS"].Users.Count;i++)
			{
				if (srv.Databases["Codex2007DS"].Users[i].Name.Trim().ToString().ToUpper() == "CODEXDSUSER") xr1 = true;
				
			}

			
            if ((xr1 == true)) this.ultraCheckEditor13.Checked = true;
			else this.ultraCheckEditor13.Checked = false;

			#endregion Info3

            this.ultraCheckEditor9.Checked = srv.Databases["codex2007DS"].IsFullTextEnabled;
			this.ultraTextEditor10.Text =  System.Environment.OSVersion.ToString();;
            this.ultraLabel31.Text = srv.Edition; ;
              

                }

        #endregion Page 8

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String Str = global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + "\\Scripts\\fulltextindexDS.txt";
            System.Diagnostics.Process.Start("Notepad", Str);
        }



        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ? \nდაადასტურეთ!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            Configuration.FirstConfiguration();
            FillForm();
        }

        private void ultraPictureBox1_Click(object sender, EventArgs e)
        {
            return;
            //int s=2;
            //int d=3;
            //int f = s - 2;
            //f = d / f;
        }


        // ახალი ფუნქიონალი
        private void ultraButton6_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                DataTable dataTable = SmoApplication.EnumAvailableSqlServers(true);
                if (dataTable.Rows.Count == 0) dataTable = SmoApplication.EnumAvailableSqlServers();
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
            this.ultraTextEditor3.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom;
            this.ultraTextEditor2.Text = global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo;

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
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = srv.Databases["master"].PrimaryFilePath.ToString();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = "";
                global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = SQLServerName;
                this.SQLInfo.Text = s + " " + srv.Information.VersionString + " Collcation " + srv.Collation;
                this.ultraLabel_S0.Text = "SQL Server";
                this.ultraLabel_S1.Text = s;
                this.ultraLabel_S2.Text = "Version";
                this.ultraLabel_S3.Text = srv.Information.VersionString;
                this.ultraLabel_S4.Text = "FullText";
                if (srv.Information.IsFullTextInstalled == true) this.ultraLabel_S5.Text = "Installed"; else this.ultraLabel_S5.Text = "Not Installed";
                this.ultraLabel_S6.Text = "Collcation";
                this.ultraLabel_S7.Text = srv.Collation;
                

            }
            catch (Exception x)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.ultraLabel_S0.Text = "";
                this.ultraLabel_S1.Text = "";
                this.ultraLabel_S2.Text = "";
                this.ultraLabel_S3.Text = ""; 
                this.ultraLabel_S4.Text = "";
                this.ultraLabel_S5.Text = "";
                this.ultraLabel_S6.Text = "";
                this.ultraLabel_S7.Text = "";
                this.SQLInfo.Text = "";
                
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება დირექტორიის მოძებნა",x.Message.ToString());
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

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
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
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = this.ultraTextEditor3.Text.Trim();
                global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = this.ultraTextEditor2.Text.Trim();

                global::ILG.Codex.Codex2007.Properties.Settings.Default.Save();
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

        private void ultraTabControl1_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {

        }


    }
}
