using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    // [NotMapped]
    public class GeneratedCouponDetail
    {
        [Column("CouponId")]
        public int Id { get; set; }
        public string Floor { get; set; }   
        public string Zone { get; set; }
        public string DeskCode { get; set; }
        public string ServiceCode { get; set; }
        public string SubServiceCode { get; set; }
        public int CouponNo { get; set; }
        public DateTime CouponGenerationDateTime { get; set; }
        public string CouponNoFormatted
        {
            get { return this.CouponNo.ToString().PadLeft(3,'0'); }
        }
    }
}