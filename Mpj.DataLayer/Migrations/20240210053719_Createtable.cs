using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Createtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PersonalImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthCertificateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorshipStatus = table.Column<int>(type: "int", nullable: false),
                    JobFather = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrithState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrithCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfIssueState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfIssueCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrithDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    SponsorshipCount = table.Column<int>(type: "int", nullable: false),
                    ChildrenCount = table.Column<int>(type: "int", nullable: false),
                    SpouseJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilitaryServiceStatus = table.Column<int>(type: "int", nullable: false),
                    PlaceOfServiceOrgan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MilitaryStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfEyes = table.Column<int>(type: "int", nullable: false),
                    UseOfGlasses = table.Column<bool>(type: "bit", nullable: false),
                    PhysicalCondition = table.Column<int>(type: "int", nullable: false),
                    InsuranceHistoryMonth = table.Column<int>(type: "int", nullable: false),
                    InsuranceHistoryYear = table.Column<int>(type: "int", nullable: false),
                    HasEmploymentHistory = table.Column<bool>(type: "bit", nullable: false),
                    DrivingLicences = table.Column<int>(type: "int", nullable: false),
                    EmploymentStatus = table.Column<int>(type: "int", nullable: false),
                    ProposedSalary = table.Column<int>(type: "int", nullable: false),
                    ResidenceState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidenceCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidencePostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidencePeriodByMonth = table.Column<int>(type: "int", nullable: false),
                    ResidencePeriodByYear = table.Column<int>(type: "int", nullable: false),
                    ResidencePhone = table.Column<int>(type: "int", nullable: false),
                    DegreeOfEducation = table.Column<int>(type: "int", nullable: false),
                    ProvinceOfPlaceOfStudy = table.Column<int>(type: "int", nullable: false),
                    CityOfPlaceOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfStartingEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfEndingEducation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceOfJob = table.Column<int>(type: "int", nullable: false),
                    CityOfJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfStartingJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfEndingJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForLeavingWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstFamiliarFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstFamiliarJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstFamiliarMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondFamiliarFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondFamiliarJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondFamiliarMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessiblePersonFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessiblePersonJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessiblePersonMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityToWorkInClericalJobs = table.Column<bool>(type: "bit", nullable: false),
                    AbilityToTravelAsAMission = table.Column<bool>(type: "bit", nullable: false),
                    AbilityToWorkInShifts = table.Column<bool>(type: "bit", nullable: false),
                    AbilityTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HavingAnAccident = table.Column<bool>(type: "bit", nullable: false),
                    DescriptionOfAccident = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Entertainments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ideas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SatisfactionRules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employments");
        }
    }
}
