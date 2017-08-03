using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class nullCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InstitutionId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstitutionId1",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FighterId",
                table: "FightPoints",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ContestCategoryId",
                table: "ContestRequests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests",
                column: "ContestCategoryId",
                principalTable: "ContestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests");

            migrationBuilder.DropColumn(
                name: "FighterId",
                table: "FightPoints");

            migrationBuilder.AlterColumn<int>(
                name: "ContestCategoryId",
                table: "ContestRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionId1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InstitutionId1",
                table: "AspNetUsers",
                column: "InstitutionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionId1",
                table: "AspNetUsers",
                column: "InstitutionId1",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests",
                column: "ContestCategoryId",
                principalTable: "ContestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
