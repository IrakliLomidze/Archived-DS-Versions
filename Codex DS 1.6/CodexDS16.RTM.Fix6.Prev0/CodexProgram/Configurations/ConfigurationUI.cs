using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ILG.Codex.CodexR4.CodexSettings;


namespace ILG.Codex.CodexR4
{
    public partial class ConfigurationUI : Form
    {
        bool _ShowInTaskBar = false;
        public ConfigurationUI(bool ShowInTaskBar =false)
        {
            InitializeComponent();
            _ShowInTaskBar = ShowInTaskBar;

           

        }

        public Form1 MainForm;

        private void FillForm()
        {
            try
            {
                this.KeyboardLayout.SelectedIndex = (int)global::ILG.Codex.CodexR4.Properties.Settings.Default.KeyboardLayout;
            }
            catch
            {
                this.KeyboardLayout.SelectedIndex = 1;
            }

            this.MaxDoc.Text = global::ILG.Codex.CodexR4.Properties.Settings.Default.MaximumDocListCodex.ToString();

            this.Zoom.Text = SetZoomValue(global::ILG.Codex.CodexR4.Properties.Settings.Default.ZoomDS);


        }

        private string SetZoomValue(int Zoom)
        {
            if (Zoom == -20) return "გვ.სიგანე";
            if (Zoom == -10) return "გვ.სიმაღლე";
            if ((Zoom < 10) || (Zoom > 400)) Zoom = -20;
            if (Zoom == -20) return "გვ.სიგანე";
            return Zoom.ToString()+"%";
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {

            int formwidth = LeftPanel.Width + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_ICON.Width * 3 + ConfiguraitonTop_ICON.Left + ConfiguraitonTop_Label.Width;
            this.ShowInTaskbar = _ShowInTaskBar;
            FillForm();
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
        




        private int configurationApplySave(bool save)
        {
            int docmaxnumber = 0;
            if (this.MaxDoc.Text.Trim() != "")
            {
                if (Int32.TryParse(this.MaxDoc.Text.Trim(), out docmaxnumber) == false)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა დოკუმენტების რაოდენობაში");
                    return 2;
                }
            }


            
            if (this.GetzoomInt(Zoom.Text) == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("შეცდომაა დოკუმენტის მასშტაბში:\nდოკუმენტის მასშტაბი უნდა იყოს 10% დან 400%მდე");
                return 21;
            }




            try
            {


                Properties.Settings.Default.MaximumDocListCodex = (uint)docmaxnumber;
                
                global::ILG.Codex.CodexR4.Properties.Settings.Default.KeyboardLayout = (uint)this.KeyboardLayout.SelectedIndex;
                
                if (this.GetzoomInt(Zoom.Text) != -1) global::ILG.Codex.CodexR4.Properties.Settings.Default.ZoomDS= this.GetzoomInt(Zoom.Text);


                // New in R4
                // Conection Strings
                
                // Update Settings
                if (MainForm != null) 
                {
                    //MessageBox.Show("1");
                    MainForm.CodexZoomFactor = global::ILG.Codex.CodexR4.Properties.Settings.Default.ZoomDS;

                    //MainForm.Codex_List_ZoomFactor = global::ILG.Codex.CodexR4.Properties.Settings.Default.DocumentPreviewZoom + 8;
                    
                }


                if (save == true) { global::ILG.Codex.CodexR4.Properties.Settings.Default.Save(); }
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
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            if (configurationApplySave(true) == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            }

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

            ConfigurationUI.FirstConfiguration();
            FillForm();
            ILG.Windows.Forms.ILGMessageBox.Show("პირველადი პარამეტრები აღდგენილია");

        }
        // Configuration Workplace
        static public void FirstConfiguration()
        {
           
           
                    Properties.Settings.Default.MaximumDocListCodex = 1200;
         
                    
                    Properties.Settings.Default.ZoomDS = -20;
         
                    
                    global::ILG.Codex.CodexR4.Properties.Settings.Default.KeyboardLayout = 1;

                    // New in R4
                    


        }

    
    
        static public void load()
        {
        
            
            
            #region Policy Settings
            // Pick String From Application Settings

      
            #region MaximumDocList*
            if ((Properties.Settings.Default.IsLimitation == true) &&
                            ((int)Properties.Settings.Default.AppMaxCodList > 1 ) 
                            )
            {

                global::ILG.Codex.CodexR4.Properties.Settings.Default.MaximumDocListCodex = (uint)global::ILG.Codex.CodexR4.Properties.Settings.Default.AppMaxCodList;
            }
            #endregion MaximumDocList*

     
      

            #region KeyboardLayout
            if ((global::ILG.Codex.CodexR4.Properties.Settings.Default.IsKeyboard == true) &&
                (global::ILG.Codex.CodexR4.Properties.Settings.Default.AppKeyboardLayout >= 0) && (global::ILG.Codex.CodexR4.Properties.Settings.Default.AppKeyboardLayout < 5))
            {
                global::ILG.Codex.CodexR4.Properties.Settings.Default.KeyboardLayout = (uint)global::ILG.Codex.CodexR4.Properties.Settings.Default.AppKeyboardLayout;
            }
            #endregion KeyboardLayout

            #region Document Zoom
            //if ((global::ILG.Codex.CodexR4.Properties.Settings.Default.IsGUI2 == true))
            {

               Properties.Settings.Default.ZoomDS = (int)Properties.Settings.Default.AppZoomDS;
           
            }

            #endregion Document Zoom

            

         
            #endregion Policy Settings
            


        }

        private void ultraButton3_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ILG.Windows.Forms.ILGMessageBox.Show("ინტერფეისში პირველადი პარამეტრების აღდგენა ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (ILG.Windows.Forms.ILGMessageBox.Show("ინტერფეისში პირველადი პარამეტრების აღდგენა ? \nდაადასტურეთ!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

           
            Properties.Settings.Default.ZoomDS = -20;


            FillForm();
            ILG.Windows.Forms.ILGMessageBox.Show("ინტერფეისში პირველადი პარამეტრები აღდგენილია");

        }

        

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[0];
        }

     
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ultraTabControl2.SelectedTab = this.ultraTabControl2.Tabs[1];
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "About":    // ButtonTool
                    AboutDS f = new AboutDS(); f.ShowDialog();
                    break;

   
                case "FeedBack":    // ButtonTool
                    System.Diagnostics.Process.Start("mailto:support@codex.ge");
                    break;

                case "Web":    // ButtonTool
                    System.Diagnostics.Process.Start("http://www.codex.ge");
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