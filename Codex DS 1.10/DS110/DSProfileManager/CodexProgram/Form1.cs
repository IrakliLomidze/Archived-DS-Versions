using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using ILG.DS.Strings;
using ILG.Windows.Forms;
using System.Reflection;


namespace ILG.Codex.CodexR4
{
    public partial class Form1 : Form
    {

        int Current_Keybard_LanguageLayout;
        public bool ForceExit = false;
        public static SplashScreen sp;

        private string profile_file_name;
        private string profile_display_name;
        private string db_name;
        private string db_user;
        private string db_userpassword;
        private string db_autherification;
        private string db_host;
        private string db_port;
        private string profile_pin;
        private int mode = 0; // 0 none, 1 new, 2 edit

        public void SetLanguageLabel(int index)
        {
            switch (index)
            {

                case 1: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "GEORGIAN(LAT)"; break;
                case 2: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "GEORGIAN(RUS)"; break;
                case 3: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "RUSSIAN(RUS)"; break;
                case 0: CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "ENGLISH"; break;

                default:
                    CodexToolBar.Tools["Language_Menu"].SharedProps.Caption = "Windows Keyboard";
                    break;
            }
        }
        public void SetLanguageLayout(int index)
        {
            switch (index)
            {

                case 1: KeyBoard.Layout.SetGeorgianLat(); break;
                case 2: KeyBoard.Layout.SetGeorgianRus();  break;
                case 3: KeyBoard.Layout.SetGeorgianRus(); break;
                case 0: KeyBoard.Layout.SetEnglish();break;

                default:
                    KeyBoard.Layout.SetOff(); break;
                    
            }
        }

        public Form1(bool FExit)
        {
            InitializeComponent();
            Current_Keybard_LanguageLayout = (int)Properties.Settings.Default.KeyboardLayout;
            SetLanguageLayout(Current_Keybard_LanguageLayout);
            SetLanguageLabel(Current_Keybard_LanguageLayout);
            DisplayParameters();
            ForceExit = FExit;
        }

        public void DisplayParameters()
        {

            profile_file_name = "";
            profile_display_name = "";
            db_name = "";
            db_user = "";
            db_userpassword = "";
            db_autherification = "";
            db_host = "";
            db_port = "";
            profile_pin = "";


    }

        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            String s = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Infragistics.Win.AppStyling.StyleManager.Office2013ColorScheme = Infragistics.Win.Office2013ColorScheme.White;
            Infragistics.Win.AppStyling.StyleManager.Office2013Theme = Infragistics.Win.Office2013Theme.Excel;
            CodexTab.SelectedTab = this.CodexTab.Tabs[0];

            if (Form1.sp.Visible == true) Form1.sp.Hide();
            this.Left = 0;
            this.Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ResumeLayout();
        }


        private void CodexToolBar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            
            switch (e.Tool.Key)
            {
                case "GeoLat":    // ButtonTool
                    SetLanguageLayout(1);
                    SetLanguageLabel(1);
                    break;
                case "English":    // ButtonTool
                    SetLanguageLayout(0);// CodexR4.KeyBoard.Layout.SetEnglish();
                    SetLanguageLabel(0);
                    break;

                case "Layout_Windows":    // ButtonTool
                    SetLanguageLayout(-1); // CodexR4.KeyBoard.Layout.SetOff();
                    SetLanguageLabel(-1);
                    break;

                case "Exit":    // ButtonTool
                    Close();
                           break;

                       

               
               
                
               
                case "Save":  break;

                case "HomeButton": HomeClick(); break;

                case "FeedBack": 
                    System.Diagnostics.Process.Start("mailto:support@codex.ge"); break;
                case "WebSite": 
                    System.Diagnostics.Process.Start("https://www.codex.ge"); break;

       
                case "About": AboutDS fabout = new AboutDS(); fabout.ShowDialog(); break;
                
                
  
            }

            


        }




   

        private void Form1_Resize(object sender, EventArgs e)
        {
            Panelss();
        }

        private void Panelss()
        {
            Codex_Search_Panel.Left = (Codex_Search_Panel.Parent.ClientSize.Width - Codex_Search_Panel.Width) / 2;
        }


        private void HomeClick()
        {
        }

        private void ultraLabel18_Click(object sender, EventArgs e)
        {

        }
    }
}