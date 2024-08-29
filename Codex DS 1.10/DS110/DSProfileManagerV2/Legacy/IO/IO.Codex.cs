using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILG.Codex.Cryptography;
using CodexInternalOperations;
using ILG.Codex.CodexR4;
using ILG.Codex.Internal;

namespace CodexR4.Operations.Update.IO
{
    public class CodexUpdateIOforCodex : CodexUpdateIOCommon, ICodexUpdateIOCommon
    {
        private string _CUF_KEY;

        public CodexUpdateIOforCodex(String UpdateDatabaseConnectionString, String MainDatabaseConnectionString, String TempDirecotry) 
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
                // Data For Codex
                DataSet ds;
                DataTable dtc1;
                DataTable dtc2;
                DataTable dtc3;
                DataTable dtc4;

                using (SqlConnection connection = new SqlConnection(_MainDatabaseConnectioString))
                {
                    String strcmd = "SELECT * FROM Codex_DAUTHOR ORDER By A_Order";
                    SqlDataAdapter dataatapter = new SqlDataAdapter(strcmd, connection);
                    ds = new DataSet();
                    dataatapter.Fill(ds);
                    dtc1 = ds.Tables[0];

                    strcmd = "SELECT * FROM Codex_DTYPE ORDER By T_Order";
                    dataatapter = new SqlDataAdapter(strcmd, connection);
                    ds = new DataSet();
                    dataatapter.Fill(ds);
                    dtc2 = ds.Tables[0];

                    strcmd = "SELECT * FROM Codex_DSubject ORDER By S_Order";
                    dataatapter = new SqlDataAdapter(strcmd, connection);
                    ds = new DataSet();
                    dataatapter.Fill(ds);
                    dtc3 = ds.Tables[0];

                    strcmd = "SELECT * FROM Codex_DWords ORDER By W_Order";
                    dataatapter = new SqlDataAdapter(strcmd, connection);
                    ds = new DataSet();
                    dataatapter .Fill(ds);
                    dtc4 = ds.Tables[0];
                }



                #endregion Attribute Iniitialisation


