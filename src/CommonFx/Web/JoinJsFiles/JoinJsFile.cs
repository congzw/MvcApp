using System;
using System.Collections.Generic;
using System.Text;

namespace CommonFx.Web.JoinJsFiles
{
    public class JoinJsFile
    {
        public JoinJsFile(string saveVirtualPath)
        {
            if (string.IsNullOrWhiteSpace(saveVirtualPath))
            {
                throw new ArgumentNullException("saveVirtualPath");
            }
            SaveVirtualPath = saveVirtualPath;
            Entries = new Dictionary<string, JoinJsFileEntry>(StringComparer.OrdinalIgnoreCase);
        }

        public Dictionary<string, JoinJsFileEntry> Entries { get; set; }

        public JoinJsFile AddOrReplace(string uniqueName, string virutalPath, string desc = null)
        {
            if (!Entries.ContainsKey(uniqueName))
            {
                //add
                Entries[uniqueName] = new JoinJsFileEntry() { UniqueName = uniqueName, VirtualPath = virutalPath, Desc = desc };
                return this;
            }

            //update
            var requireJsConfigEntry = Entries[uniqueName];
            requireJsConfigEntry.UniqueName = uniqueName;
            requireJsConfigEntry.VirtualPath = virutalPath;
            requireJsConfigEntry.Desc = desc;
            return this;
        }

        public string SaveVirtualPath { get; set; }

        private string _joinJsContentCache = null;
        public void Init(bool hardRefresh = false)
        {
            if (string.IsNullOrWhiteSpace(SaveVirtualPath))
            {
                throw new InvalidOperationException("初始化前必须为JoinJsConfigVirtualPath指定一个有效的虚拟路径");
            }
            var savePath = FileServer.MapPath(SaveVirtualPath);
            var fileExists = FileServer.Exists(savePath);
            if (hardRefresh || !fileExists)
            {
                _joinJsContentCache = null;
            }
            
            if (_joinJsContentCache != null)
            {
                return;
            }
            
            if (Entries.Count == 0)
            {
                _joinJsContentCache = string.Empty;
            }
            else
            {
                var sb = new StringBuilder();
                foreach (var jsConfigEntry in Entries.Values)
                {
                    sb.AppendLine(string.Format("//config for {0}", jsConfigEntry.UniqueName));
                    var filePath = FileServer.MapPath(jsConfigEntry.VirtualPath);
                    var jsConfig = FileServer.ReadAllText(filePath);
                    sb.AppendLine(jsConfig.TrimEnd());
                    sb.AppendLine("");
                }
                _joinJsContentCache = sb.ToString();
            }
            
            if (fileExists)
            {
                var oldValue = FileServer.ReadAllText(savePath);
                var newHash = HashHelper.HashString(_joinJsContentCache);
                var oldHash = HashHelper.HashString(oldValue);
                if (newHash == oldHash)
                {
                    return;
                }
            }
            //save hash value
            FileServer.WriteAllText(savePath, _joinJsContentCache);
        }

        private IFileServer _fileServer;
        public IFileServer FileServer
        {
            get { return _fileServer ?? (_fileServer = Web.FileServer.Resolve()); }
            set { _fileServer = value; }
        }

        private IHashHelper _hashHelper;
        public IHashHelper HashHelper
        {
            get { return _hashHelper ?? (_hashHelper = CommonFx.HashHelper.Resolve()); }
            set { _hashHelper = value; }
        }
    }
}
