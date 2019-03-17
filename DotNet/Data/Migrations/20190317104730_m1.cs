using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Book",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Book",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 1,
                column: "Country",
                value: "Usa");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 2,
                column: "Country",
                value: "Usa");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 3,
                column: "Country",
                value: "Usa");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 4,
                column: "Country",
                value: "France");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 5,
                column: "Country",
                value: "Usa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Book",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Book",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 1,
                column: "Country",
                value: null);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 2,
                column: "Country",
                value: null);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 3,
                column: "Country",
                value: null);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 4,
                column: "Country",
                value: null);

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 5,
                column: "Country",
                value: null);
        }
    }
}
