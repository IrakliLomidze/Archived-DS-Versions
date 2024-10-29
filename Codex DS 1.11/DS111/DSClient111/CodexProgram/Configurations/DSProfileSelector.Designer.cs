namespace ILG.DS.Configurations.Dialogs
{
    partial class DSProfileSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSProfileSelector));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.DSProfileSelector_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Select_Button = new Infragistics.Win.Misc.UltraButton();
            this.CloseButton = new Infragistics.Win.Misc.UltraButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConfiguraitonTop_ICON = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.ConfiguraitonTop_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraFormManager1 = new Infragistics.Win.UltraWinForm.UltraFormManager(this.components);
            this._IDFinder_UltraFormManager_Dock_Area_Top = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._IDFinder_UltraFormManager_Dock_Area_Bottom = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._IDFinder_UltraFormManager_Dock_Area_Left = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this._IDFinder_UltraFormManager_Dock_Area_Right = new Infragistics.Win.UltraWinForm.UltraFormDockArea();
            this.DSProfileSelector_Fill_Panel.ClientArea.SuspendLayout();
            this.DSProfileSelector_Fill_Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // DSProfileSelector_Fill_Panel
            // 
            // 
            // DSProfileSelector_Fill_Panel.ClientArea
            // 
            this.DSProfileSelector_Fill_Panel.ClientArea.Controls.Add(this.panel1);
            this.DSProfileSelector_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.DSProfileSelector_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DSProfileSelector_Fill_Panel.Location = new System.Drawing.Point(1, 31);
            this.DSProfileSelector_Fill_Panel.Name = "DSProfileSelector_Fill_Panel";
            this.DSProfileSelector_Fill_Panel.Size = new System.Drawing.Size(637, 290);
            this.DSProfileSelector_Fill_Panel.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Select_Button);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.TopPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 290);
            this.panel1.TabIndex = 0;
            // 
            // Select_Button
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            appearance1.ForeColor = System.Drawing.Color.White;
            this.Select_Button.Appearance = appearance1;
            this.Select_Button.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013ScrollbarButton;
            this.Select_Button.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_Button.Location = new System.Drawing.Point(531, 254);
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.Size = new System.Drawing.Size(95, 25);
            this.Select_Button.TabIndex = 18;
            this.Select_Button.Text = "არჩევა";
            this.Select_Button.UseAppStyling = false;
            this.Select_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Select_Button.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Select_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(406, 255);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Padding = new System.Drawing.Size(8, 0);
            this.CloseButton.Size = new System.Drawing.Size(110, 24);
            this.CloseButton.TabIndex = 17;
            this.CloseButton.Text = "დახურვა";
            this.CloseButton.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.CloseButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.Size = new System.Drawing.Size(637, 186);
            this.dataGridView1.TabIndex = 16;
            // 
            // TopPanel
            // 
            this.TopPanel.ColumnCount = 2;
            this.TopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TopPanel.Controls.Add(this.ConfiguraitonTop_ICON, 0, 0);
            this.TopPanel.Controls.Add(this.ConfiguraitonTop_Label, 1, 0);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.RowCount = 1;
            this.TopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TopPanel.Size = new System.Drawing.Size(637, 52);
            this.TopPanel.TabIndex = 24;
            // 
            // ConfiguraitonTop_ICON
            // 
            this.ConfiguraitonTop_ICON.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConfiguraitonTop_ICON.AutoSize = true;
            this.ConfiguraitonTop_ICON.BackColor = System.Drawing.Color.Transparent;
            this.ConfiguraitonTop_ICON.BackColorInternal = System.Drawing.Color.Transparent;
            this.ConfiguraitonTop_ICON.BorderShadowColor = System.Drawing.Color.Empty;
            this.ConfiguraitonTop_ICON.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ConfiguraitonTop_ICON.Image = ((object)(resources.GetObject("ConfiguraitonTop_ICON.Image")));
            this.ConfiguraitonTop_ICON.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.ConfiguraitonTop_ICON.Location = new System.Drawing.Point(12, 9);
            this.ConfiguraitonTop_ICON.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.ConfiguraitonTop_ICON.Name = "ConfiguraitonTop_ICON";
            this.ConfiguraitonTop_ICON.Padding = new System.Drawing.Size(1, 1);
            this.ConfiguraitonTop_ICON.Size = new System.Drawing.Size(34, 34);
            this.ConfiguraitonTop_ICON.TabIndex = 23;
            this.ConfiguraitonTop_ICON.UseAppStyling = false;
            // 
            // ConfiguraitonTop_Label
            // 
            this.ConfiguraitonTop_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "Segoe UI";
            appearance2.FontData.SizeInPoints = 14F;
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(115)))), ((int)(((byte)(70)))));
            this.ConfiguraitonTop_Label.Appearance = appearance2;
            this.ConfiguraitonTop_Label.AutoSize = true;
            this.ConfiguraitonTop_Label.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfiguraitonTop_Label.Location = new System.Drawing.Point(61, 13);
            this.ConfiguraitonTop_Label.Name = "ConfiguraitonTop_Label";
            this.ConfiguraitonTop_Label.Padding = new System.Drawing.Size(0, 4);
            this.ConfiguraitonTop_Label.Size = new System.Drawing.Size(423, 36);
            this.ConfiguraitonTop_Label.TabIndex = 22;
            this.ConfiguraitonTop_Label.Text = "დოკუმენტების არქივი DS პროფილები";
            // 
            // ultraFormManager1
            // 
            this.ultraFormManager1.Form = this;
            this.ultraFormManager1.FormStyleSettings.FormDisplayStyle = Infragistics.Win.UltraWinToolbars.FormDisplayStyle.RoundedFixed;
            this.ultraFormManager1.FormStyleSettings.Style = Infragistics.Win.UltraWinForm.UltraFormStyle.Office2013;
            // 
            // _IDFinder_UltraFormManager_Dock_Area_Top
            // 
            this._IDFinder_UltraFormManager_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._IDFinder_UltraFormManager_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._IDFinder_UltraFormManager_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Top;
            this._IDFinder_UltraFormManager_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._IDFinder_UltraFormManager_Dock_Area_Top.FormManager = this.ultraFormManager1;
            this._IDFinder_UltraFormManager_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._IDFinder_UltraFormManager_Dock_Area_Top.Name = "_IDFinder_UltraFormManager_Dock_Area_Top";
            this._IDFinder_UltraFormManager_Dock_Area_Top.Size = new System.Drawing.Size(639, 31);
            // 
            // _IDFinder_UltraFormManager_Dock_Area_Bottom
            // 
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Bottom;
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.FormManager = this.ultraFormManager1;
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.InitialResizeAreaExtent = 1;
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 321);
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.Name = "_IDFinder_UltraFormManager_Dock_Area_Bottom";
            this._IDFinder_UltraFormManager_Dock_Area_Bottom.Size = new System.Drawing.Size(639, 1);
            // 
            // _IDFinder_UltraFormManager_Dock_Area_Left
            // 
            this._IDFinder_UltraFormManager_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._IDFinder_UltraFormManager_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._IDFinder_UltraFormManager_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Left;
            this._IDFinder_UltraFormManager_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._IDFinder_UltraFormManager_Dock_Area_Left.FormManager = this.ultraFormManager1;
            this._IDFinder_UltraFormManager_Dock_Area_Left.InitialResizeAreaExtent = 1;
            this._IDFinder_UltraFormManager_Dock_Area_Left.Location = new System.Drawing.Point(0, 31);
            this._IDFinder_UltraFormManager_Dock_Area_Left.Name = "_IDFinder_UltraFormManager_Dock_Area_Left";
            this._IDFinder_UltraFormManager_Dock_Area_Left.Size = new System.Drawing.Size(1, 290);
            // 
            // _IDFinder_UltraFormManager_Dock_Area_Right
            // 
            this._IDFinder_UltraFormManager_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._IDFinder_UltraFormManager_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._IDFinder_UltraFormManager_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinForm.DockedPosition.Right;
            this._IDFinder_UltraFormManager_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._IDFinder_UltraFormManager_Dock_Area_Right.FormManager = this.ultraFormManager1;
            this._IDFinder_UltraFormManager_Dock_Area_Right.InitialResizeAreaExtent = 1;
            this._IDFinder_UltraFormManager_Dock_Area_Right.Location = new System.Drawing.Point(638, 31);
            this._IDFinder_UltraFormManager_Dock_Area_Right.Name = "_IDFinder_UltraFormManager_Dock_Area_Right";
            this._IDFinder_UltraFormManager_Dock_Area_Right.Size = new System.Drawing.Size(1, 290);
            // 
            // DSProfileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(639, 322);
            this.Controls.Add(this.DSProfileSelector_Fill_Panel);
            this.Controls.Add(this._IDFinder_UltraFormManager_Dock_Area_Left);
            this.Controls.Add(this._IDFinder_UltraFormManager_Dock_Area_Right);
            this.Controls.Add(this._IDFinder_UltraFormManager_Dock_Area_Top);
            this.Controls.Add(this._IDFinder_UltraFormManager_Dock_Area_Bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DSProfileSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS Profile Selector";
            this.Load += new System.EventHandler(this.DSProfileSelector_Load);
            this.DSProfileSelector_Fill_Panel.ClientArea.ResumeLayout(false);
            this.DSProfileSelector_Fill_Panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraFormManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraPanel DSProfileSelector_Fill_Panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel TopPanel;
        private Infragistics.Win.UltraWinEditors.UltraPictureBox ConfiguraitonTop_ICON;
        private Infragistics.Win.Misc.UltraLabel ConfiguraitonTop_Label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Infragistics.Win.UltraWinForm.UltraFormManager ultraFormManager1;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _IDFinder_UltraFormManager_Dock_Area_Left;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _IDFinder_UltraFormManager_Dock_Area_Right;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _IDFinder_UltraFormManager_Dock_Area_Top;
        private Infragistics.Win.UltraWinForm.UltraFormDockArea _IDFinder_UltraFormManager_Dock_Area_Bottom;
        private Infragistics.Win.Misc.UltraButton CloseButton;
        private Infragistics.Win.Misc.UltraButton Select_Button;
    }
}