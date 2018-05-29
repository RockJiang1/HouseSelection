using System.Web;
using System.Web.Mvc;

namespace HouseSelection.FrontEndAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
