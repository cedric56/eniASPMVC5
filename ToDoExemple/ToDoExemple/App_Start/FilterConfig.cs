using System.Web;
using System.Web.Mvc;
using ToDoExemple.Filters;

namespace ToDoExemple
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ToDoFilters());
        }
    }
}
