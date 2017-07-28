using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class fight_structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestCategories_FightStructures_FightStructureId",
                table: "ContestCategories");

            migrationBuilder.RenameColumn(
                name: "RoundlId",
                table: "FightStructures",
                newName: "RoundId");

            migrationBuilder.AlterColumn<int>(
                name: "FightStructureId",
                table: "ContestCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RoundsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightAgeCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gender = table.Column<string>(nullable: true),
                    MaxAge = table.Column<int>(nullable: false),
                    MaxWeight = table.Column<decimal>(nullable: false),
                    MinAge = table.Column<int>(nullable: false),
                    MinWeight = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightAgeCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FightStructures_RoundId",
                table: "FightStructures",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_FightStructures_WeightAgeCategoryId",
                table: "FightStructures",
                column: "WeightAgeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContestCategories_FightStructures_FightStructureId",
                table: "ContestCategories",
                column: "FightStructureId",
                principalTable: "FightStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStructures_Round_RoundId",
                table: "FightStructures",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStructures_WeightAgeCategory_WeightAgeCategoryId",
                table: "FightStructures",
                column: "WeightAgeCategoryId",
                principalTable: "WeightAgeCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestCategories_FightStructures_FightStructureId",
                table: "ContestCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStructures_Round_RoundId",
                table: "FightStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStructures_WeightAgeCategory_WeightAgeCategoryId",
                table: "FightStructures");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "WeightAgeCategory");

            migrationBuilder.DropIndex(
                name: "IX_FightStructures_RoundId",
                table: "FightStructures");

            migrationBuilder.DropIndex(
                name: "IX_FightStructures_WeightAgeCategoryId",
                table: "FightStructures");

            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "FightStructures",
                newName: "RoundlId");

            migrationBuilder.AlterColumn<int>(
                name: "FightStructureId",
                table: "ContestCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ContestCategories_FightStructures_FightStructureId",
                table: "ContestCategories",
                column: "FightStructureId",
                principalTable: "FightStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
