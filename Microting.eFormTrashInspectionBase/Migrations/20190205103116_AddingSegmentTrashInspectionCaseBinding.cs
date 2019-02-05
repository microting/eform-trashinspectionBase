using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingSegmentTrashInspectionCaseBinding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SegmentId",
                table: "TrashInspectionCaseVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "TrashInspectionCaseVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SegmentId",
                table: "TrashInspectionCases",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SegmentId",
                table: "TrashInspectionCaseVersions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "TrashInspectionCaseVersions");

            migrationBuilder.DropColumn(
                name: "SegmentId",
                table: "TrashInspectionCases");
        }
    }
}
