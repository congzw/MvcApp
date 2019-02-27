using System;

namespace CommonFx
{
    public interface IDateHelper
    {
        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        DateTime Now();
    }

    public class DateHelper : IDateHelper
    {
        #region for di extensions

        private static Func<IDateHelper> _resolve = () => ResolveAsSingleton.Resolve<DateHelper, IDateHelper>();
        public static Func<IDateHelper> Resolve
        {
            get { return _resolve; }
            set { _resolve = value; }
        }

        #endregion

        public DateTime Now()
        {
            return DateTime.Now;
        }
        
        #region for simple use

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetNow()
        {
            return Resolve().Now();
        }

        #endregion
    }
}
