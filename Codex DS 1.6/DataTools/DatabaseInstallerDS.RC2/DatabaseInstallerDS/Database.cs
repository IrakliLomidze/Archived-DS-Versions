using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Data.SqlClient;





namespace ILG.Codex.CodexR4
{
    /// <summary>
    /// Summary description for Database.
    /// </summary>
    public class CodexDatabase
    {

        Form1 Owner;
        CodexDSDataBaseInfo DataBaseInfo;

        SqlConnection _srv;

        public SqlConnection srv
        {
            get { if (_srv == null) _srv = new SqlConnection(global::ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master); return _srv; }
            set { if (value != null) _srv = value; }
        }

        public CodexDatabase(Form1 sender)
        {
            Owner = sender;
        }
        public int GetInfoFrom()
        {
            DataBaseInfo = new CodexDSDataBaseInfo();
            int i = DataBaseInfo.GetInfo(Properties.Settings.Default.CodexDatabaseFrom_Installer);
            if (i != 0)
            {

                Owner.ShowProgress_DatabaseInstaller(0, "Error", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "არ ხერხდება  [" + System.IO.Path.GetFileName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer) + "] ფაილის წაკითხვა)", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "ფაილი ან დაზიანებულია ან არ არის info ფორმატის", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "------------------------------------------------------------------------", Color.DarkRed);
                //ILG.Windows.Forms.ILGMessageBox.Show("არ ხერხდება " + System.IO.Path.GetFileName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom) + " ფაილის წაკითხვა" +
                //    "\nფაილი ან დაზიანებულია ან არ არის info ფორმატის "
                //    , "", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                
                return 1;

            }

            return 0;

        }
        public int ProcessFiles_CopyToDatabase()
        {


          
            #region Copying Databases

            // 
            foreach (var CodexDataBase in DataBaseInfo.Info.DataBases)
            {
                Owner.ShowProgress_DatabaseInstaller(0, "კოპირდება ბაზა (" + CodexDataBase.CatalogName + ")", Color.Black);
                #region FileInDatabase
                foreach (var DataFile in CodexDataBase.Files)
                {
                    try
                    {
                        String DataBaseFileName = DataFile.ToString();

                       // System.Windows.Forms.MessageBox.Show("ZXZ From" + Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer) + "\\" + DataBaseFileName);
                       // System.Windows.Forms.MessageBox.Show("ZXZ To" + ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + @"\" + DataBaseFileName);


                        Owner.ShowProgress_DatabaseInstaller(0, "კოპირდება ფაილი [" + Path.GetFileName(DataBaseFileName) + "]", Color.Black);
                        System.IO.File.Copy(Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer) + "\\" + DataBaseFileName, ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + @"\" + DataBaseFileName, true);



                        DataBaseFileName = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + @"\" + DataBaseFileName;
                        if ((File.GetAttributes(DataBaseFileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            File.SetAttributes(DataBaseFileName, System.IO.FileAttributes.Archive);
                        }
                        Owner.ShowProgress_DatabaseInstaller(0, "ფაილი  [" + Path.GetFileName(DataBaseFileName) + "] კოპირებულია", Color.Black);
                    }
                    catch (Exception Ex)
                    {
                        Owner.ShowProgress_DatabaseInstaller(0, "Error: ", Color.Black);
                        Owner.ShowProgress_DatabaseInstaller(0, "არ ხერხდება ", Color.Black);
                        Owner.ShowProgress_DatabaseInstaller(0, DataFile.ToString(), Color.Black);
                        Owner.ShowProgress_DatabaseInstaller(0, "ფაილის კოპირება", Color.Black);
                        Owner.ShowProgress_DatabaseInstaller(0, Ex.Message, Color.DarkRed);

                        Owner.ShowProgress_DatabaseInstaller(0, "------------------------------------------------------------------------", Color.DarkRed);


                        Thread thread = new Thread(() => System.Windows.Forms.Clipboard.SetText(Ex.Message.ToString()));
                        thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                        thread.Start();
                        thread.Join();

                        return 3;
                    }

                }
                #endregion FileInDatabase
                Owner.ShowProgress_DatabaseInstaller(0, "ბაზა (" + CodexDataBase.CatalogName + ") კოპირებულია", Color.Black);
            }

            #endregion Copying Databases



            try
            {


                if (File.Exists(Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + "\\") + @"\CodexDS.CodexDatabaseInfo ") == true)
                {
                    if ((File.GetAttributes(Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer) + @"\CodexDS.CodexDatabaseInfo ") & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    { File.SetAttributes(Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + "\\") + @"\CodexDS.CodexDatabaseInfo ", System.IO.FileAttributes.Archive); }
                }

                File.Copy(Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Installer) + @"\CodexDS.CodexDatabaseInfo ", Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + "\\") + @"\CodexDS.CodexDatabaseInfo ", true);
            }
            catch (Exception Ex)
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error: ", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "არ ხერხდება ", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "CodexDS.CodexDatabaseInfo", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "ფაილის კოპირება", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "------------------------------------------------------------------------", Color.DarkRed);


