using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Library.Db;
using Library.Models;

namespace Library.Controllers
{
    public class SingInController : Controller
    {
        DataContext context {get;}
        public SingInController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index(int? Id)
        {
            if(Id != null)
                ViewBag.User = context.Users.Find(Id);
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Login, string Password)
        {
            var lis = context.Roles.ToList();
            var list1 = context.Books.ToList();
            var list = context.Users.ToList();
            User FindedUser = null;
            for(int i = 0; i < list.Count;i++)
            {
                if(list[i].Login == Login && list[i].Password == Password){
                FindedUser = list[i];
                }
            }
            if(FindedUser != null)
                return RedirectToAction("Index",new{Id = FindedUser.Id});
            return View();            
        }
        [HttpGet]
        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registr(string FirstName,string LastName,string Login,string Password,string ConfirmPassword,DateTime? BirthDate)
        {
            //доделать проверку на то есть ли такой юзер
            User user = new User();
            user.LastName = LastName;
            user.FirstName = FirstName;
            user.RoleId = 2;
            user.Login=Login;
            user.Password = Password;
            if (BirthDate!=null)
            {
                user.BirthDate = Convert.ToDateTime(BirthDate);
            }
            context.Users.Add(user);
            return RedirectToAction("Index");
        }
    }
}