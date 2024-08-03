using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class BoxDTO
    {
        public int? Id { get; set; }
        [StringLength(10), DataType(DataType.Text)]
        [Required]
        public string BoxNo { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string BoxName { get; set; }
        public int UserId { get; set; }
        public DateTime InsertedDateTime {get;}
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}