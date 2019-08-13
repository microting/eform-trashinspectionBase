using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingConditionalApprovedToTrashInspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConditionalApproved",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ConditionalApproved",
                table: "TrashInspections",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConditionalApproved",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "ConditionalApproved",
                table: "TrashInspections");
        }
    }
}
