using Microsoft.EntityFrameworkCore.Migrations;

namespace CooksProjectCore.DAL.Migrations
{
    public partial class ImageLocationonUsersisadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLocation",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLocation",
                table: "Users");
        }
    }
}
