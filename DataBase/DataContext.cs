using System;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<Book> Books {get;set;}
        public DbSet<Role> Roles {get;set;}
        public DbSet<User> Users {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Default");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role(){Id = 1,RoleName = "Admin"},
                new Role(){Id =2,RoleName = "User"}
            );
            builder.Entity<User>().HasData(
                new User(){Id = 1,RoleId = 1,FirstName="Admin",LastName = "Admin",Login="@dmin",Password="123."},
                new User(){Id = 2, RoleId = 2,FirstName="Ramzi",LastName="Nazarov",Login="AB",Password="12345",BirthDate=Convert.ToDateTime("1998/07/25")}
            );
            builder.Entity<Book>().HasData(
                new Book(){Id = 1,Author="Антуан де Сент-Экзюпери",Title="Маленький принц",Genre="Фантастика,Новелла",Description="Книга о мальчике с планеты B-612",DataIzdaniya=Convert.ToDateTime("1943/04/06"),State="Free"}
            );
        }
    }
}