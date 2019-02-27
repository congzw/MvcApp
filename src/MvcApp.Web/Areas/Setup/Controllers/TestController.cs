using System.Web.Mvc;
using CommonFx.Web.Mvc;

namespace MvcApp.Web.Areas.Setup.Controllers
{
    public class TestController : MyController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Show(string view)
        {
            return View(view);
        }
    }
}
