using System;
using System.Windows.Forms;
using System.IO;
using ILG.DS.Controls;
using ILG.DS.Configurations;
using System.Diagnostics;

namespace ILG.Codex.CodexR4
{
    partial class Form1
    {
        
        public int CodexSortBy = 0;
        public string CodexFilterBy = "";
        Boolean isnews = false;
        
        #region Sorting Button
        public void CodexSorting(int i)
        {
            switch (i)
            {
                case 0: DSToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის თარიღის მიხედვით (კლებადობით)"; CodexSortBy = 0; break;
                case 1: DSToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის თარიღის მიხედვით (ზრდადობით)"; CodexSortBy = 1; break;
                case 2: DSToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "მიმღები ორგანოს მიხედვით"; CodexSortBy = 2; break;
                case 3: DSToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის სახის მიხედვით"; CodexSortBy = 3; break;
                case 4: DSToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის ნომრის მიხედვით"; CodexSortBy = 4; break;
                case 5: DSToolBar.Tools["CodexSortMenu"].SharedProps.Caption =  "დოკუმენტის სტატუსის მიხედვით"; CodexSortBy = 5; break;
            }
        }

       
        #endregion Sorting Button

        #region Filter
        
        private void CGLListFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }

        
        private void CodexListFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DSKeyboardLayout.IsActive == true)
            {
                e.KeyChar = DSKeyboardLayout.U[e.KeyChar];
            }
        }
        #endregion Filter

        void SaveList()
        {
            // ZXZ ZXZ
           this.F_DS_List.DocumentListBox1.SaveToRTF();
           
        }

        void ExportList()
        {
            String Suffix = "LL";
            String D = DateTime.Now.Ticks.ToString();
            string fn = DirectoryConfiguration.DSDocumentsDirectory + @"\" + Suffix + D;//+".Doc";
            int i = 1;
            while (File.Exists(fn + "_" + i.ToString() + ".RTF") == true) { i++; }

            fn = fn + "_" + i.ToString() + ".RTF";

            try
            {
                this.F_DS_List.DocumentListBox1.SaveToRTF(fn);
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(@"file" + @":\\" + fn)
                {
                    UseShellExecute = true
                };
                p.Start();

            }
            catch (Exception ex)
            {
                ILGMessageBox.ShowE("არ ხერხდება სიის ექსპორტი MS-Word ში" ,ex.ToString());
                return;
            }

        }

        #region Resorting Codex
        
        
        public void ResortingCodexList(int i, string Filter)
        {

            if (isnews == true) DSToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            else DSToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + Codex_Result.Tables[0].Rows.Count.ToString() + " დოკუმენტი";
            //this.ultraGrid1.DataSource = Codex_Result.Tables[0];
            
            this.F_DS_List.DocumentListBox1.FillGrid();


            switch (i)
            {
                case 0: this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Date ASC"); break;
                case 1: this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Date DESC"); break;
                case 2: this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Author"); break;
                case 3: this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Type"); break;
                case 4: this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Number"); break;
                case 5: this.F_DS_List.DocumentListBox1.DataSource = Codex_Result.Tables[0].Select(Filter, "C_Status"); break;
            }
            this.F_DS_List.DocumentListBox1.FillGrid();
            if (isnews == true) DSToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიახლის სიაში არის " + this.F_DS_List.DocumentListBox1.DataSource.Length.ToString() + " დოკუმენტი";
            else DSToolBar.Tools["Codex_List_Count"].SharedProps.Caption = "სიაში არის " + this.F_DS_List.DocumentListBox1.DataSource.Length.ToString() + " დოკუმენტი";
            
           // CodexListAmoundLabel.Text = "სიაში არის " + this.codexListBox1.DataSource.Length.ToString() + " დოკუმენტი";


        }
      


        

        
        #endregion Resorting Codex



        

    }
}
