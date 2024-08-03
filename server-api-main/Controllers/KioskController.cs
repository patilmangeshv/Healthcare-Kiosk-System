using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using server_api.Data;
using server_api.DTOs;
using server_api.Entities;

namespace server_api.Controllers
{
    public class KioskController : BaseApiController
    {
        private readonly DataContext _context;
        public KioskController(DataContext context)
        {
            this._context = context;
        }

        // api/kiosk
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<KioskMachine>>> GetKiosks()
        {
            return await this._context.KioskMachines.ToListAsync();
        }

        // // api/kiosk/validate-address{body}
        // [HttpPost("validate-address")]
        // [AllowAnonymous]
        // public async Task<ActionResult<bool>> ValidateAddress(ValidateAddressDTO addressDetails)
        // {
        //     var kiosk = await this.GetKiosk(addressDetails.IPAddress);

        //     if (kiosk == null)
        //         return Unauthorized(false);
        //     else if (kiosk.IsActive)
        //         return Ok(true);
        //     else
        //         return Unauthorized(false);
        // }

        // api/kiosk/6
        [HttpGet("{kioskId}")]
        // [Authorize]
        public async Task<ActionResult<KioskMachine>> GetKiosk(int kioskId)
        {
            var kiosk = await this._context.KioskMachines.FindAsync(kioskId);

            return (kiosk == null ? NotFound(null) : Ok(kiosk));
        }

        // api/kiosk/create-kiosk{body}
        // {
        // "KioskNo": "Kiosk05",
        // "KioskName": "Kiosk No 05",
        // "IsActive": true,
        // "userId": 1,
        // "macAddress": "dd:33:hr:12",
        // "IPAddress": "191.168.1.0"
        // }
        [HttpPost("create-kiosk")]
        // [Authorize]
        public async Task<ActionResult<KioskMachine>> CreateKiosk(KioskDTO kioskDTO)
        {
            kioskDTO.MacAddress = kioskDTO.MacAddress.ToLower();
            if (await this.IsMacAddressExists(kioskDTO.MacAddress, kioskDTO.Id))
            {
                return BadRequest("Duplicate mac address!");
            }
            else
            {
                var kiosk = new KioskMachine
                {
                    KioskNo = kioskDTO.KioskNo,
                    KioskName = kioskDTO.KioskName,
                    IsActive = kioskDTO.IsActive,
                    UserId = kioskDTO.UserId,
                    MacAddress = kioskDTO.MacAddress,
                    IPAddress = kioskDTO.IPAddress,
                    InsertedDateTime = DateTime.Now,
                };
                this._context.KioskMachines.Add(kiosk);
                await this._context.SaveChangesAsync();

                return kiosk;
            }
        }

        // api/kiosk/modify-kiosk{body}
        // {
        // "Id": 9,
        // "KioskNo": "Kiosk05",
        // "KioskName": "Kiosk No 05",
        // "IsActive": true,
        // "UpdateUserId": 1,
        // "macAddress": "dd:33:hr:12",
        // "IPAddress": "191.168.1.0"
        // }
        [HttpPost("modify-kiosk")]
        // [Authorize]
        public async Task<ActionResult<KioskMachine>> ModifyKiosk(KioskDTO kioskDTO)
        {
            kioskDTO.MacAddress = kioskDTO.MacAddress.ToLower();
            var kiosk = await this._context.KioskMachines.FindAsync(kioskDTO.Id);

            if (kiosk == null)
            {
                return BadRequest("Kiosk data does not exists!");
            }
            else if (await this.IsMacAddressExists(kioskDTO.MacAddress, kioskDTO.Id))
            {
                return BadRequest("Duplicate mac address!");
            }
            else
            {
                kiosk.KioskNo = kioskDTO.KioskNo;
                kiosk.KioskName = kioskDTO.KioskName;
                kiosk.IsActive = kioskDTO.IsActive;
                kiosk.UpdateUserId = kioskDTO.UpdateUserId;
                kiosk.MacAddress = kioskDTO.MacAddress;
                kiosk.IPAddress = kioskDTO.IPAddress;
                kiosk.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return kiosk;
            }
        }

        // api/kiosk/delete-kiosk/6
        [HttpDelete("delete-kiosk/{kioskId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteKiosk(int kioskId)
        {
            var kiosk = await this._context.KioskMachines.FindAsync(kioskId);
            if (kiosk == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.KioskMachines.Remove(kiosk);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
        private async Task<bool> IsMacAddressExists(string macAddress, int? kioskId)
        {
            var kiosk = await this._context.KioskMachines.SingleOrDefaultAsync(kiosk =>
                    kiosk.MacAddress == macAddress && (kioskId == null || kiosk.Id != kioskId));

            return (kiosk != null);
        }
    }
}