                Thread thread = new Thread(() => System.Windows.Forms.Clipboard.SetText(Ex.Message.ToString()));
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join();

                return 3;
            }


            //MainDatabaseFile = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo   + "\\"+ DataBaseInfo.ds.Tables["MainDataBase"].Rows[0]["FILE"];
            //UpdateDatabaseFile = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo + "\\"+ DataBaseInfo.ds.Tables["UpdateDataBase"].Rows[0]["FILE"];
            //HisotryDatabaseFile = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo + "\\" + DataBaseInfo.ds.Tables["UpdateDataBase"].Rows[0]["FILE"];

            return 0;
        }




        public void DropDatabase(String Catalog, ref String Err, bool SingleMode = true  )
        {

            #region Script
            //            USE master;
            //            IF(EXISTS(SELECT name FROM master.sys.databases WHERE name = 'CodexR4History'))
            //BEGIN
            // ALTER DATABASE CodexR4History
            // SET SINGLE_USER;
            //            EXEC sp_detach_db 'CodexR4History', 'true';
            //            END
            #endregion Script


            String SQL =
           "USE master;" + System.Environment.NewLine +
           "IF(EXISTS(SELECT name FROM master.sys.databases WHERE name = '"+ Catalog + "'))" + System.Environment.NewLine +
           "BEGIN" + System.Environment.NewLine + 
           "ALTER DATABASE " + Catalog + System.Environment.NewLine +
           "SET SINGLE_USER;" + System.Environment.NewLine +
           //"GO" + System.Environment.NewLine +
           "EXEC sp_detach_db '" + Catalog + "', 'true';" + System.Environment.NewLine +
           //"GO" + System.Environment.NewLine;
           "END" + System.Environment.NewLine;

            if (SingleMode == false)
            {
                SQL =
                   "USE master;" + System.Environment.NewLine +
                   "IF(EXISTS(SELECT name FROM master.sys.databases WHERE name = '" + Catalog + "'))" + System.Environment.NewLine +
                   "BEGIN" + System.Environment.NewLine +
                  "EXEC sp_detach_db '" + Catalog + "', 'true';" + System.Environment.NewLine +
                   "END" + System.Environment.NewLine;
            }

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(SQL, ref Err);

            return;
        }
        public int dropDatabase(bool DropAllActiveConnection)
  
       {


            Owner.ShowProgress_DatabaseInstaller(0, "სერვერთან დაკავშირება ", Color.Black);

            try
            {
                srv.Open();
            }
            catch (Exception Ex)
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error: ", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "არ ხერხდება ", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "SQL Server [" + global::ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer + "] დაკავშირება", Color.DarkRed);


                Thread thread = new Thread(() => System.Windows.Forms.Clipboard.SetText(Ex.Message.ToString()));
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join();


                return 1;
            }

            Owner.ShowProgress_DatabaseInstaller(0, "კავშირი დამყარებულია", Color.Black);

            var DatabaseNames = new List<string>() { "Codex2007DS".ToUpper() };

            String Err = "";
            foreach (var CatalogName in DatabaseNames)
            {
                try
                {
                    Owner.ShowProgress_DatabaseInstaller(0, "ძველი " + CatalogName + " ბაზის წაშლა", Color.Black);
                    DropDatabase(CatalogName, ref Err, DropAllActiveConnection);
                    if (Err.ToString() != "") throw new Exception(Err);
                    Owner.ShowProgress_DatabaseInstaller(0, "წაშლილია", Color.Black);
                }
                catch (Exception Ex)
                {
                    Owner.ShowProgress_DatabaseInstaller(0, "Error: ", Color.Black);
                    Owner.ShowProgress_DatabaseInstaller(0, "არ ხერხდება " + CatalogName + " ბაზის გადაწერა " + System.Environment.NewLine + Ex.Message.ToString(), Color.Black);
                    Owner.ShowProgress_DatabaseInstaller(0, "დახურეთ ყველა კოდექს პროგრამა", Color.DarkRed);

                    Thread thread = new Thread(() => System.Windows.Forms.Clipboard.SetText(Ex.Message.ToString()));
                    thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                    thread.Start();
                    thread.Join();


                    return 1;
                }

            }


            return 0;

        }


     
        public int AttachDatabase()
        {
            Owner.ShowProgress_DatabaseInstaller(0, "ბაზების რეგისტრაცია", Color.Black);

            String DBPath = Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Installer + "\\");

            if (DBPath.EndsWith("\\") == false) DBPath += "\\";

           
            String SQL =

                 "IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Codex2007DS') " + System.Environment.NewLine +
                 "BEGIN" + System.Environment.NewLine +
                 "EXEC sp_attach_db @dbname = N'Codex2007DS', " + System.Environment.NewLine +
                 "@filename1 = N'" + DBPath + "Codex2007DS_data.mdf'," + System.Environment.NewLine +
                 "@filename2 = N'" + DBPath + "Codex2007DS_blobs_data.ndf'," + System.Environment.NewLine +
                 "@filename3 = N'" + DBPath + "Codex2007DS_log.ldf' ;" + System.Environment.NewLine +
                 "END" + System.Environment.NewLine +

            
                 "" + System.Environment.NewLine;


            System.Data.SqlClient.SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);


            SqlCommand cm = new SqlCommand(SQL);
            cm.Connection = cn;
            cn.Open();
            int Result = 0;
            try
            {
                Owner.ShowProgress_DatabaseInstaller(0, " რეგისტრირდება კოდექსი DS 1.6 ის ბაზები ", Color.Black);
                cm.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error: ", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "შედომის დეტალები " + Ex.Message.ToString() + " ბაზის რეგისტრაცია ", Color.DarkRed);
                Result = 8;
             }
            finally
            {
                cn.Close();
            }

            if (Result == 0)
            {

                Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზები რეგისტრირებულია", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, "-------------------------------------------------------", Color.Black);
            }
            return Result;

        }

        // With ErrorString
        static public bool IsOnline(String CatalogName, ref String ErrorString)
        {
            #region Script
            //Select(
            //CASE WHEN EXISTS(SELECT name FROM master.sys.databases WHERE name = N'Database_Name' AND state_desc = 'ONLINE')
            //THEN 0  ELSE 1
            //END
            //) AS Result
            #endregion Script


            String Command = " Select ( " +
                             " CASE WHEN EXISTS(SELECT name FROM master.sys.databases WHERE name = N'" + CatalogName + "' AND state_desc = 'ONLINE')" +
                             " THEN 0  ELSE 1" +
                             " END " +
                             " ) AS Result";
            int result = -1;
            ErrorString = "";
            SqlConnection srv = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);
            try
            {
                SqlCommand cm = new SqlCommand(Command, srv);
                srv.Open();
                result = (int)cm.ExecuteScalar();
                srv.Close();
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message.ToString();
            }
            finally
            {
                srv.Close();
            }
            if (result == 0) return true; else return false;
        }
        // With ErrorString
        static public bool IsRegistred(String CatalogName, ref String ErrorString)
        {
            #region Script
            //Select(
            //CASE WHEN EXISTS(SELECT name FROM master.sys.databases WHERE name = N'Database_Name' )
            //THEN 0  ELSE 1
            //END
            //) AS Result
            #endregion Script

            String Command = "Select ( " +
                             "CASE WHEN EXISTS(SELECT name FROM master.sys.databases WHERE name = N'" + CatalogName + "' ) " +
                             "THEN 0  ELSE 1 " +
                             "END " +
                             ") AS Result";
            int result = -1;
            ErrorString = "";
            SqlConnection srv = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);
            try
            {
                SqlCommand cm = new SqlCommand(Command, srv);
                srv.Open();
                result = (int)cm.ExecuteScalar();
            } catch (Exception ex)
            {
                ErrorString = ex.Message.ToString();
            }
            finally
            {
                srv.Close();
            }

            if (result == 0) return true; else return false;
        }
        // With ErrorString
        static public bool IsAllAcitve(ref String ErrorString)
        {
            CodexDSDataBaseInfo Info1 = new CodexDSDataBaseInfo();
            foreach (var Catalog in Info1.Info.DatabaseNames)
            {
                if (IsRegistred(Catalog.ToUpper(),ref ErrorString) == false) return false;
            }

            bool result = true;
            foreach (var Catalog in Info1.Info.DatabaseNames)
            {
                if (IsOnline(Catalog.ToUpper(), ref ErrorString) == false) result = false;
            }
            return result;
        }

        static public void UpdateToStructure16()
        {
            string SQL = Properties.Resources.CreateHistoryTable.ToString();
            String s = "";
            CodexDatabase.ExecutionSQLScriptWithGOSeperator(SQL, ref s);
        }
        public int ProcessFiles_FromDatabase()
        {


            #region Copying Databases Updated Order

            #region Main Database
            String[] MainDataBaseFiles = { "Codex2007DS_data.mdf", "Codex2007DS_log.ldf", "Codex2007DS_blobs_data.ndf" };
            //for(int j=0;j<=df.ds.Tables["MainDataBase"].Rows.Count-1;j++)
            for (int j = 0; j <= 2; j++)
            {

                try
                {
                    //string strf  = df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString();
                    string strf = MainDataBaseFiles[j];// df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString();
                    Owner.ShowProgress_MakeDatabase(0, "კოპირდება ფაილი [" + Path.GetFileName(strf) + "]", Color.Black);

                    String DestinationFileName = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator + "\\" + strf;
                    if (File.Exists(DestinationFileName) == true)
                    {
                        FileAttributes attributes = File.GetAttributes(DestinationFileName);
                        if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            attributes = attributes & ~FileAttributes.ReadOnly;
                            File.SetAttributes(DestinationFileName, attributes);
                        }
                    }

                    File.Copy(Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator + "\\") + @"\" + strf,
                        ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator + "\\" + strf,true);

                    Owner.ShowProgress_MakeDatabase(0, "ფაილი  [" + Path.GetFileName(strf) + "] კოპირებულია", Color.Black);
                }
                catch (Exception Ex)
                {

                    Owner.ShowProgress_MakeDatabase(0, "Error: ", Color.DarkRed);
                    Owner.ShowProgress_MakeDatabase(0, "არ ხერხდება ", Color.DarkRed);
                    Owner.ShowProgress_MakeDatabase(0, MainDataBaseFiles[j], Color.DarkRed);
                    //Owner.ShowProgress(0,df.ds.Tables["MainDataBase"].Rows[j]["FILE"].ToString());
                    Owner.ShowProgress_MakeDatabase(0, "ფაილის კოპირება ..", System.Drawing.Color.DarkRed);

                    Thread thread = new Thread(() => System.Windows.Forms.Clipboard.SetText(Ex.Message.ToString()));
                    thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                    thread.Start();
                    thread.Join();

                    return 3;

                }

            }

            #endregion Main Database

            #endregion Copying Databases Updated Order

            #region Copying Databases Info File

            try
            {
                String DestinationFileName = ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator + @"\CodexDS.CodexDatabaseInfo";
                if (File.Exists(DestinationFileName) == true)
                {
                    FileAttributes attributes = File.GetAttributes(DestinationFileName);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        attributes = attributes & ~FileAttributes.ReadOnly;
                        File.SetAttributes(DestinationFileName, attributes);
                    }
                }

                File.Copy(Path.GetDirectoryName(ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseFrom_Creator + "\\") + @"\CodexDS.CodexDatabaseInfo", ILG.Codex.CodexR4.Properties.Settings.Default.CodexDatabaseTo_Creator + @"\CodexDS.CodexDatabaseInfo", true);
            }
            catch (Exception Ex)
            {
                Owner.ShowProgress_MakeDatabase(0, "Error: ", Color.Black);
                Owner.ShowProgress_MakeDatabase(0, "არ ხერხდება ", Color.DarkRed);
                Owner.ShowProgress_MakeDatabase(0, "CodexDS.CodexDatabaseInfo ფაილის კოპირება ..", TextColor: System.Drawing.Color.DarkRed);

                //Owner.ShowProgress_MakeDatabase(0, "------------------------------------------------------------------------");

                Thread thread = new Thread(() => System.Windows.Forms.Clipboard.SetText(Ex.Message.ToString()));
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join();

                return 3;
            }

            #endregion Copying Databases Info File


            return 0;
        }

        public void TakeOffline(String CatalogName, bool WithSingleMode)
        {
            #region Script
            //ALTER DATABASE CodexR4
            //SET SINGLE_USER
            //WITH ROLLBACK IMMEDIATE;
            //ALTER DATABASE CoddexR4
            //SET MULTI_USER;
            //GO

            //            if exists(SELECT * from sys.databases where name = 'CodexR4' AND state = 0)
            //BEGIN
            //ALTER DATABASE CodexR4 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            //            ALTER DATABASE CodexR4 SET MULTI_USER;
            //            ALTER DATABASE CodexR4 SET OFFLINE WITH ROLLBACK IMMEDIATE;
            //            END

            #endregion Script
            String SingleMode = " ALTER DATABASE " + CatalogName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " + System.Environment.NewLine +
                                " ALTER DATABASE " + CatalogName + " SET MULTI_USER ; " + System.Environment.NewLine;                if (WithSingleMode == false) SingleMode = "";

            String Command = "if exists(SELECT * from sys.databases where name = '" + CatalogName + "' AND state = 0) " + System.Environment.NewLine +
                            "BEGIN " + System.Environment.NewLine +
                               SingleMode + System.Environment.NewLine +
                               "ALTER DATABASE " + CatalogName + " SET OFFLINE WITH ROLLBACK IMMEDIATE; " + System.Environment.NewLine +
                             "END ";
            SqlConnection srv = new SqlConnection(Properties.Settings.Default.ConnectionString_master);

            SqlCommand cm = new SqlCommand(Command, srv);
            srv.Open();
            cm.ExecuteNonQuery();
            srv.Close();

        }

        public void TakeOnline(String CatalogName)
        {
            #region Script
            //ALTER DATABASE AdventureWorks
            //SET SINGLE_USER
            //WITH ROLLBACK IMMEDIATE;
            //ALTER DATABASE AdventureWorks
            //SET MULTI_USER;
            //GO
            #endregion Script

            String Command = "if exists(SELECT * from sys.databases where name = '" + CatalogName + "' AND state = 6) " + System.Environment.NewLine +
                         "BEGIN " + System.Environment.NewLine +
                            "ALTER DATABASE " + CatalogName + " SET ONLINE " + System.Environment.NewLine +
                          "END ";
            SqlConnection srv = new SqlConnection(Properties.Settings.Default.ConnectionString_master);

            SqlCommand cm = new SqlCommand(Command, srv);
            srv.Open();
            cm.ExecuteNonQuery();
            srv.Close();

        }

        public int TakeOfflineDatabase(bool DropAllActiveConnections, Form1.ShowProgressDelegate OwnerShow)
        {

            OwnerShow(0, "სერვერთან დაკავშირება ", System.Drawing.Color.Black);
            SqlConnection srv = new SqlConnection(Properties.Settings.Default.ConnectionString_master);
            
            
            try
            {
                srv.Open();
                srv.Close();
            }
            catch (System.Exception ex)
            {


                OwnerShow(0, "Error: ", Color.Black);
                OwnerShow(0, "არ ხერხდება ", Color.Black);
                OwnerShow(0, "SQL Server [" + ILG.Codex.CodexR4.Properties.Settings.Default.SQLServer + "] დაკავშირება", System.Drawing.Color.DarkRed);

                Thread thread = new Thread(() => System.Windows.Forms.Clipboard.SetText(ex.Message.ToString()));
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join();

                return 1;
            }
            //bool res1 = false;
            //bool res2 = false;
            //bool res3 = false;
            //bool res4 = false;

            OwnerShow(0, "კავშირი დამყარებულია", Color.Black);

 

            //if (res1 == true)
            {
                try
                {
                    OwnerShow(0, "CodexDS 1.6 ბაზის დეაქტივიზაცია", Color.Black);
                    TakeOffline("Codex2007DS", DropAllActiveConnections);
                    OwnerShow(0, "დეაქტივიზირებულია", Color.Black);
                }
                catch (Exception ex)
                {
                    OwnerShow(0, "Error: ", Color.Black);
                    OwnerShow(0, "არ ხერხდება CodexDS 1.6-ზე ოპერირება.", Color.Black);
                    OwnerShow(0, "დახურეთ ყველა კოდექს პროგრამა", Color.DarkRed);
                    OwnerShow(0, ex.Message, Color.DarkRed);
                    return 1;
                }
            }

     
            return 0;

        }

        public int TakeOnlineDatabase(Form1.ShowProgressDelegate OwnerShow)
        {

            OwnerShow(0, "ბაზების აქტივიზაცია", Color.Black);

            try
            {
                TakeOnline("Codex2007DS");
                OwnerShow(0, "Codex2007DS აქტივიზირებულია", Color.Black);
            }
            catch (Exception ex)
            {
                OwnerShow(0, "Error: ", Color.Black);
                OwnerShow(0, "არ ხერხდება Codex2007DS აქტივიზაცია", Color.DarkRed);
                OwnerShow(0, ex.Message, Color.DarkRed);


                return 8;
            }

    



            OwnerShow(0, "კოდექსის ბაზები აქტიურია", Color.DarkGreen);
            OwnerShow(0, "-------------------------------------------------------", Color.DarkGreen);
            OwnerShow(0, "კოდექსის ბაზების საინსტალაციო შექმნილია", Color.DarkGreen);

            //ILG.Windows.Forms.ILGMessageBox.Show("კოდექსის ბაზების საინსტალაციო შექმნილია");


            return 0;

        }
        
        public class CodexSQLServerInformaiton
        {
            public String ProductVersion { set; get; }
            public String ProductLevel { set; get; }
            public String Edition { set; get; }
            public String Collation { set; get; }
            public String IsFullTextInstalled { set; get; }
            public String IsLocalDB { set; get; }
        }

        static public CodexSQLServerInformaiton GetSQLServerInfo(String ConnectionStr)
        {
            SqlConnection cn = new SqlConnection(ConnectionStr);
            String Commnad = "USE master SELECT SERVERPROPERTY('productversion') AS ProductVersion, SERVERPROPERTY('productlevel') AS ProductLevel, SERVERPROPERTY('edition')  AS Edition, SERVERPROPERTY('Collation')  AS Collation, SERVERPROPERTY('IsFullTextInstalled')  AS IsFullTextInstalled, SERVERPROPERTY('IsLocalDB') AS IsLocalDB ";
            SqlCommand cm = new SqlCommand(Commnad, cn);
            cn.Open();
            var result = new CodexSQLServerInformaiton();
            result.ProductVersion = "***";
            using (SqlDataReader reader = cm.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.ProductVersion = Convert.ToString(reader["ProductVersion"]);
                    result.ProductLevel = Convert.ToString(reader["ProductLevel"]);
                    result.Edition = Convert.ToString(reader["Edition"]);
                    result.Collation = Convert.ToString(reader["Collation"]);
                    result.IsFullTextInstalled = Convert.ToString(reader["IsFullTextInstalled"]);
                    result.IsLocalDB = Convert.ToString(reader["IsLocalDB"]);
                }
            }
            cn.Close();
            return result;
        }

        static public string GetDatabasePrimaryPath(String CatalogName)
        {
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

            String Commnad = "USE "+ CatalogName + " SELECT physical_name FROM sys.database_files where data_space_id = 1";
            SqlCommand cm = new SqlCommand(Commnad, cn);
            cn.Open();
            String result = "";
            using (SqlDataReader reader = cm.ExecuteReader())
            {
                while (reader.Read())
                {
                    result  = Convert.ToString(reader["physical_name"]);
                }
            }
            cn.Close();
            return result;
        }

        static public string IsFullTextEnabled(String CatalogName)
        {
            // 1 TRUE 0 FALSE
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

            String Commnad = "use master SELECT DATABASEPROPERTY( 'CODEX2007DS' , 'IsFulltextEnabled' ) as IsFulltextEnabled";
            SqlCommand cm = new SqlCommand(Commnad, cn);
            cn.Open();
            String result = "";
            using (SqlDataReader reader = cm.ExecuteReader())
            {
                while (reader.Read())
                {
                    result = Convert.ToString(reader["IsFulltextEnabled"]);
                }
            }
            cn.Close();
            return result;
        }

        static public string IsFullTextInstalled(ref String ErrorString)
        {
            // 1 TRUE 0 FALSE
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

            String Commnad = "use master SELECT FULLTEXTSERVICEPROPERTY('IsFullTextInstalled') as IsFulltextEnabled";
            SqlCommand cm = new SqlCommand(Commnad, cn);
            cn.Open();
            String result = "0";
            ErrorString = "";
            try
            {
                using (SqlDataReader reader = cm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Convert.ToString(reader["IsFulltextEnabled"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message.ToString();
            }
            finally
            {
                cn.Close();
            }
            return result;
        }

        static public int GetFullTextCatalogsCount(String CatalogName)
        {
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);
            String Commnad = "USE "+ CatalogName + " select Count(*)  from sys.fulltext_indexes";
            SqlCommand cm = new SqlCommand(Commnad, cn);
            cn.Open();
            int result = -1;
            try {
                result = (int)cm.ExecuteScalar();
            }
            catch
            { result = -10; }
            finally
            { cn.Close(); }
            return result;
        }

        static public void SetFullTextEnabled(String CatalogName)
        {
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

            String Commnad = "use "+  CatalogName + " EXEC sp_fulltext_database 'enable'";
            SqlCommand cm = new SqlCommand(Commnad, cn);
            cn.Open();
            try
            {
                cm.ExecuteNonQuery();
            }
            catch
            { }
            finally
            { cn.Close(); }
           
       }


        static public string GetDatabaseUsersStatus(ref String ErrorString,bool CheckOldUsers, bool CheckNewUsersWithStrongPassword)
        {

            
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

            #region Check Users in Database

            String Command =

            // === CodexR4 Database =======
            "    SELECT " + System.Environment.NewLine +
            " (CASE WHEN EXISTS(SELECT name FROM codex2007ds.sys.database_principals where(type = 'S' and name = 'codexdsuser')) " + System.Environment.NewLine +
            " THEN 0  ELSE 1 END) AS CodexDS_CodexDSUser, " + System.Environment.NewLine +
            System.Environment.NewLine +

            " (CASE WHEN EXISTS(SELECT name FROM codex2007ds.sys.database_principals where(type = 'S' and name = 'codexdsxuser')) " + System.Environment.NewLine +
            " THEN 0  ELSE 1 END) AS CodexDS_CodexDSXUser, " + System.Environment.NewLine +
            System.Environment.NewLine;
            // ==============================

            SqlCommand cm = new SqlCommand(Command, cn);
            cn.Open();

            String  result = System.Environment.NewLine;
             result += "------------------------------------------------" + System.Environment.NewLine;
             result += "Codex Users Status In Databases: " + System.Environment.NewLine;
            

            String CodexDSUserErr = "";
            String CodexDSXUserErr = "";
        
            using (SqlDataReader reader = cm.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Convert.ToString(reader["CodexDS_CodexDSUser"]) != "0") CodexDSUserErr += " {CodexR} ";
                    if (Convert.ToString(reader["CodexDS_CodexDSXUser"]) != "0") CodexDSXUserErr += " {CodexRX} ";

             
                    break;
                }
            }
            cn.Close();

            if (CheckOldUsers == true)
            {
                #region OldUsers

                if (CodexDSUserErr.Trim() == "")
                {
                    result += "SQL USER CodexDSUser : OK " + System.Environment.NewLine;
                }
                else
                {
                    result += "ERROR !!! : SQL USER CodexDSUser : Is not Register in Databases Codex2007DS" +  System.Environment.NewLine;
                    ErrorString = ".";
                }

                #endregion OldUsers
            }


            if (CheckNewUsersWithStrongPassword == true)
            {
                #region NewUsersWithStrongPassword

                if (CodexDSXUserErr.Trim() == "")
                {
                    result += "SQL USER CodexDSXUser : OK " + System.Environment.NewLine;
                }
                else
                {
                    result += "ERROR !!! : SQL USER CodexDSXUser : Is not Register in Databases " + CodexDSXUserErr + System.Environment.NewLine;
                    ErrorString = ".";
                }


                

                #endregion NewUsersWithStrongPassword
            }

            #endregion

            #region Check Logons
            // SQL LOGINS CHECK


            //Command = " SELECT name AS Login_Name, type_desc AS Account_Type " + System.Environment.NewLine +
            //          " FROM sys.server_principals " + System.Environment.NewLine +
            //          " WHERE TYPE IN ('S') " + System.Environment.NewLine +
            //          " and name not like '%##%' " + System.Environment.NewLine +
            //          " ORDER BY name, type_desc ";

            Command = " SELECT " + System.Environment.NewLine +
                        " (CASE WHEN EXISTS(SELECT name FROM sys.server_principals  where(type = 'S' and name = 'CODEXDSUSER')) " + System.Environment.NewLine +
                        " THEN 0  ELSE 1 END) AS Login_CodexDSUser, " + System.Environment.NewLine +
                        " (CASE WHEN EXISTS(SELECT name FROM sys.server_principals  where(type = 'S' and name = 'CODEXDSXUSER')) " + System.Environment.NewLine +
                        " THEN 0  ELSE 1 END) AS Login_CodexDSXUser, " + System.Environment.NewLine;

            cm = new SqlCommand(Command, cn);
            cn.Open();

            result += System.Environment.NewLine;
            result += "------------------------------------------------" + System.Environment.NewLine;
            result += "Codex Users Status In SQL Logins: " + System.Environment.NewLine;

            CodexDSUserErr = "";
            CodexDSXUserErr = "";
          

            using (SqlDataReader reader = cm.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Convert.ToString(reader["Login_CodexDSUser"]) != "0") CodexDSUserErr += " {CodexR} ";
                    if (Convert.ToString(reader["Login_CodexDSXUser"]) != "0") CodexDSXUserErr += " {CodexR} ";
  
                    break;
                }
            }
            cn.Close();

            if (CheckOldUsers == true)
            {
                #region OldUsers
                if (CodexDSUserErr.Trim() == "")
                {
                    result += "SQL LOGIN CodexDSUser : OK " + System.Environment.NewLine;
                }
                else
                {
                    result += "ERROR !!! : SQL LOGIN CodexDSUser : Is not Register in SQL Server " + System.Environment.NewLine;
                }


   
                #endregion OldUsers
            }

            if (CheckNewUsersWithStrongPassword == true)
            {
                #region NewUsersWithStrongPassword
                if (CodexDSXUserErr.Trim() == "")
                {
                    result += "SQL LOGIN CodexDSXUser : OK " + System.Environment.NewLine;
                }
                else
                {
                    result += "ERROR !!! : SQL LOGIN CodexDSXUser : Is not Register in SQL Server " + System.Environment.NewLine;
                    ErrorString = ".";
                }



   

                #endregion NewUsersWithStrongPassword
            }

            #endregion Check Logons

            return result;
        }

       
        static public void ExecutionSQLScript(String SqlScript, ref String ErrorString)
        {
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

            String Commnad = SqlScript;
            SqlCommand cm = new SqlCommand(Commnad, cn);
            cn.Open();
            try
            {
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            { ErrorString = ex.Message; }
            finally
            { cn.Close(); }

        }

        static public void ExecutionSQLScriptWithGOSeperator(String SqlScript, ref String ErrorString)
        {
            SqlConnection cn = new SqlConnection(ILG.Codex.CodexR4.Properties.Settings.Default.ConnectionString_master);

            String Commnad = SqlScript;
            SqlCommand cm = new SqlCommand(Commnad, cn);


            string[] commands = SqlScript.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string SeparateCommand in commands)
            {
                cm = new SqlCommand(SeparateCommand, cn); 
                cn.Open();
                try
                {
                    cm.ExecuteNonQuery();
                }
                catch (Exception ex)
                { ErrorString +=  ex.Message + System.Environment.NewLine;  }
                finally
                {
                    cn.Close();
                }

                if (ErrorString.Trim() == "") break;
            }

            return;
        }
     
        public int RegisterCodexDSDatabaseUser()
        {
            String Err = "";
            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexdsUser მომხარებლების ის რეგისტრაცია", Color.Black);

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(Properties.Resources.Script_Drop_DSCU, ref Err);
            if (Err.Trim() != "")
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error 1 : კოდექსის ბაზებზე CodexDSUser მომხარებლების ის რეგისტრაცია", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, Err, Color.Red); return 1;
            }

            Err = "";

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(Properties.Resources.Script_Register_DSCU, ref Err);
            if (Err.Trim() != "")
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error 2 : კოდექსის ბაზებზე CodexDSUser მომხარებლების ის რეგისტრაცია", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, Err, Color.Red); return 2;
            }
           
            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexDSUser მომხარებლების ის რეგისტრაცია დასრულდა", Color.Black);

            return 0;
        }

        public int DropCodexDSDatabaseUser()
        {
            String Err = "";
            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexDSUser მომხარებლების წაშლა", Color.Black);

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(Properties.Resources.Script_Drop_DSCU, ref Err);
            if (Err.Trim() != "")
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error 1 : კოდექსის ბაზებზე CodexDSUser მომხარებლების წაშლა", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, Err, Color.Red); return 1;
            }

            Err = "";

            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexDSUser მომხარებლები წაშლილია", Color.Black);

            return 0;
        }

        public int RegisterCodexDatabaseDSXUser()
        {
            String Err = "";
            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexDSXUser მომხარებლების ის რეგისტრაცია", Color.Black);

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(Properties.Resources.Script_Drop_DSCXU, ref Err);
            if (Err.Trim() != "")
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error 1 : კოდექსის ბაზებზე CodexDSXUser მომხარებლების ის რეგისტრაცია", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, Err, Color.Red); return 1;
            }

            Err = "";

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(Properties.Resources.Script_Register_DSCXU, ref Err);
            if (Err.Trim() != "")
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error 2 : კოდექსის ბაზებზე CodexrDSXUser მომხარებლების ის რეგისტრაცია", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, Err, Color.Red); return 2;
            }

            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexrDSXUser  მომხარებლების ის რეგისტრაცია დასრულდა", Color.Black);

            return 0;
        }

        public int DropCodexDatabaseDSXUser()
        {
            String Err = "";
            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexDSXUser  მომხარებლების წაშლა", Color.Black);

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(Properties.Resources.Script_Drop_DSCXU, ref Err);
            if (Err.Trim() != "")
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error 1 : კოდექსის ბაზებზე CodexDSXUser მომხარებლების წაშლა", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, Err, Color.Red); return 1;
            }

            Err = "";

            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე CodexDSXUser მომხარებლები წაშლილია", Color.Black);

            return 0;
        }



        public int CodexFullText()
        {
            String Err = "";
            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე FullText კატალოგის შექმნა ", Color.Black);

            CodexDatabase.ExecutionSQLScriptWithGOSeperator(ILG.Codex.CodexR4.Properties.Resources.FullTextCreateAndPopulate_DS, ref Err);

            if (Err.Trim() != "")
            {
                Owner.ShowProgress_DatabaseInstaller(0, "Error 1 : კოდექსის ბაზებზე FullText კატალოგის შექმნა ", Color.Black);
                Owner.ShowProgress_DatabaseInstaller(0, Err, Color.Red); return 1;
            }
            
            Owner.ShowProgress_DatabaseInstaller(0, "კოდექსის ბაზებზე FullText კატალოგის შექმნილია ", Color.Black);

            return 0;
        }

       


    }
}
