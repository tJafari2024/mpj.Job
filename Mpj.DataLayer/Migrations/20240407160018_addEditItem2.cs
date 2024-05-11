using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addEditItem2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "EditedItemsForEmployments");

            migrationBuilder.RenameColumn(
                name: "PhysicalCondition",
                table: "EditedItemsForEmployments",
                newName: "FiledName");

            migrationBuilder.RenameColumn(
                name: "ExemptionReason",
                table: "EditedItemsForEmployments",
                newName: "FiledValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FiledValue",
                table: "EditedItemsForEmployments",
                newName: "ExemptionReason");

            migrationBuilder.RenameColumn(
                name: "FiledName",
                table: "EditedItemsForEmployments",
                newName: "PhysicalCondition");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EditedItemsForEmployments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
