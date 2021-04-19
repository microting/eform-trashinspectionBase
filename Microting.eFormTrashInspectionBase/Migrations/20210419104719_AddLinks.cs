using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstallationSites_Installations_InstallationId",
                table: "InstallationSites");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspectionCases_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCases");

            migrationBuilder.CreateIndex(
                name: "IX_TrashInspections_FractionId",
                table: "TrashInspections",
                column: "FractionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrashInspections_InstallationId",
                table: "TrashInspections",
                column: "InstallationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrashInspections_SegmentId",
                table: "TrashInspections",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TrashInspectionCases_SegmentId",
                table: "TrashInspectionCases",
                column: "SegmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallationSites_Installations_InstallationId",
                table: "InstallationSites",
                column: "InstallationId",
                principalTable: "Installations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspectionCases_Segments_SegmentId",
                table: "TrashInspectionCases",
                column: "SegmentId",
                principalTable: "Segments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspectionCases_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCases",
                column: "TrashInspectionId",
                principalTable: "TrashInspections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspections_Fractions_FractionId",
                table: "TrashInspections",
                column: "FractionId",
                principalTable: "Fractions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspections_Installations_InstallationId",
                table: "TrashInspections",
                column: "InstallationId",
                principalTable: "Installations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspections_Segments_SegmentId",
                table: "TrashInspections",
                column: "SegmentId",
                principalTable: "Segments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstallationSites_Installations_InstallationId",
                table: "InstallationSites");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspectionCases_Segments_SegmentId",
                table: "TrashInspectionCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspectionCases_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspections_Fractions_FractionId",
                table: "TrashInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspections_Installations_InstallationId",
                table: "TrashInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspections_Segments_SegmentId",
                table: "TrashInspections");

            migrationBuilder.DropIndex(
                name: "IX_TrashInspections_FractionId",
                table: "TrashInspections");

            migrationBuilder.DropIndex(
                name: "IX_TrashInspections_InstallationId",
                table: "TrashInspections");

            migrationBuilder.DropIndex(
                name: "IX_TrashInspections_SegmentId",
                table: "TrashInspections");

            migrationBuilder.DropIndex(
                name: "IX_TrashInspectionCases_SegmentId",
                table: "TrashInspectionCases");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallationSites_Installations_InstallationId",
                table: "InstallationSites",
                column: "InstallationId",
                principalTable: "Installations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspectionCases_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCases",
                column: "TrashInspectionId",
                principalTable: "TrashInspections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
