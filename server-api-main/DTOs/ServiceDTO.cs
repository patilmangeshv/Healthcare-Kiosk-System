using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class ServiceDTO
    {
        public int? Id { get; set; }
        [StringLength(15), DataType(DataType.Text)]
        [Required]
        public string ServiceCode { get; set; }

        [StringLength(100), DataType(DataType.Text)]
        public string ServiceName { get; set; }
        [StringLength(100), DataType(DataType.Text)]
        public string ServiceNameFrench { get; set; }
        [StringLength(100), DataType(DataType.Text)]
        public string ServiceNameArabic { get; set; }

        public int GroupId { get; set; }
        public int LocationId { get; set; }
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; }

        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}