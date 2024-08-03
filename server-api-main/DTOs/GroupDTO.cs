using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class GroupDTO
    {
        public int? Id { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string GroupName { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        public string GroupNameFrench { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        public string GroupNameArabic { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDateTime {get;}

        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}