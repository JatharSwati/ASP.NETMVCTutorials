using System.Web;
using System.Web.Mvc;

namespace Adding_Remember_Me_Functionality
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
