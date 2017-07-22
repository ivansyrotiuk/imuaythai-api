using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class user_fks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserRoleAcceptations_AcceptedByUserId",
                table: "UserRoleAcceptations");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAcceptations_RoleId",
                table: "UserRoleAcceptations");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAcceptations_UserId",
                table: "UserRoleAcceptations");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAcceptations_AcceptedByUserId",
                table: "UserRoleAcceptations",
                column: "AcceptedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAcceptations_RoleId",
                table: "UserRoleAcceptations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAcceptations_UserId",
                table: "UserRoleAcceptations",
                column: "UserId");

            migrationBuilder.DropIndex(
              name: "IX_AspNetUsers_InstitutionId1",
              table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InstitutionId1",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAcceptations_AcceptedByUserId",
                table: "UserRoleAcceptations");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAcceptations_RoleId",
                table: "UserRoleAcceptations");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleAcceptations_UserId",
                table: "UserRoleAcceptations");

          

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAcceptations_AcceptedByUserId",
                table: "UserRoleAcceptations",
                column: "AcceptedByUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAcceptations_RoleId",
                table: "UserRoleAcceptations",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleAcceptations_UserId",
                table: "UserRoleAcceptations",
                column: "UserId",
                unique: true);
        }
    }
}
