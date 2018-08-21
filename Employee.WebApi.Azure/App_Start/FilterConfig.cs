using System.Web;
using System.Web.Mvc;

namespace Employee.WebApi.Azure
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
