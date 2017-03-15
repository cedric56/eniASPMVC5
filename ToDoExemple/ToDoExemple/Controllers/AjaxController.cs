using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoExemple.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContenuAjax()
        {
            return Content("Mise à jour à " + DateTime.Now.ToLongTimeString());
        }

        public ActionResult Helper()
        {
            return View();
        }

        public ActionResult VuePartielle()
        {
            return PartialView("_AjaxView");
        }
    }
}