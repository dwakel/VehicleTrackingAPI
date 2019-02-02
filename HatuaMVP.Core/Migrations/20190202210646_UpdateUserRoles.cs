using Microsoft.EntityFrameworkCore.Migrations;

namespace HatuaMVP.Core.Migrations
{
    public partial class UpdateUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "ServiceProvider",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Investor",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Company",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Admin",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Admin");
        }
    }
}