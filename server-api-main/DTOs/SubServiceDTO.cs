using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class SubServiceDTO
    {
        public int? Id { get; set; }
        public int ServiceId { get; set; }

        [StringLength(15), DataType(DataType.Text)]
        [Required]
        public string SubServiceCode { get; set; }

        [StringLength(100), DataType(DataType.Text)]
        public string SubServiceName { get; set; }
        [StringLength(100), DataType(DataType.Text)]
        public string SubServiceNameFrench { get; set; }
        [StringLength(100), DataType(DataType.Text)]
        public string SubServiceNameArabic { get; set; }

        public int LocationId { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; }

        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}