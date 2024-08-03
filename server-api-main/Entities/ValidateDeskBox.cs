using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    public class ValidateDeskBox
    {
        [Column("BoxServiceId")]
        public int Id { get; set; }
        public int BoxId { get; set; }
        public int DeskId { get; set; } 
        public int ServiceId { get; set; }
        public int? SubServiceId { get; set; }
        public string DeskCode { get; set; }
        public string BoxNo { get; set; }
        public string ServiceCode { get; set; }
        public string SubServiceCode { get; set; }
    }
}