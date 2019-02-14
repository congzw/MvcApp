using System.Web.Mvc;

namespace MvcApp.Web.Areas.Auths
{
    public class AuthsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Auths"; }
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