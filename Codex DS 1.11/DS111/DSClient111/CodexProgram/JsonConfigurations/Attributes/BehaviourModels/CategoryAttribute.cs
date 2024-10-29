// Codex DS Customization models
// (C) Copyright by 2007-2022 by Georgian Microsystems
// Code Version 1.0
// Date: 2018 Aug 27


namespace ILG.DS.Configurations.JsonConfigurations.Models
{
    public class CategoryAttribute
    {
        public bool UseAsMandatory { get; set; }

        public CategoryAttribute()
        {
            UseAsMandatory = true;
        }
    }
}
