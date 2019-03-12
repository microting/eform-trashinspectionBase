/*
The MIT License (MIT)

Copyright (c) 2007 - 2019 microting

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
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
