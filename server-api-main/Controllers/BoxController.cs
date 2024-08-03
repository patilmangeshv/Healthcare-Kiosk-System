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
    public class BoxController : BaseApiController
    {
        private readonly DataContext _context;
        public BoxController(DataContext context)
        {
            this._context = context;
        }

        // api/box
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<Box>>> GetBoxes()
        {
            return await this._context.Boxes.ToListAsync();
        }

        // api/box/1
        [HttpGet("{boxId}")]
        // [Authorize]
        public async Task<ActionResult<Box>> GetBox(int boxId)
        {
            var box = await this._context.Boxes.FindAsync(boxId);

            return (box == null ? NotFound(null) : Ok(box));
        }

        // api/box/create-box{body}
        // {
        // "BoxNo": "Box05",
        // "BoxName": "Box No 05",
        // "userId": 1,
        // }
        [HttpPost("create-box")]
        // [Authorize]
        public async Task<ActionResult<Box>> CreateBox(BoxDTO boxDTO)
        {
            var box = new Box
            {
                BoxNo = boxDTO.BoxNo,
                BoxName = boxDTO.BoxName,
                UserId = boxDTO.UserId,
                InsertedDateTime = DateTime.Now,
            };
            this._context.Boxes.Add(box);
            await this._context.SaveChangesAsync();

            return box;
        }

        // api/box/modify-box{body}
        // {
        // "Id": 9,
        // "BoxNo": "Box05",
        // "BoxName": "Box No 05",
        // "UpdateUserId": 1,
        // }
        [HttpPost("modify-box")]
        // [Authorize]
        public async Task<ActionResult<Box>> ModifyBox(BoxDTO boxDTO)
        {
            var box = await this._context.Boxes.FindAsync(boxDTO.Id);
            if (box == null)
            {
                return BadRequest("Box data does not exists!");
            }
            else
            {
                box.BoxNo = boxDTO.BoxNo;
                box.BoxName = boxDTO.BoxName;
                box.UpdateUserId = boxDTO.UpdateUserId;
                box.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return box;
            }
        }

        // api/box/delete-box/6
        [HttpDelete("delete-box/{boxId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteBox(int boxId)
        {
            var box = await this._context.Boxes.FindAsync(boxId);
            if (box == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.Boxes.Remove(box);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}