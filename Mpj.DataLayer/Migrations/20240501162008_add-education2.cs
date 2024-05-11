using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addeducation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEndOfDegreeOfEducation",
                table: "EducationalRecodes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEndOfDegreeOfEducation",
                table: "EducationalRecodes");
        }
    }
}
