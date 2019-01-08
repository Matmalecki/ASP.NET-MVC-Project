using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet.Data.Migrations
{
    public partial class Populate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "ID", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1899, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ernest", "Hemingway" },
                    { 2, new DateTime(1902, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John", "Steinbeck" },
                    { 3, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "sking@mail.com", "Stephen", "King" },
                    { 4, new DateTime(1913, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Albert", "Camus" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "ID", "AuthorID", "Genre", "Isbn", "Title", "YearOfRelease" },
                values: new object[,]
                {
                    { 2, 1, "Drama", "0-9631-9574-3", "A Farewell To Arms", 1929 },
                    { 5, 1, "Drama", "0-8886-5105-8", "For Whom The Bell Tolls ", 1940 },
                    { 1, 2, "Drama", "0-7832-3901-7", "East of Eden", 1952 },
                    { 3, 3, "Horror", "0-8400-7082-9", "It", 1980 },
                    { 4, 4, "Philosophy", "0-9101-3138-4", "The Rebel", 1951 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
