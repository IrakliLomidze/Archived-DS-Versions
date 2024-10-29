using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ILG.Codex.Cryptography;
using CodexInternalOperations;
using ILG.Codex.CodexR4;
using ILG.Codex.Internal;

namespace CodexR4.Operations.Update.IO
{

    public class CodexUpdateIOforICG : CodexUpdateIOCommon, ICodexUpdateIOCommon
    {
        private string _CUF_KEY;

        public CodexUpdateIOforICG(String UpdateDatabaseConnectionString, String MainDatabaseConnectionString, String TempDirecotry) 
            : base (UpdateDatabaseConnectionString, MainDatabaseConnectionString, TempDirecotry)
        {
            _CUF_KEY = "8215421B010E3BA62418A5EF565EFB1F";
        }


    

        public bool CheckIfUpdateValid(ref String ErrorReport)
        {

            #region Description
            // Check Whither update item is already in main database
            //  1) if new document are not in main database
            //  2) if fordel and changed documents preseent in main database
            #endregion

            string Str = "";
            try
            {
                #region Attribute Iniitialisation
                DataSet ds;
                DataTable dtx1;
                DataTable dtx2;

                String strcmd = "SELECT * FROM ICG_CNTR ORDER By L_Order";
                SqlDataAdapter da = new SqlDataAdapter(strcmd, _MainDatabaseConnectioString);
                ds = new DataSet();
                da.Fill(ds);
                dtx1 = ds.Tables[0];


                strcmd = "SELECT * FROM ICG_DTYP ORDER By CT_Order";
                da = new SqlDataAdapter(strcmd, _MainDatabaseConnectioString);
                ds = new DataSet();
                da.Fill(ds);
                dtx2 = ds.Tables[0];
                #endregion Attribute Iniitialisation


                string str1 = "SELECT C_ID FROM ICG_CDOC WHERE C_TODO = 1";
                SqlConnection cn_update = new SqlConnection(_UpdateDatabaseConnectioString);
                cn_update.Open();
                ds = new DataSet();
                da = new SqlDataAdapter(str1, cn_update);
                da.Fill(ds, "z1");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i != ds.Tables[0].Rows.Count - 1) Str = Str + ds.Tables[0].Rows[i]["C_ID"].ToString() + " ,";
                        else Str = Str + ds.Tables[0].Rows[i]["C_ID"].ToString();
                    }
                }

                cn_update.Close();

                if (Str == "") return false; // Empty Database

                string Fields = "C_ID,C_Caption,C_Language,C_Date,C_Country,C_Type,C_DocEncoding";
                string str2 = "SELECT " + Fields + " FROM ICG_CDOC WHERE C_ID in ( " + Str + " )";

                ds = new DataSet();
                SqlConnection cn_base = new SqlConnection(_MainDatabaseConnectioString);
                da = new SqlDataAdapter(str2, cn_base);
                da.Fill(ds);
                cn_base.Close();

                if (ds.Tables[0].Rows.Count == 0) return true; // All Right

                
                // Generate Report

                StringBuilder Strcountry = new StringBuilder("1");
                StringBuilder Strtype = new StringBuilder("1");

                dtx1.PrimaryKey = new DataColumn[] { dtx1.Columns["L_ID"] };
                dtx2.PrimaryKey = new DataColumn[] { dtx2.Columns["CT_ID"] };


                DataRow dr;

                string result = "";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Strcountry.Remove(0, Strcountry.Length);
                    Strtype.Remove(0, Strtype.Length);

                    dr = dtx1.Rows.Find((int)ds.Tables[0].Rows[i]["C_Country"]);
                    if (dr == null) Strcountry.Append(" ");
                    else Strcountry.Append(@dr["L_Caption"].ToString().Trim());
                    dr = dtx2.Rows.Find((int)ds.Tables[0].Rows[i]["C_Type"]);

                    if (dr == null) Strtype.Append(" ");
                    else Strtype.Append(@dr["CT_Caption"].ToString().Trim());


                    DateTime dtv = (DateTime)ds.Tables[0].Rows[i]["C_Date"];
                    String dtime = GeorgianDateString.DateToString((DateTime)ds.Tables[0].Rows[i]["C_Date"]) + "  ";
                    if ((dtv.Year == 1975) && (dtv.Month == 12) && (dtv.Day == 12)) dtime = "";

                    String S = dtime +
                        Strcountry.ToString() + "  " + Strtype.ToString() + " ";

                    result = result +
                        "-----------------------------------------------------------------------------" + Environment.NewLine +
                        S +
                        Environment.NewLine + Environment.NewLine  +
                        @FilterString(ds.Tables[0].Rows[i]["C_Caption"].ToString())
                        + Environment.NewLine;
                }



                ErrorReport = result;
                return false;

            }
            catch (System.Exception ex)
            {
                return false;
            }

            return false;

        }

        public bool CheckUpdateIfEmpty()
        {
            return base.CheckUpdateIfEmpty("SELECT C_ID FROM ICG_CDOC");
        }


        public void GenerateCUF(String OutputPath, bool TimeZoneConsidiration, ref bool isCorrected)
        {

            DataSet ds = new DataSet("Data");

            string sql = "SELECT C_ID, C_CAPTION, C_LANGUAGE, C_DATE, C_ORDER, C_TEXT, C_COUNTRY, C_TYPE, C_TODO, C_DocFormat, C_DocEncoding, C_DocText," +
                "R_Str,R_int1,R_int2,R_int3,R_Float,R_Date1,R_Date2,R_blob FROM ICG_CDOC";
            SqlDataAdapter Da_ICG_CDOC = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            SqlCommandBuilder Cb_ICG_CDOC = new SqlCommandBuilder(Da_ICG_CDOC);
            Da_ICG_CDOC.Fill(ds, "ICG_CDOC");

            sql = "SELECT L_ID, L_CAPTION, L_ORDER, L_BMP, L_STATUS FROM ICG_CNTR";
            SqlDataAdapter Da_ICG_CNTR = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            SqlCommandBuilder Cb_ICG_CNTR = new SqlCommandBuilder(Da_ICG_CNTR);
            Da_ICG_CNTR.Fill(ds, "ICG_CNTR");

            sql = "SELECT CT_ID, CT_CAPTION, CT_ORDER FROM ICG_DTYP";
            SqlDataAdapter Da_ICG_DTYP = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            SqlCommandBuilder Cb_ICG_DTYP = new SqlCommandBuilder(Da_ICG_DTYP);
            Da_ICG_DTYP.Fill(ds, "ICG_DTYP");

            sql = "SELECT C_ID, C_CAPTION, C_ORDER FROM ICG_SUBJECT";
            SqlDataAdapter Da_ICG_SUBJECT = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            SqlCommandBuilder Cb_ICG_SUBJECT = new SqlCommandBuilder(Da_ICG_SUBJECT);
            Da_ICG_DTYP.Fill(ds, "ICG_SUBJECT");

            sql = "SELECT C_Version, C_Date, C_CodexDocs, C_CGLDocs, C_ICGDocs, C_CodexDate, C_CGLDate, C_ICGDate " +
                "FROM CodexR4Update";
            SqlDataAdapter Da_ICG_Codex2005Update = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            SqlCommandBuilder Cb_Codex2005Update = new SqlCommandBuilder(Da_ICG_Codex2005Update);
            Da_ICG_Codex2005Update.Fill(ds, "Codex2005Update");

            sql = "SELECT Status FROM UpdateStatus";
            SqlDataAdapter Da_Status = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            SqlCommandBuilder Cb_Status = new SqlCommandBuilder(Da_Status);
            Da_Status.Fill(ds, "Status");


            if (TimeZoneConsidiration == true)
            {
                ds.WriteXml      (Path.Combine(_TemporaryDir , "Data_ICG.xml2"));
                ds.WriteXmlSchema(Path.Combine(_TemporaryDir,  "Shema_Data_ICG.xml"));

                // ფაილის გენერაცია პრობლემის გათვალიწინებით
                ICGDateTimeFix.ICGUpdateFix(
                                        Path.Combine(_TemporaryDir, "Shema_Data_ICG.xml"),
                                        Path.Combine(_TemporaryDir, "Data_ICG.xml2"),
                                        Path.Combine(_TemporaryDir, "Data_ICG.xml"));
                bool f12 =
                    ICGDateTimeFix.CheckICGUpdate(
                                        Path.Combine(_TemporaryDir, "Shema_Data_ICG.xml"),
                                        Path.Combine(_TemporaryDir, "Data_ICG.xml2"),
                                        Path.Combine(_TemporaryDir, "Data_ICG.xml"));

                

                if (f12 == true)
                {
                    isCorrected = true;
                    GenerateCUFFile(OutputPath, GetInfoforCUF());
                    return;
                }
                // ("არ მოხერხდა ფაილის კორექტირება გენერირება მოხდება ჩვეულებრივი სისტემით");
                isCorrected = false;
            }

            // isCorrected == flase or TimeZoneConsidiration == false;
            ds.WriteXml(Path.Combine(_TemporaryDir, "Data_ICG.xml2"));
            ds.WriteXmlSchema(Path.Combine(_TemporaryDir, "Shema_Data_ICG.xml"));

            GenerateCUFFile(OutputPath, GetInfoforCUF());


        }

        protected void GenerateCUFFile(string OutputPath, UpdateCheckData data)
        {
            base.GenerateCUFFile(OutputPath, data, "ICG.zip", "Data_ICG.xml", _CUF_KEY, "CI");
        }

        private UpdateCheckData GetInfoforCUF()
        {

            UpdateCheckData result = new UpdateCheckData();

            string sql = "SELECT C_Version, C_Date, C_CodexDocs, C_ICGDocs, C_ICGDocs, C_CodexDate, C_ICGDate, C_ICGDate " +
                "FROM CodexR4Update";
            SqlDataAdapter Da_ICG_ICG2005Update = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            DataSet ds = new DataSet();
            Da_ICG_ICG2005Update.Fill(ds, "Codex2005Update");
            result.StartFrom = (ulong)ds.Tables["Codex2005Update"].Rows[0]["C_ICGDocs"];

            sql = "SELECT C_ID FROM ICG_CDOC WHERE C_TODO = 1";
            Da_ICG_ICG2005Update = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            Da_ICG_ICG2005Update.Fill(ds, "Amount");

            sql = "SELECT C_ID FROM ICG_CDOC WHERE C_TODO = -1";
            Da_ICG_ICG2005Update = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            Da_ICG_ICG2005Update.Fill(ds, "Del");

            result.Quantity = (ulong)ds.Tables["Amount"].Rows.Count;
            ulong del = (ulong)ds.Tables["Del"].Rows.Count;

            result.EndTo = (ulong)result.StartFrom + result.Quantity - del;

            return result;

        }

        public void UpdateInfoTableInUpdate(DateTime d2)
        {
            string s1 = "SELECT C_ID from ICG_CDOC";

            SqlConnection cn = new SqlConnection(_UpdateDatabaseConnectioString); 
            SqlDataAdapter da = new SqlDataAdapter(s1, cn);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "Qt");
            int qt = ds1.Tables["Qt"].Rows.Count;
            cn.Close();

            string sql = "SELECT C_Version, C_Date, C_CodexDocs, C_ICGDocs, C_ICGDocs, C_CodexDate, C_ICGDate, C_ICGDate " +
                "FROM CodexR4Update";
            SqlDataAdapter Da_ICG_ICG2005Update = new SqlDataAdapter(sql, _UpdateDatabaseConnectioString);
            SqlCommandBuilder cb = new SqlCommandBuilder(Da_ICG_ICG2005Update);

            // Update Command Builder
            DataSet ds = new DataSet();
            Da_ICG_ICG2005Update.Fill(ds, "Codex2005Update");
            ds.Tables["Codex2005Update"].Rows[0]["C_ICGDocs"] = qt;
            ds.Tables["Codex2005Update"].Rows[0]["C_ICGDate"] = d2;
            ds.Tables["Codex2005Update"].Rows[0]["C_Date"] = DateTime.Now;
            Da_ICG_ICG2005Update.Update(ds, "Codex2005Update");

        }


        private int PickCUFFile(string str)
        {
            return base.PickCUFFile(str, _CUF_KEY, "Data_ICG.xml");
        }


     
        public void PickUpCUFProcess()
        {

            using (SqlConnection connection = new SqlConnection(_UpdateDatabaseConnectioString))
            {
                connection.Open();

                #region Read CodexR4Update Table
                string sql = "SELECT * FROM CodexR4Update";
                SqlDataAdapter Da_1 = new SqlDataAdapter(sql, connection);
                var UInfoM = new DataSet();
                Da_1.Fill(UInfoM, "Codex2005Update");
                #endregion 

                #region Trancate Tables
                SqlCommand cm = new SqlCommand();
                cm.Connection = connection;
            
                cm.CommandText = "DELETE ICG_CNTR";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE ICG_DTYP";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE ICG_SUBJECT";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE CodexR4Update";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE ICG_CDOC";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE UpdateStatus";
                cm.ExecuteNonQuery();

                #endregion Trancate Tables

                #region Generata Data Schema
                var UDS = new DataSet("Data");

                sql = "SELECT  C_ID, C_CAPTION, C_LANGUAGE, C_DATE, C_ORDER, C_TEXT, C_COUNTRY, C_TYPE, C_TODO, C_DocFormat, C_DocEncoding, C_DocText," +
                    "R_Str,R_int1,R_int2,R_int3,R_Float,R_Date1,R_Date2,R_blob  " +
                    "FROM ICG_CDOC";
                SqlDataAdapter Da_ICG_CDOC = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_ICG_CDOC = new SqlCommandBuilder(Da_ICG_CDOC);
                Da_ICG_CDOC.Fill(UDS, "ICG_CDOC");

                sql = "SELECT L_ID, L_CAPTION, L_ORDER, L_BMP, L_STATUS FROM ICG_CNTR";
                SqlDataAdapter Da_ICG_CNTR = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_ICG_CNTR = new SqlCommandBuilder(Da_ICG_CNTR);
                Da_ICG_CNTR.Fill(UDS, "ICG_CNTR");

                sql = "SELECT CT_ID, CT_CAPTION, CT_ORDER FROM ICG_DTYP";
                SqlDataAdapter Da_ICG_DTYP = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_ICG_DTYP = new SqlCommandBuilder(Da_ICG_DTYP);
                Da_ICG_DTYP.Fill(UDS, "ICG_DTYP");

                sql = "SELECT C_ID, C_CAPTION, C_ORDER FROM ICG_SUBJECT";
                SqlDataAdapter Da_ICG_SUBJECT = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_ICG_SUBJECT = new SqlCommandBuilder(Da_ICG_SUBJECT);
                Da_ICG_DTYP.Fill(UDS, "ICG_SUBJECT");

                sql = "SELECT C_Version, C_Date, C_CodexDocs, C_CGLDocs, C_ICGDocs, C_CodexDate, C_CGLDate, C_ICGDate " +
                    "FROM CodexR4Update";
                SqlDataAdapter Da_ICG_ICG2005Update = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_ICG2005Update = new SqlCommandBuilder(Da_ICG_ICG2005Update);
                Da_ICG_ICG2005Update.Fill(UDS, "Codex2005Update");

                sql = "SELECT Status FROM UpdateStatus";
                SqlDataAdapter Da_Status = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Status = new SqlCommandBuilder(Da_Status);
                Da_Status.Fill(UDS, "Status");
                #endregion Generata Data Schema

                #region ReadXML
                try
                {
                    UDS.ReadXml(Path.Combine(_TemporaryDir , @"Data_ICG.xml"));
                }
                catch //(System.Exception ex)
                {
                    //ILG.Windows.Forms.ILGMessageBox.Show("პრობლემაა განახლებასთან დაკავშირებით, \n" + "Error Code:" + c.ToString() + "\nდახურეთ ყველა კოდექსის ფანჯარა და გაუშვით განახლება ხელახლა");
                    throw;
                }

                #endregion ReadXML

                #region Update to Database
                Da_ICG_CDOC.Update(UDS, "ICG_CDOC");
                Da_ICG_CNTR.Update(UDS, "ICG_CNTR");
                Da_ICG_DTYP.Update(UDS, "ICG_DTYP");
                Da_ICG_ICG2005Update.Update(UDS, "Codex2005Update");
                Da_Status.Update(UDS, "Status");
                #endregion Update to Database

                #region CodexR4Update Table Update
                sql = "SELECT * FROM CodexR4Update";
                Da_1 = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_1 = new SqlCommandBuilder(Da_1);
                DataSet X1 = new DataSet();
                if (UInfoM.Tables["Codex2005Update"].Rows.Count == 0) return;

                Da_1.Fill(X1, "Codex2005Update");
                X1.Tables["Codex2005Update"].Rows[0]["C_ICGDocs"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_ICGDocs"];
                X1.Tables["Codex2005Update"].Rows[0]["C_ICGDate"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_ICGDate"];
                X1.Tables["Codex2005Update"].Rows[0]["C_Date"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_Date"];
                Da_1.Update(X1, "Codex2005Update");

                #endregion
            }
            if (File.Exists("Data_ICG.xml") == true) File.Delete("Data_ICG.xml");


        }



    }
}
