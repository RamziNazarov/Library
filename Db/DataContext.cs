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
        public DbSet<Rent> Rents {get;set;}
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
                new User(){Id = 1,RoleId = 1,FirstName="Admin",LastName = "Admin",Login="@dmin",Password="123.",PhoneNumber=000000000},
                new User(){Id = 2, RoleId = 2,FirstName="Ramzi",LastName="Nazarov",Login="AB",Password="12345",BirthDate=Convert.ToDateTime("1998/07/25"),PhoneNumber=937393959}
            );
            builder.Entity<Book>().HasData(
                new Book(){SerNumber = 15648749,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",PublishingYear=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 15648233,Author="Рей Брэдбери",Title="451° по Фаренгейту",Genre="Научная фантастика",Description="Мастер мирового масштаба, совмещающий в литературе несовместимое. Создатель таких ярчайших шедевров, как 'Марсианские хроники', '451° по Фаренгейту', 'Вино из одуванчиков' и так далее и так далее. Лауреат многочисленных премий. Это Рэй Брэдбери.",PublishingYear = 1953,State="Free", UserId = 1,ImgPath="/Images/w165h247-c0721977.jpg"},
                new Book(){SerNumber = 15654879,Author="Джордж Оруэлл",Title="1984",Genre="Классика,Научная фантастика,Педагогика и воспитание,Фэнтези,Художественная литература",Description="Своеобразный антипод второй великой антиутопии XX века - 'О дивный новый мир' Олдоса Хаксли. Что, в сущности, страшнее: доведенное до абсурда 'общество отребления' - или доведенное до абсолюта 'общество идеи'?",PublishingYear=1949,State="Free", UserId = 1,ImgPath="/Images/w165h247-ad0efbf7.jpg"},
                new Book(){SerNumber = 43151415,Author="Маркус Зусак",Title="Книжный вор",Genre="Современная классика,Проза",Description="Январь 1939 года. Германия. Страна, затаившая дыхание. Никогда еще у смерти не было столько работы. А будет еще больше.",PublishingYear=2005,State="Free", UserId = 1,ImgPath="/Images/w165h247-4207373f.jpg"},
                new Book(){SerNumber = 56547434,Author="Чак Паланик",Title="Бойцовский клуб",Genre="Современная классика,Проза",Description="Это — самая потрясающая и самая скандальная книга 1990-х. Книга, в которой устами Чака Паланика заговорило не просто 'Поколение Икс', но — 'Поколение Икс' уже озлобленное, уже растерявшее свои последние иллюзии.",PublishingYear=1996,State="Free", UserId = 1,ImgPath="/Images/w165h247-cbe4c501.jpg"},
                new Book(){SerNumber = 15213749,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",PublishingYear=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 15632749,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",PublishingYear=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"},
                new Book(){SerNumber = 15433749,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",PublishingYear=1943,State="Free", UserId = 1,ImgPath="/Images/w.jpg"}
            );
        }
    }
}