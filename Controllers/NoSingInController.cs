using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Db;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class NoSingInController : Controller
    {
        DataContext context {get;}
        BooksRepos BooksRepos {get;}
        
        IWebHostEnvironment _appEnvironment;
        public NoSingInController(DataContext _context, IWebHostEnvironment inv)
        {
            context = _context;
            BooksRepos = new BooksRepos(context);
            _appEnvironment = inv;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            context.Comments.Add(new Comment(){BookSerNumb = 15648749,CommentDate=DateTime.Now,CommentText="Nice bookNice bookNice bookNice bookNice bookNice bookNice bookNice bookNice bookNice bookNice bookNice bookNice bookNice bookNice book",UserId=6});
            context.SaveChanges();
            await Task.Run(()=>{
                var books = new List<Book>();
                var countlist = new List<int>();
                var boklist = BooksRepos.GetBookList();
                BooksRepos.GetCountList(ref books,ref countlist,boklist);
                ViewBag.CountList = countlist;
                ViewBag.Books = books;
                ViewBag.Comments = context.Comments.ToList();
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
                
            });
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            ViewBag.Find = null;
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string Login,string Password)
        {
            var UserList = context.Users.ToList();
            for(int i = 0; i < UserList.Count;i++)
            {
                if(UserList[i].Login.ToLower() == Login.ToLower() && UserList[i].Password == Password)
                {
                    if(UserList[i].RoleId != 1)
                        return RedirectToAction("Sing","User",new {Id = UserList[i].Id});
                    else
                        return RedirectToAction("Index","Admin");
                }
            }
            ViewBag.Find = "NF";
            return View();
        }

        [HttpGet]
        public IActionResult Registr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registr(string FirstName,string LastName,string MiddleName,int PhoneNumber,string Email,string Login,string Password,string ConfirmPassword,DateTime BirthDate,IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Images/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
            context.Users.Add(new Models.User(){RoleId = 2, ImgPath = path,FirstName = FirstName,LastName = LastName,MiddleName = MiddleName,PhoneNumber = PhoneNumber,Email = Email,Login = Login,Password = Password,BirthDate = BirthDate});
            context.SaveChanges();
            }
            else
            {
                
            context.Users.Add(new Models.User(){RoleId = 2,FirstName = FirstName,LastName = LastName,MiddleName = MiddleName,PhoneNumber = PhoneNumber,Email = Email,Login = Login,Password = Password,BirthDate = BirthDate});
            context.SaveChanges();
            }
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public IActionResult Book(int Id)
        {
            Book book = context.Books.Find(Id);
            ViewBag.Book = book;
            ViewBag.Books = context.Books.Where(p=>p.Title == book.Title).ToList();
            ViewBag.Comments = context.Comments.Where(p=>p.BookSerNumb == Id).ToList();
            int id = context.Books.Find(Id).UserId;
            ViewBag.BookUser = context.Users.Find(id);
            ViewBag.Arenda = context.Arendi.Where(p=>p.BookSerNumb == book.SerNumber && p.UserId == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public IActionResult Book(string SerNumb)
        {
            Book book = context.Books.Find(int.Parse(SerNumb));
            ViewBag.Book = book;
            ViewBag.Books = context.Books.Where(p=>p.Title == book.Title).ToList();
            ViewBag.Comments = context.Comments.Where(p=>p.BookSerNumb == int.Parse(SerNumb)).ToList();
            int id = context.Books.Find(int.Parse(SerNumb)).UserId;
            ViewBag.BookUser = context.Users.Find(id);
            return View();
        }
    }
}