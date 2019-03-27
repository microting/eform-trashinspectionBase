using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class SimplifyingSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettingVersions");

            migrationBuilder.DropColumn(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettingVersions");

            migrationBuilder.DropColumn(
                name: "SelectedeFormId",
                table: "TrashInspectionPnSettingVersions");

            migrationBuilder.DropColumn(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettings");

            migrationBuilder.DropColumn(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettings");

            migrationBuilder.DropColumn(
                name: "SelectedeFormId",
                table: "TrashInspectionPnSettings");

            migrationBuilder.DropColumn(
                name: "SelectedeFormName",
                table: "TrashInspectionPnSettings");

            migrationBuilder.RenameColumn(
                name: "SelectedeFormName",
                table: "TrashInspectionPnSettingVersions",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "TrashInspectionPnSettings",
                newName: "value");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "TrashInspectionPnSettingVersions",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "TrashInspectionPnSettings",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "TrashInspectionPnSettingVersions");

            migrationBuilder.DropColumn(
                name: "name",
                table: "TrashInspectionPnSettings");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "TrashInspectionPnSettingVersions",
                newName: "SelectedeFormName");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "TrashInspectionPnSettings",
                newName: "Token");

            migrationBuilder.AddColumn<string>(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettingVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettingVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedeFormId",
                table: "TrashInspectionPnSettingVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedeFormId",
                table: "TrashInspectionPnSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedeFormName",
                table: "TrashInspectionPnSettings",
                nullable: true);
        }
    }
}
