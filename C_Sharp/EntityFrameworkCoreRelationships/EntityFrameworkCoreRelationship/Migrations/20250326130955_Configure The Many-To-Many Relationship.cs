using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreRelationship.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureTheManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CoursesCourseID",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentsID",
                table: "StudentCourse");

            migrationBuilder.RenameColumn(
                name: "StudentsID",
                table: "StudentCourse",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseID",
                table: "StudentCourse",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_StudentsID",
                table: "StudentCourse",
                newName: "IX_StudentCourse_CourseID");

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    CoursesCourseID = table.Column<int>(type: "int", nullable: false),
                    StudentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CoursesCourseID, x.StudentsID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CoursesCourseID",
                        column: x => x.CoursesCourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentsID",
                        column: x => x.StudentsID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentsID",
                table: "StudentCourses",
                column: "StudentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseID",
                table: "StudentCourse",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentID",
                table: "StudentCourse",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseID",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentID",
                table: "StudentCourse");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "StudentCourse",
                newName: "StudentsID");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "StudentCourse",
                newName: "CoursesCourseID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_CourseID",
                table: "StudentCourse",
                newName: "IX_StudentCourse_StudentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CoursesCourseID",
                table: "StudentCourse",
                column: "CoursesCourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentsID",
                table: "StudentCourse",
                column: "StudentsID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
