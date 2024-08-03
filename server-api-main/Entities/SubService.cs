using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    [Table("tblSubService")]
    public class SubService
    {
        [Column("SubServiceId")]
        public int Id { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        [StringLength(15), DataType(DataType.Text)]
        public string SubServiceCode { get; set; }

        [StringLength(100), DataType(DataType.Text)]
        [Required]
        public string SubServiceName { get; set; }
        [StringLength(500), DataType(DataType.Text)]
        public string SubServiceNameFrench { get; set; }
        [StringLength(500), DataType(DataType.Text)]
        public string SubServiceNameArabic { get; set; }

        [Required]
        public int LocationId { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}