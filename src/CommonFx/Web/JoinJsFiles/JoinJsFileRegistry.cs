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
        /// ��������ھʹ��������򷵻����е�ʵ��
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
        /// ����
        /// </summary>
        public static JoinJsFileRegistry Instance = new JoinJsFileRegistry();
    }
}