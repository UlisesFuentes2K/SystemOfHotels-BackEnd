using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOH.PERSISTENCE.Migrations
{
    /// <inheritdoc />
    public partial class DbMigra002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "SRH_Employee");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "SRH_Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "SRH_Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateCreation",
                table: "SRH_Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateModify",
                table: "SRH_Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "SRH_Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateCreation",
                table: "SRH_Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateModify",
                table: "SRH_Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateCreation",
                table: "SRH_Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateModify",
                table: "SRH_Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "SRH_Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "SRH_Users");

            migrationBuilder.DropColumn(
                name: "dateCreation",
                table: "SRH_Users");

            migrationBuilder.DropColumn(
                name: "dateModify",
                table: "SRH_Users");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "SRH_Users");

            migrationBuilder.DropColumn(
                name: "dateCreation",
                table: "SRH_Person");

            migrationBuilder.DropColumn(
                name: "dateModify",
                table: "SRH_Person");

            migrationBuilder.DropColumn(
                name: "dateCreation",
                table: "SRH_Employee");

            migrationBuilder.DropColumn(
                name: "dateModify",
                table: "SRH_Employee");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "SRH_Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
