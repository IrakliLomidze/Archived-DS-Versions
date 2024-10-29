// ***********************************************************************************************
// Codex 365 Client Code
// (C) Copyright By 1996-2022 Georgian Microsystems
// (C) Copyright By 1996-2022 Irakli Lomidze
// ***********************************************************************************************
// Verison 5.2
// Date : 2020/05/22
// Date : 2020/12/25
// Date : 2021/09/08
// Date : 2022/06/24 SKU


using DS.Configurations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ILG.DS.Configurations
{
    public class DirectoryConfiguration
    {
        private static DirectoryConfiguration instance;
        private DirectoryConfiguration() { }

        public static DirectoryConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DirectoryConfiguration();
                    instance.load();
                }
                return instance;
            }
        }


        public string DSCurrentDirectory { private set; get; }
        public string DSProfileRootDirectory { private set; get; }
        public string DSTemporaryDirectory { private set; get; }



        public void RedefineTempDirectory()
        {
            string TempDirCodex = Environment.GetEnvironmentVariable("TEMP");

            // Creating Temp Direcotry
            TempDirCodex = TempDirCodex + @"\" + DateTime.Now.Ticks.ToString();
            if (Directory.Exists(TempDirCodex) == false)
                Directory.CreateDirectory(TempDirCodex);
            DSTemporaryDirectory = TempDirCodex;

        }

        
        public static string FavoriteDocumentsDirectory { private set; get; }
        public static string DSDocumentsDirectory { private set; get; }
        public static string ComparedDocumentsDirectory { private set; get; }
        public static string DockSettingsDirectory { private set; get; }
        



        public void load()
        {
            this.DSCurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Directory.SetCurrentDirectory(DSCurrentDirectory);


            DSProfileRootDirectory = Path.Combine(DSCurrentDirectory, "Profiles");
            
            DSTemporaryDirectory = Environment.GetEnvironmentVariable("TEMP");

            // Creating Temp Direcotry
            this.DSTemporaryDirectory = DSTemporaryDirectory + @"\" + DateTime.Now.Ticks.ToString();
            if (Directory.Exists(DSTemporaryDirectory) == false) Directory.CreateDirectory(DSTemporaryDirectory);



            DSDocumentsDirectory = @Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\DS Documents";
            if (Directory.Exists(DSDocumentsDirectory) == false) Directory.CreateDirectory(DSDocumentsDirectory);


            FavoriteDocumentsDirectory = DSDocumentsDirectory + @"\Favorites";
            if (Directory.Exists(FavoriteDocumentsDirectory) == false) Directory.CreateDirectory(FavoriteDocumentsDirectory);


            ComparedDocumentsDirectory = DSDocumentsDirectory + @"\WorkDocuments";
            if (Directory.Exists(ComparedDocumentsDirectory) == false) Directory.CreateDirectory(ComparedDocumentsDirectory);

            DockSettingsDirectory = DSDocumentsDirectory + @"\settings";
            if (Directory.Exists(DockSettingsDirectory) == false) Directory.CreateDirectory(DockSettingsDirectory);


            

            //#region customer specific
            //string apppath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DS");
            //if (!Directory.Exists(apppath)) Directory.CreateDirectory(apppath);

            //string datapath = Path.Combine(apppath, "data");
            //if (!Directory.Exists(datapath)) Directory.CreateDirectory(datapath);

            //string verpath = Path.Combine(datapath, "10.0");
            //if (!Directory.Exists(verpath)) Directory.CreateDirectory(verpath);
            
            //#endregion customer specific



        }


       
    }
}
