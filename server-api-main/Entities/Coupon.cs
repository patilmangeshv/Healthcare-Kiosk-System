using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace server_api.Entities
{
    [Table("tblCoupon")]
    public class Coupon
    {
        [Column("CouponId")]
        public int Id { get; set; }

        public int KioskId { get; set; }

        // [ForeignKey("Service")]
        [Required]
        public int ServiceId { get; set; }
        // public virtual Service Service { get; set; }

        // [ForeignKey("SubService")]
        public int? SubServiceId { get; set; }
        // public virtual SubService SubService { get; set; }

        // [ForeignKey("Box")]
        public int? BoxId { get; set; }
        // public virtual Box Box { get; set; }
        public int? BoxUserId { get; set; }

        [Comment("Only stores DD/MM/YYYY. Used for generation CouponNo on daily basis.")]
        [Required]
        public DateTime CouponGenerationDate { get; set; }
        [Required]
        public int CouponNo { get; set; }
        [Comment("Stores complete coupon generation datetime.")]
        [Required]
        public DateTime CouponGenerationDateTime { get; set; }

        // [ForeignKey("Location")]
        public int LocationId { get; set; }
        // public virtual Location Location { get; set; }

        // [ForeignKey("Desk")]
        public int DeskId { get; set; }
        // public virtual Desk Desk { get; set; }

        public DateTime? CallingDateTime { get; set; }
        public bool? IsInProgress { get; set; }
        public bool? IsAbsent { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletionDateTime { get; set; }
    }
}