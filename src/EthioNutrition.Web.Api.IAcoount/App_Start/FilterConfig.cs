using System.Web;
using System.Web.Mvc;

namespace EthioNutrition.Web.Api.IAcoount
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
