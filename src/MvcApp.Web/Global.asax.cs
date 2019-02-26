using System;
using System.Web;
using CommonFx.ConfigGroups;
using MvcApp.AppLib;

namespace MvcApp.Web
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            MvcConfig.Init();
            //todo init by config
            var configGroup = ConfigGroupRegistry.Instance.Default();
            configGroup.AddOrReplace("Debug", "true", "调试状态");
            configGroup.AddOrReplace("DebugLevel", "1", "调试级别");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}