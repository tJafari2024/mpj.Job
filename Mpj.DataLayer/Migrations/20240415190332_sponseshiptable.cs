using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class sponseshiptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SponsorshipCount",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "SponsorshipStatus",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "SpouseJob",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "SpouseMobile",
                table: "Employments");

            migrationBuilder.AlterColumn<int>(
                name: "DegreeOfEducation",
                table: "EducationalRecodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Avg",
                table: "EducationalRecodes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Sponsorships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpouseJob = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SpouseMobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    EmploymentId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsorships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sponsorships_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sponsorships_EmploymentId",
                table: "Sponsorships",
                column: "EmploymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sponsorships");

            migrationBuilder.AddColumn<int>(
                name: "SponsorshipCount",
                table: "Employments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "SponsorshipStatus",
                table: "Employments",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpouseJob",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpouseMobile",
                table: "Employments",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DegreeOfEducation",
                table: "EducationalRecodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Avg",
                table: "EducationalRecodes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
