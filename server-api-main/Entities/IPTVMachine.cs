using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace server_api.Entities
{

    [Table("tblIPTV")]
    [Index(nameof(MacAddress), IsUnique = true, Name = "UK_tblIPTV_MacAddress")]
    public class IPTVMachine
    {
        [Column("IPTVId")]
        public int Id { get; set; }

        [StringLength(20), DataType(DataType.Text)]
        public string IPTVNo { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        public string IPTVName { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string MacAddress { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        public string IPAddress { get; set; }
        [ForeignKey("Desk")]
        [Required]
        public int DeskId { get; set; }
        public virtual Desk Desk { get; set; }

        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}