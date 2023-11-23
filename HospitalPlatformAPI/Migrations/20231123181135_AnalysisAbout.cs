using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalPlatformAPI.Migrations
{
    /// <inheritdoc />
    public partial class AnalysisAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Groups DROP CONSTRAINT IF EXISTS FK_Groups_Offices_OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the code that attempts to drop the foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Offices_OfficeId",
                table: "Groups");
    
            // Add the altered column back with a nullable constraint
            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
    
            // Re-add the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Offices_OfficeId",
                table: "Groups",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id");
        }

    }
}
