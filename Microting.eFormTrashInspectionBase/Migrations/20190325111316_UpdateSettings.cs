using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class UpdateSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PluginConfigurationValues",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PluginConfigurationValueVersions_Id_Version",
                table: "PluginConfigurationValueVersions",
                columns: new[] { "Id", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PluginConfigurationValues_Name",
                table: "PluginConfigurationValues",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PluginConfigurationValueVersions_Id_Version",
                table: "PluginConfigurationValueVersions");

            migrationBuilder.DropIndex(
                name: "IX_PluginConfigurationValues_Name",
                table: "PluginConfigurationValues");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PluginConfigurationValues",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
