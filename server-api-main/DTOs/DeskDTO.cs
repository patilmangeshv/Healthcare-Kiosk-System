using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class DeskDTO
    {
        public int? Id { get; set; }
        [StringLength(10), DataType(DataType.Text)]
        [Required]
        public string DeskCode { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string DeskName { get; set; }
        [StringLength(500), DataType(DataType.Text)]
        public string deskAdminMessage { get; set; }
        public int UserId { get; set; }
        public DateTime InsertedDateTime {get;}
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}