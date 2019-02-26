// ReSharper disable once CheckNamespace
namespace MvcApp.Web.Controllers
{
    public class LoadTestHelper
    {
        public int VisitCount { get; set; }

        public static LoadTestHelper Instance = new LoadTestHelper();
    }
}