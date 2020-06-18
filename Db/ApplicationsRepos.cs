using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.Db
{
    public class ApplicationsRepos
    {
        DataContext context {get;}
        public ApplicationsRepos(DataContext _context)
        {
            context = _context;
        }
        public List<Arenda> GetApplications()
        {
            return context.Arendi.ToList();
        }
        public List<Arenda> GetAppByUserId(int Id)
        {
            return context.Arendi.Where(p =>p.UserId == Id).ToList();
        }
        public List<Arenda> GetAppByBookSerNumb(int Id)
        {
            return context.Arendi.Where(p =>p.BookSerNumb == Id).ToList();
        }
        public void ChangeApp(int Id,string State)
        {
            var App = context.Arendi.Find(Id);
            App.State = State;
            context.SaveChanges();
        }
        public void ReturnBook(int Id,string State)
        {
            var App = context.Arendi.Find(Id);
            App.State = State;
            App.VozDate = DateTime.Now;
            context.SaveChanges();
        }
        public void AddApplication(int BookSerNumb,int UserId)
        {
            context.Arendi.Add(new Arenda{BookSerNumb = BookSerNumb,UserId = UserId,State = "В ожидании",TakeDate = DateTime.Now});
            context.SaveChanges();
        }
    }
}