using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastruture.Migrations
{
    public partial class kjkjl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Browser",
                table: "LoginUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Browser",
                table: "LoginUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
