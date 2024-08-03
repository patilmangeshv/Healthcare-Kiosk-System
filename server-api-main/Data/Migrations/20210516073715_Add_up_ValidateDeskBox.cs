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
                            EXEC up_ValidateDeskBox 'DEM01', 'BOX 02'
                            EXEC up_ValidateDeskBox 'DIN03', 'BOX 06'
                        */
                        CREATE PROCEDURE [dbo].[up_ValidateDeskBox]
                            @DeskCode NVARCHAR(15)
                            ,@BoxNo NVARCHAR(15)
                        AS
                        BEGIN
                            --SET NOCOUNT ON;
                            DECLARE @DeskId INT, @BoxId INT, @LDeskCode NVARCHAR(15), @LBoxNo NVARCHAR(15)

                            SELECT @LDeskCode = LOWER(@DeskCode)
                            SELECT @LBoxNo = LOWER(@BoxNo)

                            SELECT @DeskId=DeskId FROM tblDesk WHERE LOWER(DeskCode)=@DeskCode
                            SELECT @BoxId=BoxId FROM tblBox WHERE LOWER(BoxNo)=@BoxNo

                            SELECT BoxServiceId, BS.BoxId, BS.DeskId, BS.ServiceId, BS.SubServiceId, @DeskCode DeskCode, @BoxNo BoxNo, S.ServiceCode, SS.SubServiceCode 
                            FROM tblBoxService BS
                                INNER JOIN tblService S ON BS.ServiceId=S.ServiceId AND S.IsActive=1
                                LEFT JOIN tblSubService SS ON BS.SubServiceId=SS.SubServiceId
                            WHERE BS.DeskId=@DeskId AND BS.BoxId=@BoxId

                        END
                    ";

            migrationBuilder.Sql(sp_text);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
