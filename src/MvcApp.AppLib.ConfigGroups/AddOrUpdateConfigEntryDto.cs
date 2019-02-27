using CommonFx.ConfigGroups;

namespace MvcApp.AppLib.ConfigGroups
{
    public class AddOrUpdateConfigEntryDto
    {
        public string ConfigGroup { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Desc { get; set; }
        public ConfigEntryType Type { get; set; }
    }
}