using System.Collections.Generic;
using System.Linq;
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

        public ConfigGroup GetAllConfigGroup(string configGroup)
        {
            var allConfigGroups = GetAllConfigGroups();
            var theOne = allConfigGroups.FirstOrDefault(x => x.GroupName.NbEquals(configGroup));
            return theOne;
        }
    }
}
