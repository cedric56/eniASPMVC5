using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoExemple.Models;

namespace ToDoExemple.Controllers
{
    public class ClientWebApiController : Controller
    {
        // GET: ClientWebApi
        public ActionResult Index()
        {
            WebClient wClient = new WebClient();
            string url = "http://localhost:56844/api/webapi/3";
            string todoStr = wClient.DownloadString(url);

            ToDo todo = System.Web.Helpers.Json.Decode<ToDo>(todoStr);

            return View(todo);
        }

        public ActionResult ClientJs()
        {
            return View();
        }
    }
}