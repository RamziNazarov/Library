using System;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<Book> Books {get;set;}
        public DbSet<Role> Roles {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Arenda> Arendi {get;set;}
        public DbSet<Comment> Comments {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Default");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role(){Id = 1,RoleName = "Admin"},
                new Role(){Id = 2,RoleName = "User"}
            );
            builder.Entity<User>().HasData(
                new User(){Id = 1,RoleId = 1,FirstName="Admin",LastName = "Admin",Login="@dmin",Password="123.",Email="Admin",PhoneNumber=000000000},
                new User(){Id = 2, RoleId = 2,FirstName="Ramzi",LastName="Nazarov",Login="AB",Password="12345",BirthDate=Convert.ToDateTime("1998/07/25"),Email="Ramzi.13.09.18@gmail.com",PhoneNumber=937393959,MiddleName="Saidkhudzhaevich",ImgPath="~/Images/w.jpg"}
            );
            builder.Entity<Book>().HasData(
                new Book(){SerNumber = 15648749,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 15648233,Author="Автор 1",Title="Книга 1",Genre="Жанр",Description="Какая-та книга",DataIzdaniya = 1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 15654879,Author="Автор 2",Title="Книга 2",Genre="Жанр",Description="Какая-та книга",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 43151415,Author="Автор 3",Title="Книга 3",Genre="Жанр",Description="Какая-та книга",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 56547434,Author="Автор 4",Title="Книга 4",Genre="Жанр",Description="Какая-та книга",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 64134133,Author="Автор 5",Title="Книга 5",Genre="Жанр",Description="Какая-та книга",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 71436543,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 82342346,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 94425466,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 13505465,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 11124354,Author="Автор 6",Title="Книга 6",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Busy", UserId = 2,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 12123454,Author="Автор 7",Title="Книга 7",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Busy", UserId = 2,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 12135443,Author="Автор 8",Title="Книга 8",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Busy", UserId = 2,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 11234234,Author="Автор 9",Title="Книга 9",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Busy", UserId = 2,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 11234545,Author="Автор 10",Title="Книга 10",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=1943,State="Busy", UserId = 2,ImgPath="/Images/w.jpg"}
            );
        }
    }
}