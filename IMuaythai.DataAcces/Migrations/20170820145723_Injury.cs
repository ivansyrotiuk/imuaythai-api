using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class Injury : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Injury",
                table: "FightPoints",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InjuryTime",
                table: "FightPoints",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Injury",
                table: "FightPoints");

            migrationBuilder.DropColumn(
                name: "InjuryTime",
                table: "FightPoints");
        }
    }
}
