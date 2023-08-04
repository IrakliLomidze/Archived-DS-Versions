﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ILG.Codex.Codex2007
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void About_Load(object sender, EventArgs e)
        {
            
            AccessType f = License.GetRights();
            switch (f)
            {
                case AccessType.NoAccess:  
                    listView1.Items.Clear();
                    listView1.Items.Add("თქვენ არ გაქვთ სისტემასთან მუშაობის უფლება",3); 
                    break;
                
                case AccessType.GuestLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა",0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება",0);
                    break;
                case AccessType.UserLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა",0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება",0);
                    listView1.Items.Add("საჯარო დოკუმენტების ჩაწერა, კოპირება, ბეჭდვა",0);
                    break;
 
                case AccessType.PowertLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა",0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება",0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა",4);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა",1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება",1);
                    break;

                case AccessType.ManagerLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა",0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება",0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა",4);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა",1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება",1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტები  კოპირება, ბეჭდვა",4);
                    break;


                case AccessType.OperatorLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა",0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება",0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა",4);
                    listView1.Items.Add("საჯარო დოკუმენტებზე ოპერირებაა",3);
                    break;


                case AccessType.PowerOperatorLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა",0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება",0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა",4);
                    listView1.Items.Add("საჯარო დოკუმენტებზე ოპერირებაა",3);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა",1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება",1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების  კოპირება, ბეჭდვა",4);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტებზე ოპერირებაა",3);
                    break;

                case AccessType.BossLicense:
                    listView1.Items.Clear();
                    listView1.Items.Add("საჯარო დოკუმენტების ძებნა", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების დათვალიერება", 0);
                    listView1.Items.Add("საჯარო დოკუმენტების  კოპირება, ბეჭდვა", 4);
                    listView1.Items.Add("საჯარო დოკუმენტებზე ოპერირებაა", 3);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების ძებნა", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების დათვალიერება", 1);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტების  კოპირება, ბეჭდვა", 4);
                    listView1.Items.Add("კონფიდენციალური დოკუმენტებზე ოპერირებაა", 3);
                    listView1.Items.Add("სრული უფლებები სისტემაში",3);
                    break;
            }

            bool rule1 = License.GetRule1();
            if (rule1 == true)     listView1.Items.Add("საიდუმლო დოკუმენტები ჩანს სიაში",2);

            bool rule2 = License.GetRule2();
            if (rule2 == true) listView1.Items.Add("დოკუმენტის ბმულებზე წვდომა", 2); 
            
        }
    }
}