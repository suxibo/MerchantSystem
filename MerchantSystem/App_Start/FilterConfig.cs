using System.Web;
using System.Web.Mvc;
using MerchantSystem.Filters;

namespace MerchantSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ValidateLoginAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
