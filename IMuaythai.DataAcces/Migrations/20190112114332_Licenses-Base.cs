using Microsoft.EntityFrameworkCore.Migrations;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class LicensesBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_AspNetUsers_CoachId",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_License_AspNetUsers_FighterId",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_License_Institutions_InstitutionId",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_License_AspNetUsers_JudgeId",
                table: "License");

            migrationBuilder.DropForeignKey(
                name: "FK_License_LicenseTypes_LicenseTypeId",
                table: "License");

            migrationBuilder.DropPrimaryKey(
                name: "PK_License",
                table: "License");

            migrationBuilder.RenameTable(
                name: "License",
                newName: "Licenses");

            migrationBuilder.RenameIndex(
                name: "IX_License_LicenseTypeId",
                table: "Licenses",
                newName: "IX_Licenses_LicenseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_License_JudgeId",
                table: "Licenses",
                newName: "IX_Licenses_JudgeId");

            migrationBuilder.RenameIndex(
                name: "IX_License_InstitutionId",
                table: "Licenses",
                newName: "IX_Licenses_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_License_FighterId",
                table: "Licenses",
                newName: "IX_Licenses_FighterId");

            migrationBuilder.RenameIndex(
                name: "IX_License_CoachId",
                table: "Licenses",
                newName: "IX_Licenses_CoachId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_AspNetUsers_CoachId",
                table: "Licenses",
                column: "CoachId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_AspNetUsers_FighterId",
                table: "Licenses",
                column: "FighterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Institutions_InstitutionId",
                table: "Licenses",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_AspNetUsers_JudgeId",
                table: "Licenses",
                column: "JudgeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_LicenseTypes_LicenseTypeId",
                table: "Licenses",
                column: "LicenseTypeId",
                principalTable: "LicenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_AspNetUsers_CoachId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_AspNetUsers_FighterId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Institutions_InstitutionId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_AspNetUsers_JudgeId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_LicenseTypes_LicenseTypeId",
                table: "Licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses");

            migrationBuilder.RenameTable(
                name: "Licenses",
                newName: "License");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_LicenseTypeId",
                table: "License",
                newName: "IX_License_LicenseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_JudgeId",
                table: "License",
                newName: "IX_License_JudgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_InstitutionId",
                table: "License",
                newName: "IX_License_InstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_FighterId",
                table: "License",
                newName: "IX_License_FighterId");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_CoachId",
                table: "License",
                newName: "IX_License_CoachId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_License",
                table: "License",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_License_AspNetUsers_CoachId",
                table: "License",
                column: "CoachId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_License_AspNetUsers_FighterId",
                table: "License",
                column: "FighterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_License_Institutions_InstitutionId",
                table: "License",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_License_AspNetUsers_JudgeId",
                table: "License",
                column: "JudgeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_License_LicenseTypes_LicenseTypeId",
                table: "License",
                column: "LicenseTypeId",
                principalTable: "LicenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
