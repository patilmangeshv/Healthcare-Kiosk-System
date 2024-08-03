using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_api.Entities
{
    [Table("tblGroup")]
    public class Group
    {
        [Column("GroupId")]
        public int Id { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        [Required]
        public string GroupName { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        public string GroupNameFrench { get; set; }

        [StringLength(50), DataType(DataType.Text)]
        public string GroupNameArabic { get; set; }
        
        public int UserId { get; set; }
        public DateTime InsertedDateTime { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}