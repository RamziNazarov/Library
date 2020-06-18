using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Db;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller 
    {
        static User user;
        DataContext context {get;}
        BooksRepos BooksRepos {get;}
        public UserController(DataContext _context)
        {
            context = _context;
            BooksRepos = new BooksRepos(context);
        }
        public IActionResult Sing(int Id)
        {
            user = context.Users.Find(Id);
            return RedirectToAction("Index");
            // return RedirectToAction("Book",new {Id = 94425466});
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await Task.Run(()=>{
                var books = new List<Book>();
                var countlist = new List<int>();
                var boklist = BooksRepos.GetBookList();
                BooksRepos.GetCountList(ref books,ref countlist,boklist);
                ViewBag.CountList = countlist;
                ViewBag.Books = books;
                ViewBag.User = user;
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string Genre, string DataIzdaniya,string State,string AuthorAndTitle)
        {
            await Task.Run(()=>{
                var boklist = new List<Book>();
                var countlist = new List<int>();
                var books = BooksRepos.GetBookList();
                if(Genre == null)
                {
                    BooksRepos.GetBooksByAuthorOrTitle(AuthorAndTitle,ref books);
                }
                else
                {
                    BooksRepos.GetBooksByGenre(Genre,ref books);
                    BooksRepos.GetBooksByState(State,ref books);
                    BooksRepos.GetBookByYear(DataIzdaniya,ref books);
                }
                BooksRepos.GetCountList(ref boklist,ref countlist,books);
                ViewBag.CountList = countlist;
                ViewBag.Books = boklist;
                ViewBag.User = user;
            });
            return View();
        }
        [HttpGet]
        public IActionResult Book(int Id)
        {
            ViewBag.User = user;
            ViewBag.Book = context.Books.Find(Id);
            
            Book book = context.Books.Find(Id);
            ViewBag.Book = book;
            ViewBag.Books = context.Books.Where(p=>p.Title == book.Title).ToList();
            ViewBag.Comments = context.Comments.Where(p=>p.BookSerNumb == Id).ToList();
            int id = context.Books.Find(Id).UserId;
            ViewBag.BookUser = context.Users.Find(id);
            ViewBag.Arenda = context.Arendi.Where(p=>p.BookSerNumb == book.SerNumber && p.UserId == id).FirstOrDefault();
            return View();
        }
        [HttpGet]
        public IActionResult AddApplication(int Id)
        {
            context.Arendi.Add(new Arenda(){UserId = user.Id,BookSerNumb = Id,State = "Waitin1g",TakeDate = DateTime.Now,VozDate = DateTime.Now.AddMonths(1)});
            context.SaveChanges();
            return RedirectToAction("Applications");
        }
        [HttpGet]
        public IActionResult Applications()
        {
            ViewBag.Applications = context.Arendi.Where(p => p.UserId == user.Id).ToList();
            return View();
        }
    }
}