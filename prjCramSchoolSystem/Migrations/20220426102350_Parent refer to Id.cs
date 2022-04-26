using Microsoft.EntityFrameworkCore.Migrations;

namespace prjCramSchoolSystem.Migrations
{
    public partial class ParentrefertoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_StudentProfile_ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_StudentProfile_UserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_StudentProfile_UserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_StudentProfile_UserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_StudentProfile_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfile",
                schema: "Identity",
                table: "StudentProfile");

            migrationBuilder.DropColumn(
                name: "FatherName",
                schema: "Identity",
                table: "StudentProfile");

            migrationBuilder.DropColumn(
                name: "MotherName",
                schema: "Identity",
                table: "StudentProfile");

            migrationBuilder.RenameTable(
                name: "StudentProfile",
                schema: "Identity",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "User",
                newName: "MotherId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProfile_ApplicationUserId",
                schema: "Identity",
                table: "User",
                newName: "IX_User_MotherId");

            migrationBuilder.AddColumn<string>(
                name: "FatherId",
                schema: "Identity",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "Identity",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_FatherId",
                schema: "Identity",
                table: "User",
                column: "FatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_FatherId",
                schema: "Identity",
                table: "User",
                column: "FatherId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_MotherId",
                schema: "Identity",
                table: "User",
                column: "MotherId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_User_UserId",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_FatherId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_MotherId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_User_UserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FatherId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FatherId",
                schema: "Identity",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "StudentProfile",
                newSchema: "Identity");

            migrationBuilder.RenameColumn(
                name: "MotherId",
                schema: "Identity",
                table: "StudentProfile",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_MotherId",
                schema: "Identity",
                table: "StudentProfile",
                newName: "IX_StudentProfile_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                schema: "Identity",
                table: "StudentProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                schema: "Identity",
                table: "StudentProfile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfile",
                schema: "Identity",
                table: "StudentProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_StudentProfile_ApplicationUserId",
                schema: "Identity",
                table: "StudentProfile",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "StudentProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_StudentProfile_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "StudentProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_StudentProfile_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "StudentProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_StudentProfile_UserId",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "StudentProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_StudentProfile_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "StudentProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
