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
                    PhoneNumber = table.Column<int>(maxLength: 9, nullable: false),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Author = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 10, nullable: false),
                    ImgPath = table.Column<string>(maxLength: 250, nullable: false),
                    Genre = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    PublishingYear = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TakenDate = table.Column<DateTime>(nullable: false),
                    BookSerNumb = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    State = table.Column<string>(maxLength: 15, nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    BooksSerNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Books_BooksSerNumber",
                        column: x => x.BooksSerNumber,
                        principalTable: "Books",
                        principalColumn: "SerNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_Users_UserId",
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
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Login", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Admin", "@dmin", "123.", 0, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName", "Login", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { 2, new DateTime(1998, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramzi", "Nazarov", "AB", "12345", 937393959, 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 15648749, "Антуан де Сент-Экзюпери", "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.", "Фантастика,Новелла", "/Images/w.jpg", 1943, "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 15648233, "Рей Брэдбери", "Мастер мирового масштаба, совмещающий в литературе несовместимое. Создатель таких ярчайших шедевров, как 'Марсианские хроники', '451° по Фаренгейту', 'Вино из одуванчиков' и так далее и так далее. Лауреат многочисленных премий. Это Рэй Брэдбери.", "Научная фантастика", "/Images/w165h247-c0721977.jpg", 1953, "Free", "451° по Фаренгейту", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 15654879, "Джордж Оруэлл", "Своеобразный антипод второй великой антиутопии XX века - 'О дивный новый мир' Олдоса Хаксли. Что, в сущности, страшнее: доведенное до абсурда 'общество отребления' - или доведенное до абсолюта 'общество идеи'?", "Классика,Научная фантастика,Педагогика и воспитание,Фэнтези,Художественная литература", "/Images/w165h247-ad0efbf7.jpg", 1949, "Free", "1984", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 43151415, "Маркус Зусак", "Январь 1939 года. Германия. Страна, затаившая дыхание. Никогда еще у смерти не было столько работы. А будет еще больше.", "Современная классика,Проза", "/Images/w165h247-4207373f.jpg", 2005, "Free", "Книжный вор", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 56547434, "Чак Паланик", "Это — самая потрясающая и самая скандальная книга 1990-х. Книга, в которой устами Чака Паланика заговорило не просто 'Поколение Икс', но — 'Поколение Икс' уже озлобленное, уже растерявшее свои последние иллюзии.", "Современная классика,Проза", "/Images/w165h247-cbe4c501.jpg", 1996, "Free", "Бойцовский клуб", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 15213749, "Антуан де Сент-Экзюпери", "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.", "Фантастика,Новелла", "/Images/w.jpg", 1943, "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 15632749, "Антуан де Сент-Экзюпери", "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.", "Фантастика,Новелла", "/Images/w.jpg", 1943, "Free", "Маленький принц", 1 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "SerNumber", "Author", "Description", "Genre", "ImgPath", "PublishingYear", "State", "Title", "UserId" },
                values: new object[] { 15433749, "Антуан де Сент-Экзюпери", "«Маленький принц» — аллегорическая повесть, наиболее известное произведение Антуана де Сент-Экзюпери. Рисунки в книге выполнены самим автором и не менее знамениты, чем сама книга.", "Фантастика,Новелла", "/Images/w.jpg", 1943, "Free", "Маленький принц", 1 });

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
                name: "IX_Rents_BooksSerNumber",
                table: "Rents",
                column: "BooksSerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
