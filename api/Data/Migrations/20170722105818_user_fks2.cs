using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class user_fks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InstitutionId1",
                table: "AspNetUsers",
                column: "InstitutionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionId1",
                table: "AspNetUsers",
                column: "InstitutionId1",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InstitutionId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstitutionId1",
                table: "AspNetUsers");
        }
    }
}
