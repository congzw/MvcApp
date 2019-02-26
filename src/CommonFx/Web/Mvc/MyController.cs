using System;
using System.Web.Mvc;

namespace CommonFx.Web.Mvc
{
    public class MyController : Controller
    {
        public MyJsonResult<T> MyJson<T>(T model)
        {
            return this.Request.HttpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase)
                ? new MyJsonResult<T>() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet }
                : new MyJsonResult<T>() { Data = model };
        }
        
    }
}
