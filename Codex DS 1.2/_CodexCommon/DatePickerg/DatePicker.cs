using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinSchedule;

namespace ILG
{
	namespace Codex
	{
		namespace WindowsForms

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
				private Infragistics.Win.Misc.UltraButton ultraButton1;
				private Infragistics.Win.Misc.UltraButton ultraButton3;
				private Infragistics.Win.UltraWinSchedule.UltraCalendarLook ultraCalendarLook1;
				private Infragistics.Win.Misc.UltraButton ultraButton2;
				private Infragistics.Win.Misc.UltraButton ultraButtonRight;
				private Infragistics.Win.Misc.UltraButton ultraButtonLeft;
				private System.Windows.Forms.ImageList imageList1;
				private System.ComponentModel.IContainer components;

				public  DateTime PickedDate;
				private System.Windows.Forms.ToolTip toolTip1;
				public  bool Canceled ;

				public PickDate(DateTime initv)
				{
					
					//
					// Required for Windows Form Designer support
					//
					InitializeComponent();

					this.Canceled = false;

					PickedDate = initv;
					
					
					this._Day = PickedDate.Day;
					this._Month = PickedDate.Month;
					this._Year = PickedDate.Year;
					
					

					for(int i=1973;i<=2010;i++)
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

					this.comboBoxMonth.SelectedIndex = PickedDate.Month-1;
					this.comboBoxYear.SelectedIndex = PickedDate.Year - 1973;
					
					this.ultraMonthViewMulti1.CalendarInfo.MaxDate = new DateTime(2010,12,31);
					this.ultraMonthViewMulti1.CalendarInfo.MinDate = new DateTime(1973,1,1);

					Graphics gfx = CreateGraphics();
					//int w = (int)gfx.MeasureString("ÃÙÄÓ: 28 ÈÄÁÄÒÅÀËÉ 2004",this.Font).Width;

					

					int w2 = (int)gfx.MeasureString(" თებერვალი  ",this.Font).Width;
					this.comboBoxMonth.Width = 8+w2+20;

					int w3 = (int)gfx.MeasureString(" 2005 ",this.Font).Width;
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
					this.ultraMonthViewMulti1.MonthPadding = new Size((this.panel1.Width - this.ultraMonthViewMulti1.Width)/2+4,4);
					this.ultraMonthViewMulti1.Top = this.panel1.Height;
					this.ultraButton3.Width = this.panel1.Width;
					this.ultraButton3.Left = 0;
					
					this.ultraButton3.Text = "დღეს: "+DateToString(DateTime.Now);// 28 ÈÄÁÄÒÅÀËÉ 2004";
					this.ultraButton2.Width = this.ultraButton3.Width / 2;
					this.ultraButton1.Width = this.ultraButton3.Width - this.ultraButton2.Width;
					this.ultraButton3.Focus();
					this.ultraButton3.Top = this.ultraMonthViewMulti1.Top + this.ultraMonthViewMulti1.Height;
					this.ultraButton1.Left = 0;
					this.ultraButton1.Top = this.ultraButton3.Top + this.ultraButton3.Height;
					this.ultraButton2.Text = "უარი";
					this.ultraButton2.Left = this.ultraButton2.Width;
					this.ultraButton2.Top = this.ultraButton1.Top;
					this.ultraButton1.Text = "თანხმობა";

					this.ClientSize = new Size(panel1.Width,ultraButton2.Top + ultraButton2.Height);

					

					DateTime dt = this.PickedDate;
					this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Clear();
					this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Add(dt);

					foreach ( DateRange range in this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges )
					{
						foreach( Infragistics.Win.UltraWinSchedule.Day day in range.Days)
						{ 
							this.ultraMonthViewMulti1.CalendarInfo.ActiveDay = day;
						}
					}
					this.revisible();
					
			
					
					


						
				}

