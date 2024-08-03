using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class UpdateCouponStatusDTO
    {
        public int CouponId { get; set; }
        [StringLength(1)]
        public string Status { get; set; }
    }
}