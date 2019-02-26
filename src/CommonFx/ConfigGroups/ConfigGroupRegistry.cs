using System;
using System.Collections.Generic;

namespace CommonFx.ConfigGroups
{
    public class ConfigGroupRegistry
    {
        public ConfigGroupRegistry()
        {
            Groups = new Dictionary<string, ConfigGroup>(StringComparer.OrdinalIgnoreCase);
        }

        public IDictionary<string, ConfigGroup> Groups { get; set; }

        /// <summary>
        /// ��������ھʹ��������򷵻����е�ʵ��
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public ConfigGroup CreateIf(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException("groupName");
            }
            if (Groups.ContainsKey(groupName))
            {
                return Groups[groupName];
            }
            Groups.Add(groupName, new ConfigGroup(groupName));
            return Groups[groupName];
        }


        public static ConfigGroupRegistry Instance = new ConfigGroupRegistry();
    }
}