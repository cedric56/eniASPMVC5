using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ToDoExemple.Controllers
{
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController result = null;
            
            switch(controllerName.ToUpper())
            {
                case "CLIENTWEBAPI":
                    result = new ClientWebApiController();
                    break;

                case "ACCOUNT":
                    result = new AccountController();
                    break;
                case "MANAGE":
                    result = new ManageController();
                    break;
                case "TODO":
                    result = new ToDoController();
                    break;
                case "AJAX":
                    result = new AjaxController();
                    break;
                case "CACHE":
                    result = new CacheController();
                    break;
                case "STATE":
                    result = new StateController();
                    break;
                case "HOME":
                    result = new HomeController();
                    break;
                case "PIRATE":
                    result = new PirateController();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            //On a rien a faire on laisse vide
        }
    }
}