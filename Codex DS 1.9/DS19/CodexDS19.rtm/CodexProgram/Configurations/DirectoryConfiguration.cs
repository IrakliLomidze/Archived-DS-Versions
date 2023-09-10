using DS.Configurations;
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

        private static string _dockSettingsPath;
        private static string _DSPrivateSettingsDir;


        public static string CurrentDirectory { get { return _currentDirectory; } }
        public static string FavoriteDocumentsDirectory { get { return _codexFavoritesDir; } }
        public static string DSDocumentsDirectory { get { return _codexDocumentDir; } }
        public static string ComparedDocumentsDirectory { get { return _comparedDocuments; } }
        public static string DockSettingsDirectory { get { return _dockSettingsPath; } }

        public static string DSTemporaryDirectory { get { return _tempDirectory; } }

        public static string DSPrivateSettingsDir { get { return _DSPrivateSettingsDir; } }

   

        static public void LoadConfigurations()
        {
            #region Declarce Directoryes R4 Update #3 #1
            string CurrentDirCodex = System.Environment.CurrentDirectory;

            _currentDirectory = System.Environment.CurrentDirectory;

            string _applicationDocumentDirectory = @"\DS Document Storage";
            if (DSBehaviorConfiguration.Instance.content.General.ApplicationDocumentDirectory.Trim() != "")
            {
                _applicationDocumentDirectory = DSBehaviorConfiguration.Instance.content.General.ApplicationDocumentDirectory.Trim();
                if (_applicationDocumentDirectory.TrimStart().Substring(0,1) != @"\") _applicationDocumentDirectory = @"\" + _applicationDocumentDirectory;
            }



            string CodexDocuments = @Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\DS Document Storage";
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
            


            #endregion Declarce Directoryes R4 Update #1

            #region Declarce Directoryes R4 Update #3 #2

            String CodexR4PrivateSettingsDir = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonDocuments) + "\\Codex R4 Settings";

                if (Directory.Exists(CodexR4PrivateSettingsDir) == false)
                    Directory.CreateDirectory(CodexR4PrivateSettingsDir);

            _DSPrivateSettingsDir = CodexR4PrivateSettingsDir;
         
            
            #endregion Declarce Directoryes R4 Update #2

        }
    }
}
