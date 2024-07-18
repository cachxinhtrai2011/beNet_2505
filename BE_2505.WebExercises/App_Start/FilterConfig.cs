using System.Web;
using System.Web.Mvc;

namespace BE_2505.WebExercises
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
