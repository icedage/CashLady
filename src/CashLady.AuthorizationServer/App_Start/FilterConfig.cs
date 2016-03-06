using System.Web;
using System.Web.Mvc;

namespace CashLady.AuthorizationServer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
