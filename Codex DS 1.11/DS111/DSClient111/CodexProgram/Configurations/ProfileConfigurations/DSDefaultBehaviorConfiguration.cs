// *************************************************************************************
// ** DS Configurations
// ** (C) Copyright By 2007-2024 By Irakli Lomidze
// *************************************************************************************
// ** DS Configurations
// ** Version 2.5
// ** Date 2022/12/12
// ** Date 2023/01/06
// ** Date 2023/04/08 // ** Version 2.0
// ** Date 2023/06/1 // ** Version 2.5

using ILG.Codex.CodexR4;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ILG.DS.Configurations
{

    public class DSBehaviorConfiguration
    {
        
        public readonly string configFilename = "dsbehaviour.json";
        private static string _profile;

        private static DSBehaviorConfiguration instance;
        public DSBehaviorContent content { get; private set; }
        public static DSBehaviorConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DSBehaviorConfiguration();
                    instance.DefaultParameters();
                    //instance.CreateIfNotExists();
                }
                return instance;
            }
        }

        public static void configure_profile(string profile)
        {
            _profile = profile;
        }
        private string get_fullfilename()
        {
            if (_profile == null) { throw new Exception("Not Initialized profile"); }
            var current = DirectoryConfiguration.Instance.DSCurrentDirectory;
            current = current.EndsWith("/") ? current.Substring(0, current.Length - 1) : current;
            return Path.Combine(current + $"\\PROFILES\\{_profile}\\", configFilename);
        }
        private void DefaultParameters()
        {
            content = new DSBehaviorContent();
        }

        private DSBehaviorConfiguration()
        {
            //_configurationFullFilename = Path.Combine(DirectoryConfiguration.Instance.DSCurrentDirectory, configFilename);
            //CreateIfNotExists();
        }

        public void AssingNewConfiguraiton(DSBehaviorContent newconfig)
        {
            content.AssingNewConfiguraiton(newconfig);
        }

        private void _writeToFile()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(content, options);
            File.WriteAllText(get_fullfilename(), jsonString);
        }
        public void CreateIfNotExists_Admin()
        {
            if (File.Exists(get_fullfilename()) == false)
            {
                DefaultParameters();
                _writeToFile();
            }
        }
        public int ReadConfiguraiton()
        {
            try
            {
                //CreateIfNotExists();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                string jsonString = File.ReadAllText(get_fullfilename());

                content = JsonSerializer.Deserialize<DSBehaviorContent>(jsonString, options);
                return 0;
            }
            catch (Exception ) { DefaultParameters(); return 1; }
            
        }

        public void WriteConfiguration()
        {
            _writeToFile();
        }




    }
    public class DSBehaviorContent
    {
        public DSBehaviorGeneral General { get; set; }
        public DSSaveingBehavior Saving { get; set; }
        public DSViewBehavior View { get; set; }

        public DSAttributesBehavior Attributes { get; set; }

        public DSNewDocumentNotificationBehavior NewDocumentNotification { get; set; }

        public void AssingNewConfiguraiton(DSBehaviorContent newconfig)
        {
            General.AssingNewConfiguraiton(newconfig.General);
            Saving.AssingNewConfiguraiton(newconfig.Saving);
            View.AssingNewConfiguraiton(newconfig.View);
            Attributes.AssingNewConfiguraiton(newconfig.Attributes);
            if (newconfig.NewDocumentNotification != null)
                NewDocumentNotification.AssingNewConfiguraiton(newconfig.NewDocumentNotification);
            else NewDocumentNotification = new DSNewDocumentNotificationBehavior();
        }

        public DSBehaviorContent() 
        {
            General = new DSBehaviorGeneral();
            Saving = new DSSaveingBehavior();
            View = new DSViewBehavior();
            Attributes = new DSAttributesBehavior();
            NewDocumentNotification = new DSNewDocumentNotificationBehavior();
        }

    }

    public class DSAttributesBehavior
    {
        public bool ShowAdvancedAttributes { get; set; } = true;
        public bool UseStatusAsMandatory { get; set; } = true;
        public bool UseCategoryAsMandatory { get; set; } = true;
        public bool UseNumberAsManadatory { get; set; } = true;
        public bool IsDefaultParameterStatus { get; set; } = false;
        public string DefaultStatus { get; set; } = "";
        

        public void AssingNewConfiguraiton(DSAttributesBehavior newconfig)
        {
            ShowAdvancedAttributes = newconfig.ShowAdvancedAttributes;
            UseStatusAsMandatory = newconfig.UseStatusAsMandatory;
            UseCategoryAsMandatory = newconfig.UseCategoryAsMandatory;
            UseNumberAsManadatory = newconfig.UseNumberAsManadatory;
            IsDefaultParameterStatus = newconfig.IsDefaultParameterStatus;
            DefaultStatus = newconfig.DefaultStatus;
        }
        public DSAttributesBehavior()
        {

        }
    }

    public class DSSaveingBehavior
    {
        public bool AskToRemoveSections { get; set; } = true;
        public bool CheckSaveNewConditionOnDublicate { get; set; } = true;
        public bool CheckSaveChangeConditionOnDublicate { get; set; } = false;
        public bool CheckSaveConditionWithDocumentCaption { get; set; } = true;
        public bool CheckSaveConditionWithDocumentStatus { get; set; } = true;
        public bool CheckSaveWarnOnly { get; set; } = false;
        public bool DSAfterSaveNewDoc { get; set; } = false;

        public void AssingNewConfiguraiton(DSSaveingBehavior newconfig)
        {
            AskToRemoveSections = newconfig.AskToRemoveSections;
            CheckSaveNewConditionOnDublicate = newconfig.CheckSaveNewConditionOnDublicate;
            CheckSaveChangeConditionOnDublicate = newconfig.CheckSaveChangeConditionOnDublicate;
            CheckSaveConditionWithDocumentCaption = newconfig.CheckSaveConditionWithDocumentCaption;
            CheckSaveConditionWithDocumentStatus = newconfig.CheckSaveConditionWithDocumentStatus;
            CheckSaveWarnOnly = newconfig.CheckSaveWarnOnly;
            DSAfterSaveNewDoc = newconfig.DSAfterSaveNewDoc;
            
        }

        public DSSaveingBehavior()
        {

        }

    }

    public class DSViewBehavior
    {
        public int AppViewDS { get; set; } = 0;
        public int AppDockDS { get; set; } = 0;
        public int AppZoomDS { get; set; } = 0;
        public bool CodexPrintLogic { get; set; } = false;


        public void AssingNewConfiguraiton(DSViewBehavior newconfig)
        {
            AppViewDS = newconfig.AppViewDS;
            AppDockDS = newconfig.AppDockDS;
            AppZoomDS = newconfig.AppZoomDS;
            CodexPrintLogic = newconfig.CodexPrintLogic;

        }

        public DSViewBehavior()
        {

        }

    }

    public class DSBehaviorGeneral
    {

        public bool ISSaveConnectionStringInProgramFolder { get; set; } = true;

        public int AppMaxCodList { get; set; } = -1;
        public bool IsOptions { get; set; } = true;
        public bool IsLimitation { get; set; } = false;

        public bool IsKeyboard { get; set; } = false;
        public int AppKeyboardLayout { get; set; } = 0;

        public string ApplicationDocumentDirectory { get; set; } = "";

        public bool DisplayCheck { get; set; } = false;


        public bool AppSaveConnectionStringInProgramFolder { get; set; } = false;
        public int WhenCrash { get; set; } = 1;
        
        public void AssingNewConfiguraiton(DSBehaviorGeneral newconfig)
        {

            ISSaveConnectionStringInProgramFolder = newconfig.ISSaveConnectionStringInProgramFolder;


            AppMaxCodList = newconfig.AppMaxCodList;


            IsOptions = newconfig.IsOptions;
            IsLimitation = newconfig.IsLimitation;

            IsKeyboard = newconfig.IsKeyboard;
            AppKeyboardLayout = newconfig.AppKeyboardLayout;


            ApplicationDocumentDirectory = newconfig.ApplicationDocumentDirectory;

            DisplayCheck = newconfig.DisplayCheck;
            AppSaveConnectionStringInProgramFolder = newconfig.AppSaveConnectionStringInProgramFolder;

            WhenCrash = newconfig.WhenCrash;
        }

        public DSBehaviorGeneral()
        {

        }

    }

    public class DSNewDocumentNotificationBehavior
    {

        public bool use_newdocument_notification { get; set; } = true;
        public int new_document_notification { get; set; } = 60;

        public void AssingNewConfiguraiton(DSNewDocumentNotificationBehavior newconfig)
        {

            use_newdocument_notification = newconfig.use_newdocument_notification;


            new_document_notification = newconfig.new_document_notification;
            if ((new_document_notification < 1) || (new_document_notification > 365)) new_document_notification = 60;
            
        }

        public DSNewDocumentNotificationBehavior()
        {

        }

    }

}

