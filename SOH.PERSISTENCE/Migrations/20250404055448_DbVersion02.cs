using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOH.PERSISTENCE.Migrations
{
    /// <inheritdoc />
    public partial class DbVersion02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_RoomDetail",
                table: "SRH_RoomDetail");

            migrationBuilder.DropIndex(
                name: "IX_SRH_RoomDetail_idBooking",
                table: "SRH_RoomDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_CalendarDetail",
                table: "SRH_CalendarDetail");

            migrationBuilder.DropIndex(
                name: "IX_SRH_CalendarDetail_idBooking",
                table: "SRH_CalendarDetail");

            migrationBuilder.DropColumn(
                name: "idRoomDetail",
                table: "SRH_RoomDetail");

            migrationBuilder.DropColumn(
                name: "idCalendarDetail",
                table: "SRH_CalendarDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_RoomDetail",
                table: "SRH_RoomDetail",
                columns: new[] { "idBooking", "idRoom" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_CalendarDetail",
                table: "SRH_CalendarDetail",
                columns: new[] { "idBooking", "idCalendar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_RoomDetail",
                table: "SRH_RoomDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SRH_CalendarDetail",
                table: "SRH_CalendarDetail");

            migrationBuilder.AddColumn<int>(
                name: "idRoomDetail",
                table: "SRH_RoomDetail",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "idCalendarDetail",
                table: "SRH_CalendarDetail",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_RoomDetail",
                table: "SRH_RoomDetail",
                column: "idRoomDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SRH_CalendarDetail",
                table: "SRH_CalendarDetail",
                column: "idCalendarDetail");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_RoomDetail_idBooking",
                table: "SRH_RoomDetail",
                column: "idBooking");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_CalendarDetail_idBooking",
                table: "SRH_CalendarDetail",
                column: "idBooking");
        }
    }
}
