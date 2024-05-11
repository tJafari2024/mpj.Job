﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mpj.DataLayer.Context;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    [DbContext(typeof(MpgDbContext))]
    [Migration("20240419133659_update_isconfrim")]
    partial class update_isconfrim
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.EditedItemsForEmployment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("EmploymentId")
                        .HasColumnType("bigint");

                    b.Property<int>("FiledName")
                        .HasColumnType("int");

                    b.Property<string>("FiledValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentId");

                    b.ToTable("EditedItemsForEmployments");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.EducationalRecode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal?>("Avg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CentralEducation")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<long?>("CityOfPlaceOfStudyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DegreeOfEducation")
                        .HasColumnType("int");

                    b.Property<long>("EmploymentId")
                        .HasColumnType("bigint");

                    b.Property<string>("FieldOfStudy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProvinceOfPlaceOfStudyId")
                        .HasColumnType("bigint");

                    b.Property<int?>("YearOfEndingEducation")
                        .HasColumnType("int");

                    b.Property<int?>("YearOfStartingEducation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityOfPlaceOfStudyId");

                    b.HasIndex("EmploymentId");

                    b.HasIndex("ProvinceOfPlaceOfStudyId");

                    b.ToTable("EducationalRecodes");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.Employment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AbilityTitle")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("AbilityToTravelAsAMission")
                        .HasColumnType("bit");

                    b.Property<bool?>("AbilityToWorkInClericalJobs")
                        .HasColumnType("bit");

                    b.Property<bool?>("AbilityToWorkInShifts")
                        .HasColumnType("bit");

                    b.Property<string>("AccessiblePersonFullName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("AccessiblePersonJob")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("AccessiblePersonMobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Address")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BirthCertificateId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("BrithDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CardReceiptDate")
                        .HasColumnType("datetime2");

                    b.Property<byte?>("ChildrenCount")
                        .HasColumnType("tinyint");

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CityOfIssueCityId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CountSendSms")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSendSms")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionAbsorptionUnit")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("DescriptionInspectionUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionOfAccident")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DescriptionOfPhysicalCondition")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescriptionResourceUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrivingLicences")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte>("EmploymentStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Entertainments")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ExemptionCode")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ExemptionReason")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Family")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FatherName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstFamiliarFullName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstFamiliarJob")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstFamiliarMobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<bool?>("HasEmploymentHistory")
                        .HasColumnType("bit");

                    b.Property<bool?>("HavingAnAccident")
                        .HasColumnType("bit");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Ideas")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte?>("InsuranceHistoryMonth")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("InsuranceHistoryYear")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsConfirmAbsorptionUnit")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmHumanResourceUnit")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmInspectionUnit")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JobFather")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("MaritalStatus")
                        .HasColumnType("bit");

                    b.Property<byte?>("MilitaryServiceStatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("MilitaryStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NationCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PersonalCode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PersonalImage")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte?>("PhysicalCondition")
                        .HasColumnType("tinyint");

                    b.Property<string>("PlaceOfServiceOrgan")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PlaceOfWork")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long?>("ProposedSalary")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProvinceId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProvinceOfIssueId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Religion")
                        .HasColumnType("tinyint");

                    b.Property<string>("RepresentativeFullName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RepresentativeJob")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RepresentativeMobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<long?>("ResidenceCityId")
                        .HasColumnType("bigint");

                    b.Property<byte>("ResidencePeriodByMonth")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ResidencePeriodByYear")
                        .HasColumnType("tinyint");

                    b.Property<string>("ResidencePhone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ResidencePostalCode")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long?>("ResidenceProvinceId")
                        .HasColumnType("bigint");

                    b.Property<string>("ResumeFile")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SatisfactionRules")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("SecondFamiliarFullName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SecondFamiliarJob")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SecondFamiliarMobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte>("Sect")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("SpouseCount")
                        .HasColumnType("tinyint");

                    b.Property<int?>("Step")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalNumberOfEyes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TrackingCode")
                        .HasColumnType("int");

                    b.Property<bool?>("UpdateMobile")
                        .HasColumnType("bit");

                    b.Property<bool?>("UseOfGlasses")
                        .HasColumnType("bit");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CityOfIssueCityId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("ProvinceOfIssueId");

                    b.HasIndex("ResidenceCityId");

                    b.HasIndex("ResidenceProvinceId");

                    b.ToTable("Employments");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.RegistrationDocuments", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("EmploymentId")
                        .HasColumnType("bigint");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<byte?>("TypeDocument")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentId");

                    b.ToTable("RegistrationDocuments");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.Sponsorship", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("EmploymentId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpouseJob")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SpouseMobile")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentId");

                    b.ToTable("Sponsorships");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.WorkExperience", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CityOfJobId")
                        .HasColumnType("bigint");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("EmploymentId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProvinceOfJobId")
                        .HasColumnType("bigint");

                    b.Property<string>("ReasonForLeavingWork")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("YearOfEndingJob")
                        .HasColumnType("int");

                    b.Property<int?>("YearOfStartingJob")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityOfJobId");

                    b.HasIndex("EmploymentId");

                    b.HasIndex("ProvinceOfJobId");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.ProvinceAndCity.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CityName")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProvinceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.ProvinceAndCity.Province", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProvinceName")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.EditedItemsForEmployment", b =>
                {
                    b.HasOne("Mpj.DataLayer.Entities.EmploymentForm.Employment", "Employment")
                        .WithMany("EditedItemsForEmployments")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employment");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.EducationalRecode", b =>
                {
                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.City", "CityOfPlaceOfStudy")
                        .WithMany()
                        .HasForeignKey("CityOfPlaceOfStudyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mpj.DataLayer.Entities.EmploymentForm.Employment", "Employment")
                        .WithMany("EducationalRecodes")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.Province", "ProvinceOfPlaceOfStudy")
                        .WithMany()
                        .HasForeignKey("ProvinceOfPlaceOfStudyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CityOfPlaceOfStudy");

                    b.Navigation("Employment");

                    b.Navigation("ProvinceOfPlaceOfStudy");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.Employment", b =>
                {
                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.City", "CityOfIssueCity")
                        .WithMany()
                        .HasForeignKey("CityOfIssueCityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.Province", "ProvinceOfIssue")
                        .WithMany()
                        .HasForeignKey("ProvinceOfIssueId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.City", "ResidenceCity")
                        .WithMany()
                        .HasForeignKey("ResidenceCityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.Province", "ResidenceProvince")
                        .WithMany()
                        .HasForeignKey("ResidenceProvinceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("City");

                    b.Navigation("CityOfIssueCity");

                    b.Navigation("Province");

                    b.Navigation("ProvinceOfIssue");

                    b.Navigation("ResidenceCity");

                    b.Navigation("ResidenceProvince");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.RegistrationDocuments", b =>
                {
                    b.HasOne("Mpj.DataLayer.Entities.EmploymentForm.Employment", "Employment")
                        .WithMany("RegistrationDocuments")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employment");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.Sponsorship", b =>
                {
                    b.HasOne("Mpj.DataLayer.Entities.EmploymentForm.Employment", "Employment")
                        .WithMany("Sponsorships")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employment");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.WorkExperience", b =>
                {
                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.City", "CityOfJob")
                        .WithMany()
                        .HasForeignKey("CityOfJobId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Mpj.DataLayer.Entities.EmploymentForm.Employment", "Employment")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.Province", "ProvinceOfJob")
                        .WithMany()
                        .HasForeignKey("ProvinceOfJobId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CityOfJob");

                    b.Navigation("Employment");

                    b.Navigation("ProvinceOfJob");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.ProvinceAndCity.City", b =>
                {
                    b.HasOne("Mpj.DataLayer.Entities.ProvinceAndCity.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.Employment", b =>
                {
                    b.Navigation("EditedItemsForEmployments");

                    b.Navigation("EducationalRecodes");

                    b.Navigation("RegistrationDocuments");

                    b.Navigation("Sponsorships");

                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
