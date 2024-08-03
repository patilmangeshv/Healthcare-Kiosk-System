using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    public class BoxServiceIPTV
    {
        [Column("BoxServiceId")]
        public int Id { get; set; }
        public int BoxId { get; set; }
        public string BoxNo { get; set; }
        public int ServiceId { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public int? SubServiceId { get; set; }
        public string SubServiceCode { get; set; }
        public string SubServiceName { get; set; }
        public int DeskId { get; set; }
        public string DeskCode { get; set; }
        public string DeskAdminMessage { get; set; }
        public DateTime ServerDateTime { get; set; }
        public int currentCoupon { get; set; }
        public int totalCoupons { get; set; }
    }
}