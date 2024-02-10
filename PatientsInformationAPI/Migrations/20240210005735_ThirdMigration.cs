using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientsInformationAPI.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Details_Allergies_PatientID",
                table: "Allergies_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Details_PatientsInforamtion_AllergiesID",
                table: "Allergies_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_NCD_PatientID",
                table: "NCD_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_PatientsInforamtion_NCDID",
                table: "NCD_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details");

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "NCD_Details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ID",
                table: "Allergies_Details",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AllergyID",
                table: "Allergies_Details",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_NCDID",
                table: "NCD_Details",
                column: "NCDID");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_AllergyID",
                table: "Allergies_Details",
                column: "AllergyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Details_Allergies_AllergyID",
                table: "Allergies_Details",
                column: "AllergyID",
                principalTable: "Allergies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Details_PatientsInforamtion_PatientID",
                table: "Allergies_Details",
                column: "PatientID",
                principalTable: "PatientsInforamtion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_NCD_NCDID",
                table: "NCD_Details",
                column: "NCDID",
                principalTable: "NCD",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_PatientsInforamtion_PatientID",
                table: "NCD_Details",
                column: "PatientID",
                principalTable: "PatientsInforamtion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Details_Allergies_AllergyID",
                table: "Allergies_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Allergies_Details_PatientsInforamtion_PatientID",
                table: "Allergies_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_NCD_NCDID",
                table: "NCD_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_NCD_Details_PatientsInforamtion_PatientID",
                table: "NCD_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details");

            migrationBuilder.DropIndex(
                name: "IX_NCD_Details_NCDID",
                table: "NCD_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_Details_AllergyID",
                table: "Allergies_Details");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "NCD_Details");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Allergies_Details");

            migrationBuilder.DropColumn(
                name: "AllergyID",
                table: "Allergies_Details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NCD_Details",
                table: "NCD_Details",
                columns: new[] { "NCDID", "PatientID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies_Details",
                table: "Allergies_Details",
                columns: new[] { "AllergiesID", "PatientID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Details_Allergies_PatientID",
                table: "Allergies_Details",
                column: "PatientID",
                principalTable: "Allergies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allergies_Details_PatientsInforamtion_AllergiesID",
                table: "Allergies_Details",
                column: "AllergiesID",
                principalTable: "PatientsInforamtion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_NCD_PatientID",
                table: "NCD_Details",
                column: "PatientID",
                principalTable: "NCD",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NCD_Details_PatientsInforamtion_NCDID",
                table: "NCD_Details",
                column: "NCDID",
                principalTable: "PatientsInforamtion",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
