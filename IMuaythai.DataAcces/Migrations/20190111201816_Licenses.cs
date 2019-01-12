using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class Licenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Kind = table.Column<int>(nullable: false),
                    OneOff = table.Column<bool>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "License",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    ContestId = table.Column<int>(nullable: false),
                    LicenseTypeId = table.Column<int>(nullable: false),
                    Kind = table.Column<int>(nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    CoachId = table.Column<string>(nullable: true),
                    FighterId = table.Column<string>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true),
                    JudgeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_License", x => x.Id);
                    table.ForeignKey(
                        name: "FK_License_AspNetUsers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_License_AspNetUsers_FighterId",
                        column: x => x.FighterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_License_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_License_AspNetUsers_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_License_LicenseTypes_LicenseTypeId",
                        column: x => x.LicenseTypeId,
                        principalTable: "LicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_License_CoachId",
                table: "License",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_License_FighterId",
                table: "License",
                column: "FighterId");

            migrationBuilder.CreateIndex(
                name: "IX_License_InstitutionId",
                table: "License",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_License_JudgeId",
                table: "License",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_License_LicenseTypeId",
                table: "License",
                column: "LicenseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "License");

            migrationBuilder.DropTable(
                name: "LicenseTypes");
        }
    }
}
