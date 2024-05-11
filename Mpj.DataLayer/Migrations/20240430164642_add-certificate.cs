using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcertificate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialCertificate",
                table: "Employments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialCertificate",
                table: "Employments");
        }
    }
}
