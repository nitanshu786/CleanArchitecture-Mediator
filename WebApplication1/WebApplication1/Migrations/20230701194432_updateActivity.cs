using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiddlewareProject.Migrations
{
    public partial class updateActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Activitys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Activitys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Activitys");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Activitys",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys",
                column: "UserName");
        }
    }
}
