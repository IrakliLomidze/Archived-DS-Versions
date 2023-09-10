using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using ILG.Codex.CodexR4.CodexSettings;
using ILG.Codex.CodexR4;

namespace ILG.Codex.DS
{
    class DocumentComparation
    {
        
        

        private int Extract_DS_History_Document(int ID, ref string DocFileName)
        {

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            // Define Document Call Statment
            string strsql = "Select ID, C_TEXT FROM CodexDS_DDOCS_History WHERE ID = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count != 1) return -1; // Document Not Found
            byte[] doc = (byte[])dst.Tables[0].Rows[0]["C_Text"];

            #region  DS Temp Files
            String U1 = DateTime.Now.Ticks.ToString();
            string CodexDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\CH_DS_" + ID.ToString() + U1;

            while (System.IO.File.Exists(CodexDocTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                CodexDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\CH_DS_" + ID.ToString() + U1;
            }

            #endregion Codex Temp Files


            FileStream fs = new FileStream(CodexDocTempFilename + ".Zip", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();

            // UnZip there

            // C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Open(CodexDocTempFilename + ".Zip");

            CodexZip.UnZip(CodexDocTempFilename + ".Zip", "D.RTF", CodexDocTempFilename + ".RTF");
                         
            //zf.Entries.Extract("i.txt", CodexDocTempFilename + ".RTF");
            //zf.Close();
            

            File.Delete(CodexDocTempFilename + ".zip");

            DocFileName = CodexDocTempFilename + ".rtf";

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

            return 0;
        }

        private int Extract_Codex_History_DocumentV2(int ID, ref string DocFileName)
        {

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            // Define Document Call Statment
            string strsql = "Select ID, C_TEXT,H_Date FROM CodexDS_DDOCS_History WHERE ID = " + ID.ToString() + " ";
            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count != 1) return -1; // Document Not Found
            byte[] doc = (byte[])dst.Tables[0].Rows[0]["C_Text"];
            DateTime dtime = (DateTime)dst.Tables[0].Rows[0]["H_Date"];

            String datestr = dtime.Year.ToString() + "_" + dtime.ToString("MMM") + "_" + dtime.Day.ToString();

            #region  DS Temp Files
            int U1 = 0;
            string DSDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\DSHist_" + datestr + "_ID_" + ID.ToString();

            while (System.IO.File.Exists(DSDocTempFilename) || System.IO.File.Exists(DSDocTempFilename+".rtf") || System.IO.File.Exists(DSDocTempFilename+".docx")   == true)
            {
                U1 = U1 + 1;
                DSDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\DSHist_" + datestr + "_ID_" + ID.ToString() + U1.ToString();
            }

            #endregion DS Temp Files


            FileStream fs = new FileStream(DSDocTempFilename + ".Zip", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();


            // UnZip there

            // C1.C1Zip.C1ZipFile zf = new C1.C1Zip.C1ZipFile();
            //zf.Open(CodexDocTempFilename + ".Zip");

            CodexZip.UnZip(DSDocTempFilename + ".Zip", "D.RTF", DSDocTempFilename + ".RTF");

            //zf.Entries.Extract("i.txt", CodexDocTempFilename + ".RTF");
            //zf.Close();


            File.Delete(DSDocTempFilename + ".zip");

            DocFileName = DSDocTempFilename + ".rtf";

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;

            return 0;
        }


        private int Extract_Codex_Document(int ID, ref string DocFileName)
        {

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            
            string strsql = "Select C_ID, C_TEXT FROM CodexDS_DDOCS WHERE C_ID = " + ID.ToString() + " ";

            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count != 1) return -1; // Document Not Found
            byte[] doc = (byte[])dst.Tables[0].Rows[0]["C_Text"];

            #region  Codex Temp Files
            String U1 = DateTime.Now.Ticks.ToString();
            string DSDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\CC_DS_" + ID.ToString() + U1;

            while (System.IO.File.Exists(DSDocTempFilename) == true)
            {
                U1 = DateTime.Now.Ticks.ToString();
                DSDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\CC_DS_" + ID.ToString() + U1;
            }


            #endregion Codex Temp Files


            FileStream fs = new FileStream(DSDocTempFilename + ".Zip", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();


            CodexZip.UnZip(DSDocTempFilename + ".Zip", "D.RTF", DSDocTempFilename + ".RTF");

            File.Delete(DSDocTempFilename + ".zip");

            // Document Caption
            DocFileName = DSDocTempFilename + ".rtf";


            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;



            return 0;
        }

        private int Extract_DS_DocumentV2(int ID, ref string DocFileName)
        {

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            string strsql = "Select C_ID, C_TEXT FROM CodexDS_DDOCS WHERE C_ID = " + ID.ToString() + " ";

            SqlDataAdapter dacgl = new SqlDataAdapter(strsql, SQLConnectionStrings.Default.ConnectionString_CodexDS);
            DataSet dst = new DataSet();
            dacgl.Fill(dst);
            if (dst.Tables[0].Rows.Count != 1) return -1; // Document Not Found
            byte[] doc = (byte[])dst.Tables[0].Rows[0]["C_Text"];

            #region  DS Temp Files
            int U1 = 0;
            string DSDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\DSDB_Current_ID_" + ID.ToString() ;

            
            while (File.Exists(DSDocTempFilename) || File.Exists(DSDocTempFilename + ".rtf") || File.Exists(DSDocTempFilename + ".docx") == true)
            {
                    U1 = U1 + 1;
                DSDocTempFilename = DirectoryConfiguration.DSTemporaryDirectory + "\\DSDB_Current_ID_" + ID.ToString() + "_" + U1.ToString();
            }



            #endregion DS Temp Files


            FileStream fs = new FileStream(DSDocTempFilename + ".Zip", FileMode.Create, FileAccess.Write);
            fs.Write(doc, 0, doc.Length);
            fs.Close();



            CodexZip.UnZip(DSDocTempFilename + ".Zip", "D.RTF", DSDocTempFilename + ".RTF");

            
            File.Delete(DSDocTempFilename + ".zip");

            // Document Caption
            DocFileName = DSDocTempFilename + ".rtf";


            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;



            return 0;
        }

               
        
        
        public DocumentComparation()
        {
            
        }

        
        public String ExtractDocumentsFromDatabaseForComparation(bool is_Original_From_MainDatabase, int OriginalDocumentID, bool is_Revised_From_MainDatabase, int RevisedDocumentID, ref String OriginalFileName, ref String RevisedFileName)
        {
            String OriginalDocumentFileName = "";
            String RevisedDocumentFileName = "";


            if (is_Original_From_MainDatabase == true) Extract_DS_DocumentV2(OriginalDocumentID, ref OriginalDocumentFileName); else Extract_Codex_History_DocumentV2(OriginalDocumentID, ref OriginalDocumentFileName);
            if (is_Revised_From_MainDatabase == true) Extract_DS_DocumentV2(RevisedDocumentID, ref RevisedDocumentFileName); else Extract_Codex_History_DocumentV2(RevisedDocumentID, ref RevisedDocumentFileName);
            // There is Mistake on Paramenters Order Call Should be Vice Versa
            // This is Call on Original Logic
            //CompareDocumentsFiles(OriginalDocumentFileName, RevisedDocumentFileName);
            // There is Call in Corect Logic Order untill code in comparation method will not fixed

            // Genrate Flle Names
            #region Genrate Flle Names String CombinedTempFilename
            String PrefixStr = "XXX_";
            PrefixStr = "DS_"; 

            String Part1 = "Current";
            if (is_Original_From_MainDatabase == false) Part1 = "Hist_ID_" + OriginalDocumentID.ToString();

            String Part2 = "Current";
            if (is_Revised_From_MainDatabase == false) Part2 = "Hist_ID_" + RevisedDocumentID.ToString();

            String Sub = Part1 + "_To_" + Part2;

            string CombinedTempFilename = DirectoryConfiguration.ComparedDocumentsDirectory + "\\" + PrefixStr + Sub + ".docx";
            int i = 1;
            while (System.IO.File.Exists(CombinedTempFilename) == true)
            {
                CombinedTempFilename = DirectoryConfiguration.ComparedDocumentsDirectory + "\\" + PrefixStr + Sub + "_" + i.ToString() + ".docx";
                i++;
            }

            #endregion Genrate Flle Names
            //ComparedDocuments
            OriginalFileName = OriginalDocumentFileName;
            RevisedFileName = RevisedDocumentFileName;
          
            return CombinedTempFilename;
        }
   
    

    }
}
