using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library.Db;
using Library.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AdminController : Controller 
    {
        DataContext context {get;}
        BooksRepos BooksRepos {get;}
        public AdminController(DataContext _context, IWebHostEnvironment _invoriment)
        {
            context = _context;
            BooksRepos = new BooksRepos(_context,_invoriment);
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.User = context.Users.Find(1);
            var books = new List<Book>();
            var countlist = new List<int>();
            var boklist = BooksRepos.GetBookList();
            BooksRepos.GetCountList(ref books,ref countlist,boklist);
            ViewBag.Books = books;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Genre,int PYear,string State,string AuthorAndTitle)
        {
            ViewBag.User = context.Users.Find(1);
            var boklist = new List<Book>();
                var countlist = new List<int>();
                var books = BooksRepos.GetBookList();
                if(State == null)
                {
                    BooksRepos.GetBooksByAuthorOrTitle(AuthorAndTitle,ref books);
                }
                else
                {
                    BooksRepos.GetBooksByState(State,ref books);
                    BooksRepos.GetBooksByGenre(Genre,ref books);
                    BooksRepos.GetBookByYear(PYear,ref books);
                }
                BooksRepos.GetCountList(ref boklist,ref countlist,books);
                ViewBag.Books = boklist;
            return View();
        }
        [HttpGet]
        public IActionResult Book(int Id)
        {
            ViewBag.User = context.Users.Find(1);
            Book book = context.Books.Find(Id);
            ViewBag.Book = book;
            List<Comment> comments = new List<Comment>();
            var books = context.Books.Where(p=>p.Title == book.Title).ToList();
            for(int i =0; i < books.Count;i++)
            {
                comments.AddRange(context.Comments.Where(p =>p.BookSerNumb == books[i].SerNumber).ToList());
            }
            ViewBag.Books = books; 
            ViewBag.Comments = comments;
            int id = context.Books.Find(Id).UserId;
            ViewBag.BookUser = context.Users.Find(id);
            ViewBag.Users = context.Users.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Book(int Id,string Title,string Author,string Genre,int Year,string Description,IFormFile newfile)
        {
            var changingBook = context.Books.Find(Id);
            var boklist = context.Books.Where(p =>p.Title == changingBook.Title).ToList();
            for(int i = 0; i < boklist.Count;i++)
            {
                changingBook = context.Books.Find(boklist[i].SerNumber);
                BooksRepos.ChangeBook(ref changingBook,Title,Author,Genre,Year,Description,newfile);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteBook(int Id)
        {
            BooksRepos.DeleteBook(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.User = context.Users.Find(1);
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(string Title,string Author,string Genre,string Description,int Year,IFormFile uploadFile,int SerNumb)
        {
            if(uploadFile != null && ((uploadFile.ContentType.ToLower() == "image/jpg" || uploadFile.ContentType.ToLower() == "image/jpeg" || uploadFile.ContentType.ToLower() == "image/png")) && SerNumb >=0 && Year > 0)
            {
                BooksRepos.AddBook(Title,Author,Genre,Description,Year,uploadFile,SerNumb);
                return RedirectToAction("Index");
            }
            return BadRequest("Заполните поля верно");
        }
        [HttpGet]
        public IActionResult Applications()
        {
            ViewBag.User = context.Users.Find(1);
            ViewBag.Books = context.Books.ToList();
            ViewBag.Users = context.Users.Where(p =>p.RoleId !=1).ToList();
            ViewBag.Rents = context.Rents.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Applications(string State)
        {
            ViewBag.User = context.Users.Find(1);
            if(State != "Все")
                ViewBag.Rents = context.Rents.Where(p =>p.State == State).ToList();
            else
                ViewBag.Rents = context.Rents.ToList();
            ViewBag.Users = context.Users.Where(p =>p.RoleId !=1).ToList();
            ViewBag.Books = context.Books.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Users(int Id)
        {
            ViewBag.User = context.Users.Find(1);
            if(Id <=0)
                ViewBag.Users = context.Users.Where(p =>p.RoleId != 1).ToList();
            else
                ViewBag.Users = context.Users.Where(p =>p.RoleId != 1 && p.Id == Id).ToList();
            ViewBag.Books = context.Books.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult AddBookToUser(int Id)
        {
            var rent = context.Rents.Find(Id);
            rent.State = "Одобрено";
            rent.TakenDate = DateTime.Now;
            context.SaveChanges();
            var book = context.Books.Find(rent.BookSerNumb);
            book.UserId = rent.UserId;
            book.State = "Busy";
            context.SaveChanges();
            return RedirectToAction("Applications");
        }
        [HttpGet]
        public IActionResult ReturnBook(int Id)
        {
            var rent = context.Rents.Find(Id);
            rent.ReturnDate = DateTime.Now;
            rent.State = "Закрыто";
            context.SaveChanges();
            var book = context.Books.Find(rent.BookSerNumb);
            book.State = "Free";
            book.UserId = 1;
            context.SaveChanges();
            return RedirectToAction("Applications");
        }
        [HttpGet]
        public IActionResult Otkaz(int Id)
        {
            var rent = context.Rents.Find(Id);
            rent.ReturnDate = DateTime.Now;
            rent.State = "Закрыто";
            context.SaveChanges();
            return RedirectToAction("Applications");
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