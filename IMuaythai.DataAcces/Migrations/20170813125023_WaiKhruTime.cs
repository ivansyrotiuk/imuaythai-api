using Microsoft.EntityFrameworkCore.Migrations;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class WaiKhruTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FightPoints_Fights_FightId",
                table: "FightPoints");

            migrationBuilder.AlterColumn<int>(
                name: "Warnings",
                table: "FightPoints",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FightId",
                table: "FightPoints",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cautions",
                table: "FightPoints",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "J",
                table: "FightPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KnockDown",
                table: "FightPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "FightPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WaiKhruTime",
                table: "Contests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FightPoints_Fights_FightId",
                table: "FightPoints",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FightPoints_Fights_FightId",
                table: "FightPoints");

            migrationBuilder.DropColumn(
                name: "J",
                table: "FightPoints");

            migrationBuilder.DropColumn(
                name: "KnockDown",
                table: "FightPoints");

            migrationBuilder.DropColumn(
                name: "X",
                table: "FightPoints");

            migrationBuilder.DropColumn(
                name: "WaiKhruTime",
                table: "Contests");

            migrationBuilder.AlterColumn<string>(
                name: "Warnings",
                table: "FightPoints",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FightId",
                table: "FightPoints",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Cautions",
                table: "FightPoints",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FightPoints_Fights_FightId",
                table: "FightPoints",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
