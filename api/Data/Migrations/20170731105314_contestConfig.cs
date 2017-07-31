using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class contestConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contests_Institutions_InstitutionId",
                table: "Contests");

            

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionId",
                table: "Contests",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contests_Institutions_InstitutionId",
                table: "Contests");

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionId",
                table: "Contests",
                nullable: true,
                oldClrType: typeof(int));

       

        }
    }
}
