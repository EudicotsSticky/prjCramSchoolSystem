using Microsoft.EntityFrameworkCore.Migrations;

namespace prjCramSchoolSystem.Migrations
{
    public partial class ParentIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfile_ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_StudentProfile_ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "StudentProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_StudentProfile_ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile");

            migrationBuilder.DropIndex(
                name: "IX_StudentProfile_ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile");
        }
    }
}
