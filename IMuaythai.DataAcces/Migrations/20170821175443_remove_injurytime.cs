using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class remove_injurytime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InjuryTime",
                table: "FightPoints");

            migrationBuilder.DropColumn(
                name: "KOTime",
                table: "Fights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InjuryTime",
                table: "FightPoints",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KOTime",
                table: "Fights",
                nullable: true);
        }
    }
}
