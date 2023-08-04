using ILG.Codex.CodexR4.CodexSettings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4
{
    public class DirectoryConfiguration
    {
        public DirectoryConfiguration()
        {

        }

        private static string _currentDirectory;
        private static string _tempDirectory;


        private static string _codexFavoritesDir;
        private static string _codexDocumentDir;
        private static string _comparedDocuments;

        private static string _codexUpdatesDirectory;
        private static string _dockSettingsPath;
        private static string _codexR4PrivateSettingsDir;


        public static string CurrentDirectory { get { return _currentDirectory; } }
        public static string FavoriteDocumentsDirectory { get { return _codexFavoritesDir; } }
        public static string CodexDocumentsDirectory { get { return _codexDocumentDir; } }
        public static string ComparedDocumentsDirectory { get { return _comparedDocuments; } }
        public static string DockSettingsDirectory { get { return _dockSettingsPath; } }

        //public static string LocalDBCodexDatabaseLocation { get { return _localDBCodexDatabaseLocation; } }

        public static string CodexUpdateDirectory { get { return _codexUpdatesDirectory; } }

        public static string CodexTemporaryDirectory { get { return _tempDirectory; } }

        public static string CodexR4PrivateSettingsDir { get { return _codexR4PrivateSettingsDir; } }

   

        static public void LoadConfigurations()
        {
            #region Declarce Directoryes R4 Update #3 #1
            string CurrentDirCodex = System.Environment.CurrentDirectory;

            _currentDirectory = System.Environment.CurrentDirectory;

            string _applicationDocumentDirectory = @"\Codex DS 1.8 Documents";
            if (Properties.Settings.Default.ApplicationDocumentDirectory.Trim() != "")
            {
                _applicationDocumentDirectory = Properties.Settings.Default.ApplicationDocumentDirectory.Trim();
                if (_applicationDocumentDirectory.TrimStart().Substring(0,1) != @"\") _applicationDocumentDirectory = @"\" + _applicationDocumentDirectory;
            }



            string CodexDocuments = @Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Codex DS 1.8 Documents";
            if (Directory.Exists(CodexDocuments) == false)
                Directory.CreateDirectory(CodexDocuments);

            string FavoriteDocuments = CodexDocuments + @"\Favorites";
            if (Directory.Exists(FavoriteDocuments) == false)
                Directory.CreateDirectory(FavoriteDocuments);

            string ComparedDocuments = CodexDocuments + @"\WorkDocuments";
            if (Directory.Exists(ComparedDocuments) == false)
                Directory.CreateDirectory(ComparedDocuments);

            //string CodexUpdateDirectory = CodexDocuments + @"\Codex R4 Update";
            //if (Directory.Exists(CodexUpdateDirectory) == false)
            //    Directory.CreateDirectory(CodexUpdateDirectory);

            string DockSettings = CodexDocuments + @"\Settings";
            if (Directory.Exists(DockSettings) == false)
                Directory.CreateDirectory(DockSettings);

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



         
            Directory.SetCurrentDirectory(CurrentDirCodex);

            _tempDirectory = TempDirCodex;
            _codexDocumentDir = CodexDocuments;
            _codexFavoritesDir = FavoriteDocuments;
            _currentDirectory = Environment.CurrentDirectory;

            _dockSettingsPath = DockSettings;
            _comparedDocuments = ComparedDocuments;
            _codexUpdatesDirectory = CodexUpdateDirectory;


            #endregion Declarce Directoryes R4 Update #1

            #region Declarce Directoryes R4 Update #3 #2

            String CodexR4PrivateSettingsDir = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonDocuments) + "\\Codex R4 Settings";

                if (Directory.Exists(CodexR4PrivateSettingsDir) == false)
                    Directory.CreateDirectory(CodexR4PrivateSettingsDir);

            _codexR4PrivateSettingsDir = CodexR4PrivateSettingsDir;
         
            
            #endregion Declarce Directoryes R4 Update #2

        }
    }
}
