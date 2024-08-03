using server_api.Entities;

namespace server_api.DTOs
{
    public class LoginDTO
    {
        public ApplicationTypeEnum ApplicationType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MacAddress { get; set; }
        public string DeskCode { get; set; }
        public string BoxNo { get; set; }
    }
}