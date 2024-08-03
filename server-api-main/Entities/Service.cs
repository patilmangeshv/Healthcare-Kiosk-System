using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace server_api.Entities
{
    [Table("tblService")]
    [Index(nameof(ServiceCode), IsUnique = true, Name = "UK_tblService_ServiceCode")]
    public class Service
    {
        [Column("ServiceId")]
        public int Id { get; set; }

        [StringLength(15), DataType(DataType.Text)]
        public string ServiceCode { get; set; }

        [StringLength(100), DataType(DataType.Text)]
        public string ServiceName { get; set; }

        [StringLength(500), DataType(DataType.Text)]
        public string ServiceNameFrench { get; set; }

        [StringLength(500), DataType(DataType.Text)]
        public string ServiceNameArabic { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public virtual Group Group {get; set;}
        
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public virtual Location Location {get; set;}

        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}