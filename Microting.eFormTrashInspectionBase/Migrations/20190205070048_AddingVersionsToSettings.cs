using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingVersionsToSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "value",
                table: "TrashInspectionPnSettingVersions",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TrashInspectionPnSettingVersions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "TrashInspectionPnSettings",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "TrashInspectionPnSettings",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "TrashInspectionPnSettingVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "TrashInspectionPnSettings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "TrashInspectionPnSettingVersions");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "TrashInspectionPnSettings");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "TrashInspectionPnSettingVersions",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TrashInspectionPnSettingVersions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "TrashInspectionPnSettings",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TrashInspectionPnSettings",
                newName: "name");
        }
    }
}
