using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Database.Migrations
{
    public partial class init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Assignments_AssignmentID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AssignmentID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AssignmentID",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignments",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseID",
                table: "Assignments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseID",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_CourseID",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentID",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AssignmentID",
                table: "Courses",
                column: "AssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Assignments_AssignmentID",
                table: "Courses",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
