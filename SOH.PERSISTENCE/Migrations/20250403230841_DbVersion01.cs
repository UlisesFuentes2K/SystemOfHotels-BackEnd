using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOH.PERSISTENCE.Migrations
{
    /// <inheritdoc />
    public partial class DbVersion01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Calendar",
                columns: table => new
                {
                    idCalendar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Calendar", x => x.idCalendar);
                });

            migrationBuilder.CreateTable(
                name: "SRH_CategoryRoom",
                columns: table => new
                {
                    idCategoryRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cost = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_CategoryRoom", x => x.idCategoryRoom);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Country",
                columns: table => new
                {
                    idCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Country", x => x.idCountry);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Promotion",
                columns: table => new
                {
                    idPromotion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    concep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<float>(type: "real", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Promotion", x => x.idPromotion);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Recharge",
                columns: table => new
                {
                    idRecarge = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Recharge", x => x.idRecarge);
                });

            migrationBuilder.CreateTable(
                name: "SRH_TypeEmployee",
                columns: table => new
                {
                    idTypeEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_TypeEmployee", x => x.idTypeEmployee);
                });

            migrationBuilder.CreateTable(
                name: "SRH_TypePay",
                columns: table => new
                {
                    idTypePay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_TypePay", x => x.idTypePay);
                });

            migrationBuilder.CreateTable(
                name: "SRH_TypePerson",
                columns: table => new
                {
                    idTypePerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_TypePerson", x => x.idTypePerson);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Room",
                columns: table => new
                {
                    idRoom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numberRoom = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    idCategoryRoom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Room", x => x.idRoom);
                    table.ForeignKey(
                        name: "FK_SRH_Room_SRH_CategoryRoom_idCategoryRoom",
                        column: x => x.idCategoryRoom,
                        principalTable: "SRH_CategoryRoom",
                        principalColumn: "idCategoryRoom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Cities",
                columns: table => new
                {
                    idCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Cities", x => x.idCity);
                    table.ForeignKey(
                        name: "FK_SRH_Cities_SRH_Country_idCountry",
                        column: x => x.idCountry,
                        principalTable: "SRH_Country",
                        principalColumn: "idCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Person",
                columns: table => new
                {
                    idPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    document = table.Column<int>(type: "int", nullable: false),
                    numberDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idTypePerson = table.Column<int>(type: "int", nullable: false),
                    idCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Person", x => x.idPerson);
                    table.ForeignKey(
                        name: "FK_SRH_Person_SRH_Cities_idCity",
                        column: x => x.idCity,
                        principalTable: "SRH_Cities",
                        principalColumn: "idCity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SRH_Person_SRH_TypePerson_idTypePerson",
                        column: x => x.idTypePerson,
                        principalTable: "SRH_TypePerson",
                        principalColumn: "idTypePerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_SRH_Person_idPerson",
                        column: x => x.idPerson,
                        principalTable: "SRH_Person",
                        principalColumn: "idPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Booking",
                columns: table => new
                {
                    idBooking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    durationBooking = table.Column<int>(type: "int", nullable: false),
                    period = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    idPromotion = table.Column<int>(type: "int", nullable: true),
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    SR_PersonidPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Booking", x => x.idBooking);
                    table.ForeignKey(
                        name: "FK_SRH_Booking_SRH_Person_SR_PersonidPerson",
                        column: x => x.SR_PersonidPerson,
                        principalTable: "SRH_Person",
                        principalColumn: "idPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Contacts",
                columns: table => new
                {
                    idContacts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cellephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephoneHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telephoneOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Contacts", x => x.idContacts);
                    table.ForeignKey(
                        name: "FK_SRH_Contacts_SRH_Person_idPerson",
                        column: x => x.idPerson,
                        principalTable: "SRH_Person",
                        principalColumn: "idPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Employee",
                columns: table => new
                {
                    idEmployee = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shift = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    idTypeEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Employee", x => x.idEmployee);
                    table.ForeignKey(
                        name: "FK_SRH_Employee_SRH_Person_idPerson",
                        column: x => x.idPerson,
                        principalTable: "SRH_Person",
                        principalColumn: "idPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SRH_Employee_SRH_TypeEmployee_idTypeEmployee",
                        column: x => x.idTypeEmployee,
                        principalTable: "SRH_TypeEmployee",
                        principalColumn: "idTypeEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Bill",
                columns: table => new
                {
                    idBill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pay = table.Column<float>(type: "real", nullable: false),
                    Iva = table.Column<float>(type: "real", nullable: false),
                    emissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idRecharge = table.Column<int>(type: "int", nullable: false),
                    idBooking = table.Column<int>(type: "int", nullable: false),
                    idTypePay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Bill", x => x.idBill);
                    table.ForeignKey(
                        name: "FK_SRH_Bill_SRH_Booking_idBooking",
                        column: x => x.idBooking,
                        principalTable: "SRH_Booking",
                        principalColumn: "idBooking",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SRH_Bill_SRH_TypePay_idTypePay",
                        column: x => x.idTypePay,
                        principalTable: "SRH_TypePay",
                        principalColumn: "idTypePay",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_Binnacle",
                columns: table => new
                {
                    idBinnacle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idBooking = table.Column<int>(type: "int", nullable: false),
                    BookingidBooking = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_Binnacle", x => x.idBinnacle);
                    table.ForeignKey(
                        name: "FK_SRH_Binnacle_SRH_Booking_BookingidBooking",
                        column: x => x.BookingidBooking,
                        principalTable: "SRH_Booking",
                        principalColumn: "idBooking");
                });

            migrationBuilder.CreateTable(
                name: "SRH_CalendarDetail",
                columns: table => new
                {
                    idCalendarDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCalendar = table.Column<int>(type: "int", nullable: false),
                    idBooking = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_CalendarDetail", x => x.idCalendarDetail);
                    table.ForeignKey(
                        name: "FK_SRH_CalendarDetail_SRH_Booking_idBooking",
                        column: x => x.idBooking,
                        principalTable: "SRH_Booking",
                        principalColumn: "idBooking",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SRH_CalendarDetail_SRH_Calendar_idCalendar",
                        column: x => x.idCalendar,
                        principalTable: "SRH_Calendar",
                        principalColumn: "idCalendar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SRH_RoomDetail",
                columns: table => new
                {
                    idRoomDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idBooking = table.Column<int>(type: "int", nullable: false),
                    idRoom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRH_RoomDetail", x => x.idRoomDetail);
                    table.ForeignKey(
                        name: "FK_SRH_RoomDetail_SRH_Booking_idBooking",
                        column: x => x.idBooking,
                        principalTable: "SRH_Booking",
                        principalColumn: "idBooking",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SRH_RoomDetail_SRH_Room_idRoom",
                        column: x => x.idRoom,
                        principalTable: "SRH_Room",
                        principalColumn: "idRoom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_idPerson",
                table: "AspNetUsers",
                column: "idPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Bill_idBooking",
                table: "SRH_Bill",
                column: "idBooking");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Bill_idTypePay",
                table: "SRH_Bill",
                column: "idTypePay");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Binnacle_BookingidBooking",
                table: "SRH_Binnacle",
                column: "BookingidBooking");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Booking_SR_PersonidPerson",
                table: "SRH_Booking",
                column: "SR_PersonidPerson");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_CalendarDetail_idBooking",
                table: "SRH_CalendarDetail",
                column: "idBooking");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_CalendarDetail_idCalendar",
                table: "SRH_CalendarDetail",
                column: "idCalendar");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Cities_idCountry",
                table: "SRH_Cities",
                column: "idCountry");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Contacts_idPerson",
                table: "SRH_Contacts",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Employee_idPerson",
                table: "SRH_Employee",
                column: "idPerson",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Employee_idTypeEmployee",
                table: "SRH_Employee",
                column: "idTypeEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Person_idCity",
                table: "SRH_Person",
                column: "idCity");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Person_idTypePerson",
                table: "SRH_Person",
                column: "idTypePerson");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_Room_idCategoryRoom",
                table: "SRH_Room",
                column: "idCategoryRoom");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_RoomDetail_idBooking",
                table: "SRH_RoomDetail",
                column: "idBooking");

            migrationBuilder.CreateIndex(
                name: "IX_SRH_RoomDetail_idRoom",
                table: "SRH_RoomDetail",
                column: "idRoom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SRH_Bill");

            migrationBuilder.DropTable(
                name: "SRH_Binnacle");

            migrationBuilder.DropTable(
                name: "SRH_CalendarDetail");

            migrationBuilder.DropTable(
                name: "SRH_Contacts");

            migrationBuilder.DropTable(
                name: "SRH_Employee");

            migrationBuilder.DropTable(
                name: "SRH_Promotion");

            migrationBuilder.DropTable(
                name: "SRH_Recharge");

            migrationBuilder.DropTable(
                name: "SRH_RoomDetail");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SRH_TypePay");

            migrationBuilder.DropTable(
                name: "SRH_Calendar");

            migrationBuilder.DropTable(
                name: "SRH_TypeEmployee");

            migrationBuilder.DropTable(
                name: "SRH_Booking");

            migrationBuilder.DropTable(
                name: "SRH_Room");

            migrationBuilder.DropTable(
                name: "SRH_Person");

            migrationBuilder.DropTable(
                name: "SRH_CategoryRoom");

            migrationBuilder.DropTable(
                name: "SRH_Cities");

            migrationBuilder.DropTable(
                name: "SRH_TypePerson");

            migrationBuilder.DropTable(
                name: "SRH_Country");
        }
    }
}
