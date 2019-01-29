using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingMissingInclude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspectionCase_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrashInspectionCase",
                table: "TrashInspectionCase");

            migrationBuilder.RenameTable(
                name: "TrashInspectionCase",
                newName: "TrashInspectionCases");

            migrationBuilder.RenameIndex(
                name: "IX_TrashInspectionCase_TrashInspectionId",
                table: "TrashInspectionCases",
                newName: "IX_TrashInspectionCases_TrashInspectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrashInspectionCases",
                table: "TrashInspectionCases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspectionCases_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCases",
                column: "TrashInspectionId",
                principalTable: "TrashInspections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrashInspectionCases_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrashInspectionCases",
                table: "TrashInspectionCases");

            migrationBuilder.RenameTable(
                name: "TrashInspectionCases",
                newName: "TrashInspectionCase");

            migrationBuilder.RenameIndex(
                name: "IX_TrashInspectionCases_TrashInspectionId",
                table: "TrashInspectionCase",
                newName: "IX_TrashInspectionCase_TrashInspectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrashInspectionCase",
                table: "TrashInspectionCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrashInspectionCase_TrashInspections_TrashInspectionId",
                table: "TrashInspectionCase",
                column: "TrashInspectionId",
                principalTable: "TrashInspections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
