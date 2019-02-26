using System.Text;

// ReSharper disable once CheckNamespace
namespace System.Web.WebPages
{
    public static class WebPageBaseExtensions
    {
        public static void SetValueFor<T>(this WebPageBase webPageBase, string name, T value)
        {
            var nameKey = name.ToLower();
            webPageBase.Context.Items[nameKey] = value;
        }

        public static T GetValueFor<T>(this WebPageBase webPageBase, string name, T defaultValue)
        {
            var nameKey = name.ToLower();
            if (webPageBase.Context.Items[nameKey] == null)
            {
                return defaultValue;
            }
            var result = (T)webPageBase.Context.Items[nameKey];
            return result;
        }

        /// <summary>
        /// 截取汉字
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int count, string append = "")
        {

            if (value == null) return string.Empty;

            var len = count * 2;
            int aequilateLength = 0, cutLength = 0;
            var encoding = Encoding.GetEncoding("gb2312");

            var cutStr = value;
            var strLength = cutStr.Length;
            byte[] bytes;
            for (int i = 0; i < strLength; i++)
            {
                bytes = encoding.GetBytes(cutStr.Substring(i, 1));
                if (bytes.Length >= 2)//不是英文
                    aequilateLength += 2;
                else
                    aequilateLength++;

                if (aequilateLength <= len) cutLength += 1;

                if (aequilateLength > len)
                    return cutStr.Substring(0, cutLength) + append;
            }
            return cutStr;
        }

        #region for angular

        public static void SetAngularSupport(this WebPageBase webPageBase, bool value)
        {
            webPageBase.SetValueFor("AngularSupport", value);
        }

        public static bool GetAngularSupport(this WebPageBase webPageBase, bool defaultValue = true)
        {
            return webPageBase.GetValueFor("AngularSupport", defaultValue);
        }

        #endregion

        #region for debug

        public static void SetDebugMode(this WebPageBase webPageBase, bool value)
        {
            webPageBase.SetValueFor("DebugMode", value);
        }

        public static bool GetDebugMode(this WebPageBase webPageBase)
        {
            //todo read from context
            return webPageBase.GetValueFor("DebugMode", true);
        }

        #endregion

        #region for layout

        public static void SetLayoutWithContainer(this WebPageBase webPageBase, bool value)
        {
            webPageBase.SetValueFor("LayoutWithContainer", value);
        }

        public static bool GetLayoutWithContainer(this WebPageBase webPageBase, bool defaultValue = true)
        {
            return webPageBase.GetValueFor("LayoutWithContainer", defaultValue);
        }

        #endregion

        #region for domain

        /// <summary>
        /// 截取组织名
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string TruncateOrgName(this string value, int count = 10, string append = "...")
        {
            return Truncate(value, count, append);
        }

        #endregion


        #region for layout

        public static void SetShowBreadcrumbs(this WebPageBase webPageBase, bool value)
        {
            webPageBase.SetValueFor("ShowBreadcrumbs", value);
        }

        public static bool GetShowBreadcrumbs(this WebPageBase webPageBase, bool defaultValue = true)
        {
            return webPageBase.GetValueFor("ShowBreadcrumbs", defaultValue);
        }

        #endregion
    }
}
