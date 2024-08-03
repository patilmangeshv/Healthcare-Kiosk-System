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
    public class IPTVController : BaseApiController
    {
        private readonly DataContext _context;
        public IPTVController(DataContext context)
        {
            this._context = context;
        }

        // api/iptv
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<IPTVMachine>>> GetIPTVs()
        {
            return await this._context.IPTVMachines.ToListAsync();
        }

        // // api/iptv/validate-address{body}
        // [HttpPost("validate-address")]
        // [AllowAnonymous]
        // public async Task<ActionResult<bool>> ValidateAddress(ValidateAddressDTO addressDetails)
        // {
        //     var iptv  = await this.GetIPTV(addressDetails.IPAddress);

        //     if (iptv == null)
        //         return Unauthorized(false);
        //     else if (iptv.IsActive)
        //         return Ok(true);
        //     else
        //         return Unauthorized(false);
        // }

        // api/iptv/6
        [HttpGet("{iptvId}")]
        // [Authorize]
        public async Task<ActionResult<IPTVMachine>> GetIPTV(int iptvId)
        {
            var iptv = await this._context.IPTVMachines.FindAsync(iptvId);
            return (iptv == null ? NotFound(null) : Ok(iptv));
        }

        // api/iptv/create-iptv{body}
        // {
        // "iptvNo": "IPTV07",
        // "iptvName": "IPTV05 DESK INFO 07",
        // "isActive": true,
        // "userId": 1,
        // "macAddress": "77:33:34:29",
        // "ipAddress": "192.168.1.2",
        // "deskId": 3
        // }
        [HttpPost("create-iptv")]
        // [Authorize]
        public async Task<ActionResult<IPTVMachine>> CreateIPTV(IPTVDTO iptvDTO)
        {
            iptvDTO.MacAddress = iptvDTO.MacAddress.ToLower();
            if (await this.IsMacAddressExists(iptvDTO.MacAddress, iptvDTO.Id))
            {
                return BadRequest("Duplicate mac address!");
            }
            else
            {
                var iptv = new IPTVMachine
                {
                    IPTVNo = iptvDTO.IPTVNo,
                    IPTVName = iptvDTO.IPTVName,
                    IsActive = iptvDTO.IsActive,
                    UserId = iptvDTO.UserId,
                    MacAddress = iptvDTO.MacAddress,
                    IPAddress = iptvDTO.IPAddress,
                    DeskId = iptvDTO.DeskId,
                    InsertedDateTime = DateTime.Now,
                };
                this._context.IPTVMachines.Add(iptv);
                await this._context.SaveChangesAsync();

                return iptv;
            }
        }

        // api/iptv/modify-iptv{body}
        // {
        // "Id": 9,
        // "IPTVNo": "IPTV05",
        // "IPTVName": "IPTV No 05",
        // "IsActive": true,
        // "UpdateUserId": 1,
        // "macAddress": "dd:33:hr:12",
        // "IPAddress": "191.168.1.0"
        // }
        [HttpPost("modify-iptv")]
        // [Authorize]
        public async Task<ActionResult<IPTVMachine>> ModifyIPTV(IPTVDTO iptvDTO)
        {
            iptvDTO.MacAddress = iptvDTO.MacAddress.ToLower();
            var iptv = await this._context.IPTVMachines.FindAsync(iptvDTO.Id);

            if (iptv == null)
            {
                return BadRequest("IPTV data does not exists!");
            }
            else if (await this.IsMacAddressExists(iptvDTO.MacAddress, iptvDTO.Id))
            {
                return BadRequest("Duplicate mac address!");
            }
            else
            {
                iptv.IPTVNo = iptvDTO.IPTVNo;
                iptv.IPTVName = iptvDTO.IPTVName;
                iptv.IsActive = iptvDTO.IsActive;
                iptv.UpdateUserId = iptvDTO.UpdateUserId;
                iptv.MacAddress = iptvDTO.MacAddress;
                iptv.IPAddress = iptvDTO.IPAddress;
                iptv.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return iptv;
            }
        }

        // api/iptv/delete-iptv/6
        [HttpDelete("delete-iptv/{iptvId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteIPTV(int iptvId)
        {
            var iptv = await this._context.IPTVMachines.FindAsync(iptvId);
            if (iptv == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.IPTVMachines.Remove(iptv);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
        private async Task<bool> IsMacAddressExists(string macAddress, int? iptvId)
        {
            var iptv = await this._context.IPTVMachines.SingleOrDefaultAsync(iptv =>
                    iptv.MacAddress == macAddress && (iptvId == null || iptv.Id != iptvId));

            return (iptv != null);
        }
    }
}