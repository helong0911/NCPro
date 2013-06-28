using System.Web;
using System.Web.Mvc;

namespace SvHoo.UI.Merchant
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}