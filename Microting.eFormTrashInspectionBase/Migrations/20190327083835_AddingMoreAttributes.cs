using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingMoreAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedValue",
                table: "TrashInspectionVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "TrashInspectionVersions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedValue",
                table: "TrashInspections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "TrashInspections",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "TrashInspections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "eFormIdExtendedInspection",
                table: "FractionVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "eFormIdExtendedInspection",
                table: "Fractions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedValue",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "ApprovedValue",
                table: "TrashInspections");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "TrashInspections");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "TrashInspections");

            migrationBuilder.DropColumn(
                name: "eFormIdExtendedInspection",
                table: "FractionVersions");

            migrationBuilder.DropColumn(
                name: "eFormIdExtendedInspection",
                table: "Fractions");
        }
    }
}
