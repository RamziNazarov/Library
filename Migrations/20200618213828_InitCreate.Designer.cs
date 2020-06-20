﻿// <auto-generated />
using System;
using Library.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200618213828_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("SerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<int>("PublishingYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SerNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            SerNumber = 15648749,
                            Author = "Антуан де Сент-Экзюпери",
                            Description = "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "/Images/w.jpg",
                            PublishingYear = 1943,
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 15648233,
                            Author = "Рей Брэдбери",
                            Description = "Мастер мирового масштаба, совмещающий в литературе несовместимое. Создатель таких ярчайших шедевров, как 'Марсианские хроники', '451° по Фаренгейту', 'Вино из одуванчиков' и так далее и так далее. Лауреат многочисленных премий. Это Рэй Брэдбери.",
                            Genre = "Научная фантастика",
                            ImgPath = "/Images/w165h247-c0721977.jpg",
                            PublishingYear = 1953,
                            State = "Free",
                            Title = "451° по Фаренгейту",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 15654879,
                            Author = "Джордж Оруэлл",
                            Description = "Своеобразный антипод второй великой антиутопии XX века - 'О дивный новый мир' Олдоса Хаксли. Что, в сущности, страшнее: доведенное до абсурда 'общество отребления' - или доведенное до абсолюта 'общество идеи'?",
                            Genre = "Классика,Научная фантастика,Педагогика и воспитание,Фэнтези,Художественная литература",
                            ImgPath = "/Images/w165h247-ad0efbf7.jpg",
                            PublishingYear = 1949,
                            State = "Free",
                            Title = "1984",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 43151415,
                            Author = "Маркус Зусак",
                            Description = "Январь 1939 года. Германия. Страна, затаившая дыхание. Никогда еще у смерти не было столько работы. А будет еще больше.",
                            Genre = "Современная классика,Проза",
                            ImgPath = "/Images/w165h247-4207373f.jpg",
                            PublishingYear = 2005,
                            State = "Free",
                            Title = "Книжный вор",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 56547434,
                            Author = "Чак Паланик",
                            Description = "Это — самая потрясающая и самая скандальная книга 1990-х. Книга, в которой устами Чака Паланика заговорило не просто 'Поколение Икс', но — 'Поколение Икс' уже озлобленное, уже растерявшее свои последние иллюзии.",
                            Genre = "Современная классика,Проза",
                            ImgPath = "/Images/w165h247-cbe4c501.jpg",
                            PublishingYear = 1996,
                            State = "Free",
                            Title = "Бойцовский клуб",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 15213749,
                            Author = "Антуан де Сент-Экзюпери",
                            Description = "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "/Images/w.jpg",
                            PublishingYear = 1943,
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 15632749,
                            Author = "Антуан де Сент-Экзюпери",
                            Description = "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "/Images/w.jpg",
                            PublishingYear = 1943,
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 15433749,
                            Author = "Антуан де Сент-Экзюпери",
                            Description = "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "/Images/w.jpg",
                            PublishingYear = 1943,
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Library.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookSerNumb")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BooksSerNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BooksSerNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Library.Models.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookSerNumb")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BooksSerNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(15);

                    b.Property<DateTime>("TakenDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BooksSerNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Library.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER")
                        .HasMaxLength(9);

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Admin",
                            LastName = "Admin",
                            Login = "@dmin",
                            Password = "123.",
                            PhoneNumber = 0,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1998, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ramzi",
                            LastName = "Nazarov",
                            Login = "AB",
                            Password = "12345",
                            PhoneNumber = 937393959,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.User", "Users")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.Comment", b =>
                {
                    b.HasOne("Library.Models.Book", "Books")
                        .WithMany("Comments")
                        .HasForeignKey("BooksSerNumber");

                    b.HasOne("Library.Models.User", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.Rent", b =>
                {
                    b.HasOne("Library.Models.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BooksSerNumber");

                    b.HasOne("Library.Models.User", "Users")
                        .WithMany("Arendi")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.HasOne("Library.Models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
