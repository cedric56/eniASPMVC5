using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoExemple.Filters;
using ToDoExemple.Models;

namespace ToDoExemple.Controllers
{
    public class WebApiController : ApiController
    {
        private IRepository _repository;

        public WebApiController()
        {
            _repository = new Repository();
        }

        [AllowCrossSite]
        public ToDo Get(int id)
        {
            //http://localhost:56844/api/webapi/1

            //utiliser fiddler pour executer la requete
            return _repository.GetToDo(id);
        }

        [AllowCrossSite]
        public string Post(int id)
        {
            //http://localhost:56844/api/webapi/1

            //utiliser fiddler pour executer la requete
            return "OK pour post";
        }
    }
}
