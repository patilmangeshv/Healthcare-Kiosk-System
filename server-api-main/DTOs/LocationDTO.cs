using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class LocationDTO
    {
        public int? Id { get; set; }
        [StringLength(100), DataType(DataType.Text)]
        [Required]
        public string LocationName { get; set; }

        [StringLength(15), DataType(DataType.Text)]
        public string Floor { get; set; }

        [StringLength(15), DataType(DataType.Text)]
        public string Zone { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDateTime {get;}

        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}