using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Database.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_StudentCourses_ID",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "StudentCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "StudentCourses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StudentCourses_ID",
                table: "StudentCourses",
                column: "ID");
        }
    }
}
