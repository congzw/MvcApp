using System.Collections.Generic;
using System.Linq;
using CommonFx;
using CommonFx.ConfigGroups;
using CommonFx.Extensions;

namespace MvcApp.AppLib.ConfigGroups
{
    public class ConfigGroupAppService
    {
        private readonly ConfigGroupRegistry _configGroupRegistry;
        public ConfigGroupAppService(ConfigGroupRegistry registry)
        {
            _configGroupRegistry = registry;
        }

        public IList<ConfigGroup> GetAllConfigGroups()
        {
            var configGroups = _configGroupRegistry.Groups.Values.ToList();
            return configGroups;
        }

        public ConfigGroup GetConfigGroup(string configGroup)
        {
            var allConfigGroups = GetAllConfigGroups();
            var theOne = allConfigGroups.FirstOrDefault(x => x.GroupName.NbEquals(configGroup));
            return theOne;
        }

        public MessageResult AddOrUpdateConfigEntry(AddOrUpdateConfigEntryDto entry)
        {
            var messageResult = new MessageResult();
            if (entry == null)
            {
                messageResult.Message = "更新失败，数据不能为空";
                return messageResult;
            }

            var configGroup = GetConfigGroup(entry.ConfigGroup);
            if (configGroup == null)
            {
                messageResult.Message = string.Format("更新失败，没有找到配置组：[{0}]", entry.ConfigGroup);
                return messageResult;
            }

            configGroup.AddOrReplace(entry.Key, entry.Value, entry.Type, entry.Desc);

            messageResult.Message = "更新成功";
            messageResult.Success = true;
            return messageResult;
        }
    }
}
