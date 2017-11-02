using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Migrations
{
    public partial class FightCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FightJudgesMappings_Fights_FightId",
                table: "FightJudgesMappings");

            migrationBuilder.AlterColumn<int>(
                name: "FightId",
                table: "FightJudgesMappings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestCategoryId",
                table: "Fights",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fights_ContestCategoryId",
                table: "Fights",
                column: "ContestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_NextFightId",
                table: "Fights",
                column: "NextFightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_ContestCategories_ContestCategoryId",
                table: "Fights",
                column: "ContestCategoryId",
                principalTable: "ContestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_Fights_NextFightId",
                table: "Fights",
                column: "NextFightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightJudgesMappings_Fights_FightId",
                table: "FightJudgesMappings",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fights_ContestCategories_ContestCategoryId",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_Fights_NextFightId",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_FightJudgesMappings_Fights_FightId",
                table: "FightJudgesMappings");

            migrationBuilder.DropIndex(
                name: "IX_Fights_ContestCategoryId",
                table: "Fights");

            migrationBuilder.DropIndex(
                name: "IX_Fights_NextFightId",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "ContestCategoryId",
                table: "Fights");

            migrationBuilder.AlterColumn<int>(
                name: "FightId",
                table: "FightJudgesMappings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FightJudgesMappings_Fights_FightId",
                table: "FightJudgesMappings",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
