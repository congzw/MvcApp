using System.Web.Mvc;

namespace MvcApp.Web.Areas.Debug
{
    public class DebugAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Debug";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Debug_default",
                "Debug/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "MvcApp.Web.Areas.Debug.Controllers" }
            );
        }
    }
}