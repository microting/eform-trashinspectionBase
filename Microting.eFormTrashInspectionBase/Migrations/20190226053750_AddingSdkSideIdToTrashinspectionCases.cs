using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingSdkSideIdToTrashinspectionCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SdkSiteId",
                table: "TrashInspectionCaseVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SdkSiteId",
                table: "TrashInspectionCases",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SdkSiteId",
                table: "TrashInspectionCaseVersions");

            migrationBuilder.DropColumn(
                name: "SdkSiteId",
                table: "TrashInspectionCases");
        }
    }
}
