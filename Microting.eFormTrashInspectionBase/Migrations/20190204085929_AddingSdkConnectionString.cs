using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingSdkConnectionString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettingVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettingVersions");

            migrationBuilder.DropColumn(
                name: "SdkConnectionString",
                table: "TrashInspectionPnSettings");
        }
    }
}
