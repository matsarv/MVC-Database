using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Database.Migrations
{
    public partial class init_sc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Assignments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.UniqueConstraint("AK_StudentCourses_ID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Assignments");
        }
    }
}
