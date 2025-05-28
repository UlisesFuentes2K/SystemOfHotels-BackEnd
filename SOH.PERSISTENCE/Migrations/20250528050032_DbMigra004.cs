using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOH.PERSISTENCE.Migrations
{
    /// <inheritdoc />
    public partial class DbMigra004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Binnacle_SR_State_idState",
                table: "SRH_Binnacle");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Booking_SR_PeriodBooking_idPeriodBooking",
                table: "SRH_Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Employee_SR_Shift_idShift",
                table: "SRH_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Person_SR_Gender_idGender",
                table: "SRH_Person");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Person_SR_TypeDocument_idTypeDocument",
                table: "SRH_Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SR_TypeDocument",
                table: "SR_TypeDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SR_State",
                table: "SR_State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SR_Shift",
                table: "SR_Shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SR_PeriodBooking",
                table: "SR_PeriodBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SR_Gender",
                table: "SR_Gender");

            migrationBuilder.RenameTable(
                name: "SR_TypeDocument",
                newName: "SRH_TypeDocument");

            migrationBuilder.RenameTable(
                name: "SR_State",
                newName: "SRH_State");

            migrationBuilder.RenameTable(
                name: "SR_Shift",
                newName: "SRH_Shift");

            migrationBuilder.RenameTable(
                name: "SR_PeriodBooking",
                newName: "SRH_PeriodBooking");

            migrationBuilder.RenameTable(
                name: "SR_Gender",
                newName: "SRH_Gender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_TypeDocument",
                table: "SRH_TypeDocument",
                column: "idTypeDocument");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_State",
                table: "SRH_State",
                column: "idState");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_Shift",
                table: "SRH_Shift",
                column: "idShift");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_PeriodBooking",
                table: "SRH_PeriodBooking",
                column: "idPeriodBooking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_Gender",
                table: "SRH_Gender",
                column: "idGender");

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Binnacle_SRH_State_idState",
                table: "SRH_Binnacle",
                column: "idState",
                principalTable: "SRH_State",
                principalColumn: "idState",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Booking_SRH_PeriodBooking_idPeriodBooking",
                table: "SRH_Booking",
                column: "idPeriodBooking",
                principalTable: "SRH_PeriodBooking",
                principalColumn: "idPeriodBooking",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Employee_SRH_Shift_idShift",
                table: "SRH_Employee",
                column: "idShift",
                principalTable: "SRH_Shift",
                principalColumn: "idShift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Person_SRH_Gender_idGender",
                table: "SRH_Person",
                column: "idGender",
                principalTable: "SRH_Gender",
                principalColumn: "idGender",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Person_SRH_TypeDocument_idTypeDocument",
                table: "SRH_Person",
                column: "idTypeDocument",
                principalTable: "SRH_TypeDocument",
                principalColumn: "idTypeDocument",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Binnacle_SRH_State_idState",
                table: "SRH_Binnacle");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Booking_SRH_PeriodBooking_idPeriodBooking",
                table: "SRH_Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Employee_SRH_Shift_idShift",
                table: "SRH_Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Person_SRH_Gender_idGender",
                table: "SRH_Person");

            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Person_SRH_TypeDocument_idTypeDocument",
                table: "SRH_Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_TypeDocument",
                table: "SRH_TypeDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_State",
                table: "SRH_State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_Shift",
                table: "SRH_Shift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_PeriodBooking",
                table: "SRH_PeriodBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_Gender",
                table: "SRH_Gender");

            migrationBuilder.RenameTable(
                name: "SRH_TypeDocument",
                newName: "SR_TypeDocument");

            migrationBuilder.RenameTable(
                name: "SRH_State",
                newName: "SR_State");

            migrationBuilder.RenameTable(
                name: "SRH_Shift",
                newName: "SR_Shift");

            migrationBuilder.RenameTable(
                name: "SRH_PeriodBooking",
                newName: "SR_PeriodBooking");

            migrationBuilder.RenameTable(
                name: "SRH_Gender",
                newName: "SR_Gender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SR_TypeDocument",
                table: "SR_TypeDocument",
                column: "idTypeDocument");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SR_State",
                table: "SR_State",
                column: "idState");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SR_Shift",
                table: "SR_Shift",
                column: "idShift");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SR_PeriodBooking",
                table: "SR_PeriodBooking",
                column: "idPeriodBooking");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SR_Gender",
                table: "SR_Gender",
                column: "idGender");

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Binnacle_SR_State_idState",
                table: "SRH_Binnacle",
                column: "idState",
                principalTable: "SR_State",
                principalColumn: "idState",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Booking_SR_PeriodBooking_idPeriodBooking",
                table: "SRH_Booking",
                column: "idPeriodBooking",
                principalTable: "SR_PeriodBooking",
                principalColumn: "idPeriodBooking",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Employee_SR_Shift_idShift",
                table: "SRH_Employee",
                column: "idShift",
                principalTable: "SR_Shift",
                principalColumn: "idShift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Person_SR_Gender_idGender",
                table: "SRH_Person",
                column: "idGender",
                principalTable: "SR_Gender",
                principalColumn: "idGender",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Person_SR_TypeDocument_idTypeDocument",
                table: "SRH_Person",
                column: "idTypeDocument",
                principalTable: "SR_TypeDocument",
                principalColumn: "idTypeDocument",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
