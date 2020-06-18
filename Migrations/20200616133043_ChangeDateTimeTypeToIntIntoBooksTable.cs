using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class ChangeDateTimeTypeToIntIntoBooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DataIzdaniya",
                table: "Books",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 11124354,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 11234234,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 11234545,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 12123454,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 12135443,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 13505465,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 15648233,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 15648749,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 15654879,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 43151415,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 56547434,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 64134133,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 71436543,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 82342346,
                column: "DataIzdaniya",
                value: 1943);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 94425466,
                column: "DataIzdaniya",
                value: 1943);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataIzdaniya",
                table: "Books",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 11124354,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 11234234,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 11234545,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 12123454,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 12135443,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 13505465,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 15648233,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 15648749,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 15654879,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 43151415,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 56547434,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 64134133,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 71436543,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 82342346,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "SerNumber",
                keyValue: 94425466,
                column: "DataIzdaniya",
                value: new DateTime(1943, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
