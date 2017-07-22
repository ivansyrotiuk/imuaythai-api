using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MuaythaiSportManagementSystemApi.Data.Migrations
{
    public partial class renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleAcceptations");

            migrationBuilder.CreateTable(
                name: "UserRoleRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptationDate = table.Column<DateTime>(nullable: true),
                    AcceptedByUserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleRequests_AspNetUsers_AcceptedByUserId",
                        column: x => x.AcceptedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleRequests_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRequests_AcceptedByUserId",
                table: "UserRoleRequests",
                column: "AcceptedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRequests_RoleId",
                table: "UserRoleRequests",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRequests_UserId",
                table: "UserRoleRequests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleRequests");

            migrationBuilder.CreateTable(
                name: "UserRoleAcceptations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptationDate = table.Column<DateTime>(nullable: true),
                    AcceptedByUserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleAcceptations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleAcceptations_AspNetUsers_AcceptedByUserId",
                        column: x => x.AcceptedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleAcceptations_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoleAcceptations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }
    }
}
