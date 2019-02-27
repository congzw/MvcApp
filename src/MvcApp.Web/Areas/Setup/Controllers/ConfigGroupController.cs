using System.Web.Mvc;
using CommonFx.ConfigGroups;
using CommonFx.Web.Mvc;
using MvcApp.AppLib.ConfigGroups;

namespace MvcApp.Web.Areas.Setup.Controllers
{
    public class ConfigGroupController : MyController
    {
        private readonly ConfigGroupAppService _configGroupAppService;

        public ConfigGroupController()
        {
            //todo di
            _configGroupAppService = new ConfigGroupAppService(ConfigGroupRegistry.Instance);
        }

        public ActionResult Index()
        {
            var allConfigGroups = _configGroupAppService.GetAllConfigGroups();
            ViewBag.ConfigGroups = allConfigGroups;
            return View();
        }

        public ActionResult Edit(string groupName)
        {
            var allConfigGroup = _configGroupAppService.GetAllConfigGroup(groupName);
            return View(allConfigGroup);
        }
    }
}
