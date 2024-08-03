using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using server_api.Data;
using server_api.DTOs;
using server_api.Entities;
using server_api.Interfaces;

namespace server_api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public UserController(DataContext context, ITokenService tokenService)
        {
            this._tokenService = tokenService;
            this._context = context;
        }

        // api/user
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var appUsers = await this._context.Users.ToListAsync();

            if (appUsers == null)
            {
                return NotFound(null);
            }
            else
            {
                var userDTOs = new List<UserDTO>();

                foreach (var appUser in appUsers)
                {
                    userDTOs.Add(new UserDTO()
                    {
                        Id = appUser.Id,
                        UserType = appUser.UserLevel,
                        Username = appUser.UserName,
                        Password = null,
                        IsActive = appUser.IsActive,
                    });
                }
                return Ok(userDTOs);
            }
        }

        // api/user/3
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await this._context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(null);
            }
            else
            {
                var userDTO = new UserDTO()
                {
                    Id = user.Id,
                    UserType = user.UserLevel,
                    Username = user.UserName,
                    Password = null,
                    IsActive = user.IsActive,
                };

                return Ok(userDTO);
            }
        }

        // api/user/create-user{body}
        [HttpPost("create-user")]
        //[Authorize]
        public async Task<ActionResult<UserDTO>> CreateNewUser(UserDTO userDTO)
        {
            if (await this.UserExists(userDTO.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserLevel = userDTO.UserType,
                UserName = userDTO.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                PasswordSalt = hmac.Key,
                EmployeeId = 0,
                IsActive = userDTO.IsActive,
            };
            this._context.Users.Add(user);
            await this._context.SaveChangesAsync();

            return new UserDTO
            {
                Id = user.Id,
                UserType = user.UserLevel,
                Username = user.UserName,
                Password = null,
                IsActive = user.IsActive,
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await this._context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

        // api/user/modify-user{body}
        [HttpPost("modify-user")]
        // [Authorize]
        public async Task<ActionResult<UserDTO>> ModifyUser(UserDTO userDTO)
        {
            var user = await this._context.Users.FindAsync(userDTO.Id);
            if (user == null)
            {
                return BadRequest("User data does not exists!");
            }
            else
            {
                using var hmac = new HMACSHA512();

                user.UserLevel = userDTO.UserType;
                user.UserName = userDTO.Username.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                user.PasswordSalt = hmac.Key;
                user.IsActive = userDTO.IsActive;

                await this._context.SaveChangesAsync();

                var userDTOModified = new UserDTO()
                {
                    Id = user.Id,
                    UserType = user.UserLevel,
                    Username = user.UserName,
                    Password = null,
                    IsActive = user.IsActive,
                };

                return Ok(userDTOModified);
            }
        }

        // api/user/delete-user/6
        [HttpDelete("delete-user/{userId}")]
        // [Authorize]
        public async Task<ActionResult<bool>> DeleteUser(int userId)
        {
            var user = await this._context.Users.FindAsync(userId);
            if (user == null)
            {
                return BadRequest(false);
            }
            else
            {
                this._context.Users.Remove(user);
                await this._context.SaveChangesAsync();

                return Ok(true);
            }
        }
    }
}