using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingProducerTransporter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrashInspctionId",
                table: "TrashInspectionVersions",
                newName: "TrashInspectionId");

            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransporterId",
                table: "TrashInspectionVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "TrashInspections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransporterId",
                table: "TrashInspections",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "TransporterId",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "TrashInspections");

            migrationBuilder.DropColumn(
                name: "TransporterId",
                table: "TrashInspections");

            migrationBuilder.RenameColumn(
                name: "TrashInspectionId",
                table: "TrashInspectionVersions",
                newName: "TrashInspctionId");
        }
    }
}
