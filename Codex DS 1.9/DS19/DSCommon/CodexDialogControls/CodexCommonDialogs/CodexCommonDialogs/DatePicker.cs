using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinSchedule;

namespace ILG.Codex.CodexR4
{

    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class PickDate : System.Windows.Forms.Form
    {
        private Infragistics.Win.UltraWinSchedule.UltraCalendarInfo ultraCalendarInfo1;
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor comboBoxMonth;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor comboBoxYear;
        private Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti ultraMonthViewMulti1;
        private Infragistics.Win.Misc.UltraButton Button_Ok;
        private Infragistics.Win.Misc.UltraButton Button_Today;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarLook ultraCalendarLook1;
        private Infragistics.Win.Misc.UltraButton Button_Cancel;
        private Infragistics.Win.Misc.UltraButton ultraButtonRight;
        private Infragistics.Win.Misc.UltraButton ultraButtonLeft;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;

        public DateTime PickedDate;
        private System.Windows.Forms.ToolTip toolTip1;
        public bool Canceled;
        bool isICG = false;
        private Infragistics.Win.Misc.UltraPanel MainPanel;
        int startfrom;


        public PickDate(DateTime initv, bool isICGDate = false)
        {

            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            isICG = isICGDate;
            this.Canceled = false;

            PickedDate = initv;


            this._Day = PickedDate.Day;
            this._Month = PickedDate.Month;
            this._Year = PickedDate.Year;


            startfrom = 1973;

            if (isICG == true) startfrom = 1900;

            for (int i = startfrom; i <= 2048; i++)
                comboBoxYear.Items.Add(i);


            comboBoxMonth.Items.Add("იანვარი");
            comboBoxMonth.Items.Add("თებერვალი");
            comboBoxMonth.Items.Add("მარტი");
            comboBoxMonth.Items.Add("აპრილი");
            comboBoxMonth.Items.Add("მაისი");
            comboBoxMonth.Items.Add("ივნისი");
            comboBoxMonth.Items.Add("ივლისი");
            comboBoxMonth.Items.Add("აგვისტო");
            comboBoxMonth.Items.Add("სექტემბერი");
            comboBoxMonth.Items.Add("ოქტომბერი");
            comboBoxMonth.Items.Add("ნოემბერი");
            comboBoxMonth.Items.Add("დეკემბერი");

            this.comboBoxMonth.SelectedIndex = PickedDate.Month - 1;
            this.comboBoxYear.SelectedIndex = PickedDate.Year - startfrom;

            this.ultraMonthViewMulti1.CalendarInfo.MaxDate = new DateTime(2048, 12, 31);
            this.ultraMonthViewMulti1.CalendarInfo.MinDate = new DateTime(startfrom, 1, 1);

            Graphics gfx = CreateGraphics();
            //int w = (int)gfx.MeasureString("ÃÙÄÓ: 28 ÈÄÁÄÒÅÀËÉ 2004",this.Font).Width;



            int w2 = (int)gfx.MeasureString(" თებერვალი  ", this.Font).Width;
            this.comboBoxMonth.Width = 8 + w2 + 20;

            int w3 = (int)gfx.MeasureString(" 2005 ", this.Font).Width;
            //this.ultraNumericEditor1.Width = 4+w3+20;

            ultraButtonLeft.Top = 0;
            ultraButtonLeft.Left = 0;
            ultraButtonLeft.Height = comboBoxMonth.Height;
            comboBoxMonth.Top = 0;
            comboBoxMonth.Left = ultraButtonLeft.Left + ultraButtonLeft.Width;
            comboBoxYear.Top = 0;
            comboBoxYear.Left = comboBoxMonth.Left + comboBoxMonth.Width;
            this.ultraButtonRight.Top = 0;
            this.ultraButtonRight.Left = comboBoxYear.Left + comboBoxYear.Width;
            this.panel1.Height = this.comboBoxMonth.Height;
            this.panel1.Width = this.ultraButtonRight.Left + this.ultraButtonRight.Width;
            this.panel1.Top = 0;
            this.panel1.Left = 0;
            this.ultraMonthViewMulti1.Left = 0;
            this.ultraMonthViewMulti1.MonthPadding = new Size((this.panel1.Width - this.ultraMonthViewMulti1.Width) / 2 + 4, 4);
            this.ultraMonthViewMulti1.Top = this.panel1.Height;
            this.Button_Today.Width = this.panel1.Width;
            this.Button_Today.Left = 0;

            this.Button_Today.Text = "დღეს: " + DateToString(DateTime.Now);// 28 ÈÄÁÄÒÅÀËÉ 2004";
            this.Button_Cancel.Width = this.Button_Today.Width / 2;
            this.Button_Ok.Width = this.Button_Today.Width - this.Button_Cancel.Width;
            this.Button_Today.Focus();
            this.Button_Today.Top = this.ultraMonthViewMulti1.Top + this.ultraMonthViewMulti1.Height;
            this.Button_Ok.Left = 0;
            this.Button_Ok.Top = this.Button_Today.Top + this.Button_Today.Height;
            this.Button_Cancel.Text = "უარი";
            this.Button_Cancel.Left = this.Button_Cancel.Width;
            this.Button_Cancel.Top = this.Button_Ok.Top;
            this.Button_Ok.Text = "თანხმობა";

            MainPanel.Left = 0;
            MainPanel.Top = 0;
            MainPanel.Height = 0;
            MainPanel.Width = panel1.Width;
            MainPanel.Height = Button_Cancel.Top + Button_Cancel.Height;
            this.ClientSize = new Size(MainPanel.Left + MainPanel.Width, MainPanel.Top + MainPanel.Height);



            DateTime dt = this.PickedDate;
            this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Clear();
            this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Add(dt);

            foreach (DateRange range in this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges)
            {
                foreach (Infragistics.Win.UltraWinSchedule.Day day in range.Days)
                {
                    this.ultraMonthViewMulti1.CalendarInfo.ActiveDay = day;
                }
            }
            this.revisible();







        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickDate));
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraButtonLeft = new Infragistics.Win.Misc.UltraButton();
            this.ultraButtonRight = new Infragistics.Win.Misc.UltraButton();
            this.comboBoxYear = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.comboBoxMonth = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraMonthViewMulti1 = new Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti();
            this.ultraCalendarInfo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo(this.components);
            this.ultraCalendarLook1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarLook(this.components);
            this.Button_Ok = new Infragistics.Win.Misc.UltraButton();
            this.Button_Today = new Infragistics.Win.Misc.UltraButton();
            this.Button_Cancel = new Infragistics.Win.Misc.UltraButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainPanel = new Infragistics.Win.Misc.UltraPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewMulti1)).BeginInit();
            this.MainPanel.ClientArea.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ultraButtonLeft);
            this.panel1.Controls.Add(this.ultraButtonRight);
            this.panel1.Controls.Add(this.comboBoxYear);
            this.panel1.Controls.Add(this.comboBoxMonth);
            this.panel1.Location = new System.Drawing.Point(18, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 24);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ultraButtonLeft
            // 
            appearance1.Image = CodexR4.CommonDialogs.Properties.Resources.Roght3;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraButtonLeft.Appearance = appearance1;
            this.ultraButtonLeft.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraButtonLeft.Font = new System.Drawing.Font("Wingdings 3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ultraButtonLeft.ImageTransparentColor = System.Drawing.Color.Empty;
            this.ultraButtonLeft.Location = new System.Drawing.Point(0, 0);
            this.ultraButtonLeft.Name = "ultraButtonLeft";
            this.ultraButtonLeft.ShowFocusRect = false;
            this.ultraButtonLeft.ShowOutline = false;
            this.ultraButtonLeft.Size = new System.Drawing.Size(24, 23);
            this.ultraButtonLeft.TabIndex = 2;
            this.toolTip1.SetToolTip(this.ultraButtonLeft, "უკან");
            this.ultraButtonLeft.UseAppStyling = false;
            this.ultraButtonLeft.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButtonLeft.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButtonLeft.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButtonLeft.Click += new System.EventHandler(this.ultraButtonLeft_Click);
            this.ultraButtonLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // ultraButtonRight
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.Name = "Wingdings 3";
            appearance2.Image = CodexR4.CommonDialogs.Properties.Resources.Left3;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraButtonRight.Appearance = appearance2;
            this.ultraButtonRight.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraButtonRight.Font = new System.Drawing.Font("Wingdings 3", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.ultraButtonRight.ImageTransparentColor = System.Drawing.Color.Empty;
            this.ultraButtonRight.Location = new System.Drawing.Point(208, 0);
            this.ultraButtonRight.Name = "ultraButtonRight";
            this.ultraButtonRight.ShowFocusRect = false;
            this.ultraButtonRight.ShowOutline = false;
            this.ultraButtonRight.Size = new System.Drawing.Size(24, 23);
            this.ultraButtonRight.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ultraButtonRight, "წინ");
            this.ultraButtonRight.UseAppStyling = false;
            this.ultraButtonRight.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButtonRight.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ultraButtonRight.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraButtonRight.Click += new System.EventHandler(this.ultraButtonRight_Click);
            this.ultraButtonRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // comboBoxYear
            // 
            appearance3.FontData.Name = "Sylfaen";
            appearance3.FontData.SizeInPoints = 9F;
            this.comboBoxYear.Appearance = appearance3;
            this.comboBoxYear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ScenicRibbonButton;
            this.comboBoxYear.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.comboBoxYear.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.comboBoxYear.Location = new System.Drawing.Point(128, 0);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(64, 23);
            this.comboBoxYear.TabIndex = 4;
            this.comboBoxYear.UseAppStyling = false;
            this.comboBoxYear.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.comboBoxYear.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.comboBoxYear.SelectionChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
            this.comboBoxYear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // comboBoxMonth
            // 
            appearance4.FontData.Name = "Sylfaen";
            appearance4.FontData.SizeInPoints = 9F;
            this.comboBoxMonth.Appearance = appearance4;
            this.comboBoxMonth.ButtonStyle = Infragistics.Win.UIElementButtonStyle.ScenicRibbonButton;
            this.comboBoxMonth.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2013;
            this.comboBoxMonth.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.comboBoxMonth.Location = new System.Drawing.Point(0, 0);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(128, 23);
            this.comboBoxMonth.TabIndex = 3;
            this.comboBoxMonth.UseAppStyling = false;
            this.comboBoxMonth.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.comboBoxMonth.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.comboBoxMonth.SelectionChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
            this.comboBoxMonth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // ultraMonthViewMulti1
            // 
            this.ultraMonthViewMulti1.AllowMonthPopup = false;
            this.ultraMonthViewMulti1.AllowMonthSelection = false;
            this.ultraMonthViewMulti1.AllowWeekSelection = false;
            appearance5.FontData.Name = "Microsoft Sans Serif";
            appearance5.FontData.SizeInPoints = 9F;
            this.ultraMonthViewMulti1.Appearance = appearance5;
            this.ultraMonthViewMulti1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraMonthViewMulti1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.ultraMonthViewMulti1.CalendarInfo = this.ultraCalendarInfo1;
            this.ultraMonthViewMulti1.CalendarLook = this.ultraCalendarLook1;
            this.ultraMonthViewMulti1.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.FirstTwoLetters;
            this.ultraMonthViewMulti1.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow;
            this.ultraMonthViewMulti1.Location = new System.Drawing.Point(18, 43);
            this.ultraMonthViewMulti1.MonthHeadersVisible = false;
            this.ultraMonthViewMulti1.MonthPadding = new System.Drawing.Size(4, 3);
            this.ultraMonthViewMulti1.Name = "ultraMonthViewMulti1";
            this.ultraMonthViewMulti1.PlaceHoldersVisible = true;
            this.ultraMonthViewMulti1.Size = new System.Drawing.Size(201, 124);
            this.ultraMonthViewMulti1.TabIndex = 1;
            this.ultraMonthViewMulti1.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            this.ultraMonthViewMulti1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ultraMonthViewMulti1.BeforeMonthScroll += new Infragistics.Win.UltraWinSchedule.BeforeMonthScrollEventHandler(this.ultraMonthViewMulti1_BeforeMonthScroll);
            this.ultraMonthViewMulti1.DoubleClick += new System.EventHandler(this.ultraMonthViewMulti1_DoubleClick);
            this.ultraMonthViewMulti1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // ultraCalendarInfo1
            // 
            this.ultraCalendarInfo1.MaxSelectedDays = 1;
            // 
            // ultraCalendarLook1
            // 
            appearance6.FontData.BoldAsString = "True";
            appearance6.FontData.Name = "Microsoft Sans Serif";
            appearance6.FontData.SizeInPoints = 9F;
            this.ultraCalendarLook1.DayAppearance = appearance6;
            appearance7.FontData.BoldAsString = "True";
            this.ultraCalendarLook1.DayOfWeekHeaderAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.LightBlue;
            appearance8.FontData.BoldAsString = "True";
            appearance8.FontData.Name = "Sylfaen";
            appearance8.FontData.SizeInPoints = 9F;
            this.ultraCalendarLook1.SelectedDayAppearance = appearance8;
            this.ultraCalendarLook1.ViewStyle = Infragistics.Win.UltraWinSchedule.ViewStyle.Office2007;
            // 
            // Button_Ok
            // 
            this.Button_Ok.BackColorInternal = System.Drawing.Color.CornflowerBlue;
            this.Button_Ok.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Ok.Location = new System.Drawing.Point(18, 222);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.ShowFocusRect = false;
            this.Button_Ok.ShowOutline = false;
            this.Button_Ok.Size = new System.Drawing.Size(88, 23);
            this.Button_Ok.TabIndex = 7;
            this.Button_Ok.Text = "OK";
            this.Button_Ok.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Ok.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Ok.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Ok.Click += new System.EventHandler(this.ultraButton1_Click_1);
            this.Button_Ok.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // Button_Today
            // 
            this.Button_Today.BackColorInternal = System.Drawing.Color.LightSteelBlue;
            this.Button_Today.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Today.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Today.Location = new System.Drawing.Point(26, 196);
            this.Button_Today.Name = "Button_Today";
            this.Button_Today.ShowFocusRect = false;
            this.Button_Today.ShowOutline = false;
            this.Button_Today.Size = new System.Drawing.Size(200, 20);
            this.Button_Today.TabIndex = 6;
            this.Button_Today.Text = "ultraButton3";
            this.Button_Today.UseAppStyling = false;
            this.Button_Today.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Today.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Today.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Today.Click += new System.EventHandler(this.ultraButton3_Click);
            this.Button_Today.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.BackColorInternal = System.Drawing.Color.CornflowerBlue;
            this.Button_Cancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2013Button;
            this.Button_Cancel.Location = new System.Drawing.Point(114, 222);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.ShowFocusRect = false;
            this.Button_Cancel.ShowOutline = false;
            this.Button_Cancel.Size = new System.Drawing.Size(96, 23);
            this.Button_Cancel.TabIndex = 8;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Cancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Button_Cancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Button_Cancel.Click += new System.EventHandler(this.ultraButton2_Click);
            this.Button_Cancel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // MainPanel
            // 
            appearance9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.MainPanel.Appearance = appearance9;
            this.MainPanel.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // MainPanel.ClientArea
            // 
            this.MainPanel.ClientArea.Controls.Add(this.panel1);
            this.MainPanel.ClientArea.Controls.Add(this.Button_Cancel);
            this.MainPanel.ClientArea.Controls.Add(this.Button_Today);
            this.MainPanel.ClientArea.Controls.Add(this.ultraMonthViewMulti1);
            this.MainPanel.ClientArea.Controls.Add(this.Button_Ok);
            this.MainPanel.Location = new System.Drawing.Point(22, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(395, 260);
            this.MainPanel.TabIndex = 22;
            // 
            // PickDate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(729, 371);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PickDate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PickDate_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewMulti1)).EndInit();
            this.MainPanel.ClientArea.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        private int DaysinMonth(int Month, int Year)
        {
            int Count = 0;
            switch (Month)
            {
                case 1: Count = 31; break;
                case 2: Count = 28; if (((Year % 4) == 0) && (Year != 1900)) Count = 29; break;
                case 3: Count = 31; break;
                case 4: Count = 30; break;
                case 5: Count = 31; break;
                case 6: Count = 30; break;
                case 7: Count = 31; break;
                case 8: Count = 31; break;
                case 9: Count = 30; break;
                case 10: Count = 31; break;
                case 11: Count = 30; break;
                case 12: Count = 31; break;
            }
            return Count;
        }
        private static String MonthToString(int Month)
        {
            String Str = "";
            switch (Month)
            {
                case 1: Str = "იანვარი"; break;
                case 2: Str = "თებერვალი"; break;
                case 3: Str = "მარტი"; break;
                case 4: Str = "აპრილი"; break;
                case 5: Str = "მაისი"; break;
                case 6: Str = "ივნისი"; break;
                case 7: Str = "ივლისი"; break;
                case 8: Str = "აგვისტო"; break;
                case 9: Str = "სექტემბერი"; break;
                case 10: Str = "ოქტომბერი"; break;
                case 11: Str = "ნოემბერი"; break;
                case 12: Str = "დეკემბერი"; break;
            }
            return Str;

        }

        private static int StringToMonth(String Month)
        {
            int Ret = 0; ;
            switch (Month)
            {
                case "იანვარი": Ret = 1; break;
                case "თებერვალი": Ret = 2; break;
                case "მარტი": Ret = 3; break;
                case "აპრილი": Ret = 4; break;
                case "მაისი": Ret = 5; break;
                case "ივნისი": Ret = 6; break;
                case "ივლისი": Ret = 7; break;
                case "აგვისტო": Ret = 8; break;
                case "სექტემბერი": Ret = 9; break;
                case "ოქტომბერი": Ret = 10; break;
                case "ნოემბერი": Ret = 11; break;
                case "დეკემბერი": Ret = 12; break;
            }
            return Ret;

        }


        // Calendat Info
        int _Year;
        int _Month;
        int _Day;



        public static String DateToString(DateTime D)
        {
            return D.Day.ToString() + " " + MonthToString(D.Month) + " " + D.Year.ToString();
        }




        public override String ToString()
        {
            return PickedDate.Day.ToString() + " " + MonthToString(PickedDate.Month) + " " + PickedDate.Year.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void ultraButton1_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, System.EventArgs e)
        {

        }



        void revisible()
        {
            this._Day = this.ultraMonthViewMulti1.CalendarInfo.ActiveDay.Date.Day;
            if (DaysinMonth(_Month, _Year) < _Day) _Day = DaysinMonth(_Month, _Year);
            //    Get the current month
            DateTime dt = new DateTime(this._Year, this._Month, this._Day);
            Infragistics.Win.UltraWinSchedule.Month month;
            month = this.ultraMonthViewMulti1.CalendarInfo.GetMonth(dt);

            //    Set the  control‘s FirstMonth property to the current month
            this.ultraMonthViewMulti1.FirstMonth = month;

            //this.ultraMonthViewMulti1.FirstMonth.DaysInMonth

            //    Set the MonthDimensions property to only display one month
            this.ultraMonthViewMulti1.MonthDimensions = new Size(1, 1);

            //    Set the TrailingDaysVisible property to false so that only days
            //    that fall in the month being displayed are visible
            this.ultraMonthViewMulti1.TrailingDaysVisible = false;

            //    Set the PlaceHoldersVisible property to false, so that if the
            //    BorderStyleDay property is set a value other than None, borders
            //    are not drawn for the leading and trailing days
            this.ultraMonthViewMulti1.PlaceHoldersVisible = false;

            //    Hide the scroll buttons, so the user cannot change which
            //    month is being displayed
            ultraMonthViewMulti1.MonthScrollButtonsVisible = DefaultableBoolean.False;
            ultraMonthViewMulti1.YearScrollButtonsVisible = DefaultableBoolean.False;


            //ScrollButtonsVisible = false;


        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this._Month = this.comboBoxMonth.SelectedIndex + 1;
            this.revisible();

        }

        private void comboBoxYear_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this._Year = this.comboBoxYear.SelectedIndex + startfrom;
            this.revisible();
        }



        private void ultraMonthViewMulti1_BeforeMonthScroll(object sender, Infragistics.Win.UltraWinSchedule.BeforeMonthScrollEventArgs e)
        {
            this._Day = this.ultraMonthViewMulti1.CalendarInfo.ActiveDay.Date.Day;
            this._Month = e.NewFirstMonth.MonthNumber;
            this._Year = e.NewFirstMonth.Year.YearNumber;
            this.comboBoxMonth.SelectedIndex = _Month - 1;
            this.comboBoxYear.SelectedIndex = _Year - startfrom;

            if (DaysinMonth(_Month, _Year) < _Day) _Day = DaysinMonth(_Month, _Year);

            //MessageBox.Show(_Year.ToString() + " " +_Month.ToString()+ " " + _Day.ToString() );


            DateTime dt = new DateTime(_Year, _Month, _Day);
            this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Clear();
            this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Add(dt);

            foreach (DateRange range in this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges)
            {
                foreach (Infragistics.Win.UltraWinSchedule.Day day in range.Days)
                {
                    this.ultraMonthViewMulti1.CalendarInfo.ActiveDay = day;
                }
            }



        }

        private void ultraButton1_Click_1(object sender, System.EventArgs e)
        {
            this.PickedDate = this.ultraMonthViewMulti1.CalendarInfo.ActiveDay.Date;
            this.Canceled = false;
            Close();
        }

        private void ultraButton2_Click(object sender, System.EventArgs e)
        {
            this.Canceled = true;
            Close();

        }

        private void ultraNumericEditor1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void ultraButton3_Click(object sender, System.EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            this._Day = dt.Day;
            this._Month = dt.Month;
            this._Year = dt.Year;
            this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Clear();
            this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Add(dt);

            foreach (DateRange range in this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges)
            {
                foreach (Infragistics.Win.UltraWinSchedule.Day day in range.Days)
                {
                    this.ultraMonthViewMulti1.CalendarInfo.ActiveDay = day;
                }
            }
            this.revisible();

        }

        private void ultraButtonLeft_Click(object sender, System.EventArgs e)
        {
            if (this._Month == 1) { this._Month = 12; this._Year--; }
            else this._Month--;
            this.revisible();
        }

        private void ultraButtonRight_Click(object sender, System.EventArgs e)
        {
            if (this._Month == 12) { this._Month = 1; this._Year++; }
            else this._Month++;
            this.revisible();
        }


        private void PickDate_Load(object sender, System.EventArgs e)
        {
            this.SuspendLayout();
            Point p = new Point(Location.X, Location.Y);
            p.Y = p.Y - this.ClientSize.Height;
            Location = p;
            this.ResumeLayout();


        }

        private void PickDate_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.ultraButton2_Click(null, null);
            if (e.KeyCode == Keys.Enter) this.ultraButton1_Click_1(null, null);
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void ultraMonthViewMulti1_DoubleClick(object sender, System.EventArgs e)
        {

            this.ultraButton1_Click_1(null, null);

        }



    }

}