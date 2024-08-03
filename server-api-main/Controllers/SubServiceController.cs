using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using server_api.Data;
using server_api.DTOs;
using server_api.Entities;

namespace server_api.Controllers
{
    public class SubServiceController : BaseApiController
    {
        private readonly DataContext _context;
        public SubServiceController(DataContext context)
        {
            this._context = context;
        }

        // api/subservice
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<SubService>>> GetSubServices()
        {
            return await this._context.SubServices.ToListAsync();
        }

        // api/subservice/subservices/1
        [HttpGet("subservices/{serviceId}")]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<SubService>>> GetSubServices(int serviceId)
        {
            return await this._context.SubServices
                .Where(sub => sub.ServiceId == serviceId).ToListAsync();
        }

        // api/subservice/1
        [HttpGet("{subserviceId}")]
        // [Authorize]
        public async Task<ActionResult<SubService>> GetSubService(int subserviceId)
        {
            var subservice = await this._context.SubServices.FindAsync(subserviceId);

            return (subservice == null ? NotFound(null) : Ok(subservice));
        }

        // api/subservice/create-subservice{body}
        // {
        // "ServiceId": 1,
        // "SubServiceCode": "SubService05",
        // "SubServiceName": "SubService Name 05",
        // "SubServiceNameFrench": SubServiceNameFrench 05",
        // "SubServiceNameArabic": "SubServiceNameArabic 05",
        // "LocationId": 1,
        // "userId": 1,
        // }
        [HttpPost("create-subservice")]
        // [Authorize]
        public async Task<ActionResult<SubService>> CreateSubService(SubServiceDTO subserviceDTO)
        {
            var subservice = new SubService
            {
                ServiceId = subserviceDTO.ServiceId,
                SubServiceCode = subserviceDTO.SubServiceCode,
                SubServiceName = subserviceDTO.SubServiceName,
                SubServiceNameFrench = subserviceDTO.SubServiceNameFrench,
                SubServiceNameArabic = subserviceDTO.SubServiceNameArabic,
                LocationId = subserviceDTO.LocationId,
                UserId = subserviceDTO.UserId,
                InsertedDateTime = DateTime.Now,
            };
            this._context.SubServices.Add(subservice);
            await this._context.SaveChangesAsync();

            return subservice;
        }

        // api/subservice/modify-subservice{body}
        // {
        // "Id": 9,
        // "ServiceId": 1,
        // "SubServiceCode": "SubService05",
        // "SubServiceName": "SubService Name 05",
        // "SubServiceNameFrench": SubServiceNameFrench 05",
        // "SubServiceNameArabic": "SubServiceNameArabic 05",
        // "LocationId": 1,
        // "UpdateUserId": 1,
        // }
        [HttpPost("modify-subservice")]
        // [Authorize]
        public async Task<ActionResult<SubService>> ModifySubService(SubServiceDTO subserviceDTO)
        {
            var subservice = await this._context.SubServices.FindAsync(subserviceDTO.Id);
            if (subservice == null)
            {
                return BadRequest("SubService data does not exists!");
            }
            else
            {
                subservice.ServiceId = subserviceDTO.ServiceId;
                subservice.SubServiceCode = subserviceDTO.SubServiceCode;
                subservice.SubServiceName = subserviceDTO.SubServiceName;
                subservice.SubServiceNameFrench = subserviceDTO.SubServiceNameFrench;
                subservice.SubServiceNameArabic = subserviceDTO.SubServiceNameArabic;
                subservice.LocationId = subserviceDTO.LocationId;
                subservice.UpdateUserId = subserviceDTO.UpdateUserId;
                subservice.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return subservice;
            }
        }

        // api/subservice/delete-subservice/6
        [HttpDelete("delete-subservice/{subserviceId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteSubService(int subserviceId)
        {
            var subservice = await this._context.SubServices.FindAsync(subserviceId);
            if (subservice == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.SubServices.Remove(subservice);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}