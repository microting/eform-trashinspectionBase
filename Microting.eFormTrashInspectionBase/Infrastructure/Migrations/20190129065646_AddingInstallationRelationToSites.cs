using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingInstallationRelationToSites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InstallationSites_InstallationId",
                table: "InstallationSites",
                column: "InstallationId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallationSites_Installations_InstallationId",
                table: "InstallationSites",
                column: "InstallationId",
                principalTable: "Installations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstallationSites_Installations_InstallationId",
                table: "InstallationSites");

            migrationBuilder.DropIndex(
                name: "IX_InstallationSites_InstallationId",
                table: "InstallationSites");
        }
    }
}
