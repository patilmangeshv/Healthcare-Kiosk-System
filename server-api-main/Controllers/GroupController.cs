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
    public class GroupController : BaseApiController
    {
        private readonly DataContext _context;
        public GroupController(DataContext context)
        {
            this._context = context;
        }

        // api/group
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await this._context.Groups.ToListAsync();
        }

        // api/group/1
        [HttpGet("{groupId}")]
        // [Authorize]
        public async Task<ActionResult<Group>> GetGroup(int groupId)
        {
            var group = await this._context.Groups.FindAsync(groupId);

            return (group == null ? NotFound(null) : Ok(group));
        }

        // api/group/create-group{body}
        // {
        // "GroupName": "Group Name 05",
        // "GroupNameFrench": "Group Name 05",
        // "GroupNameArabic": "Group Name 05",
        // "userId": 1,
        // }
        [HttpPost("create-group")]
        // [Authorize]
        public async Task<ActionResult<Group>> CreateGroup(GroupDTO groupDTO)
        {
            var group = new Group
            {
                GroupName = groupDTO.GroupName,
                GroupNameFrench = groupDTO.GroupNameFrench,
                GroupNameArabic = groupDTO.GroupNameArabic,
                UserId = groupDTO.UserId,
                InsertedDateTime = DateTime.Now,
            };
            this._context.Groups.Add(group);
            await this._context.SaveChangesAsync();

            return group;
        }

        // api/group/modify-group{body}
        // {
        // "Id": 9,
        // "GroupName": "Group Name 05",
        // "GroupNameFrench": "Group Name 05",
        // "GroupNameArabic": "Group Name 05",
        // "UpdateUserId": 1,
        // }
        [HttpPost("modify-group")]
        // [Authorize]
        public async Task<ActionResult<Group>> ModifyGroup(GroupDTO groupDTO)
        {
            var group = await this._context.Groups.FindAsync(groupDTO.Id);
            if (group == null)
            {
                return BadRequest("Group data does not exists!");
            }
            else
            {
                group.GroupName = groupDTO.GroupName;
                group.GroupNameFrench = groupDTO.GroupNameFrench;
                group.GroupNameArabic = groupDTO.GroupNameArabic;
                group.UpdateUserId = groupDTO.UpdateUserId;
                group.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return group;
            }
        }

        // api/group/delete-group/6
        [HttpDelete("delete-group/{groupId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteGroup(int groupId)
        {
            var group = await this._context.Groups.FindAsync(groupId);
            if (group == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.Groups.Remove(group);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}