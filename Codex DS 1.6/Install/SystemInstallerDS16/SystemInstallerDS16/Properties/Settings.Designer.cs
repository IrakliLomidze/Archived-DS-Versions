﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ILG.Codex.CodexR4.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TemporaryDir {
            get {
                return ((string)(this["TemporaryDir"]));
            }
            set {
                this["TemporaryDir"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public uint WhenCrash {
            get {
                return ((uint)(this["WhenCrash"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public uint WhenCrashNew {
            get {
                return ((uint)(this["WhenCrashNew"]));
            }
            set {
                this["WhenCrashNew"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int InstallConfiguration {
            get {
                return ((int)(this["InstallConfiguration"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://msdn.microsoft.com/en-us/library/hh506443%28v=vs.110%29.aspx")]
        public string DotNetFx35Windows8 {
            get {
                return ((string)(this["DotNetFx35Windows8"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://technet.microsoft.com/en-us/library/dn482071.aspx")]
        public string DotNetFx35Windows2012 {
            get {
                return ((string)(this["DotNetFx35Windows2012"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"/QS /ACTION=Install /Hideconsole=TRUE /FEATURES=SQL,Tools /IACCEPTSQLSERVERLICENSETERMS=TRUE  /INSTANCENAME=CodexR4 /SECURITYMODE=SQL /SAPWD=""Codex$12345678"" /SQLCOLLATION=""SQL_Latin1_General_CP1_CI_AS"" /SQLSYSADMINACCOUNTS=""BUILTIN\ADMINISTRATORS"" /SQLSVCACCOUNT=""NT AUTHORITY\SYSTEM"" /AGTSVCACCOUNT=""NT AUTHORITY\Network Service"" /UPDATEENABLED=FALSE")]
        public string SQLServer_InstallCommand {
            get {
                return ((string)(this["SQLServer_InstallCommand"]));
            }
            set {
                this["SQLServer_InstallCommand"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SQLServerAdvanced_InstallCommand {
            get {
                return ((string)(this["SQLServerAdvanced_InstallCommand"]));
            }
            set {
                this["SQLServerAdvanced_InstallCommand"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PowerShell_InstallCommnad {
            get {
                return ((string)(this["PowerShell_InstallCommnad"]));
            }
            set {
                this["PowerShell_InstallCommnad"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Postgress_InstallCommand {
            get {
                return ((string)(this["Postgress_InstallCommand"]));
            }
            set {
                this["Postgress_InstallCommand"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Client_Install {
            get {
                return ((string)(this["Client_Install"]));
            }
            set {
                this["Client_Install"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Library_Install {
            get {
                return ((string)(this["Library_Install"]));
            }
            set {
                this["Library_Install"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string CodexR4_Install {
            get {
                return ((string)(this["CodexR4_Install"]));
            }
            set {
                this["CodexR4_Install"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Font_Install {
            get {
                return ((string)(this["Font_Install"]));
            }
            set {
                this["Font_Install"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Database_Install {
            get {
                return ((string)(this["Database_Install"]));
            }
            set {
                this["Database_Install"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://msdn.microsoft.com/en-us/library/hh506443(v=vs.110).aspx")]
        public string Enable_FX35_Windows81 {
            get {
                return ((string)(this["Enable_FX35_Windows81"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://support.microsoft.com/en-us/kb/2785188")]
        public string Enable_FX35_Windows8 {
            get {
                return ((string)(this["Enable_FX35_Windows8"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://blogs.msdn.com/b/sql_shep/archive/2012/08/01/windows-2012-and-net-3-5-feat" +
            "ure-install.aspx")]
        public string Enable_FX35_Windows2012 {
            get {
                return ((string)(this["Enable_FX35_Windows2012"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("www.codex.ge")]
        public string WebAddress {
            get {
                return ((string)(this["WebAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("support@codex.ge")]
        public string SupportAddress {
            get {
                return ((string)(this["SupportAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("support@codex.ge")]
        public string BugTraqMail {
            get {
                return ((string)(this["BugTraqMail"]));
            }
        }
    }
}
