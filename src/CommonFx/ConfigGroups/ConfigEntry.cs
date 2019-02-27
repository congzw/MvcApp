using System;

namespace CommonFx.ConfigGroups
{
    public class ConfigEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Desc { get; set; }
        public ConfigEntryType Type { get; set; }
        
        public static ConfigEntry Create(string key, string value, string desc, ConfigEntryType type)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }
            return new ConfigEntry(){Key = key, Value = value, Desc = desc};
        }

        public static void Reset(ConfigEntry entry, string key, string value, string desc, ConfigEntryType type)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }
            entry.Key = key;
            entry.Value = value;
            entry.Desc = desc;
        }
    }

    public enum ConfigEntryType
    {
        String = 0,
        Bool = 1,
        Int =2,
        Float = 3,
        Datetime = 4,
        Guid = 5,
        Json = 6
    }
}
