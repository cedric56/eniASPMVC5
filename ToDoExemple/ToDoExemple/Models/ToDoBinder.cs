using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDoExemple.Models
{
    public class ToDoBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            
            return new ToDo()
            {
                ToDoId = int.Parse(request.Form["ToDoId"].ToString()),
                Titre = request.Form["Titre"].ToString(),
                Etat = bool.Parse(request.Form.GetValues("Etat")[0]),
                Creation = DateTime.Now,
                MiseAJour = DateTime.Now
            };
        }
    }
}