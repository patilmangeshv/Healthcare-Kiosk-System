using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    [Table("tblLocation")]
    public class Location
    {
        [Column("LocationId")]
        public int Id { get; set; }

        [StringLength(100), DataType(DataType.Text)]
        public string LocationName { get; set; }

        [StringLength(15), DataType(DataType.Text)]
        [Required]
        public string Floor { get; set; }
        
        [StringLength(15), DataType(DataType.Text)]
        [Required]
        public string Zone { get; set; }

        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
