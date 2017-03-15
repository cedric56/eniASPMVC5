using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ToDoExemple.Models;

namespace ToDoExemple.Controllers
{
    [Authorize] //Signifie que pour toutes les actions de la classe il faut etre autorisé c'est à dire inscrit (sans Index avec AllowAnonymous)
    //[RoutePrefix("eni")]
    //[Route("{action=Index}")]
    public class ToDoController : Controller
    {
        private IRepository _repository;

        public ToDoController()
        {
            if (Properties.Settings.Default.Fake)
                _repository = new FakeRepository();
            else
                _repository = new Repository();
        }

        //static private List<Comment> MesPremiersCommentaires = new List<Comment>()
        //{
        //    new Comment() { Sujet = "Pain frais", Email = "boulanger@eni.fr", DateCreation = new DateTime(2016, 12, 13) },
        //    new Comment() { Sujet = "Pain bien cuit", Email = "patissier@eni.fr", DateCreation = new DateTime(2016, 12, 12) },            
        //};

        //static private List<ToDo> ToDoList = new List<ToDo>()
        //{
        //    new ToDo() { ToDoId = 1, Titre = "Acheter du pain", Etat = false, Commentaires = MesPremiersCommentaires },
        //    new ToDo() { ToDoId = 2, Titre = "Sortir le chien", Etat = true },
        //    new ToDo() { ToDoId = 3, Titre = "Prendre un rendez-vous chez le dentiste", Etat = false }
        //};

        // GET: ToDo
        [AllowAnonymous]//Tout le monde peut accéder à la page index sans etre inscrit
        public ActionResult Index()
        {
            //return View(ToDoList);

            var toDoList = _repository.GetToDoList();
            return View(toDoList);            
        }

        const string Administrateur = "Administrateur";
        const string UserName = "lb@eni.fr";

        [AllowAnonymous]
        public ActionResult CreateRole()
        {
            //Dans web.config
            //<roleManager enabled=true>

            if (!Roles.RoleExists(Administrateur))
                Roles.CreateRole(Administrateur);

            if (!Roles.IsUserInRole(UserName, Administrateur))
                Roles.AddUserToRole(UserName, Administrateur);

            ViewBag.Message = string.Format("{0} a le role {1}", UserName, Administrateur);
            return View();
        }

        [Authorize(Roles = Administrateur)]//On peut définir plusieurs roles à la suite
        public ActionResult Role()
        {
            return View();
        }

        public ActionResult Test()
        {
            throw new Exception("Test Exception");
        }

        /// <summary>
        /// Create est appellé lors du clic sur le lien de la page index
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Le HttpPost est appellé après la validation
        /// </summary>
        /// <param name="todoCreated"></param>
        /// <returns></returns>
        [HttpPost]        
        public ActionResult Create(ToDo todoCreated)
        {
            if (ModelState.IsValid)
            {
                //ToDoList.Add(todoCreated);
                _repository.AddToDo(todoCreated);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]//Par defaut        
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("index");

            var todo = _repository.GetToDo(id);// ToDoList.FirstOrDefault(t => t.ToDoId == id);
            if (todo == null)
                return RedirectToAction("Index");

            return View(todo);
        }

        [HttpPost]
        //C'est soit cette méthode soit l'autre en dessous (Version Sans Binding)
        public ActionResult Edit(ToDo todoUpdated)
        {
            var todo = _repository.GetToDo(todoUpdated.ToDoId);// ToDoList.FirstOrDefault(t => t.ToDoId == todoUpdated.ToDoId);
            if (todo == null)
                return RedirectToAction("Index");
  
            todo.Titre = todoUpdated.Titre;
            todo.Etat = todoUpdated.Etat;
            todo.Creation = todoUpdated.Creation;
            todo.MiseAJour = todoUpdated.MiseAJour;
            return View(todo);
        }

        //[HttpPost]        
        //public ActionResult Edit()
        //{
        //    //Vieille methode de l'asp sans avoir l'objet todo 
        //    //Request est utilisé pour recuperer les valeurs
        //    //Version sans binding
        //    var todoUpdated = new ToDo()
        //    {
        //        ToDoId = int.Parse(Request.Form["ToDoId"].ToString()),
        //        Titre = Request.Form["Titre"].ToString(),
        //        Etat = bool.Parse(Request.Form.GetValues("Etat")[0])
        //    };

        //    var todo = ToDoList.FirstOrDefault(t => t.ToDoId == todoUpdated.ToDoId);
        //    if (todo == null)
        //        return RedirectToAction("Index");

        //    todo.Titre = todoUpdated.Titre;
        //    todo.Etat = todoUpdated.Etat;
        //    return View(todo);
        //}

        
        public ActionResult Delete(int id = 0)
        {
            var todoDeleted = _repository.GetToDo(id);// ToDoList.FirstOrDefault(t => t.ToDoId == id);
            if (todoDeleted == null)
                return RedirectToAction("Index");

            return View(todoDeleted);
        }

        //[HttpPost]
        //public ActionResult Delete(decimal id = 0)
        //{
        //    var todoDeleted = ToDoList.FirstOrDefault(t => t.ToDoId == id);
        //    if (todoDeleted != null)
        //        ToDoList.Remove(todoDeleted);

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ActionName("Delete")]//Remplace la methode au dessus qui etait de la bidouille avec le decimal
        //Le nom de la méthode reste Delete
        public ActionResult ConfirmDelete(int id = 0)
        {
            _repository.DeleteToDo(id);

            //var todoDeleted = ToDoList.FirstOrDefault(t => t.ToDoId == id);
            //if (todoDeleted != null)
            //{
            //    //ToDoList.Remove(todoDeleted);
            //}

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id = 0)
        {
            var todoEdited = _repository.GetToDo(id);// ToDoList.FirstOrDefault(t => t.ToDoId == id);
            if (todoEdited == null)
                return RedirectToAction("Index");

            return View(todoEdited);
        }

        //public ActionResult Details(ToDo todoDetails)
        //{
        //    var todo = ToDoList.FirstOrDefault(t => t.ToDoId == todoDetails.ToDoId);
        //    if (todo == null)
        //        return RedirectToAction("Index");

        //    todo.Commentaires = todoDetails.Commentaires;
        //    return View(todo);
        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}