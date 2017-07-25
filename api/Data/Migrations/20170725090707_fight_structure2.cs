using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class fight_structure2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FightStructures_Round_RoundId",
                table: "FightStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStructures_WeightAgeCategory_WeightAgeCategoryId",
                table: "FightStructures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightAgeCategory",
                table: "WeightAgeCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Round",
                table: "Round");

            migrationBuilder.RenameTable(
                name: "WeightAgeCategory",
                newName: "WeightAgeCategories");

            migrationBuilder.RenameTable(
                name: "Round",
                newName: "Rounds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightAgeCategories",
                table: "WeightAgeCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FightStructures_Rounds_RoundId",
                table: "FightStructures",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStructures_WeightAgeCategories_WeightAgeCategoryId",
                table: "FightStructures",
                column: "WeightAgeCategoryId",
                principalTable: "WeightAgeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FightStructures_Rounds_RoundId",
                table: "FightStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStructures_WeightAgeCategories_WeightAgeCategoryId",
                table: "FightStructures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeightAgeCategories",
                table: "WeightAgeCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.RenameTable(
                name: "WeightAgeCategories",
                newName: "WeightAgeCategory");

            migrationBuilder.RenameTable(
                name: "Rounds",
                newName: "Round");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeightAgeCategory",
                table: "WeightAgeCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Round",
                table: "Round",
                column: "Id");

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
    }
}
