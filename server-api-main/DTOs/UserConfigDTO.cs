namespace server_api.DTOs
{
    public class UserConfigDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int DeskId { get; set; }
        public string DeskCode { get; set; }
        public int BoxId { get; set; }
        public string BoxNo { get; set; }
        public int IPTVId { get; set; }
        public int KioskId { get; set; }
        public string Token { get; set; }
    }
}