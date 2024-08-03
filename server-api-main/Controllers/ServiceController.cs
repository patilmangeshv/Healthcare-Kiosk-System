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
    public class ServiceController : BaseApiController
    {
        private readonly DataContext _context;
        public ServiceController(DataContext context)
        {
            this._context = context;
        }

        // api/service
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await this._context.Services
                    .Include(g => g.Group)
                    .Include(l => l.Location)
                    .ToListAsync();
        }

        // api/service/1
        [HttpGet("{serviceId}")]
        // [Authorize]
        public async Task<ActionResult<Service>> GetService(int serviceId)
        {
            var service = await this._context.Services.FindAsync(serviceId);

            return (service == null ? NotFound(null) : Ok(service));
        }

        // api/service/create-service{body}
        // {
        // "ServiceCode": "Service05",
        // "ServiceName": "Service Name 05",
        // "ServiceNameFrench": ServiceNameFrench 05",
        // "ServiceNameArabic": "ServiceNameArabic 05",
        // "GroupId": 1,
        // "LocationId": 1,
        // "IsActive": 1,
        // "userId": 1,
        // }
        [HttpPost("create-service")]
        // [Authorize]
        public async Task<ActionResult<Service>> CreateService(ServiceDTO serviceDTO)
        {
            var service = new Service
            {
                ServiceCode = serviceDTO.ServiceCode,
                ServiceName = serviceDTO.ServiceName,
                ServiceNameFrench = serviceDTO.ServiceNameFrench,
                ServiceNameArabic = serviceDTO.ServiceNameArabic,
                GroupId = serviceDTO.GroupId,
                LocationId = serviceDTO.LocationId,
                IsActive = serviceDTO.IsActive,
                UserId = serviceDTO.UserId,
                InsertedDateTime = DateTime.Now,
            };
            this._context.Services.Add(service);
            await this._context.SaveChangesAsync();

            return service;
        }

        // api/service/modify-service{body}
        // {
        // "Id": 9,
        // "ServiceCode": "Service05",
        // "ServiceName": "Service Name 05",
        // "ServiceNameFrench": ServiceNameFrench 05",
        // "ServiceNameArabic": "ServiceNameArabic 05",
        // "GroupId": 1,
        // "LocationId": 1,
        // "IsActive": 1,
        // "UpdateUserId": 1,
        // }
        [HttpPost("modify-service")]
        // [Authorize]
        public async Task<ActionResult<Service>> ModifyService(ServiceDTO serviceDTO)
        {
            var service = await this._context.Services.FindAsync(serviceDTO.Id);
            if (service == null)
            {
                return BadRequest("Service data does not exists!");
            }
            else
            {
                service.ServiceCode = serviceDTO.ServiceCode;
                service.ServiceName = serviceDTO.ServiceName;
                service.ServiceNameFrench = serviceDTO.ServiceNameFrench;
                service.ServiceNameArabic = serviceDTO.ServiceNameArabic;
                service.GroupId = serviceDTO.GroupId;
                service.LocationId = serviceDTO.LocationId;
                service.IsActive = serviceDTO.IsActive;
                service.UpdateUserId = serviceDTO.UpdateUserId;
                service.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return service;
            }
        }

        // api/service/delete-service/6
        [HttpDelete("delete-service/{serviceId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteService(int serviceId)
        {
            var service = await this._context.Services.FindAsync(serviceId);
            if (service == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.Services.Remove(service);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}