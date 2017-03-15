using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_First
{
    class Program
    {
        static void Main(string[] args)
        {
            ToDoDataBaseEntities context = new ToDoDataBaseEntities();

            var list = context.ToDoes.Select(t => new { id = t.ToDoId, libelle = t.Titre }).ToList();
            foreach(var obj in list)
            {
                Console.WriteLine(obj);
            }
            Console.Read();
        }
    }
}
