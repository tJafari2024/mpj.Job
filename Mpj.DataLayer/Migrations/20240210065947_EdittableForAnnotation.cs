using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EdittableForAnnotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrithCity",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "BrithState",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityOfJob",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityOfPlaceOfStudy",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "PlaceOfIssueCity",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "PlaceOfIssueState",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceOfJob",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceOfPlaceOfStudy",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ResidenceCity",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ResidenceState",
                table: "Employments");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfStartingJob",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfStartingEducation",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfEndingJob",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfEndingEducation",
                table: "Employments",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SpouseMobile",
                table: "Employments",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SpouseJob",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Sect",
                table: "Employments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondFamiliarMobile",
                table: "Employments",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondFamiliarJob",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondFamiliarFullName",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResidencePostalCode",
                table: "Employments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResidencePhone",
                table: "Employments",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Religion",
                table: "Employments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ReasonForLeavingWork",
                table: "Employments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceOfServiceOrgan",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalImage",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NationCode",
                table: "Employments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JobFather",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstFamiliarMobile",
                table: "Employments",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstFamiliarJob",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstFamiliarFullName",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FieldOfStudy",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "Employments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Family",
                table: "Employments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccessiblePersonMobile",
                table: "Employments",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccessiblePersonJob",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AccessiblePersonFullName",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ARepresentativeFullName",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employments",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CityOfIssueCityId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.AddColumn<long>(
                name: "ProvinceId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProvinceOfIssueId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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
                name: "RepresentativeJob",
                table: "Employments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RepresentativeMobile",
                table: "Employments",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ResidenceCityId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ResidenceProvinceId",
                table: "Employments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employments_CityId",
                table: "Employments",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_CityOfIssueCityId",
                table: "Employments",
                column: "CityOfIssueCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_CityOfJobId",
                table: "Employments",
                column: "CityOfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_CityOfPlaceOfStudyId",
                table: "Employments",
                column: "CityOfPlaceOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ProvinceId",
                table: "Employments",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ProvinceOfIssueId",
                table: "Employments",
                column: "ProvinceOfIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ProvinceOfJobId",
                table: "Employments",
                column: "ProvinceOfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ProvinceOfPlaceOfStudyId",
                table: "Employments",
                column: "ProvinceOfPlaceOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ResidenceCityId",
                table: "Employments",
                column: "ResidenceCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_ResidenceProvinceId",
                table: "Employments",
                column: "ResidenceProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceId",
                table: "City",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_City_CityId",
                table: "Employments",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_City_CityOfIssueCityId",
                table: "Employments",
                column: "CityOfIssueCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_City_CityOfJobId",
                table: "Employments",
                column: "CityOfJobId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_City_CityOfPlaceOfStudyId",
                table: "Employments",
                column: "CityOfPlaceOfStudyId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_City_ResidenceCityId",
                table: "Employments",
                column: "ResidenceCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Province_ProvinceId",
                table: "Employments",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Province_ProvinceOfIssueId",
                table: "Employments",
                column: "ProvinceOfIssueId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Province_ProvinceOfJobId",
                table: "Employments",
                column: "ProvinceOfJobId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Province_ProvinceOfPlaceOfStudyId",
                table: "Employments",
                column: "ProvinceOfPlaceOfStudyId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Province_ResidenceProvinceId",
                table: "Employments",
                column: "ResidenceProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employments_City_CityId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_City_CityOfIssueCityId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_City_CityOfJobId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_City_CityOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_City_ResidenceCityId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Province_ProvinceId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Province_ProvinceOfIssueId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Province_ProvinceOfJobId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Province_ProvinceOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Province_ResidenceProvinceId",
                table: "Employments");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Employments_CityId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_CityOfIssueCityId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_CityOfJobId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_CityOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ProvinceId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ProvinceOfIssueId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ProvinceOfJobId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ProvinceOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ResidenceCityId",
                table: "Employments");

            migrationBuilder.DropIndex(
                name: "IX_Employments_ResidenceProvinceId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ARepresentativeFullName",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityOfIssueCityId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityOfJobId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "CityOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceOfIssueId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceOfJobId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ProvinceOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "RepresentativeJob",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "RepresentativeMobile",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ResidenceCityId",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "ResidenceProvinceId",
                table: "Employments");

            migrationBuilder.AlterColumn<string>(
                name: "YearOfStartingJob",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "YearOfStartingEducation",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "YearOfEndingJob",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "YearOfEndingEducation",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseMobile",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "SpouseJob",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Sect",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SecondFamiliarMobile",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "SecondFamiliarJob",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SecondFamiliarFullName",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ResidencePostalCode",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "ResidencePhone",
                table: "Employments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Religion",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ReasonForLeavingWork",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceOfServiceOrgan",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PersonalImage",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NationCode",
                table: "Employments",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "JobFather",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstFamiliarMobile",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "FirstFamiliarJob",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FirstFamiliarFullName",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FieldOfStudy",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Family",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "AccessiblePersonMobile",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "AccessiblePersonJob",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "AccessiblePersonFullName",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "BrithCity",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrithState",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityOfJob",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityOfPlaceOfStudy",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfIssueCity",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfIssueState",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceOfJob",
                table: "Employments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceOfPlaceOfStudy",
                table: "Employments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResidenceCity",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResidenceState",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
