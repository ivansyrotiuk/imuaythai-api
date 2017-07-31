using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class institutionInContestCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "ContestCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategories_InstitutionId",
                table: "ContestCategories",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContestCategories_Institutions_InstitutionId",
                table: "ContestCategories",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropForeignKey(
                name: "FK_ContestCategories_Contests_ContestId",
                table: "ContestCategories");

            migrationBuilder.DropIndex(
                name: "IX_ContestCategories_ContestId",
                table: "ContestCategories");

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "ContestCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestCategories_Institutions_InstitutionId",
                table: "ContestCategories");

            migrationBuilder.DropIndex(
                name: "IX_ContestCategories_InstitutionId",
                table: "ContestCategories");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "ContestCategories");

            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "ContestCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContestCategories_ContestId",
                table: "ContestCategories",
                column: "ContestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContestCategories_Contests_ContestId",
                table: "ContestCategories",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