				/// <summary>
				/// Clean up any resources being used.
				/// </summary>
				protected override void Dispose( bool disposing )
				{
					if( disposing )
					{
						if (components != null) 
						{
							components.Dispose();
						}
					}
					base.Dispose( disposing );
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
					Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
					Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
					Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
					System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PickDate));
					this.ultraCalendarInfo1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarInfo();
					this.panel1 = new System.Windows.Forms.Panel();
					this.ultraButtonLeft = new Infragistics.Win.Misc.UltraButton();
					this.ultraButtonRight = new Infragistics.Win.Misc.UltraButton();
					this.comboBoxYear = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
					this.comboBoxMonth = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
					this.ultraMonthViewMulti1 = new Infragistics.Win.UltraWinSchedule.UltraMonthViewMulti();
					this.ultraCalendarLook1 = new Infragistics.Win.UltraWinSchedule.UltraCalendarLook();
					this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
					this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
					this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
					this.imageList1 = new System.Windows.Forms.ImageList(this.components);
					this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
					this.panel1.SuspendLayout();
					((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewMulti1)).BeginInit();
					this.SuspendLayout();
					// 
					// ultraCalendarInfo1
					// 
					this.ultraCalendarInfo1.MaxSelectedDays = 1;
					// 
					// panel1
					// 
					this.panel1.BackColor = System.Drawing.Color.SteelBlue;
					this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					this.panel1.Controls.Add(this.ultraButtonLeft);
					this.panel1.Controls.Add(this.ultraButtonRight);
					this.panel1.Controls.Add(this.comboBoxYear);
					this.panel1.Controls.Add(this.comboBoxMonth);
					this.panel1.Location = new System.Drawing.Point(8, 8);
					this.panel1.Name = "panel1";
					this.panel1.Size = new System.Drawing.Size(232, 24);
					this.panel1.TabIndex = 21;
					this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
					// 
					// ultraButtonLeft
					// 
					appearance1.ForeColor = System.Drawing.Color.White;
					this.ultraButtonLeft.Appearance = appearance1;
					this.ultraButtonLeft.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButtonLeft.FlatMode = true;
					this.ultraButtonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					this.ultraButtonLeft.ImageTransparentColor = System.Drawing.Color.Empty;
					this.ultraButtonLeft.Location = new System.Drawing.Point(0, 0);
					this.ultraButtonLeft.Name = "ultraButtonLeft";
					this.ultraButtonLeft.Size = new System.Drawing.Size(24, 23);
					this.ultraButtonLeft.SupportThemes = false;
					this.ultraButtonLeft.TabIndex = 38;
					this.ultraButtonLeft.Text = "<";
					this.toolTip1.SetToolTip(this.ultraButtonLeft, "უკან");
					this.ultraButtonLeft.Click += new System.EventHandler(this.ultraButtonLeft_Click);
					this.ultraButtonLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					// 
					// ultraButtonRight
					// 
					appearance2.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					appearance2.FontData.Name = "Microsoft Sans Serif";
					appearance2.ForeColor = System.Drawing.Color.White;
					this.ultraButtonRight.Appearance = appearance2;
					this.ultraButtonRight.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButtonRight.FlatMode = true;
					this.ultraButtonRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					this.ultraButtonRight.ImageTransparentColor = System.Drawing.Color.Empty;
					this.ultraButtonRight.Location = new System.Drawing.Point(208, 0);
					this.ultraButtonRight.Name = "ultraButtonRight";
					this.ultraButtonRight.Size = new System.Drawing.Size(24, 23);
					this.ultraButtonRight.SupportThemes = false;
					this.ultraButtonRight.TabIndex = 37;
					this.ultraButtonRight.Text = ">";
					this.toolTip1.SetToolTip(this.ultraButtonRight, "წინ");
					this.ultraButtonRight.Click += new System.EventHandler(this.ultraButtonRight_Click);
					this.ultraButtonRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					// 
					// comboBoxYear
					// 
					appearance3.FontData.Name = "Geo_Times";
					appearance3.FontData.SizeInPoints = 9F;
					this.comboBoxYear.Appearance = appearance3;
					this.comboBoxYear.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
					this.comboBoxYear.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
					this.comboBoxYear.FlatMode = true;
					this.comboBoxYear.Location = new System.Drawing.Point(128, 0);
					this.comboBoxYear.Name = "comboBoxYear";
					this.comboBoxYear.Size = new System.Drawing.Size(64, 20);
					this.comboBoxYear.SupportThemes = false;
					this.comboBoxYear.TabIndex = 18;
					this.comboBoxYear.Text = null;
					this.comboBoxYear.SelectionChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
					this.comboBoxYear.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					// 
					// comboBoxMonth
					// 
					appearance4.FontData.Name = "Geo_Times";
					appearance4.FontData.SizeInPoints = 9F;
					this.comboBoxMonth.Appearance = appearance4;
					this.comboBoxMonth.AutoSize = false;
					this.comboBoxMonth.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
					this.comboBoxMonth.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
					this.comboBoxMonth.FlatMode = true;
					this.comboBoxMonth.Location = new System.Drawing.Point(0, 0);
					this.comboBoxMonth.Name = "comboBoxMonth";
					this.comboBoxMonth.Size = new System.Drawing.Size(128, 21);
					this.comboBoxMonth.SupportThemes = false;
					this.comboBoxMonth.TabIndex = 17;
					this.comboBoxMonth.Text = null;
					this.comboBoxMonth.SelectionChanged += new System.EventHandler(this.comboBoxMonth_SelectedIndexChanged);
					this.comboBoxMonth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					// 
					// ultraMonthViewMulti1
					// 
					this.ultraMonthViewMulti1.AllowMonthPopup = false;
					this.ultraMonthViewMulti1.AllowMonthSelection = false;
					this.ultraMonthViewMulti1.AllowWeekSelection = false;
					appearance5.BackColor = System.Drawing.Color.White;
					appearance5.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(64)));
					appearance5.FontData.Name = "Sylfaen";
					appearance5.FontData.SizeInPoints = 9F;
					this.ultraMonthViewMulti1.Appearance = appearance5;
					this.ultraMonthViewMulti1.BackColor = System.Drawing.SystemColors.Window;
					this.ultraMonthViewMulti1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
					this.ultraMonthViewMulti1.CalendarInfo = this.ultraCalendarInfo1;
					this.ultraMonthViewMulti1.CalendarLook = this.ultraCalendarLook1;
					this.ultraMonthViewMulti1.DayOfWeekCaptionStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekCaptionStyle.FirstTwoLetters;
					this.ultraMonthViewMulti1.DayOfWeekDisplayStyle = Infragistics.Win.UltraWinSchedule.DayOfWeekDisplayStyle.FirstRow;
					this.ultraMonthViewMulti1.FlatMode = true;
					this.ultraMonthViewMulti1.Location = new System.Drawing.Point(8, 56);
					this.ultraMonthViewMulti1.MonthHeadersVisible = false;
					this.ultraMonthViewMulti1.MonthPadding = new System.Drawing.Size(4, 3);
					this.ultraMonthViewMulti1.Name = "ultraMonthViewMulti1";
					this.ultraMonthViewMulti1.PlaceHoldersVisible = true;
					this.ultraMonthViewMulti1.Size = new System.Drawing.Size(194, 138);
					this.ultraMonthViewMulti1.SupportThemes = false;
					this.ultraMonthViewMulti1.TabIndex = 29;
					this.ultraMonthViewMulti1.DoubleClick += new System.EventHandler(this.ultraMonthViewMulti1_DoubleClick);
					this.ultraMonthViewMulti1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					this.ultraMonthViewMulti1.BeforeMonthScroll += new Infragistics.Win.UltraWinSchedule.BeforeMonthScrollEventHandler(this.ultraMonthViewMulti1_BeforeMonthScroll);
					// 
					// ultraCalendarLook1
					// 
					appearance6.BackColor = System.Drawing.Color.LightSteelBlue;
					appearance6.BorderColor = System.Drawing.Color.Navy;
					appearance6.BorderColor3DBase = System.Drawing.Color.Navy;
					appearance6.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					appearance6.ForeColor = System.Drawing.Color.Black;
					this.ultraCalendarLook1.ActiveDayAppearance = appearance6;
					appearance7.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					appearance7.FontData.Name = "Geo_Times";
					appearance7.FontData.SizeInPoints = 9F;
					this.ultraCalendarLook1.DayAppearance = appearance7;
					appearance8.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					this.ultraCalendarLook1.DayOfWeekHeaderAppearance = appearance8;
					appearance9.BackColor = System.Drawing.Color.LightSteelBlue;
					appearance9.BorderColor = System.Drawing.Color.Navy;
					appearance9.BorderColor3DBase = System.Drawing.Color.Navy;
					appearance9.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					appearance9.FontData.Name = "Geo_Times";
					appearance9.FontData.SizeInPoints = 9F;
					this.ultraCalendarLook1.SelectedDayAppearance = appearance9;
					// 
					// ultraButton1
					// 
					appearance10.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
					this.ultraButton1.Appearance = appearance10;
					this.ultraButton1.BackColor = System.Drawing.Color.CornflowerBlue;
					this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButton1.Location = new System.Drawing.Point(0, 216);
					this.ultraButton1.Name = "ultraButton1";
					this.ultraButton1.Size = new System.Drawing.Size(88, 23);
					this.ultraButton1.SupportThemes = false;
					this.ultraButton1.TabIndex = 30;
					this.ultraButton1.Text = "ultraButton1";
					this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click_1);
					this.ultraButton1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					// 
					// ultraButton3
					// 
					this.ultraButton3.BackColor = System.Drawing.Color.LightSteelBlue;
					this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButton3.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					this.ultraButton3.Location = new System.Drawing.Point(0, 192);
					this.ultraButton3.Name = "ultraButton3";
					this.ultraButton3.Size = new System.Drawing.Size(200, 20);
					this.ultraButton3.SupportThemes = false;
					this.ultraButton3.TabIndex = 32;
					this.ultraButton3.Text = "ultraButton3";
					this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
					this.ultraButton3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					// 
					// ultraButton2
					// 
					appearance11.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(64)));
					this.ultraButton2.Appearance = appearance11;
					this.ultraButton2.BackColor = System.Drawing.Color.CornflowerBlue;
					this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButton2.Location = new System.Drawing.Point(96, 216);
					this.ultraButton2.Name = "ultraButton2";
					this.ultraButton2.Size = new System.Drawing.Size(96, 23);
					this.ultraButton2.SupportThemes = false;
					this.ultraButton2.TabIndex = 34;
					this.ultraButton2.Text = "ultraButton2";
					this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
					this.ultraButton2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					// 
					// imageList1
					// 
					this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
					this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
					this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
					this.imageList1.TransparentColor = System.Drawing.Color.Black;
					// 
					// PickDate
					// 
					this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
					this.BackColor = System.Drawing.Color.White;
					this.ClientSize = new System.Drawing.Size(600, 326);
					this.Controls.Add(this.ultraButton2);
					this.Controls.Add(this.ultraButton3);
					this.Controls.Add(this.ultraButton1);
					this.Controls.Add(this.ultraMonthViewMulti1);
					this.Controls.Add(this.panel1);
					this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
					this.Name = "PickDate";
					this.ShowInTaskbar = false;
					this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
					this.Text = "Form1";
					this.Load += new System.EventHandler(this.PickDate_Load);
					this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PickDate_KeyUp);
					this.panel1.ResumeLayout(false);
					((System.ComponentModel.ISupportInitialize)(this.ultraMonthViewMulti1)).EndInit();
					this.ResumeLayout(false);

				}
				#endregion

			
				private int DaysinMonth(int Month,int Year)
				{
					int Count = 0;
					switch (Month) 
					{
						case 1: Count = 31;break;
						case 2: Count = 28; if (( (Year % 4) == 0) && (Year != 1900)) Count = 29;  break;
						case 3: Count = 31;break;
						case 4: Count = 30;break;
						case 5: Count = 31;break;
						case 6: Count = 30;break;
						case 7: Count = 31;break;
						case 8: Count = 31;break;
						case 9: Count = 30;break;
						case 10: Count = 31;break;
						case 11: Count = 30;break;
						case 12: Count = 31;break;
					}
					return Count;
				}
				private static String MonthToString(int Month)
				{
					String Str = "";
					switch (Month) 
					{
						case 1 : Str ="იანვარი"; break;
						case 2 : Str ="თებერვალი"; break;
						case 3 : Str ="მარტი"; break;
						case 4 : Str ="აპრილი"; break;
						case 5 : Str ="მაისი"; break;
						case 6 : Str ="ივნისი"; break;
						case 7 : Str ="ივლისი"; break;
						case 8 : Str ="აგვისტო"; break;
						case 9 : Str ="სექტემბერი"; break;
						case 10: Str ="ოქტომბერი"; break;
						case 11: Str ="ნოემბერი"; break;
						case 12: Str ="დეკემბერი"; break;
					}
					return Str;

				}

				private static int  StringToMonth(String Month)
				{
					int Ret = 0;;
					switch (Month) 
					{
						case "იანვარი"   : Ret = 1; break;
						case "თებერვალი" : Ret = 2; break;
						case "მარტი"     : Ret = 3; break;
						case "აპრილი"    : Ret = 4; break;
						case "მაისი"     : Ret = 5; break;
						case "ივნისი"    : Ret = 6; break;
						case "ივლისი"    : Ret = 7; break;
						case "აგვისტო"   : Ret = 8; break;
						case "სექტემბერი": Ret = 9; break;
						case "ოქტომბერი" : Ret = 10; break;
						case "ნოემბერი"  : Ret = 11; break;
						case "დეკემბერი" : Ret = 12; break;
					}
					return Ret;

				}
				  
	
				// Calendat Info
				int _Year;
				int _Month;
				int _Day;



				public static String DateToString(DateTime D)
				{
					return  D.Day.ToString() + " " +  MonthToString(D.Month)+ " " + D.Year.ToString() ;
				}


				

				public override String ToString()
				{
					return  PickedDate.Day.ToString() + " " + MonthToString(PickedDate.Month)+ " " + PickedDate.Year.ToString() ;
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
					if (DaysinMonth(_Month,_Year) < _Day ) _Day = DaysinMonth(_Month,_Year);
					//    Get the current month
					DateTime dt = new DateTime(this._Year,this._Month,this._Day);
					Infragistics.Win.UltraWinSchedule.Month month;
					month = this.ultraMonthViewMulti1.CalendarInfo.GetMonth( dt );

					//    Set the  control‘s FirstMonth property to the current month
					this.ultraMonthViewMulti1.FirstMonth = month;

					//this.ultraMonthViewMulti1.FirstMonth.DaysInMonth

					//    Set the MonthDimensions property to only display one month
					this.ultraMonthViewMulti1.MonthDimensions = new Size( 1, 1 );

					//    Set the TrailingDaysVisible property to false so that only days
					//    that fall in the month being displayed are visible
					this.ultraMonthViewMulti1.TrailingDaysVisible = false;

					//    Set the PlaceHoldersVisible property to false, so that if the
					//    BorderStyleDay property is set a value other than None, borders
					//    are not drawn for the leading and trailing days
					this.ultraMonthViewMulti1.PlaceHoldersVisible = false;

					//    Hide the scroll buttons, so the user cannot change which
					//    month is being displayed
					this.ultraMonthViewMulti1.ScrollButtonsVisible = false;
			
			
				}

				private void comboBoxMonth_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					this._Month = this.comboBoxMonth.SelectedIndex + 1;
					this.revisible();

				}

				private void comboBoxYear_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					this._Year = this.comboBoxYear.SelectedIndex + 1973;
					this.revisible();

				}

		

				private void ultraMonthViewMulti1_BeforeMonthScroll(object sender, Infragistics.Win.UltraWinSchedule.BeforeMonthScrollEventArgs e)
				{   
					this._Day = this.ultraMonthViewMulti1.CalendarInfo.ActiveDay.Date.Day;
					this._Month = e.NewFirstMonth.MonthNumber;
					this._Year = e.NewFirstMonth.Year.YearNumber;
					this.comboBoxMonth.SelectedIndex = _Month-1;
					this.comboBoxYear.SelectedIndex = _Year - 1973;
			 
					if (DaysinMonth(_Month,_Year) < _Day ) _Day = DaysinMonth(_Month,_Year);
			 
					//MessageBox.Show(_Year.ToString() + " " +_Month.ToString()+ " " + _Day.ToString() );


					DateTime dt = new DateTime(_Year,_Month,_Day);
					this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Clear();
					this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges.Add(dt);

					foreach ( DateRange range in this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges )
					{
						foreach( Infragistics.Win.UltraWinSchedule.Day day in range.Days)
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

					foreach ( DateRange range in this.ultraMonthViewMulti1.CalendarInfo.SelectedDateRanges )
					{
						foreach( Infragistics.Win.UltraWinSchedule.Day day in range.Days)
						{ 
							this.ultraMonthViewMulti1.CalendarInfo.ActiveDay = day;
						}
					}
					this.revisible();
					
				}

				private void ultraButtonLeft_Click(object sender, System.EventArgs e)
				{
					if (this._Month == 1) { this._Month = 12; this._Year--;}
					else this._Month--;
					this.revisible();
				}

				private void ultraButtonRight_Click(object sender, System.EventArgs e)
				{
					if (this._Month == 12) { this._Month = 1; this._Year++;}
					else this._Month++;
					this.revisible();
				}


				private void PickDate_Load(object sender, System.EventArgs e)
				{
					this.SuspendLayout();
					Point p = new Point(Location.X,Location.Y);
					p.Y = p.Y - this.ClientSize.Height;
					Location = p;
					this.ResumeLayout();

					
				}

				private void PickDate_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
				{
					if (e.KeyCode == Keys.Escape) this.ultraButton2_Click(null,null);
					if (e.KeyCode == Keys.Enter) this.ultraButton1_Click_1(null,null);
				}

				private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
				{
				
				}

				private void ultraMonthViewMulti1_DoubleClick(object sender, System.EventArgs e)
				{

   					this.ultraButton1_Click_1(null,null);
				
				}

			

			}
		}
	}
}