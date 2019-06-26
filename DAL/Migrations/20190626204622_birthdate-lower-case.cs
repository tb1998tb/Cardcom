using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class birthdatelowercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Persons",
                newName: "Birthdate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Persons",
                newName: "BirthDate");
        }
    }
}
