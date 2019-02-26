using System.Web.Mvc;

// ReSharper disable once CheckNamespace
namespace MvcApp.Web.Controllers
{
    public class LoadTestController : Controller
    {
        public ActionResult Empty()
        {
            return View();
        }

        public ActionResult ReadDb()
        {
            return View();
        }

        public ActionResult Reset()
        {
            var loadTestHelper = LoadTestHelper.Instance;
            var visitCount = loadTestHelper.VisitCount;
            loadTestHelper.VisitCount = 0;
            TempData["Message"] = "Reset Count: " + visitCount + " To 0";
            return RedirectToAction("Empty");
        }
    }
}