using System;
using System.Linq;
using Library.Db;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        DataContext context {get;}
        public AdminController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Books()
        {
            ViewBag.Books = context.Books.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Books(string Title)
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        Book book {get;}
        [HttpPost]
        public IActionResult AddBook(string Author, string Description,string Title, DateTime DataIzdaniya, string Genre,string State, int UserId)
        {
            context.Books.Add(new Book{Author = Author,Title = Title,DataIzdaniya = DataIzdaniya,Genre = Genre,Description = Description,State = State,UserId = 1});
            context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult EditBook(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        [HttpPost]
        public IActionResult EditBook(int Id,string Author, string Description,string Title,string Genre,DateTime DataIzdaniya,string State,int UserId)
        {
            var findedBook = context.Books.Find(Id);
            if(findedBook != null)
            {
                findedBook.Author = Author;
                findedBook.DataIzdaniya = DataIzdaniya;
                findedBook.Description = Description;
                findedBook.Genre = Genre;
                findedBook.State = State;
                findedBook.Title = Title;
                findedBook.UserId = UserId;
            }
            return View();
        }
    }
}