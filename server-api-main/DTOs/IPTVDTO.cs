using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.DTOs
{
    public class IPTVDTO
    {
        public int? Id { get; set; }
        [StringLength(20), DataType(DataType.Text)]
        [Required]
        public string IPTVNo { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string IPTVName { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string MacAddress { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        public string IPAddress { get; set; }
        public int DeskId { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public DateTime InsertedDateTime {get;}
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}