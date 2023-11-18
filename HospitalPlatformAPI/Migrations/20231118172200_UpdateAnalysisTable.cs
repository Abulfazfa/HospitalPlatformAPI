using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPlatformAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnalysisTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnalysisPrice",
                table: "Tests",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalysisPrice",
                table: "Tests");
        }
    }
}
