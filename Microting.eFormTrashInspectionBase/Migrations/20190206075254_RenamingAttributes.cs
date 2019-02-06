using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class RenamingAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fraction",
                table: "TrashInspectionVersions",
                newName: "SegmentId");

            migrationBuilder.RenameColumn(
                name: "Fraction",
                table: "TrashInspections",
                newName: "SegmentId");

            migrationBuilder.AddColumn<int>(
                name: "FractionId",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FractionId",
                table: "TrashInspections",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FractionId",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "FractionId",
                table: "TrashInspections");

            migrationBuilder.RenameColumn(
                name: "SegmentId",
                table: "TrashInspectionVersions",
                newName: "Fraction");

            migrationBuilder.RenameColumn(
                name: "SegmentId",
                table: "TrashInspections",
                newName: "Fraction");
        }
    }
}
