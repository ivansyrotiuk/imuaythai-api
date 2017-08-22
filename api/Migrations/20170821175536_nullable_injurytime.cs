using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Migrations
{
    public partial class nullable_injurytime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InjuryTime",
                table: "FightPoints",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KOTime",
                table: "Fights",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InjuryTime",
                table: "FightPoints");

            migrationBuilder.DropColumn(
                name: "KOTime",
                table: "Fights");
        }
    }
}
