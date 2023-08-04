using System;
using System.Reflection;
using System.IO;

// Removed from 1.6 Version
// Will be implemented on Demand  (if)

namespace ILG.Codex.CodexR4.JsonConfigurations
{
    //public class CodexDSOrganizationSettings
    //{
    //    private static volatile CodexDSOrganizationSettings instance;
    //    private static object syncRoot = new Object();
    //    private CodexDSOrganizationSettings() { Settings = new CodexDSOrganizationModel(); }
    //    public static CodexDSOrganizationSettings Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //            {
    //                lock (syncRoot)
    //                {
    //                    if (instance == null)
    //                        instance = new CodexDSOrganizationSettings();
    //                }
    //            }

    //            return instance;
    //        }
    //    }

    //    public CodexDSOrganizationModel Settings { get; }

    //    public void LoadConfiguration()
    //    {

    //        String directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //        string FileName = Path.Combine(directory, "CodexDSOrganizationSettings.json");
    //        CodexDSOrganizationConfigurationFile settings = new CodexDSOrganizationConfigurationFile(FileName);
    //        if (File.Exists(FileName) == true)
    //        {
    //            settings.ReadFromFile();
    //        }
    //        else
    //        {
    //            try
    //            {
    //                settings.WritetoFile();
    //            }
    //            catch
    //            {

    //            }
    //        }

    //    }
        
    //}
}
