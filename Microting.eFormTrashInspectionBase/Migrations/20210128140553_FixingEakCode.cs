using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class FixingEakCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Eak_Code",
                table: "TrashInspections",
                "EakCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EakCode",
                table: "TrashInspections",
                "Eak_Code");
        }
    }
}
