//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase_First
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToDo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToDo()
        {
            this.Comments = new HashSet<Comment>();
        }
    
        public int ToDoId { get; set; }
        public string Titre { get; set; }
        public bool Etat { get; set; }
        public string Description { get; set; }
        public System.DateTime Creation { get; set; }
        public System.DateTime MiseAJour { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}