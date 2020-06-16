using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Arenda
    {
        public int Id {get;set;}
        [Required]
        public DateTime TakeDate {get;set;}
        [Required]
        public int BookSerNumb {get;set;}
        [Required]
        public int UserId {get;set;}
        [Required]
        [StringLength(10)]
        public string State {get;set;}
        [Required]
        public DateTime VozDate{ get;set;}

        public virtual Book Books {get;set;}
        public virtual User Users{get;set;}
    }
}