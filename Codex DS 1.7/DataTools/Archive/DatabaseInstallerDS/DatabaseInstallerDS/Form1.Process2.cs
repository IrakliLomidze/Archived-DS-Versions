using System;
using System.IO;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ILG.Codex.Codex2007
{
    partial class Form1
    {
        #region startinfo
        Server srv;
        bool res1;
        bool act1;

        private int getsqldatabasesinfo()
        {
            srv = new Server(global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer);
            srv.ConnectionContext.LoginSecure = true; // LoginSecure = true;
            try
            {
                srv.ConnectionContext.ConnectTimeout = 30;
                srv.ConnectionContext.Connect();

            }
            catch (System.Exception ex)
            {
                ILG.Windows.Forms.ILGMessageBox.Show("შეცდომა: \n" +
                    "არ ხერხდება " +
                    "SQL Server [" + global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer + "] დაკავშირება \n" + ex.Message.ToString());
                return 1;
            }
            return 0;

        }

        private void getdatabasestates()
        {
            res1 = false;
            
            for (int i = 0; i < srv.Databases.Count; i++)
            {
                //srv.Databases.Item(i).Name
                if (srv.Databases[i].Name.ToString().Trim().ToUpper() == "CODEX2007DS") res1 = true;
            }
            

            if (res1 == false)
            {
                
                this.ultraCheckEditor3.Enabled = false;
                this.ultraButton11.Enabled = false;
                this.ultraButton10.Enabled = true;
                this.ultraButton9.Enabled = false;
                this.ultraTextEditor1.Text = "ბაზა არ არის რეგისტირებული";

            }
            else
            {
                this.ultraCheckEditor3.Enabled = true;
                this.ultraButton11.Enabled = true;
                this.ultraButton10.Enabled = false;
                this.ultraButton9.Enabled = true;
                
                ultraCheckEditor3.Checked = !((srv.Databases["Codex2007DS"].Status & DatabaseStatus.Offline) == DatabaseStatus.Offline);

                this.act1 = this.ultraCheckEditor3.Checked;
                if (this.act1 == true) this.ultraTextEditor1.Text = srv.Databases["Codex2007DS"].PrimaryFilePath;
                else this.ultraTextEditor1.Text  = "ბაზა დეაქტივიზირებულია, შეუძლებელია მისი ადგილმდებარეობის განსაზღვრა";
                
            }


        }

        #endregion startinfo

    }
}
