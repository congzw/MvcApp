using System;
using System.Collections.Generic;

namespace CommonFx.Web.JoinJsFiles
{
    public class JoinJsFileRegistry
    {
        public JoinJsFileRegistry()
        {
            Groups = new Dictionary<string, JoinJsFile>(StringComparer.OrdinalIgnoreCase);
        }
        public IDictionary<string, JoinJsFile> Groups { get; set; }

        /// <summary>
        /// 如果不存在就创建，否则返回已有的实例
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public JoinJsFile CreateIf(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException("groupName");
            }
            if (Groups.ContainsKey(groupName))
            {
                return Groups[groupName];
            }
            Groups.Add(groupName, new JoinJsFile(groupName));
            return Groups[groupName];
        }
        
        /// <summary>
        /// 单例
        /// </summary>
        public static JoinJsFileRegistry Instance = new JoinJsFileRegistry();
    }
}