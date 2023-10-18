using Microsoft.EntityFrameworkCore.Migrations;

namespace hmsAPI2.Data.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Phamacy",
                table: "Phamacy");

            migrationBuilder.DropColumn(
                name: "PhamacyNumber",
                table: "Phamacy");

            migrationBuilder.DropColumn(
                name: "PhamacyLicenceNumber",
                table: "Phamacy");

            migrationBuilder.RenameColumn(
                name: "PhamacyEmail",
                table: "Phamacy",
                newName: "ResponsiblePharmacist");

            migrationBuilder.RenameColumn(
                name: "PhamacyContact",
                table: "Phamacy",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "PhamacyAddress",
                table: "Phamacy",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "Phamacist",
                table: "Phamacy",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhamacyName",
                table: "Phamacy",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LicenceNumber",
                table: "Phamacy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MEDICATION_NAME",
                table: "Patient",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phamacy",
                table: "Phamacy",
                column: "PhamacyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Phamacy",
                table: "Phamacy");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LicenceNumber",
                table: "Phamacy");

            migrationBuilder.RenameColumn(
                name: "ResponsiblePharmacist",
                table: "Phamacy",
                newName: "PhamacyEmail");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Phamacy",
                newName: "PhamacyAddress");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Phamacy",
                newName: "PhamacyContact");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Phamacy",
                newName: "Phamacist");

            migrationBuilder.AlterColumn<string>(
                name: "PhamacyName",
                table: "Phamacy",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "PhamacyNumber",
                table: "Phamacy",
                type: "nvarchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PhamacyLicenceNumber",
                table: "Phamacy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MEDICATION_NAME",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phamacy",
                table: "Phamacy",
                column: "PhamacyNumber");
        }
    }
}
