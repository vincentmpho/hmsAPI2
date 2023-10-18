﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hmsAPI2.Data;

namespace hmsAPI2.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("hmsAPI2.Models.ActiveEngredients", b =>
                {
                    b.Property<int>("EngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EngredientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EngredientID");

                    b.ToTable("ActiveEngredients");
                });

            modelBuilder.Entity("hmsAPI2.Models.ContraIndication", b =>
                {
                    b.Property<string>("ICD10_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActiveEngredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ICD10_code");

                    b.ToTable("ContraIndication");
                });

            modelBuilder.Entity("hmsAPI2.Models.Diagnosis", b =>
                {
                    b.Property<string>("ICD10_code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateDiagnosed")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiagnosisName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ICD10_code");

                    b.ToTable("Diagnosis");
                });

            modelBuilder.Entity("hmsAPI2.Models.Doctor", b =>
                {
                    b.Property<string>("DoctorNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("DoctorContact")
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("DoctorEmail")
                        .HasColumnType("nvarchar(125)");

                    b.Property<int>("DoctorHCRN")
                        .HasColumnType("int");

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(125)");

                    b.Property<string>("DoctorPracticeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorQualification")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DoctorSurname")
                        .HasColumnType("nvarchar(125)");

                    b.HasKey("DoctorNumber");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("hmsAPI2.Models.FirstVisit", b =>
                {
                    b.Property<int>("VisitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChronicHistory")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CurrentChronicMedication")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DoctorNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorNumber1")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("KnownAllegies")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VisitId");

                    b.HasIndex("DoctorNumber1");

                    b.ToTable("FirstVisit");
                });

            modelBuilder.Entity("hmsAPI2.Models.Interactions", b =>
                {
                    b.Property<int>("InteractionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("With")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InteractionID");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("hmsAPI2.Models.MedicalPractice", b =>
                {
                    b.Property<string>("PracticeNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PracticeNumber");

                    b.ToTable("MedicalPractice");
                });

            modelBuilder.Entity("hmsAPI2.Models.Medication", b =>
                {
                    b.Property<string>("MedicationNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ActiveEngredients")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ContraIndicationR")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Dosage")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Schedule")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Strengths")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("MedicationNumber");

                    b.ToTable("Medication");
                });

            modelBuilder.Entity("hmsAPI2.Models.Patient", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Allegies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chronic_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DATE_DIAGNOSED")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DIAGNOSIS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MEDICATION_NAME")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PatientAddress")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PatientContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("PatientDOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientEmail")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PatientGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PatientSurname")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PatientID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("hmsAPI2.Models.Phamacist", b =>
                {
                    b.Property<int>("PhamacistNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhamacistContact")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhamacistEmail")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhamacistName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhamacistRegistrationNumber")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhamacistSurname")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phamacy")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PhamacistNumber");

                    b.ToTable("Phamacist");
                });

            modelBuilder.Entity("hmsAPI2.Models.Phamacy", b =>
                {
                    b.Property<string>("PhamacyName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LicenceNumber")
                        .HasColumnType("int");

                    b.Property<string>("ResponsiblePharmacist")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PhamacyName");

                    b.ToTable("Phamacy");
                });

            modelBuilder.Entity("hmsAPI2.Models.Prescription", b =>
                {
                    b.Property<int>("PrescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dispenser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Filled")
                        .HasColumnType("bit");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MedicationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PrescriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Repeats")
                        .HasColumnType("int");

                    b.Property<int>("RepeatsLeft")
                        .HasColumnType("int");

                    b.HasKey("PrescriptionId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("hmsAPI2.Models.User", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("email");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("hmsAPI2.Models.FirstVisit", b =>
                {
                    b.HasOne("hmsAPI2.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorNumber1");
                });
#pragma warning restore 612, 618
        }
    }
}
