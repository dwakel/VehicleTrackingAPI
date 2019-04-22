using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gps.Core.Migrations
{
    public partial class dbintegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Distance",
                table: "Location",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "HomeLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Latitude = table.Column<string>(nullable: false),
                    Longitude = table.Column<string>(nullable: false),
                    Distance = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeLocation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeLocation");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Location");
        }
    }
}
