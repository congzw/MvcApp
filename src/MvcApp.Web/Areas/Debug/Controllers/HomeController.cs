using System.Web.Mvc;

namespace MvcApp.Web.Areas.Debug.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
