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
    public class DeskController : BaseApiController
    {
        private readonly DataContext _context;
        public DeskController(DataContext context)
        {
            this._context = context;
        }

        // api/desks
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Desk>>> GetDesks()
        {
            return await this._context.Desks.ToListAsync();
        }

        // api/desk/1
        [HttpGet("{deskId}")]
        // [Authorize]
        public async Task<ActionResult<Desk>> GetDesk(int deskId)
        {
            var desk = await this._context.Desks.FindAsync(deskId);

            return (desk == null ? NotFound(null) : Ok(desk));
        }

        // api/desk/create-desk{body}
        // {
        // "DeskCode": "Desk05",
        // "DeskName": "Desk No 05",
        // "deskAdminMessage": "Admin messsage 05",
        // "userId": 1,
        // }
        [HttpPost("create-desk")]
        // [Authorize]
        public async Task<ActionResult<Desk>> CreateDesk(DeskDTO deskDTO)
        {
            var desk = new Desk
            {
                DeskCode = deskDTO.DeskCode,
                DeskName = deskDTO.DeskName,
                deskAdminMessage = deskDTO.deskAdminMessage,
                UserId = deskDTO.UserId,
                InsertedDateTime = DateTime.Now,
            };
            this._context.Desks.Add(desk);
            await this._context.SaveChangesAsync();

            return desk;
        }

        // api/desk/modify-desk{body}
        // {
        // "Id": 9,
        // "DeskCode": "Desk05",
        // "DeskName": "Desk No 05",
        // "deskAdminMessage": "Admin messsage 05",
        // "UpdateUserId": 1,
        // }
        [HttpPost("modify-desk")]
        // [Authorize]
        public async Task<ActionResult<Desk>> ModifyDesk(DeskDTO deskDTO)
        {
            var desk = await this._context.Desks.FindAsync(deskDTO.Id);
            if (desk == null)
            {
                return BadRequest("Desk data does not exists!");
            }
            else
            {
                desk.DeskCode = deskDTO.DeskCode;
                desk.DeskName = deskDTO.DeskName;
                desk.deskAdminMessage = deskDTO.deskAdminMessage;
                desk.UpdateUserId = deskDTO.UpdateUserId;
                desk.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return desk;
            }
        }

        // api/desk/delete-desk/6
        [HttpDelete("delete-desk/{deskId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteDesk(int deskId)
        {
            var desk = await this._context.Desks.FindAsync(deskId);
            if (desk == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.Desks.Remove(desk);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}