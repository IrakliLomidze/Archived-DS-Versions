// ***********************************************************************************************
// Codex DS Client Code
// (C) Copyright By 1996-2022 Irakli Lomidze
// ***********************************************************************************************



using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ILG.DS.Profile
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


        public void load()
        {
            this.DSCurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Directory.SetCurrentDirectory(DSCurrentDirectory);
            
            DSProfileRootDirectory = @Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\DS Profiles";
            if (Directory.Exists(DSProfileRootDirectory) == false) Directory.CreateDirectory(DSProfileRootDirectory);
        }


       
    }
}
