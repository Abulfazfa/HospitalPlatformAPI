using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HospitalPlatformAPI.Migrations
{
    public partial class NaborotQizisiyoruz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Doctors",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Doctors",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Doctors");
        }
    }
}