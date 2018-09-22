using Microsoft.EntityFrameworkCore.Migrations;

namespace PGASystemData.Migrations
{
    public partial class UploadToAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationFiles_Applications_ApplicationId",
                table: "ApplicationFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationFiles",
                table: "ApplicationFiles");

            migrationBuilder.RenameTable(
                name: "ApplicationFiles",
                newName: "ApplicationFile");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationFiles_ApplicationId",
                table: "ApplicationFile",
                newName: "IX_ApplicationFile_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationFile",
                table: "ApplicationFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFile_Applications_ApplicationId",
                table: "ApplicationFile",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationFile_Applications_ApplicationId",
                table: "ApplicationFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationFile",
                table: "ApplicationFile");

            migrationBuilder.RenameTable(
                name: "ApplicationFile",
                newName: "ApplicationFiles");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationFile_ApplicationId",
                table: "ApplicationFiles",
                newName: "IX_ApplicationFiles_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationFiles",
                table: "ApplicationFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationFiles_Applications_ApplicationId",
                table: "ApplicationFiles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
