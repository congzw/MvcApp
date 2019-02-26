using System.Web;
using System.Web.Mvc;

namespace CommonFx.Web.Mvc
{
    public static class JsonExtensions
    {
        public static IHtmlString ToJsonRaw(this object value, bool indented = false)
        {
            return new MvcHtmlString(JsonHelper.Resolve().Serialize(value, indented));
        }

        public static IHtmlString ToJsonRaw<T>(this T value, bool indented = false)
        {
            return new MvcHtmlString(JsonHelper.Resolve().Serialize(value, indented));
        }

        public static string ToJson(this object value, bool indented = false)
        {
            return JsonHelper.Resolve().Serialize(value, indented);
        }

        public static string ToJson<T>(this T value, bool indented = false)
        {
            return JsonHelper.Resolve().Serialize(value, indented);
        }
    }
}
