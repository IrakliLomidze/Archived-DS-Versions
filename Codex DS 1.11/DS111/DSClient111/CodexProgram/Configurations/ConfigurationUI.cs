using System;
using System.Windows.Forms;
using ILG.DS.AppStateManagement;
using ILG.DS.Controls;
using ILG.DS.Dialogs;
using ILG.Codex.CodexR4;

namespace ILG.DS.Configurations.Dialogs
{
    public partial class ConfigurationUI : Form
    {
        bool _ShowInTaskBar = false;
        public Form1 MainForm;

        public ConfigurationUI(bool ShowInTaskBar =false)
        {
            InitializeComponent();
            _ShowInTaskBar = ShowInTaskBar;
        }


        private void FillForm()
        {
            app.state.UISettingsManager.ReadConfiguraiton();
            app.state.Current_Keyboard_Layout = app.state.UISettingsManager.content.ui_keyboard;
            try
            {
                KeyboardLayout.SelectedIndex = app.state.Current_Keyboard_Layout;
                DocumentPreviewCheckBox.Checked = app.state.UISettingsManager.content.ui_showlistpreview;
            }
            catch
            {
                KeyboardLayout.SelectedIndex = 1;
            }

            this.MaxDoc.Text = app.state.UISettingsManager.content.ui_max_list.ToString();
            this.Zoom.Text = SetZoomValue(app.state.UISettingsManager.content.ui_defaultzoom);
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
                    ILGMessageBox.Show("შეცდომაა დოკუმენტების რაოდენობაში"); return 2;
                }
            }
            
            if (this.GetzoomInt(Zoom.Text) == -1)
            {
                ILGMessageBox.Show("შეცდომაა დოკუმენტის მასშტაბში:\nდოკუმენტის მასშტაბი უნდა იყოს 10% დან 400% მდე"); return 21;
            }

            


            try
            {

                app.state.UISettingsManager.content.ui_max_list = docmaxnumber;

                //app.state.Current_Keyboard_Layout = (uint)this.KeyboardLayout.SelectedIndex;
                
                if (this.GetzoomInt(Zoom.Text) != -1) app.state.UISettingsManager.content.ui_defaultzoom = this.GetzoomInt(Zoom.Text);

                app.state.UISettingsManager.content.ui_showlistpreview = this.DocumentPreviewCheckBox.Checked;
                // New in R4
                // Conection Strings
                
                // Update Settings
                if (MainForm != null) 
                {
                    //MessageBox.Show("1");
                    MainForm.CodexZoomFactor = app.state.UISettingsManager.content.ui_defaultzoom;// global::ILG.Codex.CodexR4.Properties.Settings.Default.ZoomDS;
                    //MainForm.DS_List_ZoomFactor = global::ILG.Codex.CodexR4.Properties.Settings.Default.DocumentPreviewZoom + 8;
                }


                if (save == true) { app.state.UISettingsManager.WriteConfiguration(); } // global::ILG.Codex.CodexR4.Properties.Settings.Default.Save(); }
            }
            catch (Exception ex)
            {
                if (save == true) ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის ჩაწერა კონფიგურაციის ფაილში", ex.Message.ToString());
                else ILGMessageBox.ShowE("არ ხერხდება ინფორმაციის მიღება კონფიგურაციის ფაილში", ex.Message.ToString());
                return 3;
            }
            //ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            return 0;
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (ILGMessageBox.Show("ახალი კონფიგურაციის ჩაწერა ?", "", 
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            if (configurationApplySave(true) == 0)
            {
                ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
            }

        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            if (ILGMessageBox.Show("ახალი კონფიგურაციის მიღება ?", "",
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No) return;

            if (configurationApplySave(false) == 0)
            {
                ILGMessageBox.Show("ინფორმაცია მიღებულია");
            }
        }

        private void DetailLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (ILGMessageBox.Show("პირველადი პარამეტრების აღდგენა ? \nდაადასტურეთ!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            ConfigurationUI.FirstConfiguration();
            FillForm();
            ILGMessageBox.Show("პირველადი პარამეტრები აღდგენილია");

        }
        // Configuration Workplace
        static public void FirstConfiguration()
        {

            app.state.UISettingsManager.DefaultParameters();

        }

    
    
        static public void load()
        {
        
            
            
            #region Policy Settings
            // Pick String From Application Settings

      
            #region MaximumDocList*
            if ((DSBehaviorConfiguration.Instance.content.General.IsLimitation == true) &&
                            ((int)DSBehaviorConfiguration.Instance.content.General.AppMaxCodList > 1 ) 
                            )
            {

                app.state.UISettingsManager.content.ui_max_list = (int)DSBehaviorConfiguration.Instance.content.General.AppMaxCodList;
            }
            #endregion MaximumDocList*

     
      

            #region KeyboardLayout
           
                if ((DSBehaviorConfiguration.Instance.content.General.IsKeyboard == true) &&
                 (DSBehaviorConfiguration.Instance.content.General.AppKeyboardLayout >= 0) && (DSBehaviorConfiguration.Instance.content.General.AppKeyboardLayout < 5))
                {
                  app.state.UISettingsManager.content.ui_keyboard = (int)DSBehaviorConfiguration.Instance.content.General.AppKeyboardLayout;
                }
            
            #endregion KeyboardLayout

            #region Document Zoom
            //if (( odex.CodexR4.Properties.Settings.Default.IsGUI2 == true))
            {
                app.state.UISettingsManager.content.ui_defaultzoom = (int)DSBehaviorConfiguration.Instance.content.View.AppZoomDS;
                
               //Properties.Settings.Default.ZoomDS = (int)DSBehaviorConfiguration.Instance.content.View.AppZoomDS;
           
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
            if (ILGMessageBox.Show("ინტერფეისში პირველადი პარამეტრების აღდგენა ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;

            if (ILGMessageBox.Show("ინტერფეისში პირველადი პარამეტრების აღდგენა ? \nდაადასტურეთ!", "", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
                DialogResult.No) return;


            app.state.UISettingsManager.content.ui_defaultzoom = -20;
            app.state.UISettingsManager.content.ui_showlistpreview = true;

            FillForm();
            ILGMessageBox.Show("ინტერფეისში პირველადი პარამეტრები აღდგენილია");

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