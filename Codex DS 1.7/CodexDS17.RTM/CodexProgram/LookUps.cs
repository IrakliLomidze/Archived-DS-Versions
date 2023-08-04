using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using ILG.Codex.CodexR4.CodexSettings;

namespace ILG.Codex.CodexR4
{
    public partial class LookUps : Form
    {
        public LookUps()
        {
            InitializeComponent();
        }

        #region Authors
        // Authors
        //===========================
    
        DataSet CA;
        SqlDataAdapter DAA;
        int mode;
        
        public void ultraButton1_Click(object sender, EventArgs e)
        {
            
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            
            SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
            string sql = "SELECT A_ID,A_ORDER,A_CAPTION FROM CodexDS_DAUTHOR";
            DAA = new SqlDataAdapter(sql, cn);
            CA = new DataSet();
           // SqlCommandBuilder cb = new SqlCommandBuilder(DAA);
            DAA.Fill(CA, "Authors");
            SqlCommandBuilder cb = new SqlCommandBuilder(DAA);
            

            this.A_Grid.DataSource = CA.Tables["Authors"];
            this.A_Grid.DataBind();
            //ultraGrid1.DisplayLayout.AutoFitColumns = true;
            A_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            A_Grid.DisplayLayout.Key = "A_ID";
            A_Grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True; //FlatMode = true;

            for (int i = 0; i <= A_Grid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                A_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;


            A_Grid.DisplayLayout.Bands[0].Columns["A_Order"].Hidden = false;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Order"].Header.Caption = "მიმდევრობა";
            A_Grid.DisplayLayout.Bands[0].Columns["A_Order"].Header.VisiblePosition = 1;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Order"].Width = 94;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            A_Grid.DisplayLayout.Bands[0].Columns["A_Caption"].Hidden = false;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Caption"].Width = 80;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Caption"].Header.VisiblePosition = 2;
            A_Grid.DisplayLayout.Bands[0].Columns["A_Caption"].Header.Caption = "მიმღები ორგანო";
            A_Grid.DisplayLayout.Bands[0].Columns["A_Caption"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; ;

            A_Grid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            A_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
       
            A_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.Honeydew;//.LightSteelBlue;// .Wheat;
            A_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            A_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;


            A_Grid.DisplayLayout.MaxColScrollRegions = 1;
            A_Grid.DisplayLayout.MaxRowScrollRegions = 1;

            A_Grid.DisplayLayout.Bands[0].SortedColumns.Clear();
            A_Grid.DisplayLayout.Bands[0].SortedColumns.Add("A_ID", false);



            this.A_ultraLabel1.Visible = false;
            this.A_ultraLabel2.Visible = false;
            this.A_Order.Visible = false;
            this.A_Caption.Visible = false;
            this.A_Order.Enabled = false;
            this.A_Caption.Enabled = false;
            this.A_Add.Enabled = false;
            this.A_Add.Visible = false;

            this.A_Save.Enabled = false;
            this.A_Save.Visible = false;

            GMax = 0;
            foreach (DataRow dr in CA.Tables["Authors"].Rows)
            {
                if ((int)dr["A_ID"] > GMax) GMax = (int)dr["A_ID"];
            }
            mode = 0;
            this.Cursor = System.Windows.Forms.Cursors.Default;
           
        }

        private void A_News_Click(object sender, EventArgs e)
        {
            
            this.A_ultraLabel1.Visible = true;
            this.A_ultraLabel2.Visible = true;
            this.A_Order.Visible = true;
            this.A_Caption.Visible = true;
            this.A_Order.Enabled = true;
            this.A_Caption.Enabled = true;
            this.A_Add.Enabled = true;
            this.A_Add.Visible = true;
            this.A_Add.Text = "დამატება";
            mode = 1;
            
        }

        private void A_Add_Click(object sender, EventArgs e)
        {
            
            #region Add Information
            if (mode == 1) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი მიმღები ორგანოს დამატება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.A_Order.Text.Trim();
                if (this.A_Order.Text == "") A_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(A_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.A_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანოს დასახელება ცარიელია");
                    return;
                }

                // Add
                GMax++;
                double Order = System.Convert.ToDouble(this.A_Order.Text);
                CA.Tables["Authors"].Rows.Add(new object[] { GMax, Order, this.A_Caption.Text.Trim() });

                this.A_Save.Enabled = true;
                this.A_Save.Visible = true;

                this.A_Caption.Text = "";
                this.A_Order.Text = "";
                this.A_ultraLabel1.Visible = false;
                this.A_ultraLabel2.Visible = false;
                this.A_Caption.Visible = false;
                this.A_Order.Visible = false;
                this.A_Caption.Enabled = false;
                this.A_Order.Enabled = false;
                this.A_Add.Enabled = false;
                this.A_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია დამატებულია");
                return;
            }
            #endregion Add Information

            #region Edit Information
            if (mode == 2) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანოს რედაქტირება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.A_Order.Text.Trim();
                if (this.A_Order.Text == "") A_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(A_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.A_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანოს დასახელება ცარიელია");
                    return;
                }

                // Add
                int curr = -1;


                for (int i = 0; i < CA.Tables["Authors"].Rows.Count; i++)
                {
                    if ((int)CA.Tables["Authors"].Rows[i]["A_ID"] == this.tempid)
                    {
                        curr = i; break;
                    }
                }

                if (curr == -1)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 20001A");
                    return;
                }


                double Order = System.Convert.ToDouble(this.A_Order.Text);


                CA.Tables["Authors"].Rows[curr]["A_Order"] = Order;
                CA.Tables["Authors"].Rows[curr]["A_Caption"] = this.A_Caption.Text.Trim();



                this.A_Save.Enabled = true;
                this.A_Save.Visible = true;

