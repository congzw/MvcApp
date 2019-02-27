using System;
using System.Collections.Generic;

namespace CommonFx.ConfigGroups
{
    public class ConfigGroup
    {
        public ConfigGroup(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException("groupName");
            }
            GroupName = groupName;
            Entries = new Dictionary<string, ConfigEntry>(StringComparer.OrdinalIgnoreCase);
        }
    
        public string GroupName { get; set; }
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

        public string TryGetValue(string key, string defaultValue = null)
        {
            ConfigEntry result;
            var tryGetValue = Entries.TryGetValue(key, out result);
            return !tryGetValue ? defaultValue : result.Value;
        }

        public ConfigGroup AddOrReplaceAsJson(string key, object value, string desc = null)
        {
            var jsonHelper = JsonHelper.Resolve();
            var json = jsonHelper.Serialize(value);
            return AddOrReplace(key, json, desc);
        }
        public T TryGetValueAs<T>(string key, T defaultValue = default(T))
        {
            var tryGetValue = TryGetValue(key);
            if (tryGetValue == null)
            {
                return defaultValue;
            }
            var jsonHelper = JsonHelper.Resolve();
            return jsonHelper.Deserialize<T>(tryGetValue);
        }
    }
}
