using Microsoft.EntityFrameworkCore.Migrations;

namespace prjCramSchoolSystem.Migrations
{
    public partial class ChangeColumnNametoThumbnailName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                schema: "Identity",
                table: "StudentProfile",
                newName: "ThumbnailName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThumbnailName",
                schema: "Identity",
                table: "StudentProfile",
                newName: "ThumbnailUrl");
        }
    }
}
