using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int SerNumber { get; set; }
        [Required(ErrorMessage = "Title column can not be empty")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author column can not be empty")]
        [StringLength(50)]
        public string Author { get; set; }
        [Required(ErrorMessage = "State column can not be empty")]
        [StringLength(10)]
        public string State { get; set; }
        [Required]
        [StringLength(250)]
        public string ImgPath {get;set;}
        [Required]
        [StringLength(100)]
        public string Genre { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public int DataIzdaniya {get;set;}
        [Required]
        public int UserId {get;set;}
        
        public virtual ICollection<Comment> Comments{get;set;}
        public virtual User Users {get;set;}
    }
}