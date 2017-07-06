using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class NullUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextFightId",
                table: "Fights",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Documents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContestTypePointsId",
                table: "ContestCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AllowUnassociated",
                table: "Contests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ContestRangeId",
                table: "Contests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestTypeId",
                table: "Contests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Contests",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Contests",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Contests",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VK",
                table: "Contests",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Contests",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContestDocumentsMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentId = table.Column<int>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestDocumentsMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestDocumentsMapping_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestDocumentsMapping_Contests_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Confirmed = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    SendDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContestTypePoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContestRangeId = table.Column<int>(nullable: true),
                    ContestTypeId = table.Column<int>(nullable: true),
                    InstitutionId = table.Column<int>(nullable: true),
                    Points = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestTypePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestTypePoints_ContestRanges_ContestRangeId",
                        column: x => x.ContestRangeId,
                        principalTable: "ContestRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestTypePoints_ContestTypes_ContestTypeId",
                        column: x => x.ContestTypeId,
                        principalTable: "ContestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContestTypePoints_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategories_ContestTypePointsId",
                table: "ContestCategories",
                column: "ContestTypePointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestRangeId",
                table: "Contests",
                column: "ContestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestTypeId",
                table: "Contests",
                column: "ContestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestDocumentsMapping_DocumentId",
                table: "ContestDocumentsMapping",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestDocumentsMapping_InstitutionId",
                table: "ContestDocumentsMapping",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTypePoints_ContestRangeId",
                table: "ContestTypePoints",
                column: "ContestRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTypePoints_ContestTypeId",
                table: "ContestTypePoints",
                column: "ContestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestTypePoints_InstitutionId",
                table: "ContestTypePoints",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_UserId",
                table: "Reminders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contests_ContestRanges_ContestRangeId",
                table: "Contests",
                column: "ContestRangeId",
                principalTable: "ContestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contests_ContestTypes_ContestTypeId",
                table: "Contests",
                column: "ContestTypeId",
                principalTable: "ContestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestCategories_ContestTypePoints_ContestTypePointsId",
                table: "ContestCategories",
                column: "ContestTypePointsId",
                principalTable: "ContestTypePoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contests_ContestRanges_ContestRangeId",
                table: "Contests");

            migrationBuilder.DropForeignKey(
                name: "FK_Contests_ContestTypes_ContestTypeId",
                table: "Contests");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestCategories_ContestTypePoints_ContestTypePointsId",
                table: "ContestCategories");

            migrationBuilder.DropTable(
                name: "ContestDocumentsMapping");

            migrationBuilder.DropTable(
                name: "ContestTypePoints");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "ContestRanges");

            migrationBuilder.DropTable(
                name: "ContestTypes");

            migrationBuilder.DropIndex(
                name: "IX_ContestCategories_ContestTypePointsId",
                table: "ContestCategories");

            migrationBuilder.DropIndex(
                name: "IX_Contests_ContestRangeId",
                table: "Contests");

            migrationBuilder.DropIndex(
                name: "IX_Contests_ContestTypeId",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "NextFightId",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ContestTypePointsId",
                table: "ContestCategories");

            migrationBuilder.DropColumn(
                name: "AllowUnassociated",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestRangeId",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestTypeId",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "VK",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Contests");
        }
    }
}
