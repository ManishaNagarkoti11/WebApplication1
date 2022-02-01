using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AddedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "File",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Students");
        }
    }
}
