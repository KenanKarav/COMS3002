using Microsoft.EntityFrameworkCore.Migrations;

namespace PGASystemData.Migrations
{
    public partial class ModelApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RejectReason",
                table: "Applications",
                newName: "SupervisorRejectReason");

            migrationBuilder.AlterColumn<string>(
                name: "SupervisorApproval",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "PGCApproval",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "PGCRejectReason",
                table: "Applications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PGCRejectReason",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "SupervisorRejectReason",
                table: "Applications",
                newName: "RejectReason");

            migrationBuilder.AlterColumn<bool>(
                name: "SupervisorApproval",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PGCApproval",
                table: "Applications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
