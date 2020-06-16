﻿// <auto-generated />
using System;
using Library.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Library.Models.Arenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookSerNumb")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BooksSerNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<DateTime>("TakeDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("VozDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BooksSerNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Arendi");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("SerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataIzdaniya")
                        .HasColumnType("TEXT");

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
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 15648233,
                            Author = "Автор 1",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Какая-та книга",
                            Genre = "Жанр",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Книга 1",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 15654879,
                            Author = "Автор 2",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Какая-та книга",
                            Genre = "Жанр",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Книга 2",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 43151415,
                            Author = "Автор 3",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Какая-та книга",
                            Genre = "Жанр",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Книга 3",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 56547434,
                            Author = "Автор 4",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Какая-та книга",
                            Genre = "Жанр",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Книга 4",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 64134133,
                            Author = "Автор 5",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Какая-та книга",
                            Genre = "Жанр",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Книга 5",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 71436543,
                            Author = "Антуан де Сент-Экзюпери",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 82342346,
                            Author = "Антуан де Сент-Экзюпери",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 94425466,
                            Author = "Антуан де Сент-Экзюпери",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 13505465,
                            Author = "Антуан де Сент-Экзюпери",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Free",
                            Title = "Маленький принц",
                            UserId = 1
                        },
                        new
                        {
                            SerNumber = 11124354,
                            Author = "Автор 6",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Busy",
                            Title = "Книга 6",
                            UserId = 2
                        },
                        new
                        {
                            SerNumber = 12123454,
                            Author = "Автор 7",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Busy",
                            Title = "Книга 7",
                            UserId = 2
                        },
                        new
                        {
                            SerNumber = 12135443,
                            Author = "Автор 8",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Busy",
                            Title = "Книга 8",
                            UserId = 2
                        },
                        new
                        {
                            SerNumber = 11234234,
                            Author = "Автор 9",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Busy",
                            Title = "Книга 9",
                            UserId = 2
                        },
                        new
                        {
                            SerNumber = 11234545,
                            Author = "Автор 10",
                            DataIzdaniya = new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Книга о мальчике с планеты B-612",
                            Genre = "Фантастика,Новелла",
                            ImgPath = "~/Images/w.jpg",
                            State = "Busy",
                            Title = "Книга 10",
                            UserId = 2
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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("ImgPath")
                        .HasColumnType("TEXT")
                        .HasMaxLength(250);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

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
                            Email = "Admin",
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
                            Email = "Ramzi.13.09.18@gmail.com",
                            FirstName = "Ramzi",
                            ImgPath = "~/Images/w.jpg",
                            LastName = "Nazarov",
                            Login = "AB",
                            MiddleName = "Saidkhudzhaevich",
                            Password = "12345",
                            PhoneNumber = 937393959,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Library.Models.Arenda", b =>
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
