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
        /// <summary>
        /// Вход и определение поля user для дальнейшей работы
        /// </summary>
        /// <param name="Id">Для нахождения нужнего user-a</param>
        /// <returns>Перенаправляет нас на окно с книгами</returns>
        public IActionResult Sing(int Id)
        {
            user = context.Users.Find(Id);
            return RedirectToAction("Index");
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
        public async Task<IActionResult> Index(string Genre, int PYear,string State,string AuthorAndTitle)
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
                    BooksRepos.GetBooksByGenre(Genre,ref books);
                    BooksRepos.GetBooksByState(State,ref books);
                    BooksRepos.GetBookByYear(PYear,ref books);
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
            ViewBag.Rent = context.Rents.Where(p =>p.BookSerNumb == Id && p.State != "Закрыто").FirstOrDefault();
            ViewBag.ApplicationDate = context.Rents.Where(p=>p.BookSerNumb == book.SerNumber && p.UserId == id).Select(p =>p.TakenDate).FirstOrDefault();
            return View();
        }
        [HttpGet]
        public IActionResult AddApplication(int Id)
        {
            context.Rents.Add(new Rent(){UserId = user.Id,BookSerNumb = Id,State = "В ожидании",TakenDate = DateTime.Now});
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
        [HttpGet]
        public IActionResult MyBooks()
        {
            ViewBag.Books = context.Books.Where(p =>p.UserId == user.Id).ToList();
            ViewBag.User = user;
            return View();
        }
        [HttpGet]
        public IActionResult Settings()
        {
            ViewBag.User = user;
            ViewBag.Error = null;
            return View();
        }
        [HttpPost]
        public IActionResult Settings(string FirstName,string LastName,string Login,string Password,int PhoneNumber)
        {
            var userlist = context.Users.Where(p=>p.Login.ToLower() != user.Login.ToLower()).ToList();
            foreach(var item in userlist)
            {
                if(item.Login.ToLower() == Login.ToLower())
                {
                    ViewBag.Error = "Логин занят, выберите другой";
                    ViewBag.User = user;
                    return View();
                }
            }
            var thisUser = context.Users.Find(user.Id);
            thisUser.LastName = LastName;
            thisUser.FirstName = FirstName;
            if(PhoneNumber.ToString().Length == 9 && PhoneNumber !< 0)
                thisUser.PhoneNumber = PhoneNumber;
            if(Login.ToLower() != thisUser.Login.ToLower() || Password.ToLower() != thisUser.Password.ToLower())
            {
            thisUser.Login = Login;
            thisUser.Password = Password;
            context.SaveChanges();
            return RedirectToAction("LogIn","NoSingIn");
            }
            thisUser.Login = Login;
            thisUser.Password = Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteUser()
        {
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("LogIn","NoSingIn");
        }
    }
}