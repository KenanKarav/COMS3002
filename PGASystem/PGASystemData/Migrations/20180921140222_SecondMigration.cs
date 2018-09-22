using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PGASystemData.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File",
                table: "Applications");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "File",
                table: "Applications",
                nullable: false,
                defaultValue: "");
        }
    }
}
