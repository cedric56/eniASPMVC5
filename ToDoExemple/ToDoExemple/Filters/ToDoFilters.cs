using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoExemple.Filters
{
    public class ToDoFilters : HandleErrorAttribute, IActionFilter, IResultFilter, IAuthorizationFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {

        }

        public override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.ExceptionHandled)
            //{
            //    return;
            //}

            ////filterContext.Controller.TempData
            //filterContext.Result = new ViewResult
            //{
            //    ViewName = "~/Views/Shared/Error.cshtml"
            //};
            //filterContext.ExceptionHandled = true;

            //base.OnException(filterContext);
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }
    }
}