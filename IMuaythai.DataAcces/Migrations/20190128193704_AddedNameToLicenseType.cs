using Microsoft.EntityFrameworkCore.Migrations;

namespace IMuaythai.DataAccess.Migrations
{
    public partial class AddedNameToLicenseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LicenseTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "LicenseTypes");
        }
    }
}
