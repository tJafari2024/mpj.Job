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
    [Migration("20240210053719_Createtable")]
    partial class Createtable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mpj.DataLayer.Entities.EmploymentForm.Employment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AbilityTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AbilityToTravelAsAMission")
                        .HasColumnType("bit");

                    b.Property<bool>("AbilityToWorkInClericalJobs")
                        .HasColumnType("bit");

                    b.Property<bool>("AbilityToWorkInShifts")
                        .HasColumnType("bit");

                    b.Property<string>("AccessiblePersonFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccessiblePersonJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccessiblePersonMobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Avg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BirthCertificateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrithCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BrithDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BrithState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CardReceiptDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ChildrenCount")
                        .HasColumnType("int");

                    b.Property<string>("CityOfJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityOfPlaceOfStudy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DegreeOfEducation")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionOfAccident")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrivingLicences")
                        .HasColumnType("int");

                    b.Property<int>("EmploymentStatus")
                        .HasColumnType("int");

                    b.Property<string>("Entertainments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldOfStudy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstFamiliarFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstFamiliarJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstFamiliarMobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("HasEmploymentHistory")
                        .HasColumnType("bit");

                    b.Property<bool>("HavingAnAccident")
                        .HasColumnType("bit");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Ideas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsuranceHistoryMonth")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceHistoryYear")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("JobFather")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<int>("MilitaryServiceStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("MilitaryStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationCode")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PersonalImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhysicalCondition")
                        .HasColumnType("int");

                    b.Property<string>("PlaceOfIssueCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfIssueState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfServiceOrgan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProposedSalary")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceOfJob")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceOfPlaceOfStudy")
                        .HasColumnType("int");

                    b.Property<string>("ReasonForLeavingWork")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidenceCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResidencePeriodByMonth")
                        .HasColumnType("int");

                    b.Property<int>("ResidencePeriodByYear")
                        .HasColumnType("int");

                    b.Property<int>("ResidencePhone")
                        .HasColumnType("int");

                    b.Property<string>("ResidencePostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidenceState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SatisfactionRules")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondFamiliarFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondFamiliarJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondFamiliarMobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SponsorshipCount")
                        .HasColumnType("int");

                    b.Property<int>("SponsorshipStatus")
                        .HasColumnType("int");

                    b.Property<string>("SpouseJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseMobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalNumberOfEyes")
                        .HasColumnType("int");

                    b.Property<bool>("UseOfGlasses")
                        .HasColumnType("bit");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<string>("YearOfEndingEducation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfEndingJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfStartingEducation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfStartingJob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employments");
                });
#pragma warning restore 612, 618
        }
    }
}
