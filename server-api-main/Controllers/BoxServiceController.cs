using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using server_api.Data;
using server_api.DTOs;
using server_api.Entities;

namespace server_api.Controllers
{
    public class BoxServiceController : BaseApiController
    {
        private readonly DataContext _context;
        public BoxServiceController(DataContext context)
        {
            this._context = context;
        }

        // api/box-service
        [HttpGet("boxservices-iptv")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BoxServiceIPTV>>> GetBoxServicesIPTV(int DeskId)
        {
            var DeskIdParam = new SqlParameter("@DeskId", DeskId);

            var boxservices_IPTV = await this._context.BoxServicesIPTV
                .FromSqlRaw("EXECUTE up_GetBoxServiceIPTV @DeskId", DeskIdParam)
                .ToListAsync();

            if (boxservices_IPTV != null && boxservices_IPTV.Count > 0)
                return Ok(boxservices_IPTV);
            else
                return NotFound(null);

        }

        // api/box-service
        [HttpGet("boxservice")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BoxService>>> GetDeskBoxes(int DeskId)
        {
            var DeskBoxes = await this._context.BoxServices
                .Include(b => b.Box)
                .Include(d => d.Desk)
                // .Select(f => new {f.Id, f.BoxId, f.DeskId, 
                //     new Box{ b => {f.Box.Id}}})
                .ToListAsync();

            return Ok(DeskBoxes);
        }

        // api/boxservice
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<BoxService>>> GetBoxServices()
        {
            return await this._context.BoxServices
                    .Include(b => b.Box)
                    .Include(d => d.Desk)
                    .Include(s => s.Service)
                    // .Include(ss => ss.SubService)
                    .ToListAsync();
        }

        // api/boxservice/1
        [HttpGet("{boxserviceId}")]
        // [Authorize]
        public async Task<ActionResult<BoxService>> GetBoxService(int boxserviceId)
        {
            var boxservice = await this._context.BoxServices.FindAsync(boxserviceId);

            return (boxservice == null ? NotFound(null) : Ok(boxservice));
        }

        // api/boxservice/create-boxservice{body}
        [HttpPost("create-boxservice")]
        // [Authorize]
        public async Task<ActionResult<BoxService>> CreateBoxService(BoxServiceDTO boxserviceDTO)
        {
            var boxservice = new BoxService
            {
                DeskId = boxserviceDTO.DeskId,
                BoxId = boxserviceDTO.BoxId,
                ServiceId = boxserviceDTO.ServiceId,
                SubServiceId = boxserviceDTO.SubServiceId,
                UserId = boxserviceDTO.UserId,
                InsertedDateTime = DateTime.Now,
            };
            this._context.BoxServices.Add(boxservice);
            await this._context.SaveChangesAsync();

            return boxservice;
        }

        // api/boxservice/modify-boxservice{body}
        [HttpPost("modify-boxservice")]
        // [Authorize]
        public async Task<ActionResult<BoxService>> ModifyBoxService(BoxServiceDTO boxserviceDTO)
        {
            var boxservice = await this._context.BoxServices.FindAsync(boxserviceDTO.Id);
            if (boxservice == null)
            {
                return BadRequest("BoxService data does not exists!");
            }
            else
            {
                boxservice.DeskId = boxserviceDTO.DeskId;
                boxservice.BoxId = boxserviceDTO.BoxId;
                boxservice.ServiceId = boxserviceDTO.ServiceId;
                boxservice.SubServiceId = boxserviceDTO.SubServiceId;
                boxservice.UpdateUserId = boxserviceDTO.UpdateUserId;
                boxservice.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return boxservice;
            }
        }

        // api/boxservice/delete-boxservice/6
        [HttpDelete("delete-boxservice/{boxserviceId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteBoxService(int boxserviceId)
        {
            var boxservice = await this._context.BoxServices.FindAsync(boxserviceId);
            if (boxservice == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.BoxServices.Remove(boxservice);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}