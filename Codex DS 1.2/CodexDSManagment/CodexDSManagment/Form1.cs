using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ILG.Codex.Codex2011
{
    public partial class Form1 : Form
    {

        #region Common Values
        int Current_Language;
        public bool ForceExit = false;
        public static SplashScreen sp;
        #endregion Common Values


        private System.IO.MemoryStream codexmemoryStream = null;


        public Form1(bool FExit)
        {
            
            InitializeComponent();
            Current_Language = (int)global::ILG.Codex.Codex2011.Properties.Settings.Default.KeyboardLayout;
            //this.LanguageSwitcher.SelectedIndex = Current_Language;
            //DefaultSearchParameters();
            //LoadTables();
            //LoadTree();
            //NavigationInistialize();
            //DisplayParameters();

            //F_Codex_DOC = new Form_Codex_Document();
            //F_Codex_DOC.MainForm = this;
            //this.formContainer3.ShowForm(F_Codex_DOC);
            //ID_Finder = new IDFinder();
            //ID_Finder.MainForm = this;
            ForceExit = FExit;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory
             + "\\Styles\\Office2007Blue.isl"
            );
            //Infragistics.Win.Office2007ColorTable.ColorScheme = Infragistics.Win.Office2007ColorScheme.Black;
            //Infragistics.Win.AppStyling.StyleManager.Load("c:\\1\\Office2007Blue.isl");
            if (global::ILG.Codex.Codex2011.Properties.Settings.Default.DefaTheme == 0)
                switch (Infragistics.Win.Office2007ColorTable.ColorScheme)
                {
                    case Infragistics.Win.Office2007ColorScheme.Black: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Black.isl"); break;
                    case Infragistics.Win.Office2007ColorScheme.Blue: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Blue.isl"); break;
                    case Infragistics.Win.Office2007ColorScheme.Silver: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007silver.isl"); break;
                }
            else
            {
                switch (global::ILG.Codex.Codex2011.Properties.Settings.Default.DefaTheme)
                {
                    case 1: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Black.isl"); break;
                    case 2: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007Blue.isl"); break;
                    case 3: Infragistics.Win.AppStyling.StyleManager.Load(global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\Styles\\Office2007silver.isl"); break;
                }
            }



            #region Firt Tab loading

            //if (def == 0) { MainTabs.SelectedTab = MainTabs.Tabs[1]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[0]; }
            // if (def == 1) { MainTabs.SelectedTab = MainTabs.Tabs[0]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[1]; }
            // if (def == 2) { MainTabs.SelectedTab = MainTabs.Tabs[0]; CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[0]; }
           // LastRibbon = CodexToolBar.Ribbon.SelectedTab.Key;

            if (Form1.sp.Visible == true) Form1.sp.Hide();



            #endregion  Firt Tab loading






            this.Left = 0;
            this.Top = 0;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;


            // Codex Doced Document Part
            this.codexmemoryStream = new System.IO.MemoryStream();
            //this.F_Codex_DOC.ultraDockManager1.SaveAsBinary(this.codexmemoryStream);

            // Load Docks


            //LoadDcoksSettings();




            ResumeLayout();

        
        }


        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {

            switch (e.Tool.Key)
            {
                case "Test":    // PopupMenuTool

                    break;

                    /*
                case "GeoLat":    // ButtonTool
                    ILG.Codex.KeyBoard.Layout.SetGeorgianLat();
                    LanguageSwitcher.SelectedIndex = 1;
                    break;

                case "GeoRus":    // ButtonTool
                    ILG.Codex.KeyBoard.Layout.SetGeorgianRus();
                    LanguageSwitcher.SelectedIndex = 2;
                    break;

                case "Rus":    // ButtonTool
                    ILG.Codex.KeyBoard.Layout.SetRussian();
                    LanguageSwitcher.SelectedIndex = 3;
                    break;

                case "English":    // ButtonTool
                    ILG.Codex.KeyBoard.Layout.SetEnglish();
                    LanguageSwitcher.SelectedIndex = 0;
                    break;

                case "Exit":    // ButtonTool
                    Close();
                    break;


                    */

                //TopNavigationLeft

                case "FeedBack":
                    System.Diagnostics.Process.Start("mailto:support@codexserver.com"); break;
                case "WebSite":
                    System.Diagnostics.Process.Start("http://www.codexserver.com"); break;

                case "Manual":
                    //System.Diagnostics.Process.Start("http://www.codexserver.com/help/index.html");
                    //System.Diagnostics.Process.Start("http://www.codexserver.com/help/index.html");
                    System.Diagnostics.Process.Start(@"file" + @":\\" + global::ILG.Codex.Codex2011.Properties.Settings.Default.CodexCurrentDirectory + "\\Help\\Codex.XPS");
                    break;

                case "About": About fabout = new About(); fabout.ShowDialog(); break;





                case "ResetDocks":
                    ResetCodexDocumentDocks();
                    break;


            }

        }



        private void ResetCodexDocumentDocks()
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("პანელების დაბრუნება საწყის მდომარეობაში ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (this.codexmemoryStream == null)
                return;

            this.codexmemoryStream.Position = 0;

            //this.F_Codex_DOC.ultraDockManager1.LoadFromBinary(this.codexmemoryStream);
        }






        private void LanguageSwitcher_SelectionChanged(object sender, EventArgs e)
        {
   /*         switch (LanguageSwitcher.SelectedIndex)
            {
                case 0:
                    ILG.Codex.KeyBoard.Layout.SetEnglish();
                    break;

                case 1:
                    ILG.Codex.KeyBoard.Layout.SetGeorgianLat();
                    break;

                case 2:
                    ILG.Codex.KeyBoard.Layout.SetGeorgianRus();
                    break;

                case 3:
                    ILG.Codex.KeyBoard.Layout.SetRussian();
                    break;
            }
    * */
        }



        private void ConfigurationCall()
        {

            Configuration f = new Configuration();
           // f.MainForm = this;
            f.ShowDialog();

        }

        private void CodexToolBar_AfterRibbonTabSelected(object sender, Infragistics.Win.UltraWinToolbars.RibbonTabEventArgs e)
        {
            if (e.Tab.Key.ToString() == "RConfig")
            {
                GoToLastRibbon();
            }
        }


        private string LastRibbon = "";
        private void CodexToolBar_BeforeRibbonTabSelected(object sender, Infragistics.Win.UltraWinToolbars.BeforeRibbonTabSelectedEventArgs e)
        {
            bool f = false;
            switch (e.Tab.Key.ToString())
            {
     //           case "RCodex": this.MainTabs.SelectedTab = this.MainTabs.Tabs[0]; ActiveProgram = 2; break;

            }
            if (f != true) LastRibbon = e.Tab.Key.ToString();

        }

        private void GoToLastRibbon()
        {
       //     if (LastRibbon != "")
         //       CodexToolBar.Ribbon.SelectedTab = CodexToolBar.Ribbon.Tabs[LastRibbon];
        }


     

    }
}
