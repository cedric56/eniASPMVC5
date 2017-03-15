using System;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using ToDoExemple.Models;

namespace ToDoExemple.Controllers
{
    public class CacheController : Controller
    {
        private IRepository _repository = new Repository();
        private static int _compteur = 1;

        [OutputCache(Duration = 6)]
        public ActionResult Index()
        {
            ViewBag.Message = "Heure actuelle : " + DateTime.Now.ToLongTimeString();

            return View();
        }


        /// <summary>
        /// Pour appeler ma méthode on utilise l'url avec ?param1
        /// http://localhost:56844/Cache/Index2/?param1=1
        /// </summary>
        /// <param name="param1"></param>
        /// <returns></returns>
        [OutputCache(Duration = 6, VaryByParam = "param1", VaryByCustom = "Browser")]
        //VaryByParam = Un cache par valeur de param1
        //VaryByCustom = "Browser" = Un cache par navigateur
        public ActionResult Index2(int param1)
        {            
            //ViewBag est un objet dynamique c'est pour ca qu'on n'a pas l'intellissense
            //et qu'on peut definir une propriété en dynamic
            ViewBag.Param1 = param1;
            ViewBag.Message = "Heure actuelle : " + DateTime.Now.ToLongTimeString() + " cache n° " + _compteur;

            _compteur++;
            return View();
        }

        public ActionResult DataCache()
        {
            //Cache coté client
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);


            //Cache coté serveur
            MemoryCache.Default.AddOrGetExisting(
                "todos", _repository.GetToDoList(), DateTime.Now.AddSeconds(60));

            var todos = MemoryCache.Default.Get("todos");

            return View(todos);
        }

        public ActionResult ObjectCache()
        {
            //Voir l'ajout dans global.asax
            var val = HttpContext.Cache["MonPC"];
            if (val == null)
                ViewBag.Message1 = "Le cache a disparu";
            else
                ViewBag.Message1 = val;

            val = HttpContext.Cache["MaVoiture"];
            if (val == null)
                ViewBag.Message2 = "Le cache a disparu";
            else
                ViewBag.Message2 = val;

            return View();
        }

        public ActionResult CacheDependency()
        {
            //voir global.asax            
            var content = HttpContext.Cache["fichierText"];            
            if (content == null)
            {
                //le cache est supprimé
                //si le fichier est modifié ou sinon au bout de 1 minute
                var virtualFile = "/fichier.txt";
                var absoluteFile = Server.MapPath(virtualFile);
                content = System.IO.File.ReadAllText(absoluteFile);

                HttpContext.Cache.Insert(
                    "fichierText",
                    content,
                    new CacheDependency(absoluteFile),
                    DateTime.Now.AddMinutes(60),
                    TimeSpan.Zero,
                    System.Web.Caching.CacheItemPriority.Default,
                    null);

                ViewBag.Message = string.Format("Le cache a été detruit {0}", content);
            }
            else
            {
                ViewBag.Message = content;
            }

            
            return View();
        }
    }
}