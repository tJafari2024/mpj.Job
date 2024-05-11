using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcertificate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialCertificate",
                table: "Employments");

            migrationBuilder.AddColumn<string>(
                name: "SerialBirthCertificateSection1",
                table: "Employments",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerialBirthCertificateSection2",
                table: "Employments",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerialBirthCertificateSection3",
                table: "Employments",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialBirthCertificateSection1",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "SerialBirthCertificateSection2",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "SerialBirthCertificateSection3",
                table: "Employments");

            migrationBuilder.AddColumn<string>(
                name: "SerialCertificate",
                table: "Employments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
