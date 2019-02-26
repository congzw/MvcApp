using System;

namespace CommonFx.ConfigGroups
{
    public class ConfigEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Desc { get; set; }
        
        public static ConfigEntry Create(string key, string value, string desc)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }
            return new ConfigEntry(){Key = key, Value = value, Desc = desc};
        }

        public static void Reset(ConfigEntry entry, string key, string value, string desc)
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
}
