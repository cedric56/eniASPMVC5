using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoExemple.Validations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NombreCarMini : ValidationAttribute
    {
        public int Valeur { get; set; }

        public override bool IsValid(object titre)
        {
            if (titre == null || string.IsNullOrWhiteSpace(titre.ToString()))
                return false;

            return titre.ToString().Length >= Valeur;
        }
    }
}