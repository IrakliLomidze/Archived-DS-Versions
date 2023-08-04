using System;
using System.Windows.Forms;
using System.IO;

namespace ILG.Codex.CodexR4
{
    partial class Form1
    {
        
        int CodexSortBy = 0;
        string CodexFilterBy = "";
        Boolean isnews = false;
        
        #region Sorting Button
        public void CodexSorting(int i)
        {
            switch (i)
            {
                case 0: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის თარიღის მიხედვით (კლებადობით)"; CodexSortBy = 0; break;
                case 1: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის თარიღის მიხედვით (ზრდადობით)"; CodexSortBy = 1; break;
                case 2: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "მიმღები ორგანოს მიხედვით"; CodexSortBy = 2; break;
                case 3: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის სახის მიხედვით"; CodexSortBy = 3; break;
                case 4: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის ნომრის მიხედვით"; CodexSortBy = 4; break;
                case 5: CodexToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის სტატუსის მიხედვით"; CodexSortBy = 5; break;
            }
        }

       
        #endregion Sorting Button

        #region Filter
        
        private void CGLListFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }

        
        private void CodexListFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBoard.Layout.IsActive == true)
            {
                e.KeyChar = KeyBoard.Layout.U[e.KeyChar];
            }
        }
        #endregion Filter

        void SaveList()
        {
           this.codexListBox1.SaveToRTF();
           
        }

        void ExportList()
        {
            String Suffix = "LL";
            String D = DateTime.Now.Ticks.ToString();
            string fn = DirectoryConfiguration.CodexDocumentsDirectory + @"\" + Suffix + D;//+".Doc";
            int i = 1;
            while (File.Exists(fn + "_" + i.ToString() + ".RTF") == true) { i++; }

            fn = fn + "_" + i.ToString() + ".RTF";

            try
            {
                this.codexListBox1.SaveToRTF(fn);
                System.Diagnostics.Process.Start(@"file" + @":\\" + fn);

            }
            catch (Exception ex)
            {
                ILG.Windows.Forms.ILGMessageBox.ShowE("არ ხერხდება სიის ექსპორტი MS-Word ში" ,ex.ToString());
                return;
            }

        }

        #region Resorting Codex
        
        
        public void ResortingCodexList(int i, string Filter)
        {

            if (isnews == true) CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            else CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            //this.ultraGrid1.DataSource = Codex_Result.Tables[0];
            
            this.codexListBox1.FillGrid();


            switch (i)
            {
                case 0: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Date ASC"); break;
                case 1: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Date DESC"); break;
                case 2: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Author"); break;
                case 3: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Type"); break;
                case 4: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Number"); break;
                case 5: this.codexListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Status"); break;
            }
            this.codexListBox1.FillGrid();
            if (isnews == true) CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + this.codexListBox1.DataSource.Length.ToString() + " დოკუმენტი";
            else CodexToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + this.codexListBox1.DataSource.Length.ToString() + " დოკუმენტი";
            
           // CodexListAmoundLabel.Text = "სიაში არის " + this.codexListBox1.DataSource.Length.ToString() + " დოკუმენტი";


        }
      


        
        private void Codex_List_FilterGO_Click(object sender, EventArgs e)
        {
            string f = CodexFilterBy;
            CodexFilterBy = "C_Caption LIKE '%" + this.CodexListFilter.Text.Trim() + "%'";
            //ResortingCodexList(CodexSortBy, CodexFilterBy);
            
            if (Codex_Result.Tables[0].Select(CodexFilterBy).Length == 0)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("ფილტრაციის შედეგი ცარიელია");
                this.CodexFilterBy = f;
                Codex_List_FilterClear.Visible = false;
                CodexListFilter.Text = "";
                
            }
            else
            {
                Codex_List_FilterClear.Visible = true;
            }
            
            ResortingCodexList(CodexSortBy, CodexFilterBy);
            if (CodexListFilter.Text.Trim() == "") Codex_List_FilterClear.Visible = false;

        }

        private void Codex_List_FilterClear_Click(object sender, EventArgs e)
        {
            CodexListFilter.Text = "";
            Codex_List_FilterGO_Click(null, null);
        }
        #endregion Resorting Codex

  
        private void CodexListFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Codex_List_FilterGO_Click(null, null);
        }


        

    }
}
