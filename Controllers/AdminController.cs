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
            ViewBag.Books = context.Books.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Book(int Id)
        {
            ViewBag.User = context.Users.Find(1);
            Book book = context.Books.Find(Id);
            ViewBag.Book = book;
            ViewBag.Books = context.Books.Where(p=>p.Title == book.Title).ToList();
            ViewBag.Comments = context.Comments.Where(p=>p.BookSerNumb == Id).ToList();
            int id = context.Books.Find(Id).UserId;
            ViewBag.BookUser = context.Users.Find(id);
            return View();
        }
        [HttpPost]
        public IActionResult Book(int Id,string Title,string Author,string Genre,int Year,string Description,int UserId,IFormFile newfile)
        {
            var changingBook = context.Books.Find(Id);
            BooksRepos.ChangeBook(ref changingBook,Title,Author,Genre,Year,Description,UserId,newfile);
            context.SaveChanges();
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
            // ViewBag.Apps = context.Arendi.ToList();
            // var list = context.Arendi.ToList();
            // list[0].
            return View();
        }
    }
}