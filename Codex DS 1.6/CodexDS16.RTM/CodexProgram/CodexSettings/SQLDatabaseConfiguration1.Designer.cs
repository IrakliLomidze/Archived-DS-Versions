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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
    internal sealed partial class SQLDatabaseConfiguration : global::System.Configuration.ApplicationSettingsBase {
        
        private static SQLDatabaseConfiguration defaultInstance = ((SQLDatabaseConfiguration)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SQLDatabaseConfiguration())));
        
        public static SQLDatabaseConfiguration Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SQLServer {
            get {
                return ((string)(this["SQLServer"]));
            }
            set {
                this["SQLServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SQLAuthMethod {
            get {
                return ((bool)(this["SQLAuthMethod"]));
            }
            set {
                this["SQLAuthMethod"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public uint SQLPort {
            get {
                return ((uint)(this["SQLPort"]));
            }
            set {
                this["SQLPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseFullTextSearch {
            get {
                return ((bool)(this["UseFullTextSearch"]));
            }
            set {
                this["UseFullTextSearch"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsFullText {
            get {
                return ((bool)(this["IsFullText"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int SQLServer_Type {
            get {
                return ((int)(this["SQLServer_Type"]));
            }
            set {
                this["SQLServer_Type"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AppUseFullTextSearch {
            get {
                return ((bool)(this["AppUseFullTextSearch"]));
            }
        }
    }
}
