using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}