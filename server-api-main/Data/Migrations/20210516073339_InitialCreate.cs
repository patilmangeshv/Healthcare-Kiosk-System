using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server_api.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneratedCouponDetails",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeskCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponNo = table.Column<int>(type: "int", nullable: false),
                    CouponGenerationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedCouponDetails", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "tblBox",
                columns: table => new
                {
                    BoxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxNo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BoxName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBox", x => x.BoxId);
                });

            migrationBuilder.CreateTable(
                name: "tblCoupon",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KioskId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SubServiceId = table.Column<int>(type: "int", nullable: true),
                    BoxId = table.Column<int>(type: "int", nullable: true),
                    BoxUserId = table.Column<int>(type: "int", nullable: true),
                    CouponGenerationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Only stores DD/MM/YYYY. Used for generation CouponNo on daily basis."),
                    CouponNo = table.Column<int>(type: "int", nullable: false),
                    CouponGenerationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Stores complete coupon generation datetime."),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DeskId = table.Column<int>(type: "int", nullable: false),
                    CallingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsInProgress = table.Column<bool>(type: "bit", nullable: true),
                    IsAbsent = table.Column<bool>(type: "bit", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: true),
                    CompletionDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCoupon", x => x.CouponId);
                });

            migrationBuilder.CreateTable(
                name: "tblDesk",
                columns: table => new
                {
                    DeskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeskCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DeskName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDesk", x => x.DeskId);
                });

            migrationBuilder.CreateTable(
                name: "tblGroup",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GroupNameFrench = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GroupNameArabic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGroup", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "tblKiosk",
                columns: table => new
                {
                    KioskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KioskNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    KioskName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKiosk", x => x.KioskId);
                });

            migrationBuilder.CreateTable(
                name: "tblLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocation", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserLevel = table.Column<string>(type: "char(1)", maxLength: 1, nullable: true, comment: "Super Admin:S, Admin: A, Desk User: U, Doctor User: D, Light Users: L"),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ValidateDeskBoxes",
                columns: table => new
                {
                    BoxServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxId = table.Column<int>(type: "int", nullable: false),
                    DeskId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SubServiceId = table.Column<int>(type: "int", nullable: true),
                    DeskCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidateDeskBoxes", x => x.BoxServiceId);
                });

            migrationBuilder.CreateTable(
                name: "tblIPTV",
                columns: table => new
                {
                    IPTVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPTVNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IPTVName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeskId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIPTV", x => x.IPTVId);
                    table.ForeignKey(
                        name: "FK_tblIPTV_tblDesk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "tblDesk",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblService",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ServiceNameFrench = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ServiceNameArabic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblService", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_tblService_tblGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "tblGroup",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblService_tblLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBoxService",
                columns: table => new
                {
                    BoxServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SubServiceId = table.Column<int>(type: "int", nullable: true),
                    DeskId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBoxService", x => x.BoxServiceId);
                    table.ForeignKey(
                        name: "FK_tblBoxService_tblBox_BoxId",
                        column: x => x.BoxId,
                        principalTable: "tblBox",
                        principalColumn: "BoxId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblBoxService_tblDesk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "tblDesk",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBoxService_tblService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "tblService",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDeskService",
                columns: table => new
                {
                    DeskServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeskId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDeskService", x => x.DeskServiceId);
                    table.ForeignKey(
                        name: "FK_tblDeskService_tblDesk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "tblDesk",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblDeskService_tblService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "tblService",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblSubService",
                columns: table => new
                {
                    SubServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SubServiceCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SubServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubServiceNameFrench = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubServiceNameArabic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubService", x => x.SubServiceId);
                    table.ForeignKey(
                        name: "FK_tblSubService_tblService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "tblService",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBoxService_BoxId",
                table: "tblBoxService",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBoxService_DeskId",
                table: "tblBoxService",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBoxService_ServiceId",
                table: "tblBoxService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeskService_DeskId",
                table: "tblDeskService",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDeskService_ServiceId",
                table: "tblDeskService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_tblIPTV_DeskId",
                table: "tblIPTV",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "UK_tblIPTV_MacAddress",
                table: "tblIPTV",
                column: "MacAddress",
                unique: true,
                filter: "[MacAddress] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UK_tblKiosk_MacAddress",
                table: "tblKiosk",
                column: "MacAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblService_GroupId",
                table: "tblService",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tblService_LocationId",
                table: "tblService",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "UK_tblService_ServiceCode",
                table: "tblService",
                column: "ServiceCode",
                unique: true,
                filter: "[ServiceCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubService_ServiceId",
                table: "tblSubService",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneratedCouponDetails");

            migrationBuilder.DropTable(
                name: "tblBoxService");

            migrationBuilder.DropTable(
                name: "tblCoupon");

            migrationBuilder.DropTable(
                name: "tblDeskService");

            migrationBuilder.DropTable(
                name: "tblIPTV");

            migrationBuilder.DropTable(
                name: "tblKiosk");

            migrationBuilder.DropTable(
                name: "tblSubService");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "ValidateDeskBoxes");

            migrationBuilder.DropTable(
                name: "tblBox");

            migrationBuilder.DropTable(
                name: "tblDesk");

            migrationBuilder.DropTable(
                name: "tblService");

            migrationBuilder.DropTable(
                name: "tblGroup");

            migrationBuilder.DropTable(
                name: "tblLocation");
        }
    }
}
