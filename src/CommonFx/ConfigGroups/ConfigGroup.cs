using System;
using System.Collections.Generic;

namespace CommonFx.ConfigGroups
{
    public class ConfigGroup
    {
        public ConfigGroup(string configName)
        {
            if (string.IsNullOrWhiteSpace(configName))
            {
                throw new ArgumentNullException("configName");
            }
            ConfigName = configName;
            Entries = new Dictionary<string, ConfigEntry>(StringComparer.OrdinalIgnoreCase);
        }
    
        public string ConfigName { get; set; }
        public IDictionary<string, ConfigEntry> Entries { get; set; }

        public ConfigGroup AddOrReplace(string key, string value, string desc = null)
        {
            if (!Entries.ContainsKey(key))
            {
                //add
                Entries[key] = ConfigEntry.Create(key, value, desc);
                return this;
            }
            //update
            ConfigEntry.Reset(Entries[key], key, value, desc);
            return this;
        }
    }
}
