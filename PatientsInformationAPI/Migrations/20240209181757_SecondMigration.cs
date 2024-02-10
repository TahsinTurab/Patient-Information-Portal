using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientsInformationAPI.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseases_Details");

            migrationBuilder.AddColumn<string>(
                name: "Disease",
                table: "PatientsInforamtion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disease",
                table: "PatientsInforamtion");

            migrationBuilder.CreateTable(
                name: "Diseases_Details",
                columns: table => new
                {
                    DiseaseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases_Details", x => new { x.DiseaseID, x.PatientID });
                    table.ForeignKey(
                        name: "FK_Diseases_Details_DiseaseInformation_PatientID",
                        column: x => x.PatientID,
                        principalTable: "DiseaseInformation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diseases_Details_PatientsInforamtion_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "PatientsInforamtion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_Details_PatientID",
                table: "Diseases_Details",
                column: "PatientID");
        }
    }
}
