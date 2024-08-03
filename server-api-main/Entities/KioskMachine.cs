using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace server_api.Entities
{
    [Table("tblKiosk")]
    [Index(nameof(MacAddress), IsUnique = true, Name = "UK_tblKiosk_MacAddress")]
    public class KioskMachine
    {
        [Column("KioskId")]
        public int Id { get; set; }

        [StringLength(20), DataType(DataType.Text)]
        public string KioskNo { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        public string KioskName { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string MacAddress { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        public string IPAddress { get; set; }

        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}