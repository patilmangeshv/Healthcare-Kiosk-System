using Microsoft.EntityFrameworkCore.Migrations;

namespace server_api.Data.Migrations
{
    public partial class Add_up_ValidateDeskBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_text = 
                    @"
                    /*
                    @ApplicationType
                            iptv = 0,
                            kiosk = 1,
                            lightuser = 2,
                            deskuser = 3,
                            doctoruser = 4,
                            qms = 5,

                        EXEC up_ValidateDeskBox 1, 'DEM01', 'BOX 02'
                        EXEC up_ValidateDeskBox 2, 'DIN03', 'BOX 06'
                        EXEC up_ValidateDeskBox 0, 'DIN03', 'X'
                    */
                    ALTER PROCEDURE [dbo].[up_ValidateDeskBox]
                        @ApplicationType TINYINT
                        ,@DeskCode NVARCHAR(15)
                        ,@BoxNo NVARCHAR(15)
                    AS
                    BEGIN
                        --SET NOCOUNT ON;
                        DECLARE @DeskId INT, @BoxId INT, @LDeskCode NVARCHAR(15), @LBoxNo NVARCHAR(15)

                        SELECT @LDeskCode = LOWER(@DeskCode)
                        SELECT @LBoxNo = LOWER(@BoxNo)

                        SELECT @DeskId=DeskId FROM tblDesk WHERE LOWER(DeskCode)=@DeskCode
                        SELECT @BoxId=BoxId FROM tblBox WHERE LOWER(BoxNo)=@BoxNo

                        IF @ApplicationType = 0		-- for IPTV
                        BEGIN
                            IF @DeskId IS NOT NULL
                            BEGIN
                                SELECT BoxServiceId, BS.BoxId, BS.DeskId, BS.ServiceId, BS.SubServiceId, @DeskCode DeskCode, @BoxNo BoxNo, S.ServiceCode, SS.SubServiceCode 
                                FROM tblBoxService BS
                                    INNER JOIN tblService S ON BS.ServiceId=S.ServiceId AND S.IsActive=1
                                    LEFT JOIN tblSubService SS ON BS.SubServiceId=SS.SubServiceId
                                WHERE BS.DeskId=@DeskId
                            END
                        END
                        ELSE
                        BEGIN
                            SELECT BoxServiceId, BS.BoxId, BS.DeskId, BS.ServiceId, BS.SubServiceId, @DeskCode DeskCode, @BoxNo BoxNo, S.ServiceCode, SS.SubServiceCode 
                            FROM tblBoxService BS
                                INNER JOIN tblService S ON BS.ServiceId=S.ServiceId AND S.IsActive=1
                                LEFT JOIN tblSubService SS ON BS.SubServiceId=SS.SubServiceId
                            WHERE BS.DeskId=@DeskId AND BS.BoxId=@BoxId
                        END
                    END
                    ";

            migrationBuilder.Sql(sp_text);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
