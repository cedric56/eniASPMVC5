using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoExemple.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() :
            //base("ToDoDB") //1 ere solution pour fixer le nom (créer un fichier mdf)
            base("name=ToDoConnectionString") //2 ere solution défini dans webConfig (créer une base de données)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}