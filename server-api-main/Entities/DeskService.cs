using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    [Table("tblDeskService")]
    public class DeskService
    {
        [Column("DeskServiceId")]
        public int Id { get; set; }

        [ForeignKey("Desk")]
        [Required]
        public int DeskId { get; set; }
        public virtual Desk Desk { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        
        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}