using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Database.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Assignments",
                newName: "AssignmentNumber");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentID",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Assignments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Assignments",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "AssignmentNumber",
                table: "Assignments",
                newName: "TeacherID");

            migrationBuilder.AddColumn<int>(
                name: "AssignmentID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
