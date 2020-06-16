using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string MiddleName {get;set;}
        [StringLength(250)]
        public string ImgPath {get;set;}
        [Required]
        public int PhoneNumber {get;set;}
        [Required]
        [StringLength(200)]
        public string Email {get;set;}
        [Required]
        [StringLength(100)]
        public string Login { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public DateTime BirthDate {get;set;}

        public virtual Role Roles {get;set;}
        public virtual ICollection<Book> Books {get;set;}
        public virtual ICollection<Comment> Comments {get;set;}
        public virtual ICollection<Arenda> Arendi {get;set;}
    }
}