using Microsoft.EntityFrameworkCore.Migrations;

namespace server_api.Data.Migrations
{
    public partial class Add_up_GetBoxServiceIPTV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_text = 
                    @"
                    /*
                        EXEC up_GetBoxServiceIPTV 1
                        EXEC up_GetBoxServiceIPTV 2
                        EXEC up_GetBoxServiceIPTV 3
                    */
                    CREATE PROCEDURE [dbo].[up_GetBoxServiceIPTV]
                        @DeskId INT
                    AS
                    BEGIN
                        --SET NOCOUNT ON;
                        DECLARE @TotalCoupons INT, @CouponId INT

                        SELECT BoxServiceId, BS.BoxId, B.BoxNo, BS.ServiceId, ServiceName, SubServiceId, BS.DeskId, DeskCode, 0 AS CurrentCoupon, 0 AS TotalCoupons
                                FROM tblBoxService BS 
                                INNER JOIN tblBox B ON BS.BoxId=B.BoxId
                                INNER JOIN tblDesk D ON BS.DeskId=D.DeskId
                                INNER JOIN tblService S ON BS.ServiceId=S.ServiceId
                            WHERE BS.DeskId=@DeskId
                            ORDER BY B.BoxNo
                    END
                    ";

            migrationBuilder.Sql(sp_text);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
