using Microsoft.EntityFrameworkCore.Migrations;

namespace server_api.Data.Migrations
{
    public partial class Add_up_GetNextPendingCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_text = 
                    @"
                    /*
                        EXEC up_GetNextPendingCoupon 1, 2, 1
                        EXEC up_GetNextPendingCoupon 2, 3, 1
                        EXEC up_GetNextPendingCoupon 3, 3, 1
                    */
                    CREATE PROCEDURE [dbo].[up_GetNextPendingCoupon]
                        @DeskId INT
                        ,@BoxId INT
                        ,@BoxUserId INT
                    AS
                    BEGIN
                        --SET NOCOUNT ON;
                        DECLARE @TotalCoupons INT, @CouponId INT

                        -- 1. Get Total coupons for today for the specified desk
                        SELECT @TotalCoupons=COUNT(C.CouponId)
                        FROM tblCoupon C
                            WHERE DeskId=@DeskId AND DATEDIFF(D, CouponGenerationDate, SYSDATETIME())=0

                        -- 2. Get top most pending coupon wherein no box is assigned
                        SELECT TOP 1 @CouponId=CouponId
                        FROM tblCoupon C
                            WHERE DeskId=@DeskId AND BoxId IS NULL AND DATEDIFF(D, CouponGenerationDate, SYSDATETIME())=0
                            ORDER BY CouponGenerationDateTime ASC

                        -- 3. Update the specified box to the coupon
                        UPDATE tblCoupon SET BoxId=@BoxId, BoxUserId=@BoxUserId, CallingDateTime=SYSDATETIME()
                            WHERE CouponId=@CouponId

                        -- 4. Return coupon details
                        SELECT CouponId, CouponNo, C.ServiceId, S.ServiceCode, S.ServiceName, C.SubServiceId, SS.SubServiceCode, SS.SubServiceName, @TotalCoupons AS TotalCoupons
                        FROM tblCoupon C
                            INNER JOIN tblService S ON C.ServiceId=S.ServiceId
                            LEFT JOIN tblSubService SS ON C.SubServiceId=SS.SubServiceId
                        WHERE CouponId=@CouponId

                    END
                    ";

            migrationBuilder.Sql(sp_text);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
