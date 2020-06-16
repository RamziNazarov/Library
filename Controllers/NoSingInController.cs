using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Db;
using System.Linq;

namespace Library.Controllers
{
    public class NoSingInController : Controller
    {
        DataContext context {get;}
        public NoSingInController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Books = context.Books.ToList();
            return View();
        }
    }
}