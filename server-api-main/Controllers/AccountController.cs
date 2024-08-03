using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using server_api.Data;
using server_api.DTOs;
using server_api.Entities;
using server_api.Interfaces;

namespace server_api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            this._tokenService = tokenService;
            this._context = context;
        }

        // protected override void Dispose(bool disposing)
        // {
        //     base.Dispose(disposing);
        // }

        // api/account/login{body}
        [HttpPost("login")]
        public async Task<ActionResult<UserConfigDTO>> Login(LoginDTO loginDTO)
        {
            var DeskId = 0;
            var DeskCode = "";
            var BoxId = 0;
            var IPTVId = 0;
            var KioskId = 0;
            var BoxNo = "";

            // 1. Check if username exists
            var user = await this._context.Users.SingleOrDefaultAsync(user => user.UserName == loginDTO.Username.ToLower());

            if (user == null) return Unauthorized("Invalid user credentials.");

            // 2. Check if the password is matching
            // 2.1 Fetch user has password
            using var hmac = new HMACSHA512(user.PasswordSalt);

            // 2.2 Compute hash of the login password
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            // 2.3 Compare login hash password and user has password
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid user credentials.");
            }

            // 3. Check if user is active
            if (!user.IsActive) return Unauthorized("User is not active.");

            // 4. Check if user is allowed to access the application
            //  1. Only superadmin can login to IPTV and Kiosk
            //  2. Only superadmin ans Doctor can login to Call Doctor user application
            //  3. Only superadmin ans Desk User can login to Call Desk User application
            //  4. Desk and Doctor user is not allowed to login to QMS application but others can

            var isValid = false;

            switch (loginDTO.ApplicationType)
            {
                case ApplicationTypeEnum.iptv:
                case ApplicationTypeEnum.kiosk:
                    isValid = (user.UserLevel == "s") ? true : false;
                    break;

                case ApplicationTypeEnum.lightuser:
                    isValid = (user.UserLevel == "s" || user.UserLevel == "a" || user.UserLevel == "l") ? true : false;
                    break;

                case ApplicationTypeEnum.deskuser:
                    isValid = (user.UserLevel == "s" || user.UserLevel == "a" || user.UserLevel == "u") ? true : false;
                    break;

                case ApplicationTypeEnum.doctoruser:
                    isValid = (user.UserLevel == "s" || user.UserLevel == "a" || user.UserLevel == "d") ? true : false;
                    break;

                default:
                    isValid = (user.UserLevel == "d" || user.UserLevel == "u") ? false : true;
                    break;
            }

            // 5. Validate if mac address is valid or not
            if (isValid)
            {
                KioskId = 0;
                IPTVId = 0;

                if (loginDTO.ApplicationType == ApplicationTypeEnum.kiosk)
                {
                    var macDetails = await this.IsValidMacAddressKiosk(loginDTO);
                    if (macDetails == null || macDetails.Count < 1)
                        isValid = false;
                    else
                    {
                        KioskId = macDetails[0].Id;
                    }
                }
                else if (loginDTO.ApplicationType == ApplicationTypeEnum.iptv)
                {
                    var macDetails = await this.IsValidMacAddressIPTV(loginDTO);
                    if (macDetails == null || macDetails.Count < 1)
                        isValid = false;
                    else
                    {
                        IPTVId = macDetails[0].Id;
                    }
                }

                if (!isValid)
                    return Unauthorized("Login from this machine is not allowed.");
            }
            else
            {
                return Unauthorized("Login to this application is not allowed using this credentials.");
            }

            // 6. Validate Desk and Box for iptv, light user, desk user and doctor user
            if (isValid)
            {
                if (!(loginDTO.ApplicationType == ApplicationTypeEnum.kiosk
                     || loginDTO.ApplicationType == ApplicationTypeEnum.qms))
                {
                    if (loginDTO.DeskCode.Trim() == "" || loginDTO.BoxNo.Trim() == "")
                    {
                        return Unauthorized("Deskcode or BoxNo is mandatory!");
                    }
                    else
                    {
                        var validDeskBoxes = await this.GetDeskBoxInfo(loginDTO);
                        if (validDeskBoxes != null && validDeskBoxes.Count() > 0)
                        {
                            DeskId = validDeskBoxes[0].DeskId;
                            DeskCode = validDeskBoxes[0].DeskCode;
                            BoxId = validDeskBoxes[0].BoxId;
                            BoxNo = validDeskBoxes[0].BoxNo;
                        }
                        else
                            return NotFound("Desk and Box combination does not exists!");
                    }
                }
            }
            else
            {
                return Unauthorized("Login from this machine is not allowed.");
            }


            if (isValid)
            {
                return new UserConfigDTO
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    DeskId = DeskId,
                    DeskCode = DeskCode,
                    BoxNo = BoxNo,
                    BoxId = BoxId,
                    IPTVId = IPTVId,
                    KioskId = KioskId,
                    Token = this._tokenService.CreateToken(user),
                };
            }
            else
            {
                return Unauthorized("Login from this machine is not allowed.");
            }
        }

        private async Task<List<ValidateDeskBox>> GetDeskBoxInfo(LoginDTO loginDTO)
        {
            var ApplicationTypeParam = new SqlParameter("@ApplicationType", loginDTO.ApplicationType);
            var DeskCodeParam = new SqlParameter("@DeskCode", loginDTO.DeskCode.Trim());
            var BoxNoParam = new SqlParameter("@BoxNo", loginDTO.BoxNo.Trim());

            var validDeskBoxes = await this._context.ValidateDeskBoxes
                    .FromSqlRaw("EXECUTE up_ValidateDeskBox @ApplicationType, @DeskCode, @BoxNo", ApplicationTypeParam, DeskCodeParam, BoxNoParam)
                    .ToListAsync();

            return validDeskBoxes;
        }

        private async Task<List<KioskMachine>> IsValidMacAddressKiosk(LoginDTO loginDTO)
        {
            var macAddress = loginDTO.MacAddress.Trim().ToLower();
            if (macAddress == "")
                return null;
            else
                return await this._context.KioskMachines
                     .Where(kiosk => kiosk.IsActive && kiosk.MacAddress == macAddress).ToListAsync();
        }

        private async Task<List<IPTVMachine>> IsValidMacAddressIPTV(LoginDTO loginDTO)
        {
            var macAddress = loginDTO.MacAddress.Trim().ToLower();
            if (macAddress == "")
                return null;
            else
                return await this._context.IPTVMachines
                        .Where(iptv => iptv.IsActive && iptv.MacAddress == macAddress).ToListAsync();
        }
    }
}