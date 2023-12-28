using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _103.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentID",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Units_UnitID",
                table: "Marks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marks",
                table: "Marks");

            migrationBuilder.RenameTable(
                name: "Marks",
                newName: "Mark");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_UnitID",
                table: "Mark",
                newName: "IX_Mark_UnitID");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_StudentID",
                table: "Mark",
                newName: "IX_Mark_StudentID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Schedule",
                table: "Units",
                type: "datetime2",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mark",
                table: "Mark",
                column: "MarkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_Students_StudentID",
                table: "Mark",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mark_Units_UnitID",
                table: "Mark",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Students_StudentID",
                table: "Mark");

            migrationBuilder.DropForeignKey(
                name: "FK_Mark_Units_UnitID",
                table: "Mark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mark",
                table: "Mark");

            migrationBuilder.RenameTable(
                name: "Mark",
                newName: "Marks");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_UnitID",
                table: "Marks",
                newName: "IX_Marks_UnitID");

            migrationBuilder.RenameIndex(
                name: "IX_Mark_StudentID",
                table: "Marks",
                newName: "IX_Marks_StudentID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Schedule",
                table: "Units",
                type: "Datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherName",
                table: "Teachers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marks",
                table: "Marks",
                column: "MarkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentID",
                table: "Marks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Units_UnitID",
                table: "Marks",
                column: "UnitID",
                principalTable: "Units",
                principalColumn: "UnitID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
