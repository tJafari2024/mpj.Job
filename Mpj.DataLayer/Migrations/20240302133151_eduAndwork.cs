using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class eduAndwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationalRecodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeOfEducation = table.Column<int>(type: "int", nullable: false),
                    ProvinceOfPlaceOfStudyId = table.Column<long>(type: "bigint", nullable: false),
                    CityOfPlaceOfStudyId = table.Column<long>(type: "bigint", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearOfStartingEducation = table.Column<int>(type: "int", nullable: false),
                    YearOfEndingEducation = table.Column<int>(type: "int", nullable: false),
                    Avg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmploymentId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalRecodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalRecodes_Cities_CityOfPlaceOfStudyId",
                        column: x => x.CityOfPlaceOfStudyId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalRecodes_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EducationalRecodes_Provinces_ProvinceOfPlaceOfStudyId",
                        column: x => x.ProvinceOfPlaceOfStudyId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProvinceOfJobId = table.Column<long>(type: "bigint", nullable: false),
                    CityOfJobId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    YearOfStartingJob = table.Column<int>(type: "int", nullable: false),
                    YearOfEndingJob = table.Column<int>(type: "int", nullable: false),
                    ReasonForLeavingWork = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    EmploymentId = table.Column<long>(type: "bigint", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Cities_CityOfJobId",
                        column: x => x.CityOfJobId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Provinces_ProvinceOfJobId",
                        column: x => x.ProvinceOfJobId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationalRecodes_CityOfPlaceOfStudyId",
                table: "EducationalRecodes",
                column: "CityOfPlaceOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalRecodes_EmploymentId",
                table: "EducationalRecodes",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalRecodes_ProvinceOfPlaceOfStudyId",
                table: "EducationalRecodes",
                column: "ProvinceOfPlaceOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_CityOfJobId",
                table: "WorkExperiences",
                column: "CityOfJobId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_EmploymentId",
                table: "WorkExperiences",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_ProvinceOfJobId",
                table: "WorkExperiences",
                column: "ProvinceOfJobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationalRecodes");

            migrationBuilder.DropTable(
                name: "WorkExperiences");
        }
    }
}
