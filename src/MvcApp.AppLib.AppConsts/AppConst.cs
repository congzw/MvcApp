using System.Web;
using CommonFx;
using CommonFx.ConfigGroups;

namespace MvcApp.AppLib
{
    public class AppConst
    {
        public string RootPath { get; set; }
        public string ContentPath { get; set; }
        public string BasicPath { get; set; }
        public string AcePath { get; set; }
        public string UnifyPath { get; set; }

        private static string GetPath(string path)
        {
            var absolutePath = VirtualPathUtility.ToAbsolute(path);
            return absolutePath;
        }

        public static AppConst Create(string rootPath)
        {
            var appConst = new AppConst();
            appConst.RootPath = GetPath("~/");
            appConst.ContentPath = GetPath("~/Content/");
            appConst.BasicPath = GetPath("~/Content/libs/basic/");
            appConst.AcePath = GetPath("~/Content/libs/ace/");
            appConst.UnifyPath = GetPath("~/Content/libs/unify/");
            return appConst;
        }

        private static string AppConstKey = "AppConst";
        public static AppConst GetAppConst()
        {
            var configGroup = ConfigGroupRegistry.Instance.Default();
            var appConst = configGroup.TryGetValueAs<AppConst>(AppConstKey, null);
            if (appConst != null)
            {
                return appConst;
            }
            appConst = Create("~/");
            configGroup.AddOrReplaceAsJson(AppConstKey, appConst, "Js初始化全局变量");
            return appConst;
        }
    }
}
