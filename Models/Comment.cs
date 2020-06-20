using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Comment
    {
        public int  Id {get;set;}
        [Required]
        public int BookSerNumb {get;set;}
        [Required]
        public int UserId {get;set;}
        [Required]
        [StringLength(200)]
        public string CommentText {get;set;}
        [Required]
        public DateTime CommentDate {get;set;}

        public virtual User Users {get;set;}
        public virtual Book Books{get;set;}
    }
}