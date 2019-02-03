using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HatuaMVP.Core.Migrations
{
    public partial class CompleteRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Investor");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "ServiceProvider",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Investor",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Company",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Company",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Admin",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Company");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ServiceProvider",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Investor",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Company",
                newName: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ServiceProvider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ServiceProvider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ServiceProvider",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "ServiceProvider",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "ServiceProvider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ServiceProvider",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Investor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Investor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Investor",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Investor",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Investor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Investor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Company",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Admin",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Admin",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Admin",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Admin",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Admin",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Admin",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
