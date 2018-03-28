using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class CorrectDictionariesDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "WeightAgeCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "WeightAgeCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SuspensionTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "SuspensionTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Rounds",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Rounds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "KhanLevels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "KhanLevels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "FightStructures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "FightStructures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContestTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "ContestTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContestTypePoints",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "ContestTypePoints",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContestRanges",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "ContestRanges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "ContestCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "ContestCategories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "WeightAgeCategories");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "WeightAgeCategories");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SuspensionTypes");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "SuspensionTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "KhanLevels");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "KhanLevels");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "FightStructures");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "FightStructures");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContestTypes");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "ContestTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContestTypePoints");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "ContestTypePoints");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContestRanges");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "ContestRanges");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "ContestCategories");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "ContestCategories");
        }
    }
}
