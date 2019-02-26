using System.Web.Mvc;

namespace MvcApp.Web.Areas.Debug
{
    public class DebugAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Debug"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                AreaName + "_default",
                AreaName + "/{controller}/{action}",
                new { area = AreaName },
                new[] { GetType().Namespace + ".Controllers" });
        }
    }
}