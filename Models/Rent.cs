using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Rent
    {
        public int Id {get;set;}
        [Required]
        public DateTime TakenDate {get;set;}
        [Required]
        public int BookSerNumb {get;set;}
        [Required]
        public int UserId {get;set;}
        [Required]
        [StringLength(15)]
        public string State {get;set;}
        public DateTime ReturnDate{ get;set;}

        public virtual Book Books {get;set;}
        public virtual User Users{get;set;}
    }
}