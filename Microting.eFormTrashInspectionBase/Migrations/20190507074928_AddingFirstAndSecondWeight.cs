using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingFirstAndSecondWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FirstWeight",
                table: "TrashInspectionVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondWeight",
                table: "TrashInspectionVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstWeight",
                table: "TrashInspections",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondWeight",
                table: "TrashInspections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstWeight",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "SecondWeight",
                table: "TrashInspectionVersions");

            migrationBuilder.DropColumn(
                name: "FirstWeight",
                table: "TrashInspections");

            migrationBuilder.DropColumn(
                name: "SecondWeight",
                table: "TrashInspections");
        }
    }
}
