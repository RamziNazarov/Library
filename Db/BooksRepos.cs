using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Library.Db
{
    public class BooksRepos
    {
        DataContext context {get;}
        IWebHostEnvironment invoriment {get;}
        public BooksRepos(DataContext _context)
        {
            context = _context;
        }
        public BooksRepos(DataContext _context,IWebHostEnvironment _invoriment)
        {
            context = _context;
            invoriment = _invoriment;
        }
        public List<Book> GetBookList()
        {
            return context.Books.ToList();
        }
        public void GetBookByYear(int? Year,ref List<Book> books)
        {
            if(books != null && Year >0)
            {
                books = books.Where(p=>p.PublishingYear == Year).ToList();
            }
        }

        public void GetBooksByGenre(string Genre,ref List<Book> books)
        {
            if(books != null && Genre != null)
            {
                books = books.Where(p=>p.Genre.Contains(Genre)).ToList();
            }
        }
        public void GetBooksByState(string State,ref List<Book> books)
        {
            if(books != null && State != "All")
            {
                books = books.Where(p => p.State == State).ToList();
            }
        }
        public void GetBooksByAuthorOrTitle(string AuthorOrTitle,ref List<Book> books)
        {
            if(books != null && AuthorOrTitle != null)
            {
                books = books.Where(p => p.Title.ToLower().Contains(AuthorOrTitle.ToLower()) || p.Author.ToLower().Contains(AuthorOrTitle.ToLower())).ToList();
            }
        }
        public Book GetBook(int SerNumb)
        {
            return context.Books.Find(SerNumb);
        }
        public void GetCountList(ref List<Book> books,ref List<int> countlist,List<Book> boklist)
        {
            int b = -1;
            for(int i =0 ; i < boklist.Count;i++)
            {
                if(boklist[i] != null)
                {
                    b++;
                    int a = 0;
                    countlist.Add(a);
                    books.Add(boklist[i]);
                    countlist[b]++;
                    boklist[i] = null;
                }
                else
                {
                    continue;
                }
                for(int j = i;j < boklist.Count;j++)
                {
                    if(boklist[j] != null)
                    {
                        if(books[b].Title == boklist[j].Title)
                        {
                            boklist[j] = null;
                            countlist[b]++;
                        }
                    }
                }
            }
        }
        public void ChangeBook(ref Book changingBook,string Title,string Author,string Genre,int Year,string Description,int UserId,IFormFile newfile)
        {
            if(newfile != null && (newfile.ContentType.ToLower() == "image/jpg" || newfile.ContentType.ToLower() == "image/jpeg" || newfile.ContentType.ToLower() == "image/png"))
            {
                changingBook.ImgPath = "/Images/" + newfile.FileName;
                if(System.IO.File.Exists(invoriment.WebRootPath + changingBook.ImgPath))
                {
                    System.IO.File.Delete(invoriment.WebRootPath + changingBook.ImgPath);
                }
                using(FileStream fileStream = new FileStream(invoriment.WebRootPath + "/Images/"+newfile.FileName,FileMode.Create))
                {
                    newfile.CopyTo(fileStream);
                }
            }
            changingBook.Title = (!string.IsNullOrEmpty(Title))?Title:changingBook.Title;
            changingBook.Author = (!string.IsNullOrEmpty(Author))?Author:changingBook.Author;
            changingBook.Genre = (!string.IsNullOrEmpty(Genre))?Genre:changingBook.Genre;
            if(changingBook.UserId != UserId && changingBook.UserId != 1 && UserId > 0)
            {
                changingBook.UserId = UserId;
                changingBook.State = (changingBook.State == "Free")?"Busy":"Free";
            }
            changingBook.Description = (!string.IsNullOrEmpty(Description))?Description:changingBook.Description;
            changingBook.PublishingYear = (Year > 0)?Year:changingBook.PublishingYear;
        }
        public void AddBook(string Title,string Author,string Genre,string Description,int Year,IFormFile uploadFile,int SerNumb)
        {
            if(uploadFile != null  && (uploadFile.ContentType.ToLower() == "image/jpg" || uploadFile.ContentType.ToLower() == "image/jpeg" || uploadFile.ContentType.ToLower() == "image/png"))
            {
                context.Books.Add(new Book{Title = Title,Author = Author,Genre = Genre,Description = Description,PublishingYear = Year,UserId = 1,State = "Free",ImgPath = "/Images/" + uploadFile.FileName,SerNumber = SerNumb});
                using (var fileStream = new FileStream(invoriment.WebRootPath + "/Images/" +uploadFile.FileName, FileMode.Create))
                {
                    uploadFile.CopyTo(fileStream);
                }
                context.SaveChanges();
            }
        }
        public void DeleteBook(int SerNumb)
        {
            context.Books.Remove(context.Books.Find(SerNumb));
            context.SaveChanges();
        }
        public List<Book> GetBooksByUserId(int Id)
        {
            return context.Books.Where(p =>p.UserId == Id).ToList();
        }
    }
}