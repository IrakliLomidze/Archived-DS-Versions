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

				public PickDate(DateTime initv)
				{
					
					//
					// Required for Windows Form Designer support
					//
					InitializeComponent();

					PickedDate = initv;
					DateTime dt = new DateTime();
					dt = DateTime.Now;
					this._Day = dt.Day;
					this._Month = dt.Month;
					this._Year = dt.Year;

					for(int i=1973;i<=2010;i++)
						comboBoxYear.Items.Add(i);
			
			
					comboBoxMonth.Items.Add("�������");
					comboBoxMonth.Items.Add("���������");
					comboBoxMonth.Items.Add("�����");
					comboBoxMonth.Items.Add("������");
					comboBoxMonth.Items.Add("�����");
					comboBoxMonth.Items.Add("������");
					comboBoxMonth.Items.Add("������");
					comboBoxMonth.Items.Add("�������");
					comboBoxMonth.Items.Add("����������");
					comboBoxMonth.Items.Add("���������");
					comboBoxMonth.Items.Add("��������");
					comboBoxMonth.Items.Add("���������");

					this.comboBoxMonth.SelectedIndex = dt.Month-1;
					this.comboBoxYear.SelectedIndex = dt.Year - 1973;
					
					this.ultraMonthViewMulti1.CalendarInfo.MaxDate = new DateTime(2010,12,31);
					this.ultraMonthViewMulti1.CalendarInfo.MinDate = new DateTime(1973,1,1);

					Graphics gfx = CreateGraphics();
					//int w = (int)gfx.MeasureString("����: 28 ��������� 2004",this.Font).Width;

					

					int w2 = (int)gfx.MeasureString(" ��������� ",this.Font).Width;
					this.comboBoxMonth.Width = 8+w2+20;

					int w3 = (int)gfx.MeasureString(" 2004 ",this.Font).Width;
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
					
					this.ultraButton3.Text = "����: "+DateToString(DateTime.Now);// 28 ��������� 2004";
					this.ultraButton2.Width = this.ultraButton3.Width / 2;
					this.ultraButton1.Width = this.ultraButton3.Width - this.ultraButton2.Width;
					this.ultraButton3.Focus();
					this.ultraButton3.Top = this.ultraMonthViewMulti1.Top + this.ultraMonthViewMulti1.Height;
					this.ultraButton1.Left = 0;
					this.ultraButton1.Top = this.ultraButton3.Top + this.ultraButton3.Height;
					this.ultraButton1.Text = "����";
					this.ultraButton2.Left = this.ultraButton2.Width;
					this.ultraButton2.Top = this.ultraButton1.Top;
					this.ultraButton2.Text = "��������";

					this.ClientSize = new Size(panel1.Width,ultraButton2.Top + ultraButton2.Height);
					


						
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
					System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
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
					// 
					// ultraButtonLeft
					// 
					appearance1.ForeColor = System.Drawing.Color.White;
					this.ultraButtonLeft.Appearance = appearance1;
					this.ultraButtonLeft.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButtonLeft.FlatMode = true;
					this.ultraButtonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					this.ultraButtonLeft.ImageTransparentColor = System.Drawing.Color.Empty;
					this.ultraButtonLeft.Location = new System.Drawing.Point(0, 0);
					this.ultraButtonLeft.Name = "ultraButtonLeft";
					this.ultraButtonLeft.Size = new System.Drawing.Size(24, 23);
					this.ultraButtonLeft.SupportThemes = false;
					this.ultraButtonLeft.TabIndex = 38;
					this.ultraButtonLeft.Text = "<";
					this.ultraButtonLeft.Click += new System.EventHandler(this.ultraButtonLeft_Click);
					// 
					// ultraButtonRight
					// 
					appearance2.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					appearance2.FontData.Name = "Microsoft Sans Serif";
					appearance2.ForeColor = System.Drawing.Color.White;
					this.ultraButtonRight.Appearance = appearance2;
					this.ultraButtonRight.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButtonRight.FlatMode = true;
					this.ultraButtonRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					this.ultraButtonRight.ImageTransparentColor = System.Drawing.Color.Empty;
					this.ultraButtonRight.Location = new System.Drawing.Point(208, 0);
					this.ultraButtonRight.Name = "ultraButtonRight";
					this.ultraButtonRight.Size = new System.Drawing.Size(24, 23);
					this.ultraButtonRight.SupportThemes = false;
					this.ultraButtonRight.TabIndex = 37;
					this.ultraButtonRight.Text = ">";
					this.ultraButtonRight.Click += new System.EventHandler(this.ultraButtonRight_Click);
					// 
					// comboBoxYear
					// 
					appearance3.FontData.Name = "Geo_Times";
					appearance3.FontData.SizeInPoints = 9.75F;
					this.comboBoxYear.Appearance = appearance3;
					this.comboBoxYear.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2003;
					this.comboBoxYear.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
					this.comboBoxYear.FlatMode = true;
					this.comboBoxYear.Location = new System.Drawing.Point(128, 0);
					this.comboBoxYear.Name = "comboBoxYear";
					this.comboBoxYear.Size = new System.Drawing.Size(64, 22);
					this.comboBoxYear.SupportThemes = false;
					this.comboBoxYear.TabIndex = 18;
					this.comboBoxYear.Text = null;
					this.comboBoxYear.SelectionChanged += new System.EventHandler(this.comboBoxYear_SelectedIndexChanged);
					// 
					// comboBoxMonth
					// 
					appearance4.FontData.Name = "Geo_Times";
					appearance4.FontData.SizeInPoints = 9.75F;
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
					// 
					// ultraMonthViewMulti1
					// 
					this.ultraMonthViewMulti1.AllowMonthPopup = false;
					this.ultraMonthViewMulti1.AllowMonthSelection = false;
					this.ultraMonthViewMulti1.AllowWeekSelection = false;
					appearance5.BackColor = System.Drawing.Color.White;
					appearance5.BorderColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(64)));
					appearance5.FontData.Name = "Geo_Times";
					appearance5.FontData.SizeInPoints = 9.75F;
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
					this.ultraMonthViewMulti1.Size = new System.Drawing.Size(201, 131);
					this.ultraMonthViewMulti1.SupportThemes = false;
					this.ultraMonthViewMulti1.TabIndex = 29;
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
					appearance7.FontData.SizeInPoints = 9.75F;
					this.ultraCalendarLook1.DayAppearance = appearance7;
					appearance8.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					this.ultraCalendarLook1.DayOfWeekHeaderAppearance = appearance8;
					appearance9.BackColor = System.Drawing.Color.LightSteelBlue;
					appearance9.BorderColor = System.Drawing.Color.Navy;
					appearance9.BorderColor3DBase = System.Drawing.Color.Navy;
					appearance9.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					appearance9.FontData.Name = "Geo_Times";
					appearance9.FontData.SizeInPoints = 9.75F;
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
					// 
					// ultraButton3
					// 
					this.ultraButton3.BackColor = System.Drawing.Color.LightSteelBlue;
					this.ultraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2003ToolbarButton;
					this.ultraButton3.Location = new System.Drawing.Point(0, 192);
					this.ultraButton3.Name = "ultraButton3";
					this.ultraButton3.Size = new System.Drawing.Size(200, 23);
					this.ultraButton3.SupportThemes = false;
					this.ultraButton3.TabIndex = 32;
					this.ultraButton3.Text = "ultraButton3";
					this.ultraButton3.Click += new System.EventHandler(this.ultraButton3_Click);
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
					// 
					// imageList1
					// 
					this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
					this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
					this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
					this.imageList1.TransparentColor = System.Drawing.Color.Black;
					// 
					// Form1
					// 
					this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
					this.BackColor = System.Drawing.Color.White;
					this.ClientSize = new System.Drawing.Size(600, 326);
					this.Controls.Add(this.ultraButton2);
					this.Controls.Add(this.ultraButton3);
					this.Controls.Add(this.ultraButton1);
					this.Controls.Add(this.ultraMonthViewMulti1);
					this.Controls.Add(this.panel1);
					this.Font = new System.Drawing.Font("Geo_Times", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
					this.Name = "Form1";
					this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
					this.Text = "Form1";
					this.Load += new System.EventHandler(this.Form1_Load);
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
						case 1 : Str ="�������"; break;
						case 2 : Str ="���������"; break;
						case 3 : Str ="�����"; break;
						case 4 : Str ="������"; break;
						case 5 : Str ="�����"; break;
						case 6 : Str ="������"; break;
						case 7 : Str ="������"; break;
						case 8 : Str ="�������"; break;
						case 9 : Str ="����������"; break;
						case 10: Str ="���������"; break;
						case 11: Str ="��������"; break;
						case 12: Str ="���������"; break;
					}
					return Str;

				}

				private static int  StringToMonth(String Month)
				{
					int Ret = 0;;
					switch (Month) 
					{
						case "�������"   : Ret = 1; break;
						case "���������" : Ret = 2; break;
						case "�����"     : Ret = 3; break;
						case "������"    : Ret = 4; break;
						case "�����"     : Ret = 5; break;
						case "������"    : Ret = 6; break;
						case "������"    : Ret = 7; break;
						case "�������"   : Ret = 8; break;
						case "����������": Ret = 9; break;
						case "���������" : Ret = 10; break;
						case "��������"  : Ret = 11; break;
						case "���������" : Ret = 12; break;
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


				private void Form1_Load(object sender, System.EventArgs e)
				{
			
			

						
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

				private void comboBox3_SelectedIndexChanged(object sender, System.EventArgs e)
				{
		
				}

				private void ultraTextEditor1_ValueChanged(object sender, System.EventArgs e)
				{
		
				}

				private void ultraTextEditor1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
				{
		  
				}

				private void ultraButton5_Click(object sender, System.EventArgs e)
				{
				}

				private void button1_Click_1(object sender, System.EventArgs e)
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

					//    Set the  control�s FirstMonth property to the current month
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
					Close();
				}

				private void ultraButton2_Click(object sender, System.EventArgs e)
				{
					//this.textBox1.Text = DateToString(
					//this.ultraMonthViewMulti1.CalendarInfo.ActiveDay.Date
					//);

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

			}
		}
	}
}