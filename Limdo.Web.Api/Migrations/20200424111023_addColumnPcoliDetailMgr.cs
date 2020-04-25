using Microsoft.EntityFrameworkCore.Migrations;

namespace Limdo.Web.Api.Migrations
{
    public partial class addColumnPcoliDetailMgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PcoLicenceId",
                table: "PcoDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PcoLicenceId",
                table: "PcoDetails");
        }
    }
}
