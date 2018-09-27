using Microsoft.EntityFrameworkCore.Migrations;

namespace PGASystemData.Migrations
{
    public partial class EditUserApplicationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PGCApproval",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SIMSOutcome",
                table: "Applications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SupervisorApproval",
                table: "Applications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PGCApproval",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SIMSOutcome",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SupervisorApproval",
                table: "Applications");
        }
    }
}
