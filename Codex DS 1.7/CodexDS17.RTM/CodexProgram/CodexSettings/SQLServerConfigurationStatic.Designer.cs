﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ILG.Codex.CodexR4.CodexSettings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class SQLServerConfigurationStatic : global::System.Configuration.ApplicationSettingsBase {
        
        private static SQLServerConfigurationStatic defaultInstance = ((SQLServerConfigurationStatic)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SQLServerConfigurationStatic())));
        
        public static SQLServerConfigurationStatic Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CodexDSUser")]
        public string CodexDS_User_Client_SQLUserName {
            get {
                return ((string)(this["CodexDS_User_Client_SQLUserName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CodexDS2007")]
        public string CodexDS_User_Client_SQLPassword {
            get {
                return ((string)(this["CodexDS_User_Client_SQLPassword"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CodexDSXUser")]
        public string CodexDS_XUser_Client_SQLUserName {
            get {
                return ((string)(this["CodexDS_XUser_Client_SQLUserName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("...your password....")]
        public string CodexDS_XUser_Client_SQLPassword {
            get {
                return ((string)(this["CodexDS_XUser_Client_SQLPassword"]));
            }
        }
    }
}
