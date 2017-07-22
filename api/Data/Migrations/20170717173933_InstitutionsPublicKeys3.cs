using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class InstitutionsPublicKeys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeadCoachId",
                table: "Institutions",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                maxLength: 450,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeadCoachId",
                table: "Institutions",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
