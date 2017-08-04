using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Migrations
{
    public partial class fighterInPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Warnings",
                table: "FightPoints",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FighterId",
                table: "FightPoints",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cautions",
                table: "FightPoints",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_FightPoints_FighterId",
                table: "FightPoints",
                column: "FighterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FightPoints_AspNetUsers_FighterId",
                table: "FightPoints",
                column: "FighterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FightPoints_AspNetUsers_FighterId",
                table: "FightPoints");

            migrationBuilder.DropIndex(
                name: "IX_FightPoints_FighterId",
                table: "FightPoints");

            migrationBuilder.AlterColumn<string>(
                name: "Warnings",
                table: "FightPoints",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FighterId",
                table: "FightPoints",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cautions",
                table: "FightPoints",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
