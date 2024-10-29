using ILG.DS.Access;
using ILG.DS.AppStateManagement;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ILG.DS.Dialogs
{
    public partial class AboutDS : Form
    {
        public AboutDS()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            
            TopImage.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(TopImage.Width, this.ClientSize.Height);
            String s = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            profile_name_label.Text = app.state.DS_Porfile_DisplayName;
            profile_id_label.Text = app.state.DS_Profile_Id;
            Label_Version_And_Build.Text = "Build: "+s;
            AccessRight();
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "https://www.codex.ge",
                UseShellExecute = true
            };
            Process.Start(processStartInfo);

        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AccessRight()
        {
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(Codex.CodexR4.Properties.Resources.place_blue); // 0
            this.imageList1.Images.Add(Codex.CodexR4.Properties.Resources.place_green); // 1
            this.imageList1.Images.Add(Codex.CodexR4.Properties.Resources.place_red); // 2
            this.imageList1.Images.Add(Codex.CodexR4.Properties.Resources.place); // 3
            this.listView1.SmallImageList = imageList1;

            DSAccessType f = app.state.RunTimeLicense.GetRights(app.state.DS_Profile_Id);
            switch (f)
            {
                case DSAccessType.NoAccess:
                    //listView1.Items.Clear();
                    //listView1.Items.Add("თქვენ არ გაქვთ სისტემასთან მუშაობის უფლება", 2);
                    //case DSAccessType.GuestLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    break;

                case DSAccessType.GuestLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    break;
                case DSAccessType.UserLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების ჩაწერა, კოპირება, ბეჭდვა", 0);
                    break;

                case DSAccessType.PowertLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება", 1);
                    break;

                case DSAccessType.ManagerLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტები  კოპირება, ბეჭდვა", 1);
                    break;


                case DSAccessType.OperatorLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტებზე ოპერირებაა", 3);
                    break;


                case DSAccessType.PowerOperatorLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტებზე ოპერირებაა", 3);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების  კოპირება, ბეჭდვა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტებზე ოპერირებაა", 3);
                    break;

                case DSAccessType.BossLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტებზე ოპერირებაა", 3);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების  კოპირება, ბეჭდვა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტებზე ოპერირებაა", 3);
                    listView1.Items.Add("სრული უფლებები სისტემაში", 3);
                    break;
            }


            this.listView2.SmallImageList = imageList1;
            bool rule1 = app.state.RunTimeLicense.GetRule1(app.state.DS_Profile_Id);
            if (rule1 == true) listView2.Items.Add("საიდუმლო დოკუმენტები ჩანს სიაში", 3);

            bool rule2 = app.state.RunTimeLicense.GetRule2(app.state.DS_Profile_Id);
            if (rule2 == true) listView2.Items.Add("დოკუმენტის ბმულებზე (Attachment) ზე წვდომა", 3);



            this.listView3.SmallImageList = imageList1;


            DSHistoryAccessType h = app.state.RunTimeLicense.GetHistoryRights(app.state.DS_Profile_Id);
            switch (h)
            {
                case DSHistoryAccessType.NoAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("თქვენ არ გაქვთ დოკუმენტების ისტორიასთან წვდომა", 2);
                    break;

                case DSHistoryAccessType.PublicAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("საჯარო ისტორიასთან წვდომა (თქვენი დაშვების მიხედვით)", 0);
                    break;
                case DSHistoryAccessType.ExtendedAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("საჯარო ისტორიასთან წვდომა (თქვენი დაშვების მიხედვით)", 0);
                    listView3.Items.Add("დახურულ ისტორიასთან წვდომა (თქვენი დაშვების მიხედვით)", 3);
                    break;

                case DSHistoryAccessType.ModificationAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("საჯარო ისტორიასთან წვდომა", 0);
                    listView3.Items.Add("დახურულ ისტორიასთან წვდომა", 0);

                    listView3.Items.Add("საჯარო ისტორიის მოდიფიკაცია", 1);
                    listView3.Items.Add("დახურულ ისტორიის  მოდიფიკაცია", 3);
                    break;

                case DSHistoryAccessType.AdminAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("საჯარო ისტორიასთან წვდომა", 0);
                    listView3.Items.Add("დახურულ ისტორიასთან წვდომა", 0);

                    listView3.Items.Add("საჯარო ისტორიის მოდიფიკაცია", 1);
                    listView3.Items.Add("დახურულ ისტორიის  მოდიფიკაცია", 1);
                    listView3.Items.Add("წაშლილი დოკუმეტების ძებნა", 3);
                    listView3.Items.Add("ისტორიიდან დოკუმენტის წაშლა", 3);
                    listView3.Items.Add("წაშლილი დოკუმეტების აღდგენა", 3);
                    break;


          
            }



        }
    }
}