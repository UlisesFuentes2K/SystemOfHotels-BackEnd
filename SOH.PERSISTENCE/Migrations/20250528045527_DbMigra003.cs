using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOH.PERSISTENCE.Migrations
{
    /// <inheritdoc />
    public partial class DbMigra003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Binnacle_SRH_Booking_BookingidBooking",
                table: "SRH_Binnacle");

            migrationBuilder.DropIndex(
                name: "IX_SRH_Binnacle_BookingidBooking",
                table: "SRH_Binnacle");

            migrationBuilder.DropColumn(
                name: "BookingidBooking",
                table: "SRH_Binnacle");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "SRH_Person",
                newName: "idTypeDocument");

            migrationBuilder.RenameColumn(
                name: "document",
                table: "SRH_Person",
                newName: "idGender");

            migrationBuilder.RenameColumn(
                name: "shift",
                table: "SRH_Employee",
                newName: "idShift");

            migrationBuilder.RenameColumn(
                name: "period",
                table: "SRH_Booking",
                newName: "idPeriodBooking");

            migrationBuilder.AddColumn<int>(
                name: "idState",
                table: "SRH_Binnacle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SR_Gender",
                columns: table => new
                {
                    idGender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SR_Gender", x => x.idGender);
                });

            migrationBuilder.CreateTable(
                name: "SR_PeriodBooking",
                columns: table => new
                {
                    idPeriodBooking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    period = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SR_PeriodBooking", x => x.idPeriodBooking);
                });

            migrationBuilder.CreateTable(
                name: "SR_Shift",
                columns: table => new
                {
                    idShift = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SR_Shift", x => x.idShift);
                });

            migrationBuilder.CreateTable(
                name: "SR_State",
                columns: table => new
                {
                    idState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SR_State", x => x.idState);
                });

            migrationBuilder.CreateTable(
                name: "SR_TypeDocument",
                columns: table => new
                {
                    idTypeDocument = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SR_TypeDocument", x => x.idTypeDocument);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Person_idGender",
                table: "SRH_Person",
                column: "idGender");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Person_idTypeDocument",
                table: "SRH_Person",
                column: "idTypeDocument");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Employee_idShift",
                table: "SRH_Employee",
                column: "idShift");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Booking_idPeriodBooking",
                table: "SRH_Booking",
                column: "idPeriodBooking");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Binnacle_idBooking",
                table: "SRH_Binnacle",
                column: "idBooking");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Binnacle_idState",
                table: "SRH_Binnacle",
                column: "idState");

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Binnacle_SRH_Booking_idBooking",
                table: "SRH_Binnacle",
                column: "idBooking",
                principalTable: "SRH_Booking",
                principalColumn: "idBooking",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SRH_Binnacle_SRH_Booking_idBooking",
                table: "SRH_Binnacle");

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

            migrationBuilder.DropTable(
                name: "SR_Gender");

            migrationBuilder.DropTable(
                name: "SR_PeriodBooking");

            migrationBuilder.DropTable(
                name: "SR_Shift");

            migrationBuilder.DropTable(
                name: "SR_State");

            migrationBuilder.DropTable(
                name: "SR_TypeDocument");

            migrationBuilder.DropIndex(
                name: "IX_SRH_Person_idGender",
                table: "SRH_Person");

            migrationBuilder.DropIndex(
                name: "IX_SRH_Person_idTypeDocument",
                table: "SRH_Person");

            migrationBuilder.DropIndex(
                name: "IX_SRH_Employee_idShift",
                table: "SRH_Employee");

            migrationBuilder.DropIndex(
                name: "IX_SRH_Booking_idPeriodBooking",
                table: "SRH_Booking");

            migrationBuilder.DropIndex(
                name: "IX_SRH_Binnacle_idBooking",
                table: "SRH_Binnacle");

            migrationBuilder.DropIndex(
                name: "IX_SRH_Binnacle_idState",
                table: "SRH_Binnacle");

            migrationBuilder.DropColumn(
                name: "idState",
                table: "SRH_Binnacle");

            migrationBuilder.RenameColumn(
                name: "idTypeDocument",
                table: "SRH_Person",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "idGender",
                table: "SRH_Person",
                newName: "document");

            migrationBuilder.RenameColumn(
                name: "idShift",
                table: "SRH_Employee",
                newName: "shift");

            migrationBuilder.RenameColumn(
                name: "idPeriodBooking",
                table: "SRH_Booking",
                newName: "period");

            migrationBuilder.AddColumn<int>(
                name: "BookingidBooking",
                table: "SRH_Binnacle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Binnacle_BookingidBooking",
                table: "SRH_Binnacle",
                column: "BookingidBooking");

            migrationBuilder.AddForeignKey(
                name: "FK_SRH_Binnacle_SRH_Booking_BookingidBooking",
                table: "SRH_Binnacle",
                column: "BookingidBooking",
                principalTable: "SRH_Booking",
                principalColumn: "idBooking");
        }
    }
}
