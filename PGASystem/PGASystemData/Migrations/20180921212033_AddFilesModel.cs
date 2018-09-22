using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PGASystemData.Migrations
{
    public partial class AddFilesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "studentNumber",
                table: "Applications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationFiles_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_ApplicationId",
                table: "ApplicationFiles",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationFiles");

            migrationBuilder.DropColumn(
                name: "studentNumber",
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
    }
}
