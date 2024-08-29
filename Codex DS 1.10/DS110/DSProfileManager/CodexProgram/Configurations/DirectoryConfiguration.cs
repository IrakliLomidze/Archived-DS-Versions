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



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4
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
            
            DSProfileRootDirectory = @Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\DS Admin Profiles";
            if (Directory.Exists(DSProfileRootDirectory) == false) Directory.CreateDirectory(DSProfileRootDirectory);
        }


       
    }
}
