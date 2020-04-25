using Microsoft.EntityFrameworkCore.Migrations;

namespace Limdo.Web.Api.Migrations
{
    public partial class modifiedPcoLicenceDetailMrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PcoLicenceId",
                table: "PcoDetails");

            migrationBuilder.AddColumn<string>(
                name: "PcoLicenceNumber",
                table: "PcoDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PcoLicenceNumber",
                table: "PcoDetails");

            migrationBuilder.AddColumn<string>(
                name: "PcoLicenceId",
                table: "PcoDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
