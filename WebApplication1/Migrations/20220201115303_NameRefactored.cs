using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class NameRefactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
