using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPlatformAPI.Migrations
{
    /// <inheritdoc />
    public partial class TestNameAndEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AnalysisResults_AnalysisResultId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "AnalysisImageUrl",
                table: "AnalysisResults");

            migrationBuilder.DropColumn(
                name: "TestConclusion",
                table: "AnalysisResults");

            migrationBuilder.RenameColumn(
                name: "AnalysisResultId",
                table: "Tests",
                newName: "TestResultId");

            migrationBuilder.RenameColumn(
                name: "AnalysisPrice",
                table: "Tests",
                newName: "TestPrice");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_AnalysisResultId",
                table: "Tests",
                newName: "IX_Tests_TestResultId");

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestConclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestNameAndResultEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestNameAndResultEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestNameAndResultEntry_TestResult_TestResultId",
                        column: x => x.TestResultId,
                        principalTable: "TestResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestNameAndResultEntry_TestResultId",
                table: "TestNameAndResultEntry",
                column: "TestResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_TestResult_TestResultId",
                table: "Tests",
                column: "TestResultId",
                principalTable: "TestResult",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_TestResult_TestResultId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "TestNameAndResultEntry");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.RenameColumn(
                name: "TestResultId",
                table: "Tests",
                newName: "AnalysisResultId");

            migrationBuilder.RenameColumn(
                name: "TestPrice",
                table: "Tests",
                newName: "AnalysisPrice");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_TestResultId",
                table: "Tests",
                newName: "IX_Tests_AnalysisResultId");

            migrationBuilder.AddColumn<string>(
                name: "AnalysisImageUrl",
                table: "AnalysisResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestConclusion",
                table: "AnalysisResults",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AnalysisResults_AnalysisResultId",
                table: "Tests",
                column: "AnalysisResultId",
                principalTable: "AnalysisResults",
                principalColumn: "Id");
        }
    }
}
