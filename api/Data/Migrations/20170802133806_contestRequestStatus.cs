using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class contestRequestStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "ContestRequests");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ContestRequests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContestRequests");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "ContestRequests",
                nullable: false,
                defaultValue: false);
        }
    }
}
