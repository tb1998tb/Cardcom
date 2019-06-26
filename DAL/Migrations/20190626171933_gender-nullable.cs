using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class gendernullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
