using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoExemple.Controllers
{
    public class PirateController : Controller
    {        
        public ActionResult Forgery()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Forgery(string nom)
        {
            return View();
        }
    }
}