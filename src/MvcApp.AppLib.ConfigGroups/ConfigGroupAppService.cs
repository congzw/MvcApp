using System.Collections.Generic;
using System.Linq;
using CommonFx.ConfigGroups;

namespace MvcApp.AppLib.ConfigGroups
{
    public class ConfigGroupAppService
    {
        private readonly ConfigGroupRegistry _configGroupRegistry;
        public ConfigGroupAppService(ConfigGroupRegistry registry)
        {
            //todo di
            _configGroupRegistry = registry;
        }

        public IList<ConfigGroup> GetAllConfigGroups()
        {
            var configGroups = _configGroupRegistry.Groups.Values.ToList();
            return configGroups;
        }
    }
}
