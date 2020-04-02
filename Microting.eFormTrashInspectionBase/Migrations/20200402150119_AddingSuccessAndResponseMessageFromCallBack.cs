using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingSuccessAndResponseMessageFromCallBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ResponseSendToCallBackUrl",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessageFromCallBack",
                table: "TrashInspectionVersions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ResponseSendToCallBackUrl",
                table: "TrashInspections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SuccessMessageFromCallBack",
                table: "TrashInspections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseSendToCallBackUrl",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "SuccessMessageFromCallBack",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "ResponseSendToCallBackUrl",
                table: "TrashInspections");

            migrationBuilder.DropColumn(
                name: "SuccessMessageFromCallBack",
                table: "TrashInspections");
        }
    }
}
