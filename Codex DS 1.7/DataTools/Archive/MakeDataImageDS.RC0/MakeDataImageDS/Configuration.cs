using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ILG.Windows.Forms;
using System.IO;
using System.Xml;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer;



namespace ILG.Codex.Codex2007
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }



        public static void createfile()
        {
            FileStream fs;
            try
            {
                fs = new FileStream(ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + @"\Codex2007DataImageCreator.Config", FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            }
            catch (Exception ex)
            { // can't open outfile
                String errorStr = "არ ხერხდება ფაილის გახსნა [" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
                return;
            }

            ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = ".\\Codex2007"; // Common.Server = "Codex";



            XmlDocument doc = new XmlDocument();
            XmlTextWriter writer = new XmlTextWriter(fs, System.Text.Encoding.ASCII);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Codex2007DatabasePickerConfiguration");
            writer.WriteElementString("ServerName", ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer); // Common.Server
            writer.WriteElementString("ToDir", ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo); // ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo
            writer.WriteElementString("FromDir", ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom); // ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            fs.Close();




        }

        public static void loadformfile()
        {

            if (File.Exists(ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + @"\Codex2007DataImageCreator.Config") == false)
            {
                Configuration.createfile();
            }



            FileStream fs;
            try
            {

                fs = new FileStream(ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + @"\Codex2007DataImageCreator.Config", FileMode.Open, FileAccess.Read, FileShare.Read, 1024);
            }
            catch (Exception ex)
            { // can't open outfile
                String errorStr = "არ ხერხდება ფაილის გახსნა \n[" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
                return;
            }


            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fs);

                XmlNodeList nodes = doc.GetElementsByTagName("Codex2007DatabasePickerConfiguration");
                ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = nodes.Item(0).ChildNodes.Item(0).InnerText.ToString(); // Serve Name
                ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = nodes.Item(0).ChildNodes.Item(1).InnerText.ToString(); // cuf
                ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom  = nodes.Item(0).ChildNodes.Item(2).InnerText.ToString(); // cuf
            }
            catch //(Exception ex )
            { // can't open outfile
                String errorStr = "კონფიგურაციის ფაილი დაზიანებულია  \nგთხოვთ გაასწოროთ იგი.\nან წაშალეთ იგი,და სისტემა შექმნის მას ახლიდან  ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr, "Configuration Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            fs.Close();

        }

        public static void SaveXMLData(String ToPath,String FromPath, String SQLServer)
            
        {

            FileStream fs;
            try
            {
                fs = new FileStream(ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir + @"\Codex2007DataImageCreator.Config", FileMode.Create, FileAccess.Write, FileShare.None, 1024);
            }
            catch (Exception ex)
            { // can't open outfile
                String errorStr = "არ ხერხდება ფაილის გახსნა [" + ex.Message + "] ";
                ILG.Windows.Forms.ILGMessageBox.Show(errorStr);
                return;
            }



            //bool   UseFullText      = this.checkBox1.Checked;
            ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = ToPath;
            ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom = FromPath;
            ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer = SQLServer;



            XmlDocument doc = new XmlDocument();
            XmlTextWriter writer = new XmlTextWriter(fs, System.Text.Encoding.ASCII);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Codex2007DatabasePickerConfiguration");

            writer.WriteElementString("ServerName", ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer);
            writer.WriteElementString("ToDir", ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo);
            writer.WriteElementString("FromDir", ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseFrom);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            fs.Close();




        }

        static public void load()
        {
            
            if (global::ILG.Codex.Codex2007.Properties.Settings.Default.SQLServer == "") 
            {
                global::ILG.Codex.Codex2007.Properties.Settings.Default.Save();
            }


            #region declarce directoryes
            string CurrentDirCodex = System.Environment.CurrentDirectory;
		
            string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Codex 2007 Documents";
            if (Directory.Exists(CodexDocuments) == false)
                Directory.CreateDirectory(CodexDocuments);

            string FavoriteDocuments = CodexDocuments + @"\Favorites";
            if (Directory.Exists(FavoriteDocuments) == false)
                Directory.CreateDirectory(FavoriteDocuments);

            string CodexUpdateDirectory = CodexDocuments + @"\Codex 2007 Update";
            if (Directory.Exists(CodexUpdateDirectory) == false)
                Directory.CreateDirectory(CodexUpdateDirectory);




            string TempDirCodex = Environment.GetEnvironmentVariable("TEMP");
            if (Directory.Exists(TempDirCodex) == false)
            {
                TempDirCodex = CodexDocuments + @"\Temp";
                if (Directory.Exists(TempDirCodex) == false)
                    Directory.CreateDirectory(TempDirCodex);
            }

            // Creating Temp Direcotry
            TempDirCodex = TempDirCodex + @"\" + DateTime.Now.Ticks.ToString();
            if (Directory.Exists(TempDirCodex) == false)
                Directory.CreateDirectory(TempDirCodex);

            string HelpDir = CurrentDirCodex + @"\Help";
            if (Directory.Exists(HelpDir) == false)
                Directory.CreateDirectory(HelpDir);

            Directory.SetCurrentDirectory(CurrentDirCodex);


            #endregion declarce directoryes


            global::ILG.Codex.Codex2007.Properties.Settings.Default.TemporaryDir = TempDirCodex;
            //global::ILG.Codex.Codex2007.Properties.Settings.Default.CodexDatabaseTo = CodexDocuments;
            global::ILG.Codex.Codex2007.Properties.Settings.Default.CurrentDir = Environment.CurrentDirectory;
          
        }

        
        

  
        
        
        
    }
}