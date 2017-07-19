using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class InstitutionsPublicKeys5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionsId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "InstitutionsId",
                table: "AspNetUsers",
                newName: "InstitutionId1");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_InstitutionsId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_InstitutionId1");

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

            migrationBuilder.RenameColumn(
                name: "InstitutionId1",
                table: "AspNetUsers",
                newName: "InstitutionsId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_InstitutionId1",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_InstitutionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionsId",
                table: "AspNetUsers",
                column: "InstitutionsId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
