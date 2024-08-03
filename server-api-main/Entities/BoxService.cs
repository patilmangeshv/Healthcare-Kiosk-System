using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    [Table("tblBoxService")]
    public class BoxService
    {
        [Column("BoxServiceId")]
        public int Id { get; set; }

        [ForeignKey("Box")]
        public int? BoxId { get; set; }
        public virtual Box Box { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public int? SubServiceId { get; set; }

        [ForeignKey("Desk")]
        public int DeskId { get; set; }
        public virtual Desk Desk { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}