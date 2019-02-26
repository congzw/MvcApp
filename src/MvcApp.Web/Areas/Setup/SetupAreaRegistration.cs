using System.Web.Mvc;

namespace MvcApp.Web.Areas.Setup
{
    public class SetupAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Setup"; }
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