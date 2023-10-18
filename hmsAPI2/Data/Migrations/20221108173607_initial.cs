using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hmsAPI2.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveEngredients",
                columns: table => new
                {
                    EngredientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngredientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveEngredients", x => x.EngredientID);
                });

            migrationBuilder.CreateTable(
                name: "ContraIndication",
                columns: table => new
                {
                    ICD10_code = table.Column<string>(nullable: false),
                    ActiveEngredients = table.Column<string>(nullable: true),
                    Diagnosis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraIndication", x => x.ICD10_code);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    ICD10_code = table.Column<string>(nullable: false),
                    DiagnosisName = table.Column<string>(nullable: true),
                    DateDiagnosed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.ICD10_code);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DoctorSurname = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DoctorContact = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DoctorEmail = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    DoctorQualification = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    DoctorPracticeNumber = table.Column<string>(nullable: true),
                    DoctorHCRN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorNumber);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    InteractionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    With = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.InteractionID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalPractice",
                columns: table => new
                {
                    PracticeNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPractice", x => x.PracticeNumber);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    MedicationNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ActiveEngredients = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Strengths = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Schedule = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ContraIndicationR = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedicationNumber);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PatientSurname = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PatientAddress = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    PatientContact = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PatientEmail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PatientDOB = table.Column<DateTime>(nullable: false),
                    PatientGender = table.Column<string>(nullable: true),
                    Allegies = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "Phamacist",
                columns: table => new
                {
                    PhamacistNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhamacistName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhamacistSurname = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhamacistContact = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhamacistEmail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhamacistRegistrationNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Phamacy = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phamacist", x => x.PhamacistNumber);
                });

            migrationBuilder.CreateTable(
                name: "Phamacy",
                columns: table => new
                {
                    PhamacyNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PhamacyName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhamacyContact = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PhamacyEmail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhamacyAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Phamacist = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhamacyLicenceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phamacy", x => x.PhamacyNumber);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionDate = table.Column<DateTime>(nullable: false),
                    MedicationNumber = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Repeats = table.Column<int>(nullable: false),
                    RepeatsLeft = table.Column<int>(nullable: false),
                    Dispenser = table.Column<string>(nullable: true),
                    Filled = table.Column<bool>(nullable: false),
                    PatientID = table.Column<string>(nullable: true),
                    DoctorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "FirstVisit",
                columns: table => new
                {
                    VisitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChronicHistory = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DoctorNumber = table.Column<string>(nullable: true),
                    DoctorNumber1 = table.Column<string>(nullable: true),
                    CurrentChronicMedication = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    KnownAllegies = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstVisit", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_FirstVisit_Doctor_DoctorNumber1",
                        column: x => x.DoctorNumber1,
                        principalTable: "Doctor",
                        principalColumn: "DoctorNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstVisit_DoctorNumber1",
                table: "FirstVisit",
                column: "DoctorNumber1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveEngredients");

            migrationBuilder.DropTable(
                name: "ContraIndication");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "FirstVisit");

            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "MedicalPractice");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Phamacist");

            migrationBuilder.DropTable(
                name: "Phamacy");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
