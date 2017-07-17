using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class dictionaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.RenameColumn(
                name: "Wamings",
                table: "FightPoints",
                newName: "Warnings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Warnings",
                table: "FightPoints",
                newName: "Wamings");

        }
    }
}
