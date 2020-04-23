using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Limdo.Web.Api.Migrations
{
    public partial class firstLimdoMgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(nullable: false),
                    CountryName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

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
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "PcoDetails",
                columns: table => new
                {
                    PcoId = table.Column<string>(nullable: false),
                    ExprireDate = table.Column<string>(nullable: true),
                    IssueDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcoDetails", x => x.PcoId);
                });

            migrationBuilder.CreateTable(
                name: "dbo_UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 50, nullable: false),
                    ClaimType = table.Column<string>(maxLength: 250, nullable: false),
                    ClaimValue = table.Column<string>(maxLength: 250, nullable: false),
                    UserSubjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_UserClaims_dbo_Users_UserSubjectId",
                        column: x => x.UserSubjectId,
                        principalTable: "dbo_Users",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dbo_UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(maxLength: 50, nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 250, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 250, nullable: false),
                    UserSubjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo_UserLogins_dbo_Users_UserSubjectId",
                        column: x => x.UserSubjectId,
                        principalTable: "dbo_Users",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(nullable: false),
                    SubjectId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstLineOfAddress = table.Column<string>(nullable: true),
                    SecondLineOfAddress = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CountryId = table.Column<string>(nullable: true),
                    GenderId = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false),
                    ModifierAppUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_AppUsers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUsers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUsers_dbo_Users_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbo_Users",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CountryId",
                table: "AppUsers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_GenderId",
                table: "AppUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_SubjectId",
                table: "AppUsers",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dbo_UserClaims_UserSubjectId",
                table: "dbo_UserClaims",
                column: "UserSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_UserLogins_UserSubjectId",
                table: "dbo_UserLogins",
                column: "UserSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "dbo_UserClaims");

            migrationBuilder.DropTable(
                name: "dbo_UserLogins");

            migrationBuilder.DropTable(
                name: "PcoDetails");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "dbo_Users");
        }
    }
}
