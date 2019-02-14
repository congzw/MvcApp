using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApp.Web
{
    public class MvcConfig
    {
        public static void Init()
        {
            RegisterRoutes(RouteTable.Routes);
            RegisterGlobalFilters(GlobalFilters.Filters);
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default_Root",
                url: "",
                defaults: new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                name: "Default_Common",
                url: "Common/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new MyHandleErrorAttribute());
        }
    }
}
