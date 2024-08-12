using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Padrrif.Migrations
{
    /// <inheritdoc />
    public partial class Log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNumberOnHoursDevice",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyFather",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GrandFather",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IBAN",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobNo",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameInEnglish",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicGovernment",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SignaturePath",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkStartedIn",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmployeeNumberOnHoursDevice",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FamilyFather",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GrandFather",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IBAN",
                table: "User");

            migrationBuilder.DropColumn(
                name: "JobNo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NameInEnglish",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PublicGovernment",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SignaturePath",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "User");

            migrationBuilder.DropColumn(
                name: "WorkStartedIn",
                table: "User");
        }
    }
}
