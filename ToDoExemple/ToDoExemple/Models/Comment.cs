using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoExemple.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Sujet { get; set; }

        [DisplayName("Date de création")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreation { get; set; }


        //[DataType(DataType.EmailAddress)] //Solution 1
        [EmailAddress] //Solution 2
        //[RegularExpression(@".+\@.+\..+")] //Solution 3
        public string Email { get; set; }
    }
}