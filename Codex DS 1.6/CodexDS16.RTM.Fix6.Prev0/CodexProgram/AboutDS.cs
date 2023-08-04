using System;
using System.Reflection;
using System.Windows.Forms;

namespace ILG.Codex.CodexR4
{
    public partial class AboutDS : Form
    {
        public AboutDS()
        {
            InitializeComponent();
        }

        private void ultraTabPageControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            
            TopImage.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(TopImage.Width, this.ClientSize.Height);
            String s = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Label_Version_And_Build.Text = "Build: "+s;
            AccessRight();
        }

        private void ultraFormattedLinkLabel1_LinkClicked(object sender, Infragistics.Win.FormattedLinkLabel.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codex.ge"); 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AccessRight()
        {
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(Properties.Resources.place_blue); // 0
            this.imageList1.Images.Add(Properties.Resources.place_green); // 1
            this.imageList1.Images.Add(Properties.Resources.place_red); // 2
            this.imageList1.Images.Add(Properties.Resources.place); // 3
            this.listView1.SmallImageList = imageList1;

            AccessType f = License.GetRights();
            switch (f)
            {
                case AccessType.NoAccess:
                    listView1.Items.Clear();
                    listView1.Items.Add("თქვენ არ გაქვთ სისტემასთან მუშაობის უფლება", 2);
                    break;

                case AccessType.GuestLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    break;
                case AccessType.UserLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების ჩაწერა, კოპირება, ბეჭდვა", 0);
                    break;

                case AccessType.PowertLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება", 1);
                    break;

                case AccessType.ManagerLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტები  კოპირება, ბეჭდვა", 1);
                    break;


                case AccessType.OperatorLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტებზე ოპერირებაა", 3);
                    break;


                case AccessType.PowerOperatorLicense:
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

                case AccessType.BossLicense:
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
            bool rule1 = License.GetRule1();
            if (rule1 == true) listView2.Items.Add("საიდუმლო დოკუმენტები ჩანს სიაში", 3);

            bool rule2 = License.GetRule2();
            if (rule2 == true) listView2.Items.Add("დოკუმენტის ბმულებზე (Attachment) ზე წვდომა", 3);



            this.listView3.SmallImageList = imageList1;


            HistoryAccessType h = License.GetHistoryRights();
            switch (h)
            {
                case HistoryAccessType.NoAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("თქვენ არ გაქვთ დოკუმენტების ისტორიასთან წვდომა", 2);
                    break;

                case HistoryAccessType.PublicAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("საჯარო ისტორიასთან წვდომა (თქვენი დაშვების მიხედვით)", 0);
                    break;
                case HistoryAccessType.ExtendedAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("საჯარო ისტორიასთან წვდომა (თქვენი დაშვების მიხედვით)", 0);
                    listView3.Items.Add("დახურულ ისტორიასთან წვდომა (თქვენი დაშვების მიხედვით)", 3);
                    break;

                case HistoryAccessType.ModificationAccess:
                    listView3.Items.Clear();
                    listView3.Items.Add("საჯარო ისტორიასთან წვდომა", 0);
                    listView3.Items.Add("დახურულ ისტორიასთან წვდომა", 0);

                    listView3.Items.Add("საჯარო ისტორიის მოდიფიკაცია", 1);
                    listView3.Items.Add("დახურულ ისტორიის  მოდიფიკაცია", 3);
                    break;

                case HistoryAccessType.AdminAccess:
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