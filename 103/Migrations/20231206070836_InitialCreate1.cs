using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _103.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Teachers_TeacherId",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Units",
                newName: "TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_Units_TeacherId",
                table: "Units",
                newName: "IX_Units_TeacherID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Marks",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                newName: "IX_Marks_StudentID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Schedule",
                table: "Units",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherName",
                table: "Teachers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "Marks",
                type: "char(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentID",
                table: "Marks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Teachers_TeacherID",
                table: "Units",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentID",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Teachers_TeacherID",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Units",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_TeacherID",
                table: "Units",
                newName: "IX_Units_TeacherId");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Marks",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_StudentID",
                table: "Marks",
                newName: "IX_Marks_StudentId");

            migrationBuilder.AlterColumn<int>(
                name: "Schedule",
                table: "Units",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherName",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Marks",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Teachers_TeacherId",
                table: "Units",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
