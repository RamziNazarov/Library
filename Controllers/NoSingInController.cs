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
        public NoSingInController(DataContext _context)
        {
            context = _context;
            BooksRepos = new BooksRepos(context);
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
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Genre,int PYear,string State,string AuthorAndTitle)
        {
            await Task.Run(()=>{
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
        public async Task<IActionResult> LogIn(string Login,string Password)
        {
            var UserList = await context.Users.ToListAsync();
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
        public async Task<IActionResult> Registr(string FirstName,string LastName,string MiddleName,int PhoneNumber,string Login,string Password,string ConfirmPassword,DateTime BirthDate)
        {
            var userlist = await context.Users.ToListAsync();
            foreach(var item in userlist)
            {
                if(item.Login.ToLower() == Login.ToLower())
                    return BadRequest("Пользователь с таким логином существует");
            }
            await context.Users.AddAsync(new Models.User(){RoleId = 2,FirstName = FirstName,LastName = LastName,PhoneNumber = PhoneNumber,Login = Login,Password = Password,BirthDate = BirthDate});
            await context.SaveChangesAsync();
            return RedirectToAction("LogIn");
        }

        [HttpGet]
        public async Task<IActionResult> Book(int Id)
        {
            Book book = await context.Books.FindAsync(Id);
            ViewBag.Book = book;
            ViewBag.Books = await context.Books.Where(p=>p.Title == book.Title).ToListAsync();
            ViewBag.Comments = await context.Comments.Where(p=>p.BookSerNumb == Id).ToListAsync();
            int id = context.Books.Find(Id).UserId;
            ViewBag.BookUser = await context.Users.FindAsync(id);
            ViewBag.Users = await context.Users.ToListAsync();
            ViewBag.Rent = await context.Rents.Where(p=>p.BookSerNumb == book.SerNumber && p.UserId == id).FirstOrDefaultAsync();
            return View();
        }
        [HttpPost]
        public IActionResult Book(string SerNumb)
        {
            return RedirectToAction("Book",new {Id = int.Parse(SerNumb)});
        }
    }
}