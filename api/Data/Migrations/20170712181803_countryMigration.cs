using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class countryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestTypePoints_ContestRanges_ContestRangeId",
                table: "ContestTypePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestTypePoints_ContestTypes_ContestTypeId",
                table: "ContestTypePoints");

            migrationBuilder.AlterColumn<int>(
                name: "ContestTypeId",
                table: "ContestTypePoints",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContestRangeId",
                table: "ContestTypePoints",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestTypePoints_ContestRanges_ContestRangeId",
                table: "ContestTypePoints",
                column: "ContestRangeId",
                principalTable: "ContestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestTypePoints_ContestTypes_ContestTypeId",
                table: "ContestTypePoints",
                column: "ContestTypeId",
                principalTable: "ContestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestTypePoints_ContestRanges_ContestRangeId",
                table: "ContestTypePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestTypePoints_ContestTypes_ContestTypeId",
                table: "ContestTypePoints");

            migrationBuilder.AlterColumn<int>(
                name: "ContestTypeId",
                table: "ContestTypePoints",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ContestRangeId",
                table: "ContestTypePoints",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ContestTypePoints_ContestRanges_ContestRangeId",
                table: "ContestTypePoints",
                column: "ContestRangeId",
                principalTable: "ContestRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestTypePoints_ContestTypes_ContestTypeId",
                table: "ContestTypePoints",
                column: "ContestTypeId",
                principalTable: "ContestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
