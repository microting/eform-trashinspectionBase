using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormTrashInspectionBase.Migrations
{
    public partial class AddingTrashInspectionCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TrashInspections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TrashInspectionCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TrashInspectionId = table.Column<int>(nullable: false),
                    SdkCaseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrashInspectionCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrashInspectionCase_TrashInspections_TrashInspectionId",
                        column: x => x.TrashInspectionId,
                        principalTable: "TrashInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrashInspectionCase_TrashInspectionId",
                table: "TrashInspectionCase",
                column: "TrashInspectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrashInspectionCase");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TrashInspections");
        }
    }
}
