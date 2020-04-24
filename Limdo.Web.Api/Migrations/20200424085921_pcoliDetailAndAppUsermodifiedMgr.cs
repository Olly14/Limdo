using Microsoft.EntityFrameworkCore.Migrations;

namespace Limdo.Web.Api.Migrations
{
    public partial class pcoliDetailAndAppUsermodifiedMgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Genders_GenderId",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "PcoDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "GenderId",
                table: "AppUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_PcoDetails_AppUserId",
                table: "PcoDetails",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Genders_GenderId",
                table: "AppUsers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PcoDetails_AppUsers_AppUserId",
                table: "PcoDetails",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Genders_GenderId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PcoDetails_AppUsers_AppUserId",
                table: "PcoDetails");

            migrationBuilder.DropIndex(
                name: "IX_PcoDetails_AppUserId",
                table: "PcoDetails");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "PcoDetails");

            migrationBuilder.AlterColumn<string>(
                name: "GenderId",
                table: "AppUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Genders_GenderId",
                table: "AppUsers",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
