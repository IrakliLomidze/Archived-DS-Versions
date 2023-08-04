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


            //if (global::ILG.Codex.CodexR4.Properties.Settings.Default.InstallConfiguration == 0)
            //{
            ////    Check_Label_Codex.Text = "Codex DS Workstation";

            ////    Check_Label_SQLExpress.Text = "SQL Server 2014 LocalDB";  
            ////    Check_Label_SQLExpress.Enabled = true;
            //}

            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.InstallConfiguration == 1)
            {
                Check_Label_Codex.Text = "Codex DS 1.7 Server";

                Check_Label_SQLExpress.Text = "SQL Server 2014 Express Advanced Service";
                Check_Label_SQLExpress.Enabled = true;

                Pic_AdobeReader.Visible = false;
                AdobeReaderCheckBox.Visible = false;
                AdobeReaderCheckBox.Enabled = false;
                Linlk_AcrobatReader.Enabled = false;
                Linlk_AcrobatReader.Visible = false;
            }

            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.InstallConfiguration == 2)
            {

                Check_Label_Codex.Text = "Codex DS 1.7 Client";

                Check_Label_SQLExpress.Text = "SQL Server 2014 Express";
                Check_Label_SQLExpress.Enabled = false;

                Check_Label_SQLExpress.Visible = false;;

                Linlk_SqlMessage.Visible = false;
                Linlk_Sql.Visible = false;
                Pic_SQLExpress.Visible = false;


                Pic_AdobeReader.Visible = true;
                AdobeReaderCheckBox.Visible = true;
                AdobeReaderCheckBox.Enabled = true;
                Linlk_AcrobatReader.Enabled = true;
                Linlk_AcrobatReader.Visible = true;


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





        bool InstallWarning = false;
        bool NETFX48_isRequred = false;
        bool SQLExpress_Installed = false;
        bool AcrobatDC_isRequred = false;


        void Identify_Current_State()
        {


            #region Check Existance of .NET 3.5 SP1
            // if Windows is Server 2008 R2 or 8 DotNEt Must cheked

            Linlk_NetFXMessage.Text = "";
            Linlk_NetFXMessage.Visible = false;
            Linlk_NetFXMessage.Enabled = false;

            // Ingore Check in .NET 3.5 SP1 in Client and Workstation Scenarios
            if ((Properties.Settings.Default.InstallConfiguration != 0) && (Properties.Settings.Default.InstallConfiguration != 2))
            {
                if (DONNETFX.IsNET35SP1() == false)
                {
                    Linlk_NetFXMessage.Text = ".NET 3.5 SP1 is requred";
                    Linlk_NetFXMessage.Visible = true;
                    Linlk_NetFXMessage.Enabled = true;
                    InstallWarning = true;
                }
                else
                {
                    Linlk_NetFXMessage.Text = "";
                    Linlk_NetFXMessage.Visible = false;
                    Linlk_NetFXMessage.Enabled = false;
                }
            }
            #endregion Check Existance of .NET 3.5 SP1

            #region .NET 4.5.2
            //switch (DONNETFX.CheckFor45DotVersion_i())
            //{
            //    case 0: NETFX450 = true; Check_Label_NetFx.Checked = true; break;
            //    case 1: NETFX450 = true; NETFX451 = true; Check_Label_NetFx.Checked = true; break;
            //    case 2: NETFX450 = true; NETFX451 = true; NETFX452 = true; Check_Label_NetFx.Checked = false; break;
            //}
            #endregion .NET 4.5.2

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


            #region SQLServer

            #region SQL Express
            SQLServerExpress ex = new SQLServerExpress();
            int Express_Version = ex.GetSQLVersion();

            //MessageBox.Show("SQL " + Express_Version.ToString());
            if (Express_Version == 1000)
            {
                Check_Label_SQLExpress.Checked = true;
            }
            else
            {
                if ((Express_Version == 3000)) // Unknow Version
                {
                    Linlk_SqlMessage.Text = "Unknown Instance of SQL Server";
                    Linlk_SqlMessage.Visible = true;
                    Linlk_SqlMessage.Enabled = true;
                    InstallWarning = true;
                }

            }

            SQLExpress_Installed = false;

            if (Express_Version == 2014)
            {
                Check_Label_SQLExpress.Checked = false;
                SQLExpress_Installed = true;
            }

            #endregion SQL Express

            #region Local DB Express


            if (Properties.Settings.Default.InstallConfiguration == 0)
            //CodexR4System.CodexWorksationKey
            {

                SQLExpress_Installed = false;


                if (ex.IsLocalDB2014Installed() == 2014)
                {
                    Check_Label_SQLExpress.Checked = false;
                    SQLExpress_Installed = true;
                }
                else
                {
                    Check_Label_SQLExpress.Checked = true;
                    SQLExpress_Installed = false;
                }
            }

            #endregion Local DB Express


            #endregion SQLServer

            #region Acrobat DC
            AdobeDC dc = new AdobeDC();
            dc.Analize();
            if (dc.ProductType == AcrobatType.notinstalled)
            {
                AdobeReaderCheckBox.Checked = true;
                AcrobatDC_isRequred = true;
            }
            else
            {
                AdobeReaderCheckBox.Checked = false;
                AcrobatDC_isRequred = false;
            }
            #endregion 


            CodexDSSystem codexsys = new CodexDSSystem();

            String CheckKey32 = CodexDSSystem.CodexDSToolsKey32; 
            String CheckKey64 = CodexDSSystem.CodexDSToolsKey64;
            switch (Properties.Settings.Default.InstallConfiguration)
            {
                case 0:
                    {
                        CheckKey32 = CodexDSSystem.CodexDSClientKey32;
                        CheckKey64 = CodexDSSystem.CodexDSClientKey64;
                    } break;
                case 1:
                    {
                        CheckKey32 = CodexDSSystem.CodexDSToolsKey32;
                        CheckKey64 = CodexDSSystem.CodexDSToolsKey64;
                    }
                    break;
            }

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

            //Check_Label_Codex.Checked = true;
            //Check_Label_FontOthers.Checked = true;
            //Check_Label_Database.Checked = true;

            //Check_Label_Database.Visible = false;
            //Check_Label_Database.Enabled = false;


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

            //Configuration f = new Configuration();
            //f.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdobeDC dc = new AdobeDC();
            dc.Analize();
            if (dc.ProductType != AcrobatType.notinstalled)
            {
                MessageBox.Show(
                "Description :" + dc.ProductDescription + System.Environment.NewLine +
                "File Version :" + dc.ProductType.ToString() + System.Environment.NewLine);
            }
            else
            {
                MessageBox.Show(
       "Not Installed" 
     );
            }


        }

  

        private void Linlk_NetFXMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Show how to enable Install .NET 3.5 on Windows 8,2012
            //System.OperatingSystem osInfo = System.Environment.OSVersion;
            
            System.Diagnostics.Process.Start(ILG.Codex.CodexR4.Properties.Settings.Default.Enable_FX35_Windows8);
            System.Diagnostics.Process.Start(ILG.Codex.CodexR4.Properties.Settings.Default.Enable_FX35_Windows81);
            System.Diagnostics.Process.Start(ILG.Codex.CodexR4.Properties.Settings.Default.Enable_FX35_Windows2012);
        }

        private void Linlk_NetFX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Get and Show ActualStatus for .NET
            String S = "";
            if (DONNETFX.IsNET35SP1() == true) S = "OK: .NET Framework 3.51 installed"; else S = "WARNING: .NET Framework 3.51 need to be installed";
            S = S + System.Environment.NewLine + DONNETFX.CheckFor45DotVersion();
            S = S + System.Environment.NewLine + DONNETFX.CheckFor46_48DotVersion();
            MessageBox.Show(S);
        }

        private void Linlk_SqlMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Linlk_SqlMessage.Text == "Unknown Instance of SQL Server")
            {
                MessageBox.Show("Unknow Version Please Uninstall CodexR4 Instance of SQL Server" + System.Environment.NewLine +
                   "You need to install SQL Server 2014 Express Edition named 'CodexR4' Instance");
            }
        }

  

        private void Linlk_VS2013Lib_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //VCRedist vs = new VCRedist();
            //String S = "";

            //if (vs.VS2015() == true) S =  S + "OK: Visual C++ 2015 Redistributable Package (x86) Installed";
            //else S = S + "WARNING: Visual C++ 2015 Redistributable Package (x86) NEED TO BE INSTALED";

            //S = S + System.Environment.NewLine;

            //if (vs.VS2015WOW64() == true) S = S + "OK: Visual C++ 2015 Redistributable Package (x64) Installed";
            //else S = S + "WARNING: Visual C++ 2015 Redistributable Package (x64) NEED TO BE INSTALED";

            ////MessageBox.Show(S);

            //if (vs.DetectVS2015RunTime() == false)
            //{
            //    Check_Label_LIB.Checked = true; VCDistrib_isRequred = true;
            //}
            //else
            //{ Check_Label_LIB.Checked = false; VCDistrib_isRequred = false; }
        }

        private void ClearDots()
        {
            Pic_NetFx.Image = null;
            Pic_SQLExpress.Image = null;
            Pic_AdobeReader.Image = null;
            Pic_LIB.Image = null;
            Pic_Codex.Image = null;
            return;
        }

        private void UpdateDots()
        {
            ClearDots();
            if (Check_Label_NetFx.Checked == true) Pic_NetFx.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
            if (Check_Label_SQLExpress.Checked == true) Pic_SQLExpress.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
            //if (Check_Label_LIB.Checked == true) Pic_LIB.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
            //if (Check_Label_CLI.Checked == true) Pic_CLI.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;


            if (Check_Label_Codex.Checked == true) Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
     
            return;
        }

        private void ultraButton1_Click_1(object sender, EventArgs e)
        {
            // Need to Call Detect Current State

            // Install Process

                
                if (InstallWarning == true) { MessageBox.Show("WARRNING !!! : PLEASE SEE INSTALLATION WARNINGS !!!"); return; }
         
            UpdateDots();

            // Codex R4 Server Installing Scenario
            #region Server Installation
            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.InstallConfiguration == 1)
            {
                //Codex R4 Server Installing Scenario
                bool Result = false;
                Result = Install_NET48Process();
                if (Result == false) return;

                //MessageBox.Show("Done 1");

                Result = Install_SQLServer2014_CodexR4_Server();
                if (Result == false) return;

                //MessageBox.Show("Done 2");
                // Removed In Update 1
                //Result = Install_VCRedist();
                //if (Result == false) return;

                Result = Install_CodexDSTools();
                if (Result == false) return;
                else
                {
                    Installation_Complte();
                    return;
                    /* Install Codex */
                }


                
            }
            #endregion Server Installation

            #region Client Installation 
            if (global::ILG.Codex.CodexR4.Properties.Settings.Default.InstallConfiguration == 2)
            {
                //Codex R4 Client Installing Scenario
                bool Result = false;
                Result = Install_NET48Process();
                if (Result == false) return;

                // Removed In Update 1
                //Result = Install_SQLCLI();
                //if (Result == false) return;

                // Removed In Update 1
                //Result = Install_VCRedist();
                //if (Result == false) return;

                if (AcrobatDC_isRequred == true)
                {
                    if (this.AdobeReaderCheckBox.Checked == true)
                        Result = Install_Acrobat();
                    if (Result == false) return;
                }



                Result = Install_CodexClient();
                if (Result == false) return;
                else
                {
                    Installation_Complte();
                    return;
                    /* Install Codex */
                }



            }

            #endregion Client Installation






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
                this.Pic_NetFx.Image = ILG.Codex.CodexR4.Properties.Resources.arrow_right;

                // Update UI

                this.Installing_Activity_Indicator.Start(true);

                System.Diagnostics.Process myprocess = new System.Diagnostics.Process();
                //myprocess.StartInfo.FileName = FileWithLocation;
                //myprocess.StartInfo.Arguments = CommandLineParameters;


          
                Process myProcess = null;
                myProcess = System.Diagnostics.Process.Start(FileWithLocation, CommandLineParameters);

                do
                {
                    // Some Animagioin
                } while (!myProcess.WaitForExit(3000));

                this.Installing_Activity_Indicator.Stop();
                
                if (myProcess.ExitCode == 1602)
                {
                    MessageBox.Show("Installation Caneled By you");
                    this.Status_String.Text = "... ";
                    this.Pic_NetFx.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
                    return false;

                    // DO Some UI Update
                }


                if (myProcess.ExitCode == 1603)
                {
                    MessageBox.Show("Error During Installation See Log Below"+ System.Environment.NewLine+ @"%temp%\SP46.htm");
                    System.Diagnostics.Process.Start(System.Environment.GetEnvironmentVariable("%temp%").ToString() + "\\SP46.htm");
                    // DO Some UI Update
                    this.Status_String.Text = " Error During Installation ";
                    this.Pic_NetFx.Image = ILG.Codex.CodexR4.Properties.Resources.RedDot;
                    return false;

                }

                if ((myProcess.ExitCode == 1641) || (myProcess.ExitCode == 3010))
                {
                    MessageBox.Show("Please Restart your System to Finish Installation");
                    this.Status_String.Text = " Please Restart your System to Finish Installation ";
                    this.Pic_NetFx.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
                    // DO Some UI Update
                    is_Restart_Requred = true;
                    return false;
                }



                if ((myProcess.ExitCode == 0) )
                {
                    this.Status_String.Text = " ... ";
                    this.Pic_NetFx.Image = ILG.Codex.CodexR4.Properties.Resources.GreenDot;
                    return true;
                }

            }

            return true;
        }


        private bool Install_Acrobat()
        {
            {
                String FileWithLocation = CurrentDirctory + @"\" + @"..\Packages\Adobe\" + "AcroRdrDC2100520060_en_US.exe";
                //String CommandLineParameters = @" /passive /promptrestart /showrmui /log %temp%\SP46.htm";
             
                this.Status_String.Text = "Installing Acrobat DC Reader ... ";
                this.Pic_AdobeReader.Image = ILG.Codex.CodexR4.Properties.Resources.arrow_right;

                // Update UI

                this.Installing_Activity_Indicator.Start(true);

                System.Diagnostics.Process myprocess = new System.Diagnostics.Process();
                


                Process myProcess = null;
                myProcess = System.Diagnostics.Process.Start(FileWithLocation, "");

                do
                {
                    // Some Animagioin
                } while (!myProcess.WaitForExit(3000));

                this.Installing_Activity_Indicator.Stop();

                if (myProcess.ExitCode != 0)
                {
                    MessageBox.Show("Installation Failed");
                    this.Status_String.Text = "... ";
                    this.Pic_AdobeReader.Image = ILG.Codex.CodexR4.Properties.Resources.BlueDot;
                    this.Pic_AdobeReader.Image = ILG.Codex.CodexR4.Properties.Resources.RedDot;

                    return false;

                    // DO Some UI Update
                }


    

                if ((myProcess.ExitCode == 0))
                {
                    this.Status_String.Text = " ... ";
                    this.Pic_AdobeReader.Image = ILG.Codex.CodexR4.Properties.Resources.GreenDot;
                    return true;
                }

            }

            return true;
        }

        private bool Install_SQLServer2014_CodexR4_Server()
        {

            if (SQLExpress_Installed == false)
            {

                #region SQL Server
                String FileWithLocation = CurrentDirctory + @"\" + @"..\Packages\sqlexpress\" + "SQLEXPRADV_x86_ENU.exe";
                if  (System.Environment.Is64BitOperatingSystem == true)
                {
                    FileWithLocation = CurrentDirctory + @"\" + @"..\Packages\sqlexpress\" + "SQLEXPRADV_x64_ENU.exe";
                }


                String CommandLineParameters = ""; // For Internal And Server Version there is a Documentaiton  ILG.Codex.CodexR4.Properties.Settings.Default.SQLServerAdvanced_InstallCommand;

                // Update UI
                this.Status_String.Text = "Installing SQL Server 2014 Express Advanced Version... ";
                this.Pic_SQLExpress.Image = ILG.Codex.CodexR4.Properties.Resources.arrow_right;

                this.Installing_Activity_Indicator.Start(true);
                Process myProcess = null;
                myProcess = new System.Diagnostics.Process();

            //    MessageBox.Show(FileWithLocation);
              //  MessageBox.Show(CommandLineParameters);
                myProcess =  System.Diagnostics.Process.Start(FileWithLocation, CommandLineParameters);

                do
                {
                    // Some Animagioin
                } while (!myProcess.WaitForExit(5000));


                if (myProcess.ExitCode != 0)
                {
                    MessageBox.Show("Error During Installation See Log Below" + System.Environment.NewLine +
                        "C:\\Prgoram Files\\Microsoft SQL Server\\120\\Setup Bootstrap\\Log\\Summary.txt");

                    // System.Diagnostics.Process.Start(System.Environment.GetEnvironmentVariable("%temp%").ToString() + "\\SP46.htm");
                    // DO Some UI Update
                    this.Status_String.Text = "Installing SQL Server 2014 Express Advanced Failed";
                    this.Pic_SQLExpress.Image = ILG.Codex.CodexR4.Properties.Resources.RedDot;
                    return false;
                }


                if ((myProcess.ExitCode == 0))
                {
                    this.Status_String.Text = "...";
                    this.Pic_SQLExpress.Image = ILG.Codex.CodexR4.Properties.Resources.GreenDot;
                 
                }



                #endregion SQL Server

                #region Management Studio
                                                          
                //FileWithLocation = CurrentDirctory + @"..\Packages\sqlexpress\" + "SQLManagementStudio_x86_ENU.exe ";
                //if (System.Environment.Is64BitOperatingSystem == true)
                //{
                //    FileWithLocation = CurrentDirctory + @"..\Packages\sqlexpress\" + "SQLManagementStudio_x64_ENU.exe";
                //}


                //CommandLineParameters = ""; // For Internal And Server Version there is a Documentaiton  ILG.Codex.CodexR4.Properties.Settings.Default.SQLServerAdvanced_InstallCommand;

                //// Update UI
                //this.Status_String.Text = "Installing SQL Server 2014 Management Studio... ";
                //this.Pic_SQLExpress.Image = ILG.Codex.CodexR4.Properties.Resources.arrow_right;

                //this.Installing_Activity_Indicator.Start(true);
           

                //myProcess = System.Diagnostics.Process.Start(FileWithLocation, CommandLineParameters);

                //do
                //{
                //    // Some Animagioin
                //} while (!myProcess.WaitForExit(5000));


                //if (myProcess.ExitCode != 0)
                //{
                //    MessageBox.Show("Error During Installation See Log Below" + System.Environment.NewLine +
                //        "C:\\Prgoram Files\\Microsoft SQL Server\\120\\Setup Bootstrap\\Log\\Summary.txt");

                //    // System.Diagnostics.Process.Start(System.Environment.GetEnvironmentVariable("%temp%").ToString() + "\\SP46.htm");
                //    // DO Some UI Update
                //    this.Status_String.Text = "Installation of SQL Server 2014 Management Studio Failed";
                //    this.Pic_SQLExpress.Image = ILG.Codex.CodexR4.Properties.Resources.RedDot;

                //}


                //if ((myProcess.ExitCode == 0))
                //{
                //    this.Status_String.Text = "...";
                //    this.Pic_SQLExpress.Image = ILG.Codex.CodexR4.Properties.Resources.GreenDot;
                //    return true;
                //}




                #endregion Management Studio
            }

            return  true; ;
        }

   

        
     

        private bool Install_CodexClient()
        {

            CodexDSSystem codexsys = new CodexDSSystem();

            if (codexsys.isCodexNeedToBeInstalled(CodexDSSystem.CodexDSClientKey32, CodexDSSystem.CodexDSClientKey64) == true)
            {

                String FileWithLocation = "msiexec";



                String CommandLineParameters = @"/i CodexDS17Client.msi ";/// qn IACCEPTSQLLOCALDBLICENSETERMS = YES ";
                String WorkingDirecotry = CurrentDirctory + @"\" + @"..\CodexPackages\";

                this.Status_String.Text = "Installing Codex DS 1.7 Client ... ";
                this.Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.arrow_right;


                Process myProcess = new System.Diagnostics.Process();

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
                    this.Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.RedDot;
                    myProcess.Close();
                    return false;
                }



                if ((myProcess.ExitCode == 0))
                {
                    this.Status_String.Text = " ... ";
                    this.Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.GreenDot;
                    myProcess.Close();
                }



            }

            return true;
        }

        private bool Install_CodexDSTools()
        {

            CodexDSSystem codexsys = new CodexDSSystem();

            if (codexsys.isCodexNeedToBeInstalled(CodexDSSystem.CodexDSToolsKey32, CodexDSSystem.CodexDSToolsKey64) == true)
            {

                String FileWithLocation = "msiexec";



                String CommandLineParameters = @"/i CodexDS17Server.msi ";/// qn IACCEPTSQLLOCALDBLICENSETERMS = YES ";
                String WorkingDirecotry = CurrentDirctory + @"\" + @"..\CodexPackages\";

                this.Status_String.Text = "Installing Codex DS 1.7 Server ... ";
                this.Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.arrow_right;


                Process myProcess = new System.Diagnostics.Process();

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
                    this.Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.RedDot;
                    myProcess.Close();
                    return false;
                }



                if ((myProcess.ExitCode == 0))
                {
                    this.Status_String.Text = " ... ";
                    this.Pic_Codex.Image = ILG.Codex.CodexR4.Properties.Resources.GreenDot;
                    myProcess.Close();
                }



            }

            return true;
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About f = new About();f.ShowDialog();
        }

        private void Link_CodexBundle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
