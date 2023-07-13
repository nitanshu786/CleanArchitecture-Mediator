using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiddlewareProject.Migrations
{
    public partial class updataActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Activitys");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Activitys",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Activitys");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Activitys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
