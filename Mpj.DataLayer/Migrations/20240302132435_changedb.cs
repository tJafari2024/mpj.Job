using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class changedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Cities_CityOfJobId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Cities_CityOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfJobId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_CityOfJobId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_CityOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ProvinceOfJobId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ProvinceOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "Avg",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityOfJobId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "DegreeOfEducation",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "FieldOfStudy",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceOfJobId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ReasonForLeavingWork",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "YearOfEndingEducation",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "YearOfEndingJob",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "YearOfStartingEducation",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "YearOfStartingJob",
                table: "Employments");

            migrationBuilder.AlterColumn<string>(
                name: "BirthCertificateId",
                table: "Employments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ExemptionCode",
                table: "Employments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExemptionReason",
                table: "Employments",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExemptionCode",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ExemptionReason",
                table: "Employments");

            migrationBuilder.AlterColumn<string>(
                name: "BirthCertificateId",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<decimal>(
                name: "Avg",
                table: "Employments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "CityOfJobId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CityOfPlaceOfStudyId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DegreeOfEducation",
                table: "Employments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FieldOfStudy",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ProvinceOfJobId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProvinceOfPlaceOfStudyId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForLeavingWork",
                table: "Employments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearOfEndingEducation",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearOfEndingJob",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearOfStartingEducation",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YearOfStartingJob",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_CityOfJobId",
                table: "Employments",
                column: "CityOfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_CityOfPlaceOfStudyId",
                table: "Employments",
                column: "CityOfPlaceOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ProvinceOfJobId",
                table: "Employments",
                column: "ProvinceOfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ProvinceOfPlaceOfStudyId",
                table: "Employments",
                column: "ProvinceOfPlaceOfStudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Cities_CityOfJobId",
                table: "Employments",
                column: "CityOfJobId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Cities_CityOfPlaceOfStudyId",
                table: "Employments",
                column: "CityOfPlaceOfStudyId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfJobId",
                table: "Employments",
                column: "ProvinceOfJobId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfPlaceOfStudyId",
                table: "Employments",
                column: "ProvinceOfPlaceOfStudyId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
