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
    public class LocationController : BaseApiController
    {
        private readonly DataContext _context;
        public LocationController(DataContext context)
        {
            this._context = context;
        }

        // api/location
        [HttpGet]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await this._context.Locations.ToListAsync();
        }

        // api/location/1
        [HttpGet("{locationId}")]
        // [Authorize]
        public async Task<ActionResult<Location>> GetLocation(int locationId)
        {
            var location = await this._context.Locations.FindAsync(locationId);

            return (location == null ? NotFound(null) : Ok(location));
        }

        // api/location/create-location{body}
        // {
        // "LocationName": "Location Name 05",
        // "Floor": "Floor05",
        // "Zone": "Zone05",
        // "userId": 1,
        // }
        [HttpPost("create-location")]
        // [Authorize]
        public async Task<ActionResult<Location>> CreateLocation(LocationDTO locationDTO)
        {
            var location = new Location
            {
                LocationName = locationDTO.LocationName,
                Floor = locationDTO.Floor,
                Zone = locationDTO.Zone,
                UserId = locationDTO.UserId,
                InsertedDateTime = DateTime.Now,
            };
            this._context.Locations.Add(location);
            await this._context.SaveChangesAsync();

            return location;
        }

        // api/location/modify-location{body}
        // {
        // "Id": 9,
        // "LocationName": "Location Name 05",
        // "Floor": "Floor05",
        // "Zone": "Zone05",
        // "UpdateUserId": 1,
        // }
        [HttpPost("modify-location")]
        // [Authorize]
        public async Task<ActionResult<Location>> ModifyLocation(LocationDTO locationDTO)
        {
            var location = await this._context.Locations.FindAsync(locationDTO.Id);
            if (location == null)
            {
                return BadRequest("Location data does not exists!");
            }
            else
            {
                location.LocationName = locationDTO.LocationName;
                location.Floor = locationDTO.Floor;
                location.Zone = locationDTO.Zone;
                location.UpdateUserId = locationDTO.UpdateUserId;
                location.UpdateDateTime = DateTime.Now;

                await this._context.SaveChangesAsync();

                return location;
            }
        }

        // api/location/delete-location/6
        [HttpDelete("delete-location/{locationId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteLocation(int locationId)
        {
            var location = await this._context.Locations.FindAsync(locationId);
            if (location == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.Locations.Remove(location);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}