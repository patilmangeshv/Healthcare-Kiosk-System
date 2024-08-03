using System;
using System.ComponentModel.DataAnnotations;

namespace server_api.DTOs
{
    public class BoxServiceDTO
    {
        public int? Id { get; set; }
        public int DeskId { get; set; }
        public int BoxId { get; set; }
        public int ServiceId { get; set; }
        public int? SubServiceId { get; set; }
        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; }
    }
}