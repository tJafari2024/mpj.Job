using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addfiledToSpouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "BasicInsurance",
                table: "Sponsorships",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCertificateId",
                table: "Sponsorships",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BrithDate",
                table: "Sponsorships",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Sponsorships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Sponsorships",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Sponsorships",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCovered",
                table: "Sponsorships",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MaritalStatus",
                table: "Sponsorships",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sponsorships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationCode",
                table: "Sponsorships",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ProvinceId",
                table: "Sponsorships",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProvinceOfIssueId",
                table: "Sponsorships",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Relation",
                table: "Sponsorships",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialInsurance",
                table: "Sponsorships",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicInsurance",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "BirthCertificateId",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "BrithDate",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "IsCovered",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "NationCode",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "ProvinceOfIssueId",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "Relation",
                table: "Sponsorships");

            migrationBuilder.DropColumn(
                name: "SerialInsurance",
                table: "Sponsorships");
        }
    }
}
