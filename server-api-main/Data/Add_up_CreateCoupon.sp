using Microsoft.EntityFrameworkCore.Migrations;

namespace server_api.Data.Migrations
{
    public partial class Add_up_CreateCoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_text = 
                    @"
                    CREATE PROCEDURE up_CreateCoupon
                        @ServiceCode NVARCHAR(15)
                        ,@SubServiceCode NVARCHAR(15)
                        ,@KioskId INT
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        -- Generate Coupon
                        -- Fields to generate next Coupon No
                        -- ServiceId,SubServiceId,BoxId,CouponGenerationDate -- for Coupon generation for information and emergency we don't need Box

                        IF @SubServiceCode = ''
                            SET @SubServiceCode = NULL

                        DECLARE @CouponId INT, @Floor NVARCHAR(10), @Zone NVARCHAR(5), @DeskCode NVARCHAR(5)
                        DECLARE @ServiceId INT, @SubServiceId INT, @CouponGenerationDate DATE, @BoxId INT, @BoxUserId INT, @CouponNo INT, @LocationId INT, @DeskId INT

                        SELECT @CouponGenerationDate = SYSDATETIME()

                        -- 1. Get Service id and location id
                        SELECT @ServiceId=ServiceId, @LocationId=LocationId FROM tblService WHERE ServiceCode=@ServiceCode AND IsActive=1

                        -- 2. Get sub service id and location id if @SubServiceCode is specified
                        IF @SubServiceCode IS NOT NULL
                            SELECT @SubServiceId=SubServiceId, @LocationId=LocationId, @LocationId=LocationId FROM tblSubService WHERE ServiceId=@ServiceId AND SubServiceCode=@SubServiceCode

                        -- 3. Get Location details
                        SELECT @Floor=[Floor], @Zone=[Zone] FROM tblLocation WHERE LocationId=@LocationId

                        -- 4. Get Desk Id
                        SELECT @DeskId=DeskId FROM tblDeskService WHERE ServiceId=@ServiceId
                        SELECT @DeskCode=DeskCode FROM tblDesk WHERE DeskId=@DeskId

                        -- 5. Get next coupon number
                        IF @SubServiceCode IS NULL
                            SELECT @CouponNo=MAX(CouponNo)+1 FROM tblCoupon
                            WHERE ServiceId=@ServiceId AND CouponGenerationDate=@CouponGenerationDate
                            GROUP BY ServiceId,CouponGenerationDate
                        ELSE
                            SELECT @CouponNo=MAX(CouponNo)+1 FROM tblCoupon
                                WHERE ServiceId=@ServiceId AND SubServiceId=@SubServiceId AND CouponGenerationDate=@CouponGenerationDate
                                GROUP BY ServiceId,SubServiceId,CouponGenerationDate

                        IF @@ROWCOUNT=0
                            -- No record found so this is the first coupon
                            SET @CouponNo=1

                        -- 6. Generate Coupon
                        INSERT INTO tblCoupon
                            (ServiceId
                            ,SubServiceId
                            ,BoxId
                            ,BoxUserId
                            ,CouponGenerationDate
                            ,CouponNo
                            ,CouponGenerationDateTime
                            ,LocationId
                            ,DeskId
                            ,IsInProgress
                            ,KioskId)
                        VALUES (
                            @ServiceId
                            ,@SubServiceId
                            ,@BoxId
                            ,@BoxUserId
                            ,@CouponGenerationDate
                            ,@CouponNo
                            ,SYSDATETIME()
                            ,@LocationId
                            ,@DeskId
                            ,1		-- By default whenever we create coupon it will be in progress
                            ,@KioskId
                        )
                        SELECT @CouponId=SCOPE_IDENTITY()

                        -- 7. Return newly generated Coupon details to be printed on Coupon
                        SELECT @CouponId AS CouponId, @Floor AS [Floor], @Zone AS [Zone], @DeskCode AS DeskCode, @ServiceCode AS ServiceCode, @SubServiceCode AS SubServiceCode, CouponNo, CouponGenerationDateTime
                        FROM tblCoupon
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
