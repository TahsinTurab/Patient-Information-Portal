using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientsInformationAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformation",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NCD",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PatientsInforamtion",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasEpilepsy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsInforamtion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Allergies_Details",
                columns: table => new
                {
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllergiesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies_Details", x => new { x.AllergiesID, x.PatientID });
                    table.ForeignKey(
                        name: "FK_Allergies_Details_Allergies_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Allergies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allergies_Details_PatientsInforamtion_AllergiesID",
                        column: x => x.AllergiesID,
                        principalTable: "PatientsInforamtion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diseases_Details",
                columns: table => new
                {
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "NCD_Details",
                columns: table => new
                {
                    PatientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NCDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD_Details", x => new { x.NCDID, x.PatientID });
                    table.ForeignKey(
                        name: "FK_NCD_Details_NCD_PatientID",
                        column: x => x.PatientID,
                        principalTable: "NCD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCD_Details_PatientsInforamtion_NCDID",
                        column: x => x.NCDID,
                        principalTable: "PatientsInforamtion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_Details_PatientID",
                table: "Allergies_Details",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_Details_PatientID",
                table: "Diseases_Details",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_PatientID",
                table: "NCD_Details",
                column: "PatientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies_Details");

            migrationBuilder.DropTable(
                name: "Diseases_Details");

            migrationBuilder.DropTable(
                name: "NCD_Details");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "DiseaseInformation");

            migrationBuilder.DropTable(
                name: "NCD");

            migrationBuilder.DropTable(
                name: "PatientsInforamtion");
        }
    }
}
