using ILG.DS.Configurations.Profile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ILG.DS.Configurations.Dialogs
{
    public partial class DSProfileSelector : Form
    {
        private readonly List<DSProfileItemViewModel> _propfileList;
        public DSProfileSelector(List<DSProfileItemViewModel> propfileList)
        {
            InitializeComponent();
            _propfileList = propfileList;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DSProfileSelector_Load(object sender, EventArgs e)
        {
            SuspendLayout();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _propfileList;

            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.MultiSelect = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.RowHeadersWidth = 24;
            
            for(int i=0; i< dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = false;
                dataGridView1.Columns[i].HeaderText = i.ToString();
            }
            

            dataGridView1.Columns["DS_Profile_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["DS_Profile_Name"].HeaderText = "Id";
            dataGridView1.Columns["DS_Profile_Name"].Visible = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(253, 253, 253);
            dataGridView1.GridColor = Color.FromArgb(242, 242, 242);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 220, 220);// Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;



            dataGridView1.Columns["DS_Porfile_DisplayName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["DS_Porfile_DisplayName"].HeaderText = "პროფილის სახელი";
            dataGridView1.Columns["DS_Porfile_DisplayName"].Visible = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(253, 253, 253);
            dataGridView1.GridColor = Color.FromArgb(242, 242, 242);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 220, 220);// Color.Blue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            int h = TopPanel.Height + dataGridView1.Height + CloseButton.Height + (CloseButton.Height / 2) + (CloseButton.Height / 2);
            int w = ConfiguraitonTop_ICON.Margin.Left + ConfiguraitonTop_ICON.Size.Width + ConfiguraitonTop_ICON.Margin.Right +
                    ConfiguraitonTop_Label.Width + ConfiguraitonTop_ICON.Size.Width;
            
            this.ClientSize = new System.Drawing.Size(w, h);
            
            Select_Button.Left = w - Select_Button.Width - 8;
            Select_Button.Top = w - CloseButton.Height - CloseButton.Height / 2;
            CloseButton.Left = Select_Button.Left - CloseButton.Width - 12;
            Select_Button.Top = CloseButton.Top;

            this.ClientSize = new Size(w, h);

            ResumeLayout();
        }

        public string _DS_Porfile_DisplayName = "";
        public string _DS_Profile_Name = "";
        private void DoSelecting()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                _DS_Porfile_DisplayName = dataGridView1.SelectedRows[0].Cells["DS_Porfile_DisplayName"].Value.ToString(); ;
                _DS_Profile_Name = dataGridView1.SelectedRows[0].Cells["DS_Profile_Name"].Value.ToString();
            }
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            DoSelecting();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Select_Button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            DoSelecting();
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}
