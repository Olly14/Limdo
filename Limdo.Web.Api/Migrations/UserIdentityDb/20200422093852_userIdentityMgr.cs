using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Limdo.Web.Api.Migrations.UserIdentityDb
{
    public partial class userIdentityMgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbo_Users",
                columns: table => new
                {
                    SubjectId = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_Users", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "dbo_UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 50, nullable: false),
                    ClaimType = table.Column<string>(maxLength: 250, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_UserClaims_dbo_Users_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbo_Users",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbo_UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 50, nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 250, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_UserLogins_dbo_Users_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbo_Users",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo_UserClaims_SubjectId",
                table: "dbo_UserClaims",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_UserLogins_SubjectId",
                table: "dbo_UserLogins",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbo_UserClaims");

            migrationBuilder.DropTable(
                name: "dbo_UserLogins");

            migrationBuilder.DropTable(
                name: "dbo_Users");
        }
    }
}