                this.A_Caption.Text = "";
                this.A_Order.Text = "";
                this.A_ultraLabel1.Visible = false;
                this.A_ultraLabel2.Visible = false;
                this.A_Caption.Visible = false;
                this.A_Order.Visible = false;
                this.A_Caption.Enabled = false;
                this.A_Order.Enabled = false;
                this.A_Add.Enabled = false;
                this.A_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
                return;
            }
            #endregion Edit Information
            
        }
        int GMax = -1;
        int tempid = -1;
        
        private void A_Change_Click(object sender, EventArgs e)
        {
            
            if (this.A_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ  მიმღები ორგანო");
                return;
            }
            this.A_ultraLabel1.Visible = true;
            this.A_ultraLabel2.Visible = true;
            this.A_Order.Visible = true;
            this.A_Caption.Visible = true;
            this.A_Order.Enabled = true;
            this.A_Caption.Enabled = true;
            this.A_Add.Enabled = true;
            this.A_Add.Visible = true;
            this.A_Add.Text = "შეცვლა";
            
            mode = 2;
            tempid = (int)this.A_Grid.Selected.Rows[0].Cells["A_ID"].Value;
            foreach (DataRow dr in CA.Tables["Authors"].Rows)
            {
                if ((int)dr["A_ID"] == tempid)
                {
                    this.A_Order.Text = dr["A_Order"].ToString().Trim();
                    this.A_Caption.Text = dr["A_Caption"].ToString().Trim();
                    return;
                }
            }
			

            
        }

        private void A_Delete_Click(object sender, EventArgs e)
        {
            if (this.A_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ მიმღები ორგანო");
                return;
            }

            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული მიმღები ორგანოს წაშლა\n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული მიმღები ორგანოს წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული მიმღები ორგანოს წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული მიმღები ორგანოს წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ კიდევ ერთხელ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            int tid = (int)this.A_Grid.Selected.Rows[0].Cells["A_ID"].Value;
            int curr = -1;


            for (int i = 0; i < CA.Tables["Authors"].Rows.Count; i++)
            {
                if ((int)CA.Tables["Authors"].Rows[i]["A_ID"] == tid)
                {
                    curr = i; break;
                }
            }


            if (curr == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000DA");
                return;
            }

            // Checking if Attribute is Used
            SqlDataAdapter ch1 = new SqlDataAdapter("SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_Author = " + tid.ToString(),
                SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet Ds = new DataSet();
            ch1.Fill(Ds);
            int CCount=-1;
            try
            {
                CCount = (int)Ds.Tables[0].Rows[0][0];
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000CA");
                return;
            }

            if (CCount > 0)
            {
                 ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული მიმღები ორგანო უკვე გამოყენებულია არსებულ დოკუმენტებში \n"+
                "მისი წაშლისთვის მოძებნეთ ყველა დოკუმენტი შესაბამისი ავტორით და შეუცვლეთ მას ეს ატრიბუტი\n"+
                "მას შემდეგ რა სისტემა დარწმუნდება, რომ ეს ატრიბუტი არსად არ არის გამოყენებული იგი მოგცემთ მისი წაშლის საშუალებას");
                return;
            }

            CA.Tables["Authors"].Rows[curr].Delete();//.RemoveAt(curr);
            this.A_Save.Enabled = true;
            this.A_Save.Visible = true;

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია წაშლილია");
            
		
        }

        private void A_Save_Click(object sender, EventArgs e)
        {
          
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DAA.Update(CA, "Authors");

            this.A_Save.Visible = false;
            this.A_Save.Enabled = false;
           // IntCGLLocalVars.InitData();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
          
        }



        #endregion Authors
        #region Types

        // Types ================================================================================
       
        DataSet CT;
        SqlDataAdapter DAT;
        int modeT;
        int Ttempid = -1;
        int GMaxT = -1;
   
        public void ultraButton6_Click(object sender, EventArgs e)
        {
            
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
            string sql = "SELECT T_ID,T_ORDER,T_CAPTION FROM CodexDS_DType";
            DAT = new SqlDataAdapter(sql, cn);
            CT = new DataSet();
            SqlCommandBuilder cb = new SqlCommandBuilder(DAT);
            DAT.Fill(CT, "Types");


            this.T_Grid.DataSource = CT.Tables["Types"];
            this.T_Grid.DataBind();
            //ultraGrid1.DisplayLayout.AutoFitColumns = true;
            T_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            T_Grid.DisplayLayout.Key = "T_ID";
            T_Grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True; //FlatMode = true;

            for (int i = 0; i <= T_Grid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                T_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;


            T_Grid.DisplayLayout.Bands[0].Columns["T_Order"].Hidden = false;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Order"].Header.Caption = "მიმდევრობა";
            T_Grid.DisplayLayout.Bands[0].Columns["T_Order"].Header.VisiblePosition = 1;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Order"].Width = 94;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            T_Grid.DisplayLayout.Bands[0].Columns["T_Caption"].Hidden = false;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Caption"].Width = 80;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Caption"].Header.VisiblePosition = 2;
            T_Grid.DisplayLayout.Bands[0].Columns["T_Caption"].Header.Caption = "დოკუმენტის სახე";
            T_Grid.DisplayLayout.Bands[0].Columns["T_Caption"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; ;

            T_Grid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            //T_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.AliceBlue;//.LightSteelBlue;// .Wheat;
            //T_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            //T_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            //T_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;

            T_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.Honeydew;//.LightSteelBlue;// .Wheat;
            T_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            T_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;

            T_Grid.DisplayLayout.MaxColScrollRegions = 1;
            T_Grid.DisplayLayout.MaxRowScrollRegions = 1;

            T_Grid.DisplayLayout.Bands[0].SortedColumns.Clear();
            T_Grid.DisplayLayout.Bands[0].SortedColumns.Add("T_ID", false);



            this.T_ultraLabel1.Visible = false;
            this.T_ultraLabel2.Visible = false;
            this.T_Order.Visible = false;
            this.T_Caption.Visible = false;
            this.T_Order.Enabled = false;
            this.T_Caption.Enabled = false;
            this.T_Add.Enabled = false;
            this.T_Add.Visible = false;

            this.T_Save.Enabled = false;
            this.T_Save.Visible = false;

            GMax = 0;
            foreach (DataRow dr in CT.Tables["Types"].Rows)
            {
                if ((int)dr["T_ID"] > GMax) GMax = (int)dr["T_ID"];
            }
            modeT = 0;
            this.Cursor = System.Windows.Forms.Cursors.Default;
     
        }

        private void T_New_Click(object sender, EventArgs e)
        {
            
            this.T_ultraLabel1.Visible = true;
            this.T_ultraLabel2.Visible = true;
            this.T_Order.Visible = true;
            this.T_Caption.Visible = true;
            this.T_Order.Enabled = true;
            this.T_Caption.Enabled = true;
            this.T_Add.Enabled = true;
            this.T_Add.Visible = true;
            this.T_Add.Text = "დამატება";
            modeT = 1;
             
        }

        private void T_Change_Click(object sender, EventArgs e)
        {
          
            if (this.T_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ  დოკუმენტის სახე");
                return;
            }
            this.T_ultraLabel1.Visible = true;
            this.T_ultraLabel2.Visible = true;
            this.T_Order.Visible = true;
            this.T_Caption.Visible = true;
            this.T_Order.Enabled = true;
            this.T_Caption.Enabled = true;
            this.T_Add.Enabled = true;
            this.T_Add.Visible = true;
            this.T_Add.Text = "შეცვლა";

            modeT = 2;
            Ttempid = (int)this.T_Grid.Selected.Rows[0].Cells["T_ID"].Value;
            foreach (DataRow dr in CT.Tables["Types"].Rows)
            {
                if ((int)dr["T_ID"] == Ttempid)
                {
                    this.T_Order.Text = dr["T_Order"].ToString().Trim();
                    this.T_Caption.Text = dr["T_Caption"].ToString().Trim();
                    return;
                }
            }
			

            
      
        }

        private void T_Delete_Click(object sender, EventArgs e)
        {
          
            if (this.T_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ მიმღები ორგანო");
                return;
            }

            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სახეს წაშლა\n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სახეს წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სახეს წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სახეს წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ კიდევ ერთხელ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            int tid = (int)this.T_Grid.Selected.Rows[0].Cells["T_ID"].Value;
            int curr = -1;


            for (int i = 0; i < CT.Tables["Types"].Rows.Count; i++)
            {
                if ((int)CT.Tables["Types"].Rows[i]["T_ID"] == tid)
                {
                    curr = i; break;
                }
            }


            if (curr == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000DA");
                return;
            }

            // Checking if Attribute is Used
            SqlDataAdapter ch1 = new SqlDataAdapter("SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_type = " + tid.ToString(),
                SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet Ds = new DataSet();
            ch1.Fill(Ds);
            int CCount = -1;
            try
            {
                CCount = (int)Ds.Tables[0].Rows[0][0];
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000CA");
                return;
            }

            if (CCount > 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სახე უკვე გამოყენებულია არსებულ დოკუმენტებში \n" +
               "მისი წაშლისთვის მოძებნეთ ყველა დოკუმენტი შესაბამისი ტიპით და შეუცვლეთ მას ეს ატრიბუტი\n" +
               "მას შემდეგ რა სისტემა დარწმუნდება, რომ ეს ატრიბუტი არსად არ არის გამოყენებული იგი მოგცემთ მისი წაშლის საშუალებას");
                return;
            }

            CT.Tables["Types"].Rows[curr].Delete();// .RemoveAt(curr);
            this.T_Save.Enabled = true;
            this.T_Save.Visible = true;

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია წაშლილია");
            
		
        }

        private void ultraButton4_Click(object sender, EventArgs e)
        {
            
            #region Add Information
            if (modeT == 1) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი დოკუმენტის სახეს დამატება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.T_Order.Text.Trim();
                if (this.T_Order.Text == "") T_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(T_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.T_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სახეს დასახელება ცარიელია");
                    return;
                }

                // Add
                GMaxT++;
                double Order = System.Convert.ToDouble(this.T_Order.Text);
                CT.Tables["Types"].Rows.Add(new object[] { GMaxT, Order, this.T_Caption.Text.Trim() });

                this.T_Save.Enabled = true;
                this.T_Save.Visible = true;

                this.T_Caption.Text = "";
                this.T_Order.Text = "";
                this.T_ultraLabel1.Visible = false;
                this.T_ultraLabel2.Visible = false;
                this.T_Caption.Visible = false;
                this.T_Order.Visible = false;
                this.T_Caption.Enabled = false;
                this.T_Order.Enabled = false;
                this.T_Add.Enabled = false;
                this.T_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია დამატებულია");
                return;
            }
            #endregion Add Information

            #region Edit Information
            if (modeT == 2) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("მიმღები ორგანოს რედაქტირება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.T_Order.Text.Trim();
                if (this.T_Order.Text == "") T_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(T_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.T_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სახეს დასახელება ცარიელია");
                    return;
                }

                // Add
                int curr = -1;


                for (int i = 0; i < CT.Tables["Types"].Rows.Count; i++)
                {
                    if ((int)CT.Tables["Types"].Rows[i]["T_ID"] == this.Ttempid)
                    {
                        curr = i; break;
                    }
                }

                if (curr == -1)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 20001A");
                    return;
                }


                double Order = System.Convert.ToDouble(this.T_Order.Text);


                CT.Tables["Types"].Rows[curr]["T_Order"] = Order;
                CT.Tables["Types"].Rows[curr]["T_Caption"] = this.T_Caption.Text.Trim();



                this.T_Save.Enabled = true;
                this.T_Save.Visible = true;

                this.T_Caption.Text = "";
                this.T_Order.Text = "";
                this.T_ultraLabel1.Visible = false;
                this.T_ultraLabel2.Visible = false;
                this.T_Caption.Visible = false;
                this.T_Order.Visible = false;
                this.T_Caption.Enabled = false;
                this.T_Order.Enabled = false;
                this.T_Add.Enabled = false;
                this.T_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
                return;
            }
            #endregion Edit Information
            
        }

        private void T_Save_Click(object sender, EventArgs e)
        {
            
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
              != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DAT.Update(CT, "Types");

            this.T_Save.Visible = false;
            this.T_Save.Enabled = false;
            // IntCGLLocalVars.InitData();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
        
            
        }

        private void ultraTabPageControl7_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion Types

        #region Subject
        // Subject ================================================================================
      
        DataSet CS;
        SqlDataAdapter DAC;
        int modeS;
        int Stempid = -1;
        int GMaxS = -1;
        SqlCommandBuilder cb_Subject;
        
        public void S_Refresh_Click(object sender, EventArgs e)
        {
            
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
            string sql = "SELECT S_ID,S_ORDER,S_CAPTION FROM CodexDS_DSubject";
            cn.Open();
            DAC = new SqlDataAdapter(sql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            CS = new DataSet();
            cb_Subject = new SqlCommandBuilder(DAC);
            
            DAC.Fill(CS, "Subjects");
       
            this.S_Grid.DataSource = CS.Tables["Subjects"];
            this.S_Grid.DataBind();
            //ultraGrid1.DisplayLayout.AutoFitColumns = true;
            S_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            S_Grid.DisplayLayout.Key = "S_ID";
            S_Grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True; //FlatMode = true;

            for (int i = 0; i <= S_Grid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                S_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;


            S_Grid.DisplayLayout.Bands[0].Columns["S_Order"].Hidden = false;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Order"].Header.Caption = "მიმდევრობა";
            S_Grid.DisplayLayout.Bands[0].Columns["S_Order"].Header.VisiblePosition = 1;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Order"].Width = 94;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            S_Grid.DisplayLayout.Bands[0].Columns["S_Caption"].Hidden = false;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Caption"].Width = 80;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Caption"].Header.VisiblePosition = 2;
            S_Grid.DisplayLayout.Bands[0].Columns["S_Caption"].Header.Caption = "თემატიკა";
            S_Grid.DisplayLayout.Bands[0].Columns["S_Caption"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; ;

            S_Grid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            S_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.AliceBlue;//.LightSteelBlue;// .Wheat;
            S_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            S_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            S_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;
            S_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.Honeydew;//.LightSteelBlue;// .Wheat;
            

            S_Grid.DisplayLayout.MaxColScrollRegions = 1;
            S_Grid.DisplayLayout.MaxRowScrollRegions = 1;

            S_Grid.DisplayLayout.Bands[0].SortedColumns.Clear();
            S_Grid.DisplayLayout.Bands[0].SortedColumns.Add("S_ID", false);



            this.S_ultraLabel1.Visible = false;
            this.S_ultraLabel2.Visible = false;
            this.S_Order.Visible = false;
            this.S_Caption.Visible = false;
            this.S_Order.Enabled = false;
            this.S_Caption.Enabled = false;
            this.S_Add.Enabled = false;
            this.S_Add.Visible = false;

            this.S_Save.Enabled = false;
            this.S_Save.Visible = false;

            GMaxS = 0;
            foreach (DataRow dr in CS.Tables["Subjects"].Rows)
            {
                if ((int)dr["S_ID"] > GMaxS) GMaxS = (int)dr["S_ID"];
            }
            modeS = 0;
            this.Cursor = System.Windows.Forms.Cursors.Default;
             
        }

        private void S_News_Click(object sender, EventArgs e)
        {
            
            this.S_ultraLabel1.Visible = true;
            this.S_ultraLabel2.Visible = true;
            this.S_Order.Visible = true;
            this.S_Caption.Visible = true;
            this.S_Order.Enabled = true;
            this.S_Caption.Enabled = true;
            this.S_Add.Enabled = true;
            this.S_Add.Visible = true;
            this.S_Add.Text = "დამატება";
            modeS = 1;
            
        }

        private void S_Change_Click(object sender, EventArgs e)
        {
            
            if (this.S_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ  დოკუმენტის თემატიკა");
                return;
            }
            this.S_ultraLabel1.Visible = true;
            this.S_ultraLabel2.Visible = true;
            this.S_Order.Visible = true;
            this.S_Caption.Visible = true;
            this.S_Order.Enabled = true;
            this.S_Caption.Enabled = true;
            this.S_Add.Enabled = true;
            this.S_Add.Visible = true;
            this.S_Add.Text = "შეცვლა";

            modeS = 2;
            Stempid = (int)this.S_Grid.Selected.Rows[0].Cells["S_ID"].Value;
            foreach (DataRow dr in CS.Tables["Subjects"].Rows)
            {
                if ((int)dr["S_ID"] == Stempid)
                {
                    this.S_Order.Text = dr["S_Order"].ToString().Trim();
                    this.S_Caption.Text = dr["S_Caption"].ToString().Trim();
                    return;
                }
            }
			

	
            

        }

        private void S_Delete_Click(object sender, EventArgs e)
        {
            
            if (this.S_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ დოკუმენტის თემატიკა");
                return;
            }

            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის თემატიკის წაშლა\n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის თემატიკის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის თემატიკის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის თემატიკის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ კიდევ ერთხელ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            int tid = (int)this.S_Grid.Selected.Rows[0].Cells["S_ID"].Value;
            int curr = -1;


            for (int i = 0; i < CS.Tables["Subjects"].Rows.Count; i++)
            {
                if ((int)CS.Tables["Subjects"].Rows[i]["S_ID"] == tid)
                {
                    curr = i; break;
                }
            }


            if (curr == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000DA");
                return;
            }

            // Checking if Attribute is Used
            SqlDataAdapter ch1 = new SqlDataAdapter("SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_Subject = " + tid.ToString(),
                SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet Ds = new DataSet();
            ch1.Fill(Ds);
            int CCount = -1;
            try
            {
                CCount = (int)Ds.Tables[0].Rows[0][0];
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000CA");
                return;
            }

            if (CCount > 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის თემატიკა უკვე გამოყენებულია არსებულ დოკუმენტებში \n" +
               "მისი წაშლისთვის მოძებნეთ ყველა დოკუმენტი შესაბამისი თემით და შეუცვლეთ მას ეს ატრიბუტი\n" +
               "მას შემდეგ რა სისტემა დარწმუნდება, რომ ეს ატრიბუტი არსად არ არის გამოყენებული იგი მოგცემთ მისი წაშლის საშუალებას");
                return;
            }

            CS.Tables["Subjects"].Rows[curr].Delete();// RemoveAt(curr);
            this.S_Save.Enabled = true;
            this.S_Save.Visible = true;

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია წაშლილია");

		
        }

        private void S_Save_Click(object sender, EventArgs e)
        {
         
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
              != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DAC.Update(CS, "Subjects");

            this.S_Save.Visible = false;
            this.S_Save.Enabled = false;
            // IntCGLLocalVars.InitData();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
           
        }

        private void S_Add_Click(object sender, EventArgs e)
        {
            
            #region Add Information
            if (modeS == 1) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკის დამატება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.S_Order.Text.Trim();
                if (this.S_Order.Text == "") S_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(S_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.S_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკის დასახელება ცარიელია");
                    return;
                }

                // Add
                GMaxS++;
                double Order = System.Convert.ToDouble(this.S_Order.Text);
                CS.Tables["Subjects"].Rows.Add(new object[] { GMaxS, Order, this.S_Caption.Text.Trim() });

                this.S_Save.Enabled = true;
                this.S_Save.Visible = true;

                this.S_Caption.Text = "";
                this.S_Order.Text = "";
                this.S_ultraLabel1.Visible = false;
                this.S_ultraLabel2.Visible = false;
                this.S_Caption.Visible = false;
                this.S_Order.Visible = false;
                this.S_Caption.Enabled = false;
                this.S_Order.Enabled = false;
                this.S_Add.Enabled = false;
                this.S_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია დამატებულია");
                return;
            
            }
            #endregion Add Information

            #region Edit Information
            if (modeS == 2) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკის რედაქტირება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.S_Order.Text.Trim();
                if (this.S_Order.Text == "") S_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(S_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.S_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის თემატიკის დასახელება ცარიელია");
                    return;
                }

                // Add
                int curr = -1;


                for (int i = 0; i < CS.Tables["Subjects"].Rows.Count; i++)
                {
                    if ((int)CS.Tables["Subjects"].Rows[i]["S_ID"] == this.Stempid)
                    {
                        curr = i; break;
                    }
                }

                if (curr == -1)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 20001A");
                    return;
                }


                double Order = System.Convert.ToDouble(this.S_Order.Text);


                CS.Tables["Subjects"].Rows[curr]["S_Order"] = Order;
                CS.Tables["Subjects"].Rows[curr]["S_Caption"] = this.S_Caption.Text.Trim();



                this.S_Save.Enabled = true;
                this.S_Save.Visible = true;

                this.S_Caption.Text = "";
                this.S_Order.Text = "";
                this.S_ultraLabel1.Visible = false;
                this.S_ultraLabel2.Visible = false;
                this.S_Caption.Visible = false;
                this.S_Order.Visible = false;
                this.S_Caption.Enabled = false;
                this.S_Order.Enabled = false;
                this.S_Add.Enabled = false;
                this.S_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
                return;
            }
            #endregion Edit Information
            
        }
        #endregion Subject

        #region Category
        
        DataSet CC;
        SqlDataAdapter DACC;
        int modeC;
        int Ctempid = -1;
        int GMaxC = -1;
        SqlCommandBuilder cb_Category;
        

        public void C_Refresh_Click(object sender, EventArgs e)
        {
            
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
            string sql = "SELECT C_ID,C_ORDER,C_CAPTION FROM CodexDS_DCategory";
            cn.Open();
            DACC = new SqlDataAdapter(sql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            CC = new DataSet();
            cb_Category = new SqlCommandBuilder(DACC);

            DACC.Fill(CC, "Category");

            this.C_Grid.DataSource = CC.Tables["Category"];
            this.C_Grid.DataBind();
            //ultraGrid1.DisplayLayout.AutoFitColumns = true;
            C_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            C_Grid.DisplayLayout.Key = "C_ID";
            C_Grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True; //FlatMode = true;

            for (int i = 0; i <= C_Grid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                C_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;


            C_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Hidden = false;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Header.Caption = "მიმდევრობა";
            C_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Header.VisiblePosition = 1;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Width = 94;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            C_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Hidden = false;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Width = 80;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Header.VisiblePosition = 2;
            C_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Header.Caption = "თემატიკა";
            C_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; ;

            C_Grid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            C_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.Honeydew;//.LightSteelBlue;// .Wheat;
            C_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            C_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            C_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;
            C_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;


            C_Grid.DisplayLayout.MaxColScrollRegions = 1;
            C_Grid.DisplayLayout.MaxRowScrollRegions = 1;

            C_Grid.DisplayLayout.Bands[0].SortedColumns.Clear();
            C_Grid.DisplayLayout.Bands[0].SortedColumns.Add("C_ID", false);



            this.C_ultraLabel1.Visible = false;
            this.C_ultraLabel2.Visible = false;
            this.C_Order.Visible = false;
            this.C_Caption.Visible = false;
            this.C_Order.Enabled = false;
            this.C_Caption.Enabled = false;
            this.C_Add.Enabled = false;
            this.C_Add.Visible = false;

            this.C_Save.Enabled = false;
            this.C_Save.Visible = false;

            GMaxC = 0;
            foreach (DataRow dr in CC.Tables["Category"].Rows)
            {
                if ((int)dr["C_ID"] > GMaxC) GMaxC = (int)dr["C_ID"];
            }
            modeC = 0;
            this.Cursor = System.Windows.Forms.Cursors.Default;
             
        }

        private void C_News_Click(object sender, EventArgs e)
        {
            
            this.C_ultraLabel1.Visible = true;
            this.C_ultraLabel2.Visible = true;
            this.C_Order.Visible = true;
            this.C_Caption.Visible = true;
            this.C_Order.Enabled = true;
            this.C_Caption.Enabled = true;
            this.C_Add.Enabled = true;
            this.C_Add.Visible = true;
            this.C_Add.Text = "დამატება";
            modeC = 1;
            
        }

        private void C_Change_Click(object sender, EventArgs e)
        {
            
            if (this.C_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ  დოკუმენტის კატეგორია");
                return;
            }
            this.C_ultraLabel1.Visible = true;
            this.C_ultraLabel2.Visible = true;
            this.C_Order.Visible = true;
            this.C_Caption.Visible = true;
            this.C_Order.Enabled = true;
            this.C_Caption.Enabled = true;
            this.C_Add.Enabled = true;
            this.C_Add.Visible = true;
            this.C_Add.Text = "შეცვლა";

            modeC = 2;
            Ctempid = (int)this.C_Grid.Selected.Rows[0].Cells["C_ID"].Value;
            foreach (DataRow dr in CC.Tables["Category"].Rows)
            {
                if ((int)dr["C_ID"] == Ctempid)
                {
                    this.C_Order.Text = dr["C_Order"].ToString().Trim();
                    this.C_Caption.Text = dr["C_Caption"].ToString().Trim();
                    return;
                }
            }
			

	
          

        }

        private void C_Delete_Click(object sender, EventArgs e)
        {
            
            if (this.C_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ დოკუმენტის კატეგორია");
                return;
            }

            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის კატეგორიის წაშლა\n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის კატეგორიის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის კატეგორიის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის კატეგორიის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ კიდევ ერთხელ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            int tid = (int)this.C_Grid.Selected.Rows[0].Cells["C_ID"].Value;
            int curr = -1;


            for (int i = 0; i < CC.Tables["Category"].Rows.Count; i++)
            {
                if ((int)CC.Tables["Category"].Rows[i]["C_ID"] == tid)
                {
                    curr = i; break;
                }
            }


            if (curr == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000DA");
                return;
            }

            // Checking if Attribute is Used
            SqlDataAdapter ch1 = new SqlDataAdapter("SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_Category = " + tid.ToString(),
                SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet Ds = new DataSet();
            ch1.Fill(Ds);
            int CCount = -1;
            try
            {
                CCount = (int)Ds.Tables[0].Rows[0][0];
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000CA");
                return;
            }

            if (CCount > 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის კატეგორია უკვე გამოყენებულია არსებულ დოკუმენტებში \n" +
               "მისი წაშლისთვის მოძებნეთ ყველა დოკუმენტი შესაბამისი კატეგორიიდან და შეუცვლეთ მას ეს ატრიბუტი\n" +
               "მას შემდეგ რა სისტემა დარწმუნდება, რომ ეს ატრიბუტი არსად არ არის გამოყენებული იგი მოგცემთ მისი წაშლის საშუალებას");
                return;
            }

            CC.Tables["Category"].Rows[curr].Delete();// RemoveAt(curr);
            this.C_Save.Enabled = true;
            this.C_Save.Visible = true;

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია წაშლილია");

		    
        }

        private void C_Save_Click(object sender, EventArgs e)
        {
            
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
              != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DACC.Update(CC, "Category");

            this.C_Save.Visible = false;
            this.C_Save.Enabled = false;
            // IntCGLLocalVars.InitData();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
           
        }

        private void C_Add_Click(object sender, EventArgs e)
        {
            
            #region Add Information
            if (modeC == 1) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი დოკუმენტის  კატეგორიის დამატება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.C_Order.Text.Trim();
                if (this.C_Order.Text == "") C_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(C_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.C_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის კატეგორიის დასახელება ცარიელია");
                    return;
                }

                // Add
                GMaxC++;
                double Order = System.Convert.ToDouble(this.C_Order.Text);
                CC.Tables["Category"].Rows.Add(new object[] { GMaxC, Order, this.C_Caption.Text.Trim() });

                this.C_Save.Enabled = true;
                this.C_Save.Visible = true;

                this.C_Caption.Text = "";
                this.C_Order.Text = "";
                this.C_ultraLabel1.Visible = false;
                this.C_ultraLabel2.Visible = false;
                this.C_Caption.Visible = false;
                this.C_Order.Visible = false;
                this.C_Caption.Enabled = false;
                this.C_Order.Enabled = false;
                this.C_Add.Enabled = false;
                this.C_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია დამატებულია");
                return;
            
            }
            #endregion Add Information

            #region Edit Information
            if (modeC == 2) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის კატეგორიის რედაქტირება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.C_Order.Text.Trim();
                if (this.C_Order.Text == "") C_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(C_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.C_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის კატეგორიის დასახელება ცარიელია");
                    return;
                }

                // Add
                int curr = -1;


                for (int i = 0; i < CC.Tables["Category"].Rows.Count; i++)
                {
                    if ((int)CC.Tables["Category"].Rows[i]["C_ID"] == this.Ctempid)
                    {
                        curr = i; break;
                    }
                }

                if (curr == -1)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 20001A");
                    return;
                }


                double Order = System.Convert.ToDouble(this.C_Order.Text);


                CC.Tables["Category"].Rows[curr]["C_Order"] = Order;
                CC.Tables["Category"].Rows[curr]["C_Caption"] = this.C_Caption.Text.Trim();



                this.C_Save.Enabled = true;
                this.C_Save.Visible = true;

                this.C_Caption.Text = "";
                this.C_Order.Text = "";
                this.C_ultraLabel1.Visible = false;
                this.C_ultraLabel2.Visible = false;
                this.C_Caption.Visible = false;
                this.C_Order.Visible = false;
                this.C_Caption.Enabled = false;
                this.C_Order.Enabled = false;
                this.C_Add.Enabled = false;
                this.C_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
                return;
            }
            #endregion Edit Information
            
        }

        #endregion Category

        #region Status

        
        DataSet CST;
        SqlDataAdapter DAST;
        int modeST;
        int STtempid = -1;
        int GMaxST = -1;
        SqlCommandBuilder cb_Status;
        

        public void ST_Refresh_Click(object sender, EventArgs e)
        {
              
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            
            SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
            string sql = "SELECT C_ID,C_ORDER,C_CAPTION FROM CodexDS_DStatus";
            cn.Open();
            DAST = new SqlDataAdapter(sql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            CST = new DataSet();
            cb_Status = new SqlCommandBuilder(DAST);

            DAST.Fill(CST, "Status");

            this.ST_Grid.DataSource = CST.Tables["Status"];
            this.ST_Grid.DataBind();
            //ultraGrid1.DisplayLayout.AutoFitColumns = true;
            ST_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            ST_Grid.DisplayLayout.Key = "C_ID";
            ST_Grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True; //FlatMode = true;

            for (int i = 0; i <= ST_Grid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                ST_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;

            if (CodexDSBehavioral.Default.IsDefaultParameterStatus == true)
            {
                ST_Grid.DisplayLayout.Bands[0].Columns["C_ID"].Hidden = false;
                ST_Grid.DisplayLayout.Bands[0].Columns["C_ID"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
                ST_Grid.DisplayLayout.Bands[0].Columns["C_ID"].Header.Caption = "Id";
                ST_Grid.DisplayLayout.Bands[0].Columns["C_ID"].Header.VisiblePosition = 0;
                ST_Grid.DisplayLayout.Bands[0].Columns["C_ID"].Width = 34;
                ST_Grid.DisplayLayout.Bands[0].Columns["C_ID"].AutoEditMode = Infragistics.Win.DefaultableBoolean.False;
                ST_Grid.DisplayLayout.Bands[0].Columns["C_ID"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            }


            ST_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Hidden = false;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Header.Caption = "მიმდევრობა";
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Header.VisiblePosition = 1;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Width = 94;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            ST_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Hidden = false;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Width = 80;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Header.VisiblePosition = 2;
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Header.Caption = "თემატიკა";
            ST_Grid.DisplayLayout.Bands[0].Columns["C_Caption"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; ;

            ST_Grid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ST_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.Honeydew;//.LightSteelBlue;// .Wheat;
            ST_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;


            ST_Grid.DisplayLayout.MaxColScrollRegions = 1;
            ST_Grid.DisplayLayout.MaxRowScrollRegions = 1;

            ST_Grid.DisplayLayout.Bands[0].SortedColumns.Clear();
            ST_Grid.DisplayLayout.Bands[0].SortedColumns.Add("C_ID", false);
            ST_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            ST_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;



            this.ST_ultraLabel1.Visible = false;
            this.ST_ultraLabel2.Visible = false;
            this.ST_Order.Visible = false;
            this.ST_Caption.Visible = false;
            this.ST_Order.Enabled = false;
            this.ST_Caption.Enabled = false;
            this.ST_Add.Enabled = false;
            this.ST_Add.Visible = false;

            this.ST_Save.Enabled = false;
            this.ST_Save.Visible = false;

            GMaxST = 0;
            foreach (DataRow dr in CST.Tables["Status"].Rows)
            {
                if ((int)dr["C_ID"] > GMaxST) GMaxST = (int)dr["C_ID"];
            }
            modeST = 0;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            
        }

        private void ST_News_Click(object sender, EventArgs e)
        {
            
            this.ST_ultraLabel1.Visible = true;
            this.ST_ultraLabel2.Visible = true;
            this.ST_Order.Visible = true;
            this.ST_Caption.Visible = true;
            this.ST_Order.Enabled = true;
            this.ST_Caption.Enabled = true;
            this.ST_Add.Enabled = true;
            this.ST_Add.Visible = true;
            this.ST_Add.Text = "დამატება";
            modeST = 1;
            
        }

        private void ST_Change_Click(object sender, EventArgs e)
        {
            
            if (this.ST_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ  დოკუმენტის სტატუსი");
                return;
            }
            this.ST_ultraLabel1.Visible = true;
            this.ST_ultraLabel2.Visible = true;
            this.ST_Order.Visible = true;
            this.ST_Caption.Visible = true;
            this.ST_Order.Enabled = true;
            this.ST_Caption.Enabled = true;
            this.ST_Add.Enabled = true;
            this.ST_Add.Visible = true;
            this.ST_Add.Text = "შეცვლა";

            modeST = 2;
            STtempid = (int)this.ST_Grid.Selected.Rows[0].Cells["C_ID"].Value;
            foreach (DataRow dr in CST.Tables["Status"].Rows)
            {
                if ((int)dr["C_ID"] == STtempid)
                {
                    this.ST_Order.Text = dr["C_Order"].ToString().Trim();
                    this.ST_Caption.Text = dr["C_Caption"].ToString().Trim();
                    return;
                }
            }
			
            
        }

        private void ST_Delete_Click(object sender, EventArgs e)
        {
            
            if (this.ST_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ დოკუმენტის სტატუსი");
                return;
            }

            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სტატუსის წაშლა\n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სტატუსის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სტატუსის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სტატუსის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ კიდევ ერთხელ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            int tid = (int)this.ST_Grid.Selected.Rows[0].Cells["C_ID"].Value;
            int curr = -1;


            for (int i = 0; i < CST.Tables["Status"].Rows.Count; i++)
            {
                if ((int)CST.Tables["Status"].Rows[i]["C_ID"] == tid)
                {
                    curr = i; break;
                }
            }


            if (curr == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000DA");
                return;
            }

            // Checking if Attribute is Used
            SqlDataAdapter ch1 = new SqlDataAdapter("SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_Status = " + tid.ToString(),
                SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet Ds = new DataSet();
            ch1.Fill(Ds);
            int CCount = -1;
            try
            {
                CCount = (int)Ds.Tables[0].Rows[0][0];
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000CA");
                return;
            }

            if (CCount > 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის სტატუსი უკვე გამოყენებულია არსებულ დოკუმენტებში \n" +
               "მისი წაშლისთვის მოძებნეთ ყველა დოკუმენტი შესაბამისი სტატუსით და შეუცვლეთ მას ეს ატრიბუტი\n" +
               "მას შემდეგ რა სისტემა დარწმუნდება, რომ ეს ატრიბუტი არსად არ არის გამოყენებული იგი მოგცემთ მისი წაშლის საშუალებას");
                return;
            }

            CST.Tables["Status"].Rows[curr].Delete();// RemoveAt(curr);
            this.ST_Save.Enabled = true;
            this.ST_Save.Visible = true;

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია წაშლილია");
            
		    
        }

        private void ST_Save_Click(object sender, EventArgs e)
        {
            
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
              != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DAST.Update(CST, "Status");

            this.ST_Save.Visible = false;
            this.ST_Save.Enabled = false;
            // IntCGLLocalVars.InitData();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
           

        }

        private void ST_Add_Click(object sender, EventArgs e)
        {
            
            #region Add Information
            if (modeST == 1) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი დოკუმენტის  სტატუსის დამატება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.ST_Order.Text.Trim();
                if (this.ST_Order.Text == "") ST_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(ST_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.ST_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სტატუსის დასახელება ცარიელია");
                    return;
                }

                // Add
                GMaxST++;
                double Order = System.Convert.ToDouble(this.ST_Order.Text);
                CST.Tables["Status"].Rows.Add(new object[] { GMaxST, Order, this.ST_Caption.Text.Trim() });

                this.ST_Save.Enabled = true;
                this.ST_Save.Visible = true;

                this.ST_Caption.Text = "";
                this.ST_Order.Text = "";
                this.ST_ultraLabel1.Visible = false;
                this.ST_ultraLabel2.Visible = false;
                this.ST_Caption.Visible = false;
                this.ST_Order.Visible = false;
                this.ST_Caption.Enabled = false;
                this.ST_Order.Enabled = false;
                this.ST_Add.Enabled = false;
                this.ST_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია დამატებულია");
                return;
            
            }
            #endregion Add Information

            #region Edit Information
            if (modeST == 2) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სტატუსის რედაქტირება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.ST_Order.Text.Trim();
                if (this.ST_Order.Text == "") ST_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(ST_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.ST_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის სტატუსის დასახელება ცარიელია");
                    return;
                }

                // Add
                int curr = -1;


                for (int i = 0; i < CST.Tables["Status"].Rows.Count; i++)
                {
                    if ((int)CST.Tables["Status"].Rows[i]["C_ID"] == this.STtempid)
                    {
                        curr = i; break;
                    }
                }

                if (curr == -1)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 20001A");
                    return;
                }


                double Order = System.Convert.ToDouble(this.ST_Order.Text);


                CST.Tables["Status"].Rows[curr]["C_Order"] = Order;
                CST.Tables["Status"].Rows[curr]["C_Caption"] = this.ST_Caption.Text.Trim();



                this.ST_Save.Enabled = true;
                this.ST_Save.Visible = true;

                this.ST_Caption.Text = "";
                this.ST_Order.Text = "";
                this.ST_ultraLabel1.Visible = false;
                this.ST_ultraLabel2.Visible = false;
                this.ST_Caption.Visible = false;
                this.ST_Order.Visible = false;
                this.ST_Caption.Enabled = false;
                this.ST_Order.Enabled = false;
                this.ST_Add.Enabled = false;
                this.ST_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
                return;
            }
            #endregion Edit Information
            
        }


        #endregion Status


        #region Words

        DataSet CW;
        SqlDataAdapter DAW;
        int modeW;
        int Wtempid = -1;
        int GMaxW = -1;
        SqlCommandBuilder cb_Word;

        public void W_Refresh_Click(object sender, EventArgs e)
        {
              
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            SqlConnection cn = new SqlConnection(SQLConnectionStrings.Default.ConnectionString_CodexDS);
            string sql = "SELECT W_ID,W_ORDER,W_CAPTION FROM CodexDS_DWords";
            cn.Open();
            DAW = new SqlDataAdapter(sql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            CW = new DataSet();
            cb_Word = new SqlCommandBuilder(DAW);

            DAW.Fill(CW, "Words");

            this.W_Grid.DataSource = CW.Tables["Words"];
            this.W_Grid.DataBind();
            //ultraGrid1.DisplayLayout.AutoFitColumns = true;
            W_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            W_Grid.DisplayLayout.Key = "W_ID";
            W_Grid.UseFlatMode = Infragistics.Win.DefaultableBoolean.True; //FlatMode = true;

            for (int i = 0; i <= W_Grid.DisplayLayout.Bands[0].Columns.Count - 1; i++)
                W_Grid.DisplayLayout.Bands[0].Columns[i].Hidden = true;


            W_Grid.DisplayLayout.Bands[0].Columns["W_Order"].Hidden = false;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Order"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Order"].Header.Caption = "მიმდევრობა";
            W_Grid.DisplayLayout.Bands[0].Columns["W_Order"].Header.VisiblePosition = 1;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Order"].Width = 94;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Order"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


            W_Grid.DisplayLayout.Bands[0].Columns["W_Caption"].Hidden = false;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Caption"].AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Caption"].Width = 80;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Caption"].Header.VisiblePosition = 2;
            W_Grid.DisplayLayout.Bands[0].Columns["W_Caption"].Header.Caption = "თემატიკა";
            W_Grid.DisplayLayout.Bands[0].Columns["W_Caption"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit; ;

            W_Grid.DisplayLayout.Bands[0].Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            W_Grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.Honeydew;//.LightSteelBlue;// .Wheat;
            W_Grid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            W_Grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.SeaGreen;
       
            W_Grid.DisplayLayout.MaxColScrollRegions = 1;
            W_Grid.DisplayLayout.MaxRowScrollRegions = 1;

            W_Grid.DisplayLayout.Bands[0].SortedColumns.Clear();
            W_Grid.DisplayLayout.Bands[0].SortedColumns.Add("W_ID", false);



            this.W_ultraLabel1.Visible = false;
            this.W_ultraLabel2.Visible = false;
            this.W_Order.Visible = false;
            this.W_Caption.Visible = false;
            this.W_Order.Enabled = false;
            this.W_Caption.Enabled = false;
            this.W_Add.Enabled = false;
            this.W_Add.Visible = false;

            this.W_Save.Enabled = false;
            this.W_Save.Visible = false;

            GMaxW = 0;
            foreach (DataRow dr in CW.Tables["Words"].Rows)
            {
                if ((int)dr["W_ID"] > GMaxW) GMaxW = (int)dr["W_ID"];
            }
            modeW = 0;
            this.Cursor = System.Windows.Forms.Cursors.Default;
           
        }

        private void W_News_Click(object sender, EventArgs e)
        {

               this.W_ultraLabel1.Visible = true;
               this.W_ultraLabel2.Visible = true;
               this.W_Order.Visible = true;
               this.W_Caption.Visible = true;
               this.W_Order.Enabled = true;
               this.W_Caption.Enabled = true;
               this.W_Add.Enabled = true;
               this.W_Add.Visible = true;
               this.W_Add.Text = "დამატება";
               modeW = 1;
               
        }

        private void W_Change_Click(object sender, EventArgs e)
        {
            
            if (this.W_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ  დოკუმენტის საკვანძო სიტყვა");
                return;
            }
            this.W_ultraLabel1.Visible = true;
            this.W_ultraLabel2.Visible = true;
            this.W_Order.Visible = true;
            this.W_Caption.Visible = true;
            this.W_Order.Enabled = true;
            this.W_Caption.Enabled = true;
            this.W_Add.Enabled = true;
            this.W_Add.Visible = true;
            this.W_Add.Text = "შეცვლა";

            modeW = 2;
            Wtempid = (int)this.W_Grid.Selected.Rows[0].Cells["W_ID"].Value;
            foreach (DataRow dr in CW.Tables["Words"].Rows)
            {
                if ((int)dr["W_ID"] == Wtempid)
                {
                    this.W_Order.Text = dr["W_Order"].ToString().Trim();
                    this.W_Caption.Text = dr["W_Caption"].ToString().Trim();
                    return;
                }
            }
			
            
        }

        private void W_Delete_Click(object sender, EventArgs e)
        {
            
            if (this.W_Grid.Selected.Rows.Count == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნეთ დოკუმენტის საკვანძო სიტყვა");
                return;
            }

            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის საკვანძო სიტყვის წაშლა\n დარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის საკვანძო სიტყვის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის საკვანძო სიტყვის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის საკვანძო სიტყვის წაშლა \n დარწმუნებული ხართ ? დაადასტურეთ კიდევ ერთხელ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            int tid = (int)this.W_Grid.Selected.Rows[0].Cells["W_ID"].Value;
            int curr = -1;

            string sss = this.W_Grid.Selected.Rows[0].Cells["W_Caption"].Value.ToString().Trim();
            for (int i = 0; i < CW.Tables["Words"].Rows.Count; i++)
            {
                if ((int)CW.Tables["Words"].Rows[i]["W_ID"] == tid)
                {
                    curr = i; break;
                }
            }


            if (curr == -1)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000DA");
                return;
            }

            if (sss == "") sss = "asdfakldfhkladhflkashdflkjahdflkjahsfaljkfhqeuirywury2ouirwejkf";
            SqlDataAdapter ch1 = new SqlDataAdapter("SELECT COUNT(*) FROM CodexDS_DDOCS WHERE C_Words LIKE N'%" + sss + "%'",
                SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet Ds = new DataSet();
            ch1.Fill(Ds);
            int CCount = -1;
            try
            {
                CCount = (int)Ds.Tables[0].Rows[0][0];
            }
            catch
            {
                ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 2000CA");
                return;
            }

            if (CCount > 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("მონიშნული დოკუმენტის საკვანძო სიტყვა უკვე გამოყენებულია არსებულ დოკუმენტებში \n" +
               "მისი წაშლისთვის მოძებნეთ ყველა დოკუმენტი შესაბამისი საკვანძო სიტყვებით და შეუცვლეთ მას ეს ატრიბუტი\n" +
               "მას შემდეგ რა სისტემა დარწმუნდება, რომ ეს ატრიბუტი არსად არ არის გამოყენებული იგი მოგცემთ მისი წაშლის საშუალებას");
                return;
            }

            CW.Tables["Words"].Rows[curr].Delete();// RemoveAt(curr);
            this.W_Save.Enabled = true;
            this.W_Save.Visible = true;

            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია წაშლილია");
            
		    
        }

        private void W_Save_Click(object sender, EventArgs e)
        {
            
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ?", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
              != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;
            if (ILG.Windows.Forms.ILGMessageBox.Show("ცვლილებების ჩაწერა მონაცემთა ბაზაში \nდარწმუნებული ხართ ? დაადასტურეთ ხელმეორედ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2)
                != System.Windows.Forms.DialogResult.Yes) return;

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DAW.Update(CW, "Words");

            this.W_Save.Visible = false;
            this.W_Save.Enabled = false;
            // IntCGLLocalVars.InitData();
            this.Cursor = System.Windows.Forms.Cursors.Default;
            ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
           

        }

        private void W_Add_Click(object sender, EventArgs e)
        {
            
            #region Add Information
            if (modeW == 1) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("ახალი დოკუმენტის  საკვანძო სიტყვის დამატება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.W_Order.Text.Trim();
                if (this.W_Order.Text == "") W_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(W_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.W_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის საკვანძო სიტყვის დასახელება ცარიელია");
                    return;
                }

                // Add
                GMaxW++;
                double Order = System.Convert.ToDouble(this.W_Order.Text);
                CW.Tables["Words"].Rows.Add(new object[] { GMaxW, Order, this.W_Caption.Text.Trim() });

                this.W_Save.Enabled = true;
                this.W_Save.Visible = true;

                this.W_Caption.Text = "";
                this.W_Order.Text = "";
                this.W_ultraLabel1.Visible = false;
                this.W_ultraLabel2.Visible = false;
                this.W_Caption.Visible = false;
                this.W_Order.Visible = false;
                this.W_Caption.Enabled = false;
                this.W_Order.Enabled = false;
                this.W_Add.Enabled = false;
                this.W_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია დამატებულია");
                return;
            
            }
            #endregion Add Information

            #region Edit Information
            if (modeW == 2) // Add Information
            {
                if (ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის საკვანძო სიტყვის რედაქტირება, დაადასტურეთ", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, System.Windows.Forms.MessageBoxDefaultButton.Button2) !=
                    System.Windows.Forms.DialogResult.Yes) return;

                this.W_Order.Text.Trim();
                if (this.W_Order.Text == "") W_Order.Text = "1000";
                try
                {
                    double Orderi = System.Convert.ToDouble(W_Order.Text);
                }
                catch
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("მიმდევრობის განსაზღვრა ვერ მოხერხდა");
                    return;
                }
                if (this.W_Caption.Text.Trim() == "")
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("დოკუმენტის საკვანძო სიტყვის დასახელება ცარიელია");
                    return;
                }

                // Add
                int curr = -1;


                for (int i = 0; i < CW.Tables["Words"].Rows.Count; i++)
                {
                    if ((int)CW.Tables["Words"].Rows[i]["W_ID"] == this.Wtempid)
                    {
                        curr = i; break;
                    }
                }

                if (curr == -1)
                {
                    ILG.Windows.Forms.ILGMessageBox.Show("Codex Internal Error 20001A");
                    return;
                }


                double Order = System.Convert.ToDouble(this.W_Order.Text);


                CW.Tables["Words"].Rows[curr]["W_Order"] = Order;
                CW.Tables["Words"].Rows[curr]["W_Caption"] = this.W_Caption.Text.Trim();



                this.W_Save.Enabled = true;
                this.W_Save.Visible = true;

                this.W_Caption.Text = "";
                this.W_Order.Text = "";
                this.W_ultraLabel1.Visible = false;
                this.W_ultraLabel2.Visible = false;
                this.W_Caption.Visible = false;
                this.W_Order.Visible = false;
                this.W_Caption.Enabled = false;
                this.W_Order.Enabled = false;
                this.W_Add.Enabled = false;
                this.W_Add.Visible = false;

                ILG.Windows.Forms.ILGMessageBox.Show("ინფორმაცია ჩაწერილია");
                return;
            }
            #endregion Edit Information

        }
        #endregion Words


        public void SetTab(int i)
        {
            this.Panels.SelectedTab = this.Panels.Tabs[i];
        }

        private void A_Caption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void T_Caption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void S_Caption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void C_Caption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void ST_Caption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void W_Caption_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        private void ultraTabPageControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraButton25_Click(object sender, EventArgs e)
        {
            Close();
        }

   
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {

                case "პროგრამის შესახებ":   
                    AboutDS f = new AboutDS(); f.ShowDialog();
                    break;

                case "პარამეტრები":    // ButtonTool
                    CodexConfiguration fc = new CodexConfiguration(); fc.ShowDialog();
                    break;

                case "მიმღები ორგანო":    // ButtonTool
                    Panels.SelectedTab = this.Panels.Tabs[0];
                    break;

                 case "დოკუმენტის სახე":    // ButtonTool
                    Panels.SelectedTab = this.Panels.Tabs[1];
                    break;

                  case "თემატიკა":    // ButtonTool
                     Panels.SelectedTab = this.Panels.Tabs[2];
                    break;

                  case "კატეგორია":    // ButtonTool
                       Panels.SelectedTab = this.Panels.Tabs[3];
                    break;


                case "სტატუსი":    // ButtonTool
                    Panels.SelectedTab = this.Panels.Tabs[4];
                    break;

                       
                case "საკვანძო სიტყვა":    // ButtonTool
                    Panels.SelectedTab = this.Panels.Tabs[5];
                    break;

                case "დახურვა":    // ButtonTool
                    Close();
                    break;
            }


            
              

                
            
            

        }


    }
}