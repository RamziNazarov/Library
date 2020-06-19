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
        public async Task<IActionResult> Index(string Genre, int DataIzdaniya,string State,string AuthorAndTitle)
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
            Book book = context.Books.Find(Id);
            ViewBag.Book = book;
            ViewBag.Books = context.Books.Where(p=>p.Title == book.Title).ToList();
            ViewBag.Comments = context.Comments.Where(p=>p.BookSerNumb == Id).ToList();
            int id = context.Books.Find(Id).UserId;
            ViewBag.BookUser = context.Users.Find(id);
            ViewBag.Users = context.Users.ToList();
            ViewBag.ApplicationDate = context.Rents.Where(p=>p.BookSerNumb == book.SerNumber && p.UserId == id).Select(p =>p.TakenDate).FirstOrDefault();
            return View();
        }
        [HttpGet]
        public IActionResult AddApplication(int Id)
        {
            context.Rents.Add(new Rent(){UserId = user.Id,BookSerNumb = Id,State = "Waitin1g",TakenDate = DateTime.Now,ReturnDate = DateTime.Now.AddMonths(1)});
            context.SaveChanges();
            return RedirectToAction("Applications");
        }
        [HttpGet]
        public IActionResult Applications()
        {
            ViewBag.Books = context.Books.ToList();
            ViewBag.Applications = context.Rents.Where(p => p.UserId == user.Id).ToList();
            ViewBag.User = user;
            return View();
        }
        [HttpPost]
        public IActionResult Applications(string State)
        {
            ViewBag.Books = context.Books.ToList();
            if(State != "Все")
            ViewBag.Applications = context.Rents.Where(p => p.UserId == user.Id && p.State == State).ToList();
            else
                ViewBag.Applications = context.Rents.Where(p =>p.UserId == user.Id).ToList();
            ViewBag.User = user;
            return View();
        }
        [HttpGet]
        public IActionResult ReturnBook(int Id)
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ChangeComment(int SerNumb,int Id,string CommentText)
        {
            var comment = context.Comments.Find(Id);
            comment.CommentDate = DateTime.Now;
            comment.CommentText = CommentText;
            context.SaveChanges();
            return RedirectToAction("Book",new {Id = SerNumb});
        }
        [HttpPost]
        public IActionResult AddComment(int SerNumb,string CommentText)
        {
            context.Comments.Add(new Comment{CommentDate = DateTime.Now,CommentText = CommentText,UserId = user.Id,BookSerNumb = SerNumb});
            context.SaveChanges();
            return RedirectToAction("Book",new {Id = SerNumb});
        }
        [HttpGet]
        public IActionResult DeleteComment(int Id)
        {
            context.Comments.Remove(context.Comments.Find(Id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}