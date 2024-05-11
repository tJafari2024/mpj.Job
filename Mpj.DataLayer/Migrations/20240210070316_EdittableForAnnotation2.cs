using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mpj.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EdittableForAnnotation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Province_ProvinceId",
                table: "City");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Province",
                table: "Province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "Province",
                newName: "Provinces");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_City_ProvinceId",
                table: "Cities",
                newName: "IX_Cities_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Cities_CityId",
                table: "Employments",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Cities_CityOfIssueCityId",
                table: "Employments",
                column: "CityOfIssueCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Employments_Cities_ResidenceCityId",
                table: "Employments",
                column: "ResidenceCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Provinces_ProvinceId",
                table: "Employments",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfIssueId",
                table: "Employments",
                column: "ProvinceOfIssueId",
                principalTable: "Provinces",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Employments_Provinces_ResidenceProvinceId",
                table: "Employments",
                column: "ResidenceProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Cities_CityId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Cities_CityOfIssueCityId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Cities_CityOfJobId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Cities_CityOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Cities_ResidenceCityId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Provinces_ProvinceId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfIssueId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfJobId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Provinces_ProvinceOfPlaceOfStudyId",
                table: "Employments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employments_Provinces_ResidenceProvinceId",
                table: "Employments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "Province");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_ProvinceId",
                table: "City",
                newName: "IX_City_ProvinceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Province",
                table: "Province",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Province_ProvinceId",
                table: "City",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
