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
        public List<Rent> GetApplications()
        {
            return context.Rents.ToList();
        }
        public List<Rent> GetAppByUserId(int Id)
        {
            return context.Rents.Where(p =>p.UserId == Id).ToList();
        }
        public List<Rent> GetAppByBookSerNumb(int Id)
        {
            return context.Rents.Where(p =>p.BookSerNumb == Id).ToList();
        }
        public void ChangeApp(int Id,string State)
        {
            var App = context.Rents.Find(Id);
            App.State = State;
            context.SaveChanges();
        }
        public void ReturnBook(int Id,string State)
        {
            var App = context.Rents.Find(Id);
            App.State = State;
            App.ReturnDate = DateTime.Now;
            context.SaveChanges();
        }
        public void AddApplication(int BookSerNumb,int UserId)
        {
            context.Rents.Add(new Rent{BookSerNumb = BookSerNumb,UserId = UserId,State = "В ожидании",TakenDate = DateTime.Now});
            context.SaveChanges();
        }
    }
}