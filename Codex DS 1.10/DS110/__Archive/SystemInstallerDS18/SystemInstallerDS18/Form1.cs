using System;
using System.Windows.Forms;
using CodexInstaller;
using System.Diagnostics;

namespace ILG.Codex.CodexR4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SplashScreen sp;

        public static bool   Copying;
        

   
   
        public delegate void ShowProgressDelegate(int progress, string Str);

    
       

        delegate void ProcessDelegate();

        String CurrentDirctory;

        int pagenumber;
        int way = -1;
        private void Form1_Load(object sender, EventArgs e)
        {
            SuspendLayout();
            pagenumber = 1;

            CurrentDirctory = System.Environment.CurrentDirectory;


            if (Properties.Settings.Default.InstallConfiguration == 2)
            {

                Check_Label_Codex.Text = "Codex DS 1.8 Client";

            }





            Identify_Current_State();

            ResumeLayout();
            this.Installing_Activity_Indicator.Stop();

            if (Form1.sp.Visible == true) Form1.sp.Hide();
       
        }

     

   


        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quite from Application ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) Close();
        }


        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (CurrentNavigationPosition == 1)
            {
                InstallerTab.SelectedTab = InstallerTab.Tabs[0];
                InstallerTab.ActiveTab = InstallerTab.Tabs[0];
            }
        }





        
        bool NETFX48_isRequred = false;
        bool AcrobatDC_isRequred = false;


        void Identify_Current_State()
        {

            #region .NET 4.8
            if (DONNETFX.CheckFor48DotVersion_i() >= 480)
            {
                Check_Label_NetFx.Checked = false;
                NETFX48_isRequred = false;

            }
            else
            {
                Check_Label_NetFx.Checked = true;
                NETFX48_isRequred = true;
            }
            #endregion .NET 4.8


            CodexDSSystem codexsys = new CodexDSSystem();

            String CheckKey32 = CodexDSSystem.CodexDSClientKey32; 
            String CheckKey64 = CodexDSSystem.CodexDSClientKey64;
            

            if (codexsys.isCodexNeedToBeInstalled(CheckKey32, CheckKey64) == true)
            {
                Check_Label_Codex.Checked = true;
                this.Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
            }
            else
            {
                Check_Label_Codex.Checked = false;
                Pic_Codex.Image = null;
            }
        


             
            this.Status_String.Text = " ";
            UpdateDots();
        }

        int CurrentNavigationPosition = 0;
        private void Button_Next_Click(object sender, EventArgs e)
        {
            if (CurrentNavigationPosition == 0)
            {
                Identify_Current_State();
                InstallerTab.SelectedTab = InstallerTab.Tabs[1];
                InstallerTab.ActiveTab = InstallerTab.Tabs[1];
            }
        }

        private void Installation_Complte()
        {
            InstallerTab.SelectedTab = InstallerTab.Tabs[2];
            InstallerTab.ActiveTab = InstallerTab.Tabs[2];
            Button_Next.Enabled = false;
            Button_Back.Enabled = false;
            Button_Close.Enabled = true;
        }

        private void Link_Config_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About f = new About();
            f.ShowDialog();
        }

        

  

        private void Linlk_NetFX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Get and Show ActualStatus for .NET
            String S = "";
            S = S + System.Environment.NewLine + DONNETFX.CheckFor46_48DotVersion();
            MessageBox.Show(S);
        }


      
        private void ClearDots()
        {
            Pic_NetFx.Image = null;
            Pic_Codex.Image = null;
            return;
        }

        private void UpdateDots()
        {
            ClearDots();
            if (Check_Label_NetFx.Checked == true) Pic_NetFx.Image = Properties.Resources.BlueDot;

            if (Check_Label_Codex.Checked == true) Pic_Codex.Image = Properties.Resources.BlueDot;
     
            return;
        }

        private void ultraButton1_Click_1(object sender, EventArgs e)
        {


            ///            if (InstallWarning == true) { MessageBox.Show("WARRNING !!! : PLEASE SEE INSTALLATION WARNINGS !!!"); return; }

            UpdateDots();




            if (Check_Label_NetFx.Checked == true)
            {
                bool Result = false;
                Result = Install_NET48Process();
                if (Result == false) return;
            }


            if (Check_Label_Codex.Checked == true)

            {
                bool Result = Install_CodexClient();
                if (Result == false) return;
                else
                {
                    Installation_Complte();
                    return;
                }
            }


        }

        bool is_Restart_Requred = false;

        private bool Install_NET48Process()
        {
            
            if (NETFX48_isRequred == true)
            {
                String FileWithLocation = CurrentDirctory + @"\"+@"..\Packages\netframework\" + "ndp48-x86-x64-allos-enu.exe";
                //String CommandLineParameters = @" /passive /promptrestart /showrmui /log %temp%\SP46.htm";
                String CommandLineParameters = "";// @" /passive /norestart /showrmui /log %temp%\SP46.htm";

                this.Status_String.Text = "Installing .NET Framework 4.8 ... ";
                this.Pic_NetFx.Image = Properties.Resources.arrow_right;

                // Update UI

                this.Installing_Activity_Indicator.Start(true);

                Process myprocess = new Process();
                //myprocess.StartInfo.FileName = FileWithLocation;
                //myprocess.StartInfo.Arguments = CommandLineParameters;


          
                Process myProcess = null;
                myProcess = Process.Start(FileWithLocation, CommandLineParameters);

                do
                {
                    // Some Animagioin
                } while (!myProcess.WaitForExit(3000));

                this.Installing_Activity_Indicator.Stop();
                
                if (myProcess.ExitCode == 1602)
                {
                    MessageBox.Show("Installation Caneled By you");
                    this.Status_String.Text = "... ";
                    this.Pic_NetFx.Image = Properties.Resources.BlueDot;
                    return false;

                    // DO Some UI Update
                }


                if (myProcess.ExitCode == 1603)
                {
                    MessageBox.Show("Error During Installation See Log Below"+ System.Environment.NewLine+ @"%temp%\SP46.htm");
                    Process.Start(System.Environment.GetEnvironmentVariable("%temp%").ToString() + "\\SP46.htm");
                    // DO Some UI Update
                    this.Status_String.Text = " Error During Installation ";
                    this.Pic_NetFx.Image = Properties.Resources.RedDot;
                    return false;

                }

                if ((myProcess.ExitCode == 1641) || (myProcess.ExitCode == 3010))
                {
                    MessageBox.Show("Please Restart your System to Finish Installation");
                    this.Status_String.Text = " Please Restart your System to Finish Installation ";
                    this.Pic_NetFx.Image = Properties.Resources.BlueDot;
                    // DO Some UI Update
                    is_Restart_Requred = true;
                    return false;
                }



                if ((myProcess.ExitCode == 0) )
                {
                    this.Status_String.Text = " ... ";
                    this.Pic_NetFx.Image = Properties.Resources.GreenDot;
                    return true;
                }

            }

            return true;
        }



        private bool Install_CodexClient()
        {

            CodexDSSystem codexsys = new CodexDSSystem();

            if (codexsys.isCodexNeedToBeInstalled(CodexDSSystem.CodexDSClientKey32, CodexDSSystem.CodexDSClientKey64) == true)
            {

                String FileWithLocation = "msiexec";



                String CommandLineParameters = @"/i CodexDS19Client.msi ";/// qn IACCEPTSQLLOCALDBLICENSETERMS = YES ";
                String WorkingDirecotry = CurrentDirctory + @"\" + @"..\CodexPackages\";

                this.Status_String.Text = "Installing Codex DS 1.9 Client ... ";
                this.Pic_Codex.Image = Properties.Resources.arrow_right;


                Process myProcess = new Process();

                myProcess.StartInfo.FileName = FileWithLocation;//  FileWithLocation;
                myProcess.StartInfo.Arguments = "  " + CommandLineParameters;
                myProcess.StartInfo.WorkingDirectory = WorkingDirecotry;
                myProcess.StartInfo.UseShellExecute = false;


                // Update UI
                try
                {
                    myProcess.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


                do
                {
                    // Some Animagioin
                } while (!myProcess.WaitForExit(3000));

                this.Installing_Activity_Indicator.Stop();



                if (myProcess.ExitCode != 0)
                {
                    MessageBox.Show("Error During Installation");
                    this.Status_String.Text = " Error During Installation ";
                    this.Pic_Codex.Image = Properties.Resources.RedDot;
                    myProcess.Close();
                    return false;
                }



                if ((myProcess.ExitCode == 0))
                {
                    this.Status_String.Text = " ... ";
                    this.Pic_Codex.Image = Properties.Resources.GreenDot;
                    myProcess.Close();
                }



            }

            return true;
        }

   


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About f = new About();f.ShowDialog();
        }

    }
}
