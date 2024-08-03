using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    public class NextPendingCoupon
    {
        [Column("CouponId")]
        public int Id { get; set; }
        public int CouponNo { get; set; }
        public int ServiceId { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int? SubServiceId { get; set; }
        public string SubServiceCode { get; set; }
        public string SubServiceName { get; set; }
        public int TotalCoupons { get; set; }
    }
}