                string str1 = "SELECT D_ID FROM CODEX_DDOCS WHERE C_TODO = 1";
                SqlConnection cn_update = new SqlConnection(_UpdateDatabaseConnectioString);
                cn_update.Open();
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(str1, cn_update);
                da.Fill(ds, "z1");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i != ds.Tables[0].Rows.Count - 1) Str = Str + ds.Tables[0].Rows[i]["D_ID"].ToString() + " ,";
                        else Str = Str + ds.Tables[0].Rows[i]["D_ID"].ToString();
                    }
                }

                cn_update.Close();

                if (Str == "") return false; // Empty Database

                string Fields = "D_ID,D_Caption,C_Author,C_Topic,C_Type,C_Words,C_Number,C_Date,C_lastEdit,C_EnterDate,C_Status,C_DocEncoding";
                string str2 = "SELECT " + Fields + " FROM CODEX_DDOCS WHERE D_ID in ( " + Str + " )";

                ds = new DataSet();
                SqlConnection cn_base = new SqlConnection(_UpdateDatabaseConnectioString);
                da = new SqlDataAdapter(str2, cn_base);
                da.Fill(ds);
                cn_base.Close();

                if (ds.Tables[0].Rows.Count == 0) return true; // All Right

             
                StringBuilder Strauthor = new StringBuilder("1");
                StringBuilder Strtype = new StringBuilder("1");

                dtc1.PrimaryKey = new DataColumn[] { dtc1.Columns["A_ID"] };
                dtc2.PrimaryKey = new DataColumn[] { dtc2.Columns["T_ID"] };
                DataRow dr;

                string result = "";

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Strauthor.Remove(0, Strauthor.Length);
                    Strtype.Remove(0, Strtype.Length);

                    dr = dtc1.Rows.Find((int)ds.Tables[0].Rows[i]["C_Author"]);

                    if (dr == null) Strauthor.Append(" ");
                    else Strauthor.Append(@dr["A_Caption"].ToString().Trim());

                    dr = dtc2.Rows.Find((int)ds.Tables[0].Rows[i]["C_Type"]);

                    if (dr == null) Strtype.Append(" ");
                    else Strtype.Append(@dr["T_Caption"].ToString().Trim());

                    String S =
                        GeorgianDateString.DateToString((DateTime)ds.Tables[0].Rows[i]["C_Date"]) + "  "
                        + Strauthor.ToString() + "  " + Strtype + " ";
                    if ((int)ds.Tables[0].Rows[i]["C_number"] != 0) S = S + "N " + ((int)ds.Tables[0].Rows[i]["C_number"]).ToString();

                    result = result +
                                       "-----------------------------------------------------------------------------" + Environment.NewLine +
                                       S +
                                       Environment.NewLine + Environment.NewLine +
                                       @FilterString(ds.Tables[0].Rows[i]["D_Caption"].ToString())
                                       + Environment.NewLine;

                }



                ErrorReport = result;
        
            }
            catch (System.Exception ex)
            {
                ErrorReport += Environment.NewLine + ex.ToString();
                return false;
            }

            return false;

        }

        // Check if it emptuy
        public bool CheckUpdateIfEmpty()
        {
            return base.CheckUpdateIfEmpty("SELECT D_ID FROM CODEX_DDOCS");
        }


        public void GenerateCUF(String OutputPath, bool TimeZoneConsidiration, ref bool isCorrected)
        {
            DataSet ds = new DataSet("Data");

            #region Fill DataSet
            using (SqlConnection connection = new SqlConnection(_UpdateDatabaseConnectioString))
            {
                connection.Open();
                string sql = "SELECT A_ID, A_ORDER, A_CAPTION FROM Codex_DAUTHOR";
                SqlDataAdapter Da_Codex_DAUTHOR = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DAUTHOR = new SqlCommandBuilder(Da_Codex_DAUTHOR);
                Da_Codex_DAUTHOR.Fill(ds, "Codex_DAUTHOR");

                sql = "SELECT T_ID, T_ORDER, T_CAPTION FROM Codex_DTYPE";
                SqlDataAdapter Da_Codex_DTYPE = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DTYPE = new SqlCommandBuilder(Da_Codex_DTYPE);
                Da_Codex_DTYPE.Fill(ds, "Codex_DTYPE");

                sql = "SELECT S_ID, S_ORDER, S_CAPTION FROM Codex_DSUBJECT";
                SqlDataAdapter Da_Codex_DSUBJECT = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DSUBJECT = new SqlCommandBuilder(Da_Codex_DSUBJECT);
                Da_Codex_DSUBJECT.Fill(ds, "Codex_DSUBJECT");

                sql = "SELECT W_ID, W_ORDER, W_CAPTION FROM Codex_DWORDS";
                SqlDataAdapter Da_Codex_DWORDS = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DWORDS = new SqlCommandBuilder(Da_Codex_DWORDS);
                Da_Codex_DWORDS.Fill(ds, "Codex_DWORDS");

                sql = "SELECT C_Version, C_Date, C_CodexDocs, C_CGLDocs, C_ICGDocs, C_CodexDate, C_CGLDate, C_ICGDate " +
                    "FROM Codex2007Update";
                SqlDataAdapter Da_Codex_Codex2005Update = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex2005Update = new SqlCommandBuilder(Da_Codex_Codex2005Update);
                Da_Codex_Codex2005Update.Fill(ds, "Codex2005Update");

                sql = "SELECT  D_ID,D_CAPTION,C_AUTHOR,C_TOPIC,C_TYPE,C_WORDS,C_NUMBER,C_DATE,C_LASTEDIT,C_ENTERDATE," +
                    "C_STATUS,C_TODO,C_DocFormat,C_DocEncoding,C_TEXT,C_LINK,C_DocText,R_Str,R_int1,R_int2,R_int3,R_Float,R_Date1,R_Date2,R_blob  " +
                    "FROM Codex_DDOCS";
                SqlDataAdapter Da_Codex_DDOCS = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DDOCS = new SqlCommandBuilder(Da_Codex_DDOCS);
                Da_Codex_DDOCS.Fill(ds, "Codex_DDOCS");

                sql = "SELECT Status FROM UpdateStatus";
                SqlDataAdapter Da_Status = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Status = new SqlCommandBuilder(Da_Status);
                Da_Status.Fill(ds, "Status");


            }
            #endregion Fill DataSet

            if (TimeZoneConsidiration == true)
            {
                ds.WriteXml(Path.Combine(_TemporaryDir, "Data_Codex.xml2"));
                ds.WriteXmlSchema(Path.Combine(_TemporaryDir, "Shema_Data_Codex.xml"));

                //MessageBox.Show("X");

                // ფაილის გენერაცია პრობლემის გათვალიწინებით
                CodexDateTimeFix.CodexUpdateFix(
                    Path.Combine(_TemporaryDir, "Shema_Data_Codex.xml"),
                    Path.Combine(_TemporaryDir, "Data_Codex.xml2"),
                    Path.Combine(_TemporaryDir, "Data_Codex.xml"));

                bool f12 =
                CodexDateTimeFix.CheckCodexUpdate(
                    Path.Combine(_TemporaryDir, "Shema_Data_Codex.xml"),
                    Path.Combine(_TemporaryDir, "Data_Codex.xml2"),
                    Path.Combine(_TemporaryDir, "Data_Codex.xml"));

                if (f12 == true)
                {
                    isCorrected = true;
                  
                    GenerateCUFFile(OutputPath, GetInfoforCUF());
                    return;
                }
                isCorrected = false;
                //else ILG.Windows.Forms.ILGMessageBox.Show("არ მოხერხდა ფაილის კორექტირება გენერირება მოხდება ჩვეულებრივი სისტემით");
            }


            ds.WriteXml(Path.Combine(_TemporaryDir,  "Data_Codex.xml"));
            ds.WriteXmlSchema(Path.Combine(_TemporaryDir, "Shema_Data_Codex.xml"));

           
            GenerateCUFFile(OutputPath, GetInfoforCUF());

        }

        public void GenerateCUFFile(string OutputPath, UpdateCheckData data)
        {
            base.GenerateCUFFile(OutputPath, data, "Codex.zip", "Data_Codex.xml", _CUF_KEY, "CC");
        }

        public UpdateCheckData GetInfoforCUF()
        {
            UpdateCheckData result = new UpdateCheckData();

            string sql = "SELECT C_Version, C_Date, C_CodexDocs, C_CGLDocs, C_ICGDocs, C_CodexDate, C_CGLDate, C_ICGDate " +
                "FROM CodexR4Update";

            DataSet ds = new DataSet();

            using (SqlConnection connection = new SqlConnection(_UpdateDatabaseConnectioString))
            {
                connection.Open();

                SqlDataAdapter Da_Codex_Codex2005Update = new SqlDataAdapter(sql, connection);
                
                Da_Codex_Codex2005Update.Fill(ds, "Codex2005Update");
                result.StartFrom = (uint)ds.Tables["Codex2005Update"].Rows[0]["C_CodexDocs"];

                sql = "SELECT D_ID FROM Codex_DDOCS WHERE C_TODO = 1";
                Da_Codex_Codex2005Update = new SqlDataAdapter(sql, connection);
                Da_Codex_Codex2005Update.Fill(ds, "Amount");

                sql = "SELECT D_ID FROM Codex_DDOCS WHERE C_TODO = -1";
                Da_Codex_Codex2005Update = new SqlDataAdapter(sql, connection);
                Da_Codex_Codex2005Update.Fill(ds, "Del");

            }

            result.Quantity = (ulong)ds.Tables["Amount"].Rows.Count;
            ulong del = (ulong)ds.Tables["Del"].Rows.Count;

            result.EndTo = result.StartFrom + result.Quantity - del;

            return result;

        }

      


        // --------------------------------------------------------------------------------------
        #region Generate CUF






        public void FillInfoTable()
        {
            string s1 = "SELECT D_ID from Codex_DDOCS";
            SqlConnection cn = new SqlConnection(_MainDatabaseConnectioString); // Main Database
            SqlDataAdapter da = new SqlDataAdapter(s1, cn);
            DataSet ds1 = new DataSet();
            da.Fill(ds1, "Qt");
            int qt = ds1.Tables["Qt"].Rows.Count;
            cn.Close();

            string sql = "SELECT C_Version, C_Date, C_CodexDocs, C_CGLDocs, C_ICGDocs, C_CodexDate, C_CGLDate, C_ICGDate " +
                "FROM Codex2007Update";
            SqlDataAdapter Da_Codex_Codex2005Update = new SqlDataAdapter(sql, _MainDatabaseConnectioString);
            SqlCommandBuilder cb = new SqlCommandBuilder(Da_Codex_Codex2005Update);

            // Update Command Builder
            DataSet ds = new DataSet();
            Da_Codex_Codex2005Update.Fill(ds, "Codex2005Update");
            ds.Tables["Codex2005Update"].Rows[0]["C_CodexDocs"] = qt;
            ds.Tables["Codex2005Update"].Rows[0]["C_CodexDate"] = DateTime.Now;
            ds.Tables["Codex2005Update"].Rows[0]["C_Date"] = DateTime.Now;
            Da_Codex_Codex2005Update.Update(ds, "Codex2005Update");

        }


      
     
   
    

        #endregion
        // --------------------------------------------------------------------------------------


    
     

    
        public int PickCUFFile(string str)
        {
            return base.PickCUFFile(str, _CUF_KEY, "Data_Codex.xml");
        }


    
       


        public void PickCUFProcess(string filename)
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

                cm.CommandText = "DELETE Codex_DAUTHOR";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE Codex_DTYPE";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE Codex_DSUBJECT";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE Codex_DWORDS";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE Codex2007Update";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE Codex_DDOCS";
                cm.ExecuteNonQuery();
                cm.CommandText = "DELETE UpdateStatus";
                cm.ExecuteNonQuery();



                #endregion Trancate Tables

                #region Generata Data Schema
                var UDS = new DataSet("Data");

                sql = "SELECT A_ID, A_ORDER, A_CAPTION FROM Codex_DAUTHOR";
                SqlDataAdapter Da_Codex_DAUTHOR = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DAUTHOR = new SqlCommandBuilder(Da_Codex_DAUTHOR);
                Da_Codex_DAUTHOR.Fill(UDS, "Codex_DAUTHOR");

                sql = "SELECT T_ID, T_ORDER, T_CAPTION FROM Codex_DTYPE";
                SqlDataAdapter Da_Codex_DTYPE = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DTYPE = new SqlCommandBuilder(Da_Codex_DTYPE);
                Da_Codex_DTYPE.Fill(UDS, "Codex_DTYPE");

                sql = "SELECT S_ID, S_ORDER, S_CAPTION FROM Codex_DSUBJECT";
                SqlDataAdapter Da_Codex_DSUBJECT = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DSUBJECT = new SqlCommandBuilder(Da_Codex_DSUBJECT);
                Da_Codex_DSUBJECT.Fill(UDS, "Codex_DSUBJECT");

                sql = "SELECT W_ID, W_ORDER, W_CAPTION FROM Codex_DWORDS";
                SqlDataAdapter Da_Codex_DWORDS = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DWORDS = new SqlCommandBuilder(Da_Codex_DWORDS);
                Da_Codex_DWORDS.Fill(UDS, "Codex_DWORDS");

                sql = "SELECT C_Version, C_Date, C_CodexDocs, C_CGLDocs, C_ICGDocs, C_CodexDate, C_CGLDate, C_ICGDate " +
                    "FROM CodexR4Update";
                SqlDataAdapter Da_Codex_Codex2005Update = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex2005Update = new SqlCommandBuilder(Da_Codex_Codex2005Update);
                Da_Codex_Codex2005Update.Fill(UDS, "Codex2005Update");

                sql = "SELECT  D_ID,D_CAPTION,C_AUTHOR,C_TOPIC,C_TYPE,C_WORDS,C_NUMBER,C_DATE,C_LASTEDIT,C_ENTERDATE," +
                    "C_STATUS,C_TODO,C_DocFormat,C_DocEncoding,C_TEXT,C_LINK,C_DocText " +
                    "FROM Codex_DDOCS";
                SqlDataAdapter Da_Codex_DDOCS = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Codex_DDOCS = new SqlCommandBuilder(Da_Codex_DDOCS);
                Da_Codex_DDOCS.Fill(UDS, "Codex_DDOCS");

                sql = "SELECT Status FROM UpdateStatus";
                SqlDataAdapter Da_Status = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_Status = new SqlCommandBuilder(Da_Status);
                Da_Status.Fill(UDS, "Status");
                #endregion Generata Data Schema

                #region ReadXML
                try
                {
                    UDS.ReadXml(Path.Combine(_TemporaryDir, "Data_Codex.xml"));
                }
                catch //(System.Exception ex)
                {
                    //ILG.Windows.Forms.ILGMessageBox.Show("პრობლემაა განახლებასთან დაკავშირებით, \n" + "Error Code:" + c.ToString() + "\nდახურეთ ყველა კოდექსის ფანჯარა და გაუშვით განახლება ხელახლა");
                    throw;
                }

                #endregion ReadXML

                #region Update to Database
                Da_Status.Update(UDS, "Status");
                Da_Codex_DDOCS.Update(UDS, "Codex_DDOCS");
                Da_Codex_Codex2005Update.Update(UDS, "Codex2005Update");
                Da_Codex_DWORDS.Update(UDS, "Codex_DWORDS");
                Da_Codex_DSUBJECT.Update(UDS, "Codex_DSUBJECT");
                Da_Codex_DTYPE.Update(UDS, "Codex_DTYPE");
                Da_Codex_DAUTHOR.Update(UDS, "Codex_DAUTHOR");
                #endregion Update to Database

                #region CodexR4Update Table Update 
                sql = "SELECT * FROM CodexR4Update";
                Da_1 = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder Cb_1 = new SqlCommandBuilder(Da_1);
                DataSet X1 = new DataSet();
                if (UInfoM.Tables["Codex2005Update"].Rows.Count == 0) return;

                Da_1.Fill(X1, "Codex2005Update");
                X1.Tables["Codex2005Update"].Rows[0]["C_CGLDocs"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_CGLDocs"];
                X1.Tables["Codex2005Update"].Rows[0]["C_CGLDate"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_CGLDate"];
                X1.Tables["Codex2005Update"].Rows[0]["C_ICGDocs"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_ICGDocs"];
                X1.Tables["Codex2005Update"].Rows[0]["C_ICGDate"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_ICGDate"];
                X1.Tables["Codex2005Update"].Rows[0]["C_Date"] = UInfoM.Tables["Codex2005Update"].Rows[0]["C_Date"];
                Da_1.Update(X1, "Codex2005Update");

                #endregion


            }

            if (File.Exists("Data_Codex.xml") == true) File.Delete("Data_Codex.xml");
        }


        // -----------------------------------------------------------


        public void UpdateInfoTableInUpdate()
        {
            // NOT WORKING ZXZ

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
          //  ds.Tables["Codex2005Update"].Rows[0]["C_ICGDate"] = d2;
            ds.Tables["Codex2005Update"].Rows[0]["C_Date"] = DateTime.Now;
            Da_ICG_ICG2005Update.Update(ds, "Codex2005Update");

        }

    }
}
