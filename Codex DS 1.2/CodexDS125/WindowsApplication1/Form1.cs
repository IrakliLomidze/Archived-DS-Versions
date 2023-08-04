using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter d = new SqlDataAdapter("SELECT * FROM Codex_DAUTHOR ORDER By A_Order;SELECT * FROM CGL_DTYPE ORDER By T_Order", 
                @"workstation id=ILGXPEXP;packet size=4096;integrated security=SSPI;data source=ILGXPEXP\Codex;persist security info=False;initial catalog=Codex2005;Connection Timeout=30");
            DataSet ds = new DataSet();
            d.Fill(ds);
            ds.WriteXml("C:\\111.xml");
            ds.WriteXmlSchema("C:\\113.xml");
            MessageBox.Show("D");

            


        }
    }
}