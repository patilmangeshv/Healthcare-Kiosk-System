using Microsoft.EntityFrameworkCore.Migrations;

namespace server_api.Data.Migrations
{
    public partial class Add_NextPendingCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NextPendingCoupons",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponNo = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubServiceId = table.Column<int>(type: "int", nullable: true),
                    SubServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCoupons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextPendingCoupons", x => x.CouponId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextPendingCoupons");
        }
    }
}
