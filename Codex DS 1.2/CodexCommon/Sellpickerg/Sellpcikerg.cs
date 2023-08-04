using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using Infragistics.Win; 
using Infragistics.Win.UltraWinGrid; 
using Infragistics.Shared;

namespace ILG
{
	namespace Codex2007
	{
		/// <summary>
		/// Summary description for Sellpickerg.
		/// </summary>
		public class Sellpickerg : System.Windows.Forms.Form
		{
			private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
			private Infragistics.Win.Misc.UltraButton ultraButton2;
			private Infragistics.Win.UltraWinEditors.UltraComboEditor ultraComboEditor1;
			private Infragistics.Win.Misc.UltraLabel ultraLabel1;
            private Infragistics.Win.Misc.UltraButton ultraButton1;
            private IContainer components;
			private String CCaption;
			private String CSQL;
			private String NoSellStr;
			private String CaptionField;
			private String IDField;
			private int SQLStyle ;
			private int Selx; // 0 no sellected 1 sellect 2 NoT
			private String SQLField;
            private Infragistics.Win.UltraWinEditors.UltraTextEditor ultraTextEditor1;
            private ContextMenuStrip contextMenuStrip1;
			public bool canceled;
            private BindingSource bs;



			public Sellpickerg(DataTable dt,int Style,String IDFieldP,String SQLFieldP,String CaptionFieldP,String HeaderStr,String NoSellStrP,int X,int Y,int Width)
			{
				//
				// Required for Windows Form Designer support
				//
		    
				InitializeComponent();
               // MessageBox.Show(dt.Rows.Count.ToString()); 

                
				NoSellStr = NoSellStrP;
				IDField = IDFieldP;
				SQLField = SQLFieldP;
				CaptionField = CaptionFieldP;
				SQLStyle = Style;
				this.Width = Width;

				ultraLabel1.Text = "მოიძებნოს";
				ultraLabel1.AutoSize = true;
				ultraLabel1.Appearance.FontData.Name = "Sylfaen";
				ultraLabel1.Appearance.FontData.SizeInPoints = 9.0f;
				ultraComboEditor1.Items.Add("T","მონიშნული/ები");
				ultraComboEditor1.Items.Add("F","ყველა მონიშნულის/ების გარდა");
				ultraComboEditor1.Value = "T";
				ultraComboEditor1.Appearance.FontData.Name = "Sylfaen";
				ultraComboEditor1.Appearance.FontData.SizeInPoints = 9.0f;
				ultraButton2.Text = "თანხმობა";
				ultraButton1.Text = "უარი";
				ultraButton1.Appearance.FontData.Name = "Sylfaen";
				ultraButton1.Appearance.FontData.SizeInPoints = 9.0f;
				ultraButton2.Appearance.FontData.Name = "Sylfaen";
				ultraButton2.Appearance.FontData.SizeInPoints = 9.0f;

		
				// DataBinding
                bs = new BindingSource();
                
                bs.Filter = "";
                bs.DataSource = dt;
                ultraGrid1.DataSource = bs;
                
			
				ultraGrid1.DataBind();
				ultraGrid1.DisplayLayout.AutoFitColumns = true;
				ultraGrid1.DisplayLayout.Key = IDField;
				ultraGrid1.FlatMode = true;
		
				
				for(int i=0;i<=ultraGrid1.DisplayLayout.Bands[0].Columns.Count-1;i++)
					ultraGrid1.DisplayLayout.Bands[0].Columns[i].Hidden = true;

			
				ultraGrid1.DisplayLayout.Bands[0].Columns[CaptionField].Hidden = false;
				ultraGrid1.DisplayLayout.Bands[0].ColHeadersVisible = false;
				ultraGrid1.DisplayLayout.Bands[0].HeaderVisible = false;
				ultraGrid1.DisplayLayout.Bands[0].Columns[CaptionField].AutoEdit = false;
				ultraGrid1.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
				//ultraGrid1.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.AliceBlue;//.LightSteelBlue;// .Wheat;
				
				//ultraGrid1.DisplayLayout.Bands[0].Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
				//ultraGrid1.DisplayLayout.Bands[0].Override.AllowColSizing =  Infragistics.Win.UltraWinGrid.AllowColSizing.None;
				ultraGrid1.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;



				ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
				ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
				ultraGrid1.Text = HeaderStr;

				// Display
				ultraGrid1.Left = 0;
				ultraGrid1.Top = 0;
				ultraGrid1.Width = ClientSize.Width;
				ultraGrid1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
// Height Calculded Code
				int hhx=0;
				hhx= (this.ultraGrid1.Rows[0].Height +1+
					this.ultraGrid1.Rows[0].RowSpacingBefore+
					this.ultraGrid1.Rows[0].RowSpacingAfter) * (ultraGrid1.Rows.Count+1)+2;
				
				if ((hhx>0)&&(this.ultraGrid1.Height > hhx )) this.ultraGrid1.Height = hhx;


				ultraComboEditor1.Top  = ultraGrid1.Top  + ultraGrid1.Height;
				ultraComboEditor1.Left = ClientSize.Width-ultraComboEditor1.Width;
				ultraComboEditor1.Anchor = ( AnchorStyles.Right | AnchorStyles.Top);

			
				ultraLabel1.AutoSize = true;

				ultraLabel1.Top = ultraComboEditor1.Top + (ultraComboEditor1.Height - ultraLabel1.Height)/2;
				ultraLabel1.Left = ultraComboEditor1.Left - ultraLabel1.Width-8;
				ultraLabel1.Anchor = ( AnchorStyles.Right | AnchorStyles.Top);

				ultraButton1.Width = ClientSize.Width / 2;
				ultraButton2.Width = ClientSize.Width / 2 - 1;
				ultraButton2.Left = 0;
				ultraButton1.Top = ultraComboEditor1.Top + ultraComboEditor1.Height+2;
				ultraButton2.Top = ultraButton1.Top;
				ultraButton1.Left = ultraButton1.Width;

				this.Height = ultraButton2.Top + ultraButton2.Height;

                this.ultraTextEditor1.Text = "";
                this.ultraTextEditor1.Left = 4;
                this.ultraTextEditor1.Top = ultraComboEditor1.Top + ((ultraComboEditor1.Height - this.ultraTextEditor1.Height)/2);
                this.ultraTextEditor1.Width = this.ultraLabel1.Left - 48;


				Point p = new Point(X,Y);
				Location = p;


				// calculder free space
				
					
						  
			
			

		
			
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
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
                this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
                this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
                this.ultraComboEditor1 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
                this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
                this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
                this.ultraTextEditor1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
                this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).BeginInit();
                this.SuspendLayout();
                // 
                // ultraGrid1
                // 
                this.ultraGrid1.Cursor = System.Windows.Forms.Cursors.Default;
                appearance1.BackColor = System.Drawing.Color.AliceBlue;
                this.ultraGrid1.DisplayLayout.CaptionAppearance = appearance1;
                this.ultraGrid1.DisplayLayout.Override.TipStyleScroll = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
                this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
                this.ultraGrid1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
                this.ultraGrid1.Name = "ultraGrid1";
                this.ultraGrid1.Size = new System.Drawing.Size(360, 240);
                this.ultraGrid1.TabIndex = 1;
                this.ultraGrid1.Text = "ultraGrid1";
                this.ultraGrid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                this.ultraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.ultraGrid1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyUp);
                this.ultraGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ultraGrid1_MouseUp);
                this.ultraGrid1.DoubleClick += new System.EventHandler(this.ultraGrid1_DoubleClick);
                this.ultraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGrid1_InitializeLayout);
                this.ultraGrid1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ultraGrid1_KeyPress);
                // 
                // ultraButton2
                // 
                this.ultraButton2.BackColorInternal = System.Drawing.Color.SteelBlue;
                this.ultraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
                this.ultraButton2.Location = new System.Drawing.Point(184, 280);
                this.ultraButton2.Name = "ultraButton2";
                this.ultraButton2.ShowFocusRect = false;
                this.ultraButton2.ShowOutline = false;
                this.ultraButton2.Size = new System.Drawing.Size(168, 23);
                this.ultraButton2.TabIndex = 5;
                this.ultraButton2.Text = "ultraButton2";
                this.ultraButton2.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                this.ultraButton2.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
                this.ultraButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
                this.ultraButton2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyUp);
                // 
                // ultraComboEditor1
                // 
                appearance2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
                appearance2.FontData.Name = "Sylfaen";
                appearance2.FontData.SizeInPoints = 8F;
                this.ultraComboEditor1.Appearance = appearance2;
                this.ultraComboEditor1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
                this.ultraComboEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
                this.ultraComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
                this.ultraComboEditor1.Location = new System.Drawing.Point(158, 248);
                this.ultraComboEditor1.Name = "ultraComboEditor1";
                this.ultraComboEditor1.Size = new System.Drawing.Size(202, 23);
                this.ultraComboEditor1.TabIndex = 3;
                this.ultraComboEditor1.UseAppStyling = false;
                this.ultraComboEditor1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.ultraComboEditor1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyUp);
                // 
                // ultraLabel1
                // 
                appearance3.BackColor = System.Drawing.Color.Transparent;
                appearance3.FontData.Name = "Sylfaen";
                appearance3.FontData.SizeInPoints = 9F;
                this.ultraLabel1.Appearance = appearance3;
                this.ultraLabel1.AutoSize = true;
                this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
                this.ultraLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
                this.ultraLabel1.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ultraLabel1.Location = new System.Drawing.Point(104, 250);
                this.ultraLabel1.Name = "ultraLabel1";
                this.ultraLabel1.Size = new System.Drawing.Size(63, 18);
                this.ultraLabel1.TabIndex = 18;
                this.ultraLabel1.Text = "ultraLabel1";
                // 
                // ultraButton1
                // 
                this.ultraButton1.BackColorInternal = System.Drawing.Color.SteelBlue;
                this.ultraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007ScrollbarButton;
                this.ultraButton1.Location = new System.Drawing.Point(8, 280);
                this.ultraButton1.Name = "ultraButton1";
                this.ultraButton1.ShowFocusRect = false;
                this.ultraButton1.ShowOutline = false;
                this.ultraButton1.Size = new System.Drawing.Size(168, 23);
                this.ultraButton1.TabIndex = 4;
                this.ultraButton1.Text = "ultraButton1";
                this.ultraButton1.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                this.ultraButton1.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
                this.ultraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
                this.ultraButton1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyUp);
                // 
                // ultraTextEditor1
                // 
                appearance4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
                this.ultraTextEditor1.Appearance = appearance4;
                this.ultraTextEditor1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                this.ultraTextEditor1.ContextMenuStrip = this.contextMenuStrip1;
                this.ultraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
                this.ultraTextEditor1.Font = new System.Drawing.Font("Sylfaen", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.ultraTextEditor1.Location = new System.Drawing.Point(13, 247);
                this.ultraTextEditor1.Name = "ultraTextEditor1";
                this.ultraTextEditor1.Size = new System.Drawing.Size(100, 19);
                this.ultraTextEditor1.TabIndex = 2;
                this.ultraTextEditor1.Text = "ultraTextEditor1";
                this.ultraTextEditor1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.ultraTextEditor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ultraTextEditor1_KeyPress);
                this.ultraTextEditor1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraTextEditor1_KeyUp);
                this.ultraTextEditor1.TextChanged += new System.EventHandler(this.ultraTextEditor1_TextChanged);
                // 
                // contextMenuStrip1
                // 
                this.contextMenuStrip1.Name = "contextMenuStrip1";
                this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
                // 
                // Sellpickerg
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
                this.BackColor = System.Drawing.Color.AliceBlue;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(360, 318);
                this.Controls.Add(this.ultraTextEditor1);
                this.Controls.Add(this.ultraButton2);
                this.Controls.Add(this.ultraComboEditor1);
                this.Controls.Add(this.ultraLabel1);
                this.Controls.Add(this.ultraButton1);
                this.Controls.Add(this.ultraGrid1);
                this.DoubleBuffered = true;
                this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "Sellpickerg";
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "Sellpickerg";
                this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ultraGrid1_KeyUp);
                this.Load += new System.EventHandler(this.Sellpickerg_Load);
                ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.ultraComboEditor1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.ultraTextEditor1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

			}
			#endregion

			private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
			{
		
			}

			private void Sellpickerg_Load(object sender, System.EventArgs e)
			{
				this.SuspendLayout();
				Point p = new Point(Location.X,Location.Y);
				p.Y = p.Y - this.ClientSize.Height;
				this.Location = p;
				this.ResumeLayout();
				
		
			}

			private void ultraButton2_Click(object sender, System.EventArgs e)
			{
				StringBuilder St = new StringBuilder("");
				StringBuilder StSQL = new StringBuilder("");

				if (ultraGrid1.Selected.Rows.Count == 0)  
				{ 
					St.Append(NoSellStr);
					Selx = 0;
				
				}

				if (ultraGrid1.Selected.Rows.Count == 1)  
				{
					if (this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim() != "")
					{
						St.Append(this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim());
						if (ultraComboEditor1.Value.ToString() == "T")
						{
							Selx = 1;
							if (SQLStyle == 0) { StSQL.Append(" ( "+SQLField+" = "+ this.ultraGrid1.Selected.Rows[0].Cells[IDField].Text.ToString()+" )"); }
							else  { StSQL.Append(" ( "+SQLField+" LIKE  N'%"+ this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim()+"%' )"); }
						}
						else
						{
							Selx = 2;
							if (SQLStyle == 0) { StSQL.Append(" ( "+SQLField+" <> "+ this.ultraGrid1.Selected.Rows[0].Cells[IDField].Text.ToString()+" )"); }
							else  { StSQL.Append(" ( "+SQLField+" NOT LIKE N'%"+ this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim()+"%' )"); }
						}
					}
					else
					{ 
						St.Append(NoSellStr);
					}

				}
				if (ultraGrid1.Selected.Rows.Count > 1)  
				{

					for(int i=0;i<ultraGrid1.Selected.Rows.Count;i++)
					{
                        if (ultraGrid1.Selected.Rows[i].Cells[CaptionField].Text.ToString().Trim() == "") continue;
                        St.Append(ultraGrid1.Selected.Rows[i].Cells[CaptionField].Text.ToString().Trim());
						if ( i != ultraGrid1.Selected.Rows.Count-1 ) St.Append(", ");
						// SQL Generation
						if (ultraComboEditor1.Value.ToString() == "T")
						{
							Selx = 1;
							if (SQLStyle == 0) { StSQL.Append(" ( "+SQLField+" = "+ ultraGrid1.Selected.Rows[i].Cells[IDField].Text.ToString().Trim()+ " ) "); }
							else               { StSQL.Append(" ( "+SQLField+" LIKE N'%"+ this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim()+"%' )"); }
							if ( i != ultraGrid1.Selected.Rows.Count-1 ) StSQL.Append(" OR ");
						}
						else
						{
							Selx = 2;
							if (SQLStyle == 0) { StSQL.Append(" ( "+SQLField+" <> "+ ultraGrid1.Selected.Rows[i].Cells[IDField].Text.ToString().Trim()+ " ) "); }
							else               { StSQL.Append(" ( "+SQLField+" NOT LIKE  N'%"+ this.ultraGrid1.Selected.Rows[0].Cells[CaptionField].Text.ToString().Trim()+"%' )"); }
							if ( i != ultraGrid1.Selected.Rows.Count-1 ) StSQL.Append(" AND ");
						}
					}

				}
			

				CCaption = St.ToString();
				CSQL     = StSQL.ToString();			
				this.canceled = false;
				Close();
				return;
			}

			public override String ToString()
			{ 
				return CCaption;
			}
			public String ToSQLString()
			{
				return CSQL;
			}

			public int ToWhat()
			{
				return Selx;
			}

			private void ultraButton1_Click(object sender, System.EventArgs e)
			{
				
				CCaption = NoSellStr;
				CSQL     = "";
				Selx = 0;
				this.canceled = true;
				Close();
			}

			private void ultraGrid1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				
			}

			private void ultraGrid1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Escape) this.ultraButton1_Click(null,null);
				if (e.KeyCode == Keys.Enter) this.ultraButton2_Click(null,null);

			}

			private void ultraGrid1_DoubleClick(object sender, System.EventArgs e)
			{
				if (this.AScrooling == false) this.ultraButton2_Click(null,null);
			}

			bool AScrooling  = true;
			private void ultraGrid1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				// declare and retrieve a reference to the UIElement
				Infragistics.Win.UIElement aUIElement = this.ultraGrid1.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
				if (aUIElement is Infragistics.Win.EditorWithTextDisplayTextUIElement) AScrooling = false; else AScrooling = true;
			}

            private void ultraTextEditor1_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.KeyChar = ILG.Codex.KeyBoard.Layout.U[e.KeyChar];
            }

            private void ultraTextEditor1_TextChanged(object sender, EventArgs e)
            {

                bs.Filter = "";
                bs.Filter = " "+ CaptionField + " Like '%"+ultraTextEditor1.Text+"%' ";
                if (this.ultraGrid1.Rows.Count != 0)
                {
                    for(int i=0;i<this.ultraGrid1.Rows.Count-1;i++)
                        this.ultraGrid1.Rows[i].Selected = false;

                    this.ultraGrid1.Rows[0].Selected = true;
                    
                }
                /*   this.ultraGrid1.DisplayLayout.Bands[0].Override.AllowRowFiltering = DefaultableBoolean.True;
                this.ultraGrid1.DisplayLayout.Bands[0].Override.RowFilterMode = RowFilterMode.SiblingRowsOnly;
                this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters[CaptionField].FilterConditions.Clear();
                this.ultraGrid1.DisplayLayout.Bands[0].ColumnFilters[CaptionField].FilterConditions.Add(FilterComparisionOperator.Contains, this.ultraTextEditor1.Text);
                MessageBox.Show(this.ultraGrid1.Rows.Count.ToString());
                */

            }

            private void ultraTextEditor1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape) ultraTextEditor1.Text = "";
            }

		}
	}
}