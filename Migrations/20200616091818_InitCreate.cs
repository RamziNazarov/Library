using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    ImgPath = table.Column<string>(maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Login = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    SerNumber = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 10, nullable: false),
                    ImgPath = table.Column<string>(maxLength: 250, nullable: false),
                    Genre = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    DataIzdaniya = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.SerNumber);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arendi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TakeDate = table.Column<DateTime>(nullable: false),
                    BookSerNumb = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    State = table.Column<string>(maxLength: 10, nullable: false),
                    VozDate = table.Column<DateTime>(nullable: false),
                    BooksSerNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arendi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arendi_Books_BooksSerNumber",
                        column: x => x.BooksSerNumber,
                        principalTable: "Books",
                        principalColumn: "SerNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Arendi_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookSerNumb = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(maxLength: 200, nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    BooksSerNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BooksSerNumber",
                        column: x => x.BooksSerNumber,
                        principalTable: "Books",
                        principalColumn: "SerNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "ImgPath", "LastName", "Login", "MiddleName", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Admin", null, "Admin", "@dmin", null, "123.", 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "ImgPath", "LastName", "Login", "MiddleName", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { 2, new DateTime(1998, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramzi.13.09.18@gmail.com", "Ramzi", "~/Images/w.jpg", "Nazarov", "AB", "Saidkhudzhaevich", "12345", 937393959, 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 15648749, "Антуан де Сент-Экзюпери", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 15648233, "Автор 1", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Какая-та книга", "Жанр", "~/Images/w.jpg", "Free", "Книга 1", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 15654879, "Автор 2", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Какая-та книга", "Жанр", "~/Images/w.jpg", "Free", "Книга 2", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 43151415, "Автор 3", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Какая-та книга", "Жанр", "~/Images/w.jpg", "Free", "Книга 3", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 56547434, "Автор 4", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Какая-та книга", "Жанр", "~/Images/w.jpg", "Free", "Книга 4", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 64134133, "Автор 5", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Какая-та книга", "Жанр", "~/Images/w.jpg", "Free", "Книга 5", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 71436543, "Антуан де Сент-Экзюпери", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 82342346, "Антуан де Сент-Экзюпери", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 94425466, "Антуан де Сент-Экзюпери", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 13505465, "Антуан де Сент-Экзюпери", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 11124354, "Автор 6", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Busy", "Книга 6", 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 12123454, "Автор 7", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Busy", "Книга 7", 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 12135443, "Автор 8", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Busy", "Книга 8", 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 11234234, "Автор 9", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Busy", "Книга 9", 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "DataIzdaniya", "Description", "Genre", "ImgPath", "State", "Title", "UserId" },
                values: new object[] { 11234545, "Автор 10", new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Книга о мальчике с планеты B-612", "Фантастика,Новелла", "~/Images/w.jpg", "Busy", "Книга 10", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Arendi_BooksSerNumber",
                table: "Arendi",
                column: "BooksSerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Arendi_UserId",
                table: "Arendi",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BooksSerNumber",
                table: "Comments",
                column: "BooksSerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arendi");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
