using System;
using System.Web;
using CommonFx;

namespace MvcApp.AppLib.Common
{
    public interface IApiPathHelper
    {
        string CreateMvcApi(string area, string controller, string action);
    }

    public class ApiPathHelper : IApiPathHelper
    {
        #region for di extensions

        private static Func<IApiPathHelper> _resolve = () => ResolveAsSingleton.Resolve<ApiPathHelper, IApiPathHelper>();
        public static Func<IApiPathHelper> Resolve
        {
            get { return _resolve; }
            set { _resolve = value; }
        }

        #endregion

        public string CreateMvcApi(string area, string controller, string action)
        {
            var virtualApi = string.Format("~/{0}/{1}/{2}", area, controller, action);
            var absoluteApi = VirtualPathUtility.ToAbsolute(virtualApi);
            return absoluteApi;
        }
    }
}