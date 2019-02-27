namespace MvcApp.AppLib.Common
{
    public class LayoutHelper
    {
        public LayoutHelper()
        {
            BasicLayout = "~/Views/Shared/_Basic/_Layout.cshtml";
            AceLayout = "~/Views/Shared/_Ace/_AceLayout.cshtml";
            UnifyLayout = "~/Views/Shared/_Unify/_UnifyLayout.cshtml";
        }

        public string BasicLayout { get; set; }
        public string AceLayout { get; set; }
        public string UnifyLayout { get; set; }


        public static LayoutHelper Intance = new LayoutHelper();
    }
}
