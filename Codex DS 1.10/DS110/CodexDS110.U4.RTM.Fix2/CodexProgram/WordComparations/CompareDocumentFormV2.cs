using ILG.Codex.CodexR4.CodexSettings;
using ILG.Codex.CodexR4.History;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
    public partial class CompareDocumentFormV2 : Form
    {
        public CompareDocumentFormV2()
        {
            InitializeComponent();
        }

        public int OriginalDocID;
        public int RevisedDocID;
        public String OriginalDocStr;
        public String RevisedDocStr;
        public String Tilte;

        public int Original_SelectedIndex;
        public int Revised_SelectedIndex;

        public const bool MSWordMode = true;

        private void CompareDocumentForm_Load(object sender, EventArgs e)
        {
            Granularity.SelectedIndex = 0;
            ShowChangesIn.SelectedIndex = 2;
            SourceDocuments.SelectedIndex = 0;
            RevisionPanel.SelectedIndex = 1;
            ChangeMode.SelectedIndex = 1;
        }

  
        string HistoryListDateTimetoGString_2(DateTime dt)
        {

            String Str = "";
            switch (dt.Month)
            {
                case 1: Str = "იანვრის"; break;
                case 2: Str = "თებერვლის"; break;
                case 3: Str = "მარტის"; break;
                case 4: Str = "აპრილის"; break;
                case 5: Str = "მაისის"; break;
                case 6: Str = "ივნისის"; break;
                case 7: Str = "ივლისის"; break;
                case 8: Str = "აგვისტოს"; break;
                case 9: Str = "სექტემბრის"; break;
                case 10: Str = "ოქტომბრის"; break;
                case 11: Str = "ნოემბრის"; break;
                case 12: Str = "დეკემბრის"; break;
            }

            Str = dt.Year.ToString() + " წ. " + dt.Day.ToString() + " " + Str + " მდგომარეობით";
            return Str;
        }



        HistoryMenuModel MyDataTable;
        public void InitialiseCombos(HistoryMenuModel ds, int _Original_SelectedIndex, int _Revised_SelectedIndex)
        {
            OriginalDocID = -1;
            RevisedDocID = -1;
            //bool InternalMode = true;


            MyDataTable = new HistoryMenuModel();
            if (ds.Items.Count > 0)
            {
                MyDataTable.Items.AddRange(ds.Items);
            }
            HistoryMenuModelEntry item = new HistoryMenuModelEntry();
            item.ID = -1;
            item.Caption = "მიმდინარე";
            MyDataTable.Items.Add(item);



            OriginalCombo.DataSource = MyDataTable.Items;
            OriginalCombo.ValueMember = "ID";
            OriginalCombo.DisplayMember = "Caption";

            RevisedCombo.DataSource = MyDataTable.Items;
            RevisedCombo.ValueMember = "ID";
            RevisedCombo.DisplayMember = "Caption";

            OriginalCombo.SelectedIndex = _Original_SelectedIndex;
            RevisedCombo.SelectedIndex = _Revised_SelectedIndex;

            Original_SelectedIndex = _Original_SelectedIndex;
            Revised_SelectedIndex = _Revised_SelectedIndex;
        }

        public bool isCaneled = true;
        private void OKButton_Click(object sender, EventArgs e)
        {
            if ((int)OriginalCombo.Value == (int)RevisedCombo.Value)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("შესადარებელი დოკუმენტები იდენტურია");
                return;
            }


            

            OriginalDocID = (int)OriginalCombo.Value;
            RevisedDocID = (int)RevisedCombo.Value;



             if ((OriginalCombo.SelectedIndex == 0) || 
                ((OriginalCombo.SelectedIndex < RevisedCombo.SelectedIndex) && (RevisedCombo.SelectedIndex != 0)))
            {
              if (ILG.Windows.Forms.ILGMessageBox.Show("ორიგინალი დოკუმენტი უფრო ახალია ვიდრე რევიზირებული დოკუმენტი." + System.Environment.NewLine +
                                                       "შედარება ხორციელდება უფრო ახალი დოკუმენტის ძველ დოკუმენტთან." + System.Environment.NewLine +
                                                       "ეს ნიშნავს რომ კომბინირებულ დოკუმენტში მიიღებთ პირიქით შედეგს." + System.Environment.NewLine +
                                                        System.Environment.NewLine +
                                                        "განხორციელდეს შედარება ?","",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2 ) == System.Windows.Forms.DialogResult.No) return;
                
            }



            Tilte = "დარდება: ";

            if (OriginalDocID == -1) { Tilte = Tilte + "მიმდინარე დოკუმენტი <->"; }
            else { Tilte = Tilte + "დოკუმენტი " + OriginalCombo.Text.Trim().Substring(0, OriginalCombo.Text.Trim().Length - "მდგომარეობით".Length) + " მდგომარეობით <==> "; }

            

            if (RevisedDocID == -1) { Tilte = Tilte + "მიმდინარე დოკუმენტს "; }
            else { Tilte = Tilte + " (" + RevisedCombo.Text.Trim().Substring(0, RevisedCombo.Text.Trim().Length - "მდგომარეობით".Length) + ") მდგომარეობით დოკუმენტს "; }

            // if Left Selection is Hiegr than Right one Warn to User

            isCaneled = false;

            Original_SelectedIndex = OriginalCombo.SelectedIndex;
            Revised_SelectedIndex = RevisedCombo.SelectedIndex;

            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            isCaneled = true;
            Close();
        }

        private void OriginalCombo_ValueChanged(object sender, EventArgs e)
        {
            LabelWarning.Text = GenerateTitle();
        }

        private void RevisedCombo_ValueChanged(object sender, EventArgs e)
        {
            LabelWarning.Text = GenerateTitle();
        }

        private String GenerateTitle()
        {
            if (OriginalCombo.Value == null) return "";
            if (RevisedCombo.Value == null) return "";

            LabelWarning2.Text = "";
            LabelWarning2.Visible = false;
       

            int OriginalDocID = (int)OriginalCombo.Value;
            int RevisedDocID = (int)RevisedCombo.Value;


            if (OriginalCombo.SelectedIndex != RevisedCombo.SelectedIndex)
            {

                if ((OriginalCombo.SelectedIndex == 0) ||
                   ((OriginalCombo.SelectedIndex < RevisedCombo.SelectedIndex) && (RevisedCombo.SelectedIndex != 0)))
                {
                    LabelWarning2.Visible = true;
                    LabelWarning2.Text = "უფრო ახალი დოკუმენტის დარდება ძველ დოკუმენტთან (შედეგს მიიღებთ პირიქით)";
                }
            }


            String Tilte = "დარდება: ";

            if (OriginalDocID == -1) { Tilte = Tilte + "მიმდინარე დოკუმენტი <->"; }
            else { Tilte = Tilte + "დოკუმენტი " + OriginalCombo.Text.Trim().Substring(0, OriginalCombo.Text.Trim().Length - "მდგომარეობით".Length) + " მდგომარეობით <==> "; }



            if (RevisedDocID == -1) { Tilte = Tilte + "მიმდინარე დოკუმენტს "; }
            else { Tilte = Tilte + " (" + RevisedCombo.Text.Trim().Substring(0, RevisedCombo.Text.Trim().Length - "მდგომარეობით".Length) + ") მდგომარეობით დოკუმენტს "; }

            SwipeButton.Focus();
            return Tilte;
        }


        private void SwipeButton_Click(object sender, EventArgs e)
        {
            if (OriginalCombo.Value == null) return ;
            if (RevisedCombo.Value == null) return ;
            int Origin = OriginalCombo.SelectedIndex;
            int Revise = RevisedCombo.SelectedIndex;

            OriginalCombo.SelectedIndex = Revise;
            RevisedCombo.SelectedIndex = Origin;


            
        }


    }
}
