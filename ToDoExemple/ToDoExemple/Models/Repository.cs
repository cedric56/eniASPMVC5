using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoExemple.Models
{
    public class Repository : IRepository
    {
        private ToDoContext _context;

        public Repository()
        {
            _context = new ToDoContext();
        }

        public void DeleteToDo(int id)
        {
            var todo = _context.ToDos.FirstOrDefault(t => t.ToDoId == id);
            if (todo != null)
            {
                _context.ToDos.Remove(todo);
                _context.SaveChanges();//Pour mettre à jour la base de données
            }
        }

        public ToDo GetToDo(int id)
        {
            return _context.ToDos.FirstOrDefault(t => t.ToDoId == id);
        }

        public void AddToDo(ToDo todoCreated)
        {
            if (todoCreated != null)
            {
                _context.ToDos.Add(todoCreated);
                _context.SaveChanges();//Pour mettre à jour la base de données
            }
        }

        public ICollection<ToDo> GetToDoList()
        {
            return _context.ToDos.ToList();
        }

        public void EditTodo(ToDo toDoEdited)
        {
            _context.Entry(toDoEdited).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }


    public class FakeRepository : IRepository
    {
        public void AddToDo(ToDo todo)
        {
            
        }

        public void DeleteToDo(int id)
        {
            
        }

        public ToDo GetToDo(int id)
        {
            return null;
        }

        public ICollection<ToDo> GetToDoList()
        {
            List<Comment> MesPremiersCommentaires = new List<Comment>()
            {
                new Comment() { Sujet = "Pain frais", Email = "boulanger@eni.fr", DateCreation = new DateTime(2016, 12, 13) },
                new Comment() { Sujet = "Pain bien cuit", Email = "patissier@eni.fr", DateCreation = new DateTime(2016, 12, 12) },
            };

            List<ToDo> ToDoList = new List<ToDo>()
            {
                new ToDo() { ToDoId = 1, Titre = "Acheter du pain", Etat = false, Commentaires = MesPremiersCommentaires },
                new ToDo() { ToDoId = 2, Titre = "Sortir le chien", Etat = true },
                new ToDo() { ToDoId = 3, Titre = "Prendre un rendez-vous chez le dentiste", Etat = false }
            };
            return ToDoList;
        }
    }

    public interface IRepository
    {
        void DeleteToDo(int id);
        ToDo GetToDo(int id);
        ICollection<ToDo> GetToDoList();
        void AddToDo(ToDo todo);
    }
}