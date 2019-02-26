using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingAttributesToFractions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemNumber",
                table: "FractionVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "FractionVersions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNumber",
                table: "Fractions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "Fractions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "FractionVersions");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "FractionVersions");

            migrationBuilder.DropColumn(
                name: "ItemNumber",
                table: "Fractions");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "Fractions");
        }
    }
}
