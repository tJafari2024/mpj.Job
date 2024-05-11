using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class update_isconfrim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsConfirm",
                table: "Employments",
                newName: "IsConfirmInspectionUnit");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Employments",
                newName: "DescriptionAbsorptionUnit");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionInspectionUnit",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionResourceUnit",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmAbsorptionUnit",
                table: "Employments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmHumanResourceUnit",
                table: "Employments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionInspectionUnit",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "DescriptionResourceUnit",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "IsConfirmAbsorptionUnit",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "IsConfirmHumanResourceUnit",
                table: "Employments");

            migrationBuilder.RenameColumn(
                name: "IsConfirmInspectionUnit",
                table: "Employments",
                newName: "IsConfirm");

            migrationBuilder.RenameColumn(
                name: "DescriptionAbsorptionUnit",
                table: "Employments",
                newName: "Description");
        }
    }
}
