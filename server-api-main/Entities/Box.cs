using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    [Table("tblBox")]
    public class Box
    {
        [Column("BoxId")]
        public int Id { get; set; }

        [StringLength(10), DataType(DataType.Text)]
        [Required]
        public string BoxNo { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        public string BoxName { get; set; }
        
        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}