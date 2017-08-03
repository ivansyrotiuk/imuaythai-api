using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class contestRequestStatus3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ContestRequests",
                newName: "IssueDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptanceDate",
                table: "ContestRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptanceDate",
                table: "ContestRequests");

            migrationBuilder.RenameColumn(
                name: "IssueDate",
                table: "ContestRequests",
                newName: "Date");
        }
    }
}
