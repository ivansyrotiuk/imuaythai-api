using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class InstitutionsPublicKeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Institutions_HeadCoachId",
                table: "Institutions");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_HeadCoachId",
                table: "Institutions",
                column: "HeadCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InstitutionsId",
                table: "AspNetUsers",
                column: "InstitutionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionsId",
                table: "AspNetUsers",
                column: "InstitutionsId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Institutions_InstitutionsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_HeadCoachId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InstitutionsId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_HeadCoachId",
                table: "Institutions",
                column: "HeadCoachId",
                unique: true);
        }
    }
}
