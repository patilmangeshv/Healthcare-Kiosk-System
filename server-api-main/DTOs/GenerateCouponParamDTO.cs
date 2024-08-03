using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class GenerateCouponParamDTO
    {
        [StringLength(15), DataType(DataType.Text)]
        public string ServiceCode { get; set; }
        [StringLength(15), DataType(DataType.Text)]
        public string SubServiceCode { get; set; }
        public int KioskId { get; set; }
        [StringLength(50), DataType(DataType.Text)]
        public string BiometricNo { get; set; }
    }
}