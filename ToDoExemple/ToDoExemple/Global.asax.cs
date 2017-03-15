using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ToDoExemple.Controllers;
using ToDoExemple.Models;

namespace ToDoExemple
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApi
            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Ajout du binder propre à todo
            //ModelBinders.Binders.Add(typeof(ToDo), new ToDoBinder());

            //Ajout du controller redefini
            ControllerBuilder.Current.SetControllerFactory(new MyControllerFactory());

            Application["Application"] = "valeur";
            Application["Compteur"] = 0;

            //Fais disparaitre la valeur dans le cache au bout de 20 secondes
            //il n'est plus affiché en rafraichissant
            HttpContext.Current.Cache.Insert("MonPC", "DELL M4800", null, DateTime.Now.AddSeconds(20), Cache.NoSlidingExpiration);

            //Disparait aau bout de 20 secondes si pas acceder entre temps
            HttpContext.Current.Cache.Insert("MaVoiture", "Peugeot", null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(20));

            //CacheDependency
            var virtualFile = "/fichier.txt";
            var absoluteFile = Server.MapPath(virtualFile);
            var contenu = System.IO.File.ReadAllText(absoluteFile);
            
            HttpContext.Current.Cache.Insert(
                "fichierText", 
                contenu,
                new CacheDependency(absoluteFile),
                DateTime.Now.AddMinutes(60),
                TimeSpan.Zero,
                CacheItemPriority.Default,
                null);

          
        }

        protected void Application_BeginRequest(object source, EventArgs e)
        {
            string culture = Request.UserLanguages == null ? null : Request.UserLanguages[0].Split(';')[0];
                //.FirstOrDefault(l => l == "es-ES");
            if (culture == null)
                culture = "es-ES";

            Thread.CurrentThread.CurrentUICulture =
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        }

        protected void Session_Start()
        {
            int i = (int)Application["Compteur"];
            i++;
            Application["Compteur"] = i;
        }

        //Pas fiable on ne s'est pas quand cela arrive
        protected void Session_End()
        {            
            int i = (int)Application["Compteur"];
            i--;
            Application["Compteur"] = i;
        }
    }
}
