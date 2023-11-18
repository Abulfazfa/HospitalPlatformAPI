using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPlatformAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAnalysisTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_TestResults_TestResultId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "ResultEntries");

            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "TestResultId",
                table: "Tests",
                newName: "AnalysisResultId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tests",
                newName: "AnalysisName");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_TestResultId",
                table: "Tests",
                newName: "IX_Tests_AnalysisResultId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReady",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AnalysisResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalysisImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestConclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    AnalysisResultId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analyses_AnalysisResults_AnalysisResultId",
                        column: x => x.AnalysisResultId,
                        principalTable: "AnalysisResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnalysisNameAndResultEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalysisResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisNameAndResultEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisNameAndResultEntries_AnalysisResults_AnalysisResultId",
                        column: x => x.AnalysisResultId,
                        principalTable: "AnalysisResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tests_AppUserId",
                table: "Tests",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_AnalysisResultId",
                table: "Analyses",
                column: "AnalysisResultId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisNameAndResultEntries_AnalysisResultId",
                table: "AnalysisNameAndResultEntries",
                column: "AnalysisResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AnalysisResults_AnalysisResultId",
                table: "Tests",
                column: "AnalysisResultId",
                principalTable: "AnalysisResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_AppUserId",
                table: "Tests",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AnalysisResults_AnalysisResultId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_AppUserId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "AnalysisNameAndResultEntries");

            migrationBuilder.DropTable(
                name: "AnalysisResults");

            migrationBuilder.DropIndex(
                name: "IX_Tests_AppUserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "IsReady",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "AnalysisResultId",
                table: "Tests",
                newName: "TestResultId");

            migrationBuilder.RenameColumn(
                name: "AnalysisName",
                table: "Tests",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_AnalysisResultId",
                table: "Tests",
                newName: "IX_Tests_TestResultId");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Tests",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TestConclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestResultId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultEntries_TestResults_TestResultId",
                        column: x => x.TestResultId,
                        principalTable: "TestResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResultEntries_TestResultId",
                table: "ResultEntries",
                column: "TestResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_TestResults_TestResultId",
                table: "Tests",
                column: "TestResultId",
                principalTable: "TestResults",
                principalColumn: "Id");
        }
    }
}
