// Codex DS Customization models
// (C) Copyright by 2007-2018 by Georgian Microsystems
// Code Version 1.0
// Date: 2018 Aug 27

namespace ILG.Codex.CodexR4.JsonConfigurations.DisplayModel
{
    public class KeyWordsAttribute
    {
        public bool IsCustomized { get; set; }
        public string DisplayName { get; set; }
        public string DisplayNameShort { get; set; }


        public KeyWordsAttribute()
        {
            IsCustomized = false;
            DisplayName = "საკვანძო სიტყვები";
            DisplayNameShort = "საკვანძო სიტყვები";
        }
    }
}
