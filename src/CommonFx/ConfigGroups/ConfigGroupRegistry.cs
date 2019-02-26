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
        /// 如果不存在就创建，否则返回已有的实例
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