using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class InstitutionsPublicKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Countries_Countryid",
                table: "Institutions");

            migrationBuilder.RenameColumn(
                name: "HeadCoachid",
                table: "Institutions",
                newName: "HeadCoachId");

            migrationBuilder.RenameColumn(
                name: "Countryid",
                table: "Institutions",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Institutions_Countryid",
                table: "Institutions",
                newName: "IX_Institutions_CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_HeadCoachId",
                table: "Institutions",
                column: "HeadCoachId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Countries_CountryId",
                table: "Institutions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_AspNetUsers_HeadCoachId",
                table: "Institutions",
                column: "HeadCoachId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_Countries_CountryId",
                table: "Institutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutions_AspNetUsers_HeadCoachId",
                table: "Institutions");

            migrationBuilder.DropIndex(
                name: "IX_Institutions_HeadCoachId",
                table: "Institutions");

            migrationBuilder.RenameColumn(
                name: "HeadCoachId",
                table: "Institutions",
                newName: "HeadCoachid");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Institutions",
                newName: "Countryid");

            migrationBuilder.RenameIndex(
                name: "IX_Institutions_CountryId",
                table: "Institutions",
                newName: "IX_Institutions_Countryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutions_Countries_Countryid",
                table: "Institutions",
                column: "Countryid",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
