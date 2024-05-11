using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class takmiliinfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfMarriage",
                table: "Employments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceNumber",
                table: "Employments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TejaratBankNumber",
                table: "Employments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TejaratSheba",
                table: "Employments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfMarriage",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "InsuranceNumber",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "TejaratBankNumber",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "TejaratSheba",
                table: "Employments");
        }
    }
}
