using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToDoExemple.Validations;

namespace ToDoExemple.Models
{
    public class ToDo
    {
        //Pour EntityFramework Id est nécessaire
        public int ToDoId { get; set; }
        //ou
        //[Key]
        //public int Cle { get; set; }

        [Required]
        [NombreCarMini(Valeur = 8)]
        //ou
        //[MinLength(8)]
        public string Titre { get; set; }
        public bool Etat { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Date de création")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Creation { get; set; }

        [DisplayName("Date de mise à jour")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MiseAJour { get; set; }
        public virtual ICollection<Comment> Commentaires { get; set; }
    }
}