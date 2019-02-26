using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingNewAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ExtendedInspection",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InspectionDone",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExtendedInspection",
                table: "TrashInspections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InspectionDone",
                table: "TrashInspections",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtendedInspection",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "InspectionDone",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "ExtendedInspection",
                table: "TrashInspections");

            migrationBuilder.DropColumn(
                name: "InspectionDone",
                table: "TrashInspections");
        }
    }
}
