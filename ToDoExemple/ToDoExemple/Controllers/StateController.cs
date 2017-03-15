using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoExemple.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {
            //Défini dans le global.asax
            //HttpContext.Application["Compteur"] = 0;

            //Application = Pour tous les clients 
            ViewBag.Application = HttpContext.Application["Application"];
            ViewBag.Compteur = HttpContext.Application["Compteur"];

            //Pour la session de chaque client
            ViewBag.Session = HttpContext.Session.SessionID;
            

            return View();
        }
    }
}