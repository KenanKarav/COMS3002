using Microsoft.EntityFrameworkCore.Migrations;

namespace PGASystemData.Migrations
{
    public partial class TitleRejectReasonApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SIMSOutcome",
                table: "Applications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SIMSOutcome",
                table: "Applications",
                nullable: false,
                defaultValue: false);
        }
    }
}
