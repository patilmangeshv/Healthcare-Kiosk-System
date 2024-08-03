using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class NextPendingCouponDTO
    {
        public int DeskId { get; set; }
        public int BoxId { get; set; }
        public int BoxUserId { get; set; }
    }
}