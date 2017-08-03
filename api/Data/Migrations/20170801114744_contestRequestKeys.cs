using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class contestRequestKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestRequests_Contests_ContestId",
                table: "ContestRequests");

     

            migrationBuilder.DropColumn(
                name: "ContestId",
                table: "ContestCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ContestId",
                table: "ContestRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContestCategoryId",
                table: "ContestRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests",
                column: "ContestCategoryId",
                principalTable: "ContestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_Contests_ContestId",
                table: "ContestRequests",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestRequests_Contests_ContestId",
                table: "ContestRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ContestId",
                table: "ContestRequests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ContestCategoryId",
                table: "ContestRequests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ContestId",
                table: "ContestCategories",
                nullable: true);
            

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_ContestCategories_ContestCategoryId",
                table: "ContestRequests",
                column: "ContestCategoryId",
                principalTable: "ContestCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestRequests_Contests_ContestId",
                table: "ContestRequests",
                column: "ContestId",
                principalTable: "Contests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
