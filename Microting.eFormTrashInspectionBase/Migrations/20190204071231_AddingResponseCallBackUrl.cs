using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingResponseCallBackUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrashInspectionId",
                table: "TrashInspectionPnSettingVersions",
                newName: "TrashInspectionPnSettingId");

            migrationBuilder.AddColumn<string>(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettingVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettingVersions");

            migrationBuilder.DropColumn(
                name: "ResponseCallBackUrl",
                table: "TrashInspectionPnSettings");

            migrationBuilder.RenameColumn(
                name: "TrashInspectionPnSettingId",
                table: "TrashInspectionPnSettingVersions",
                newName: "TrashInspectionId");
        }
    }
}
