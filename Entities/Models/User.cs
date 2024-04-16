using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(256)]
        [Column("USERNAME", TypeName = "varchar(256)")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail is required")]
        [MaxLength(256)]
        [Column("MAIL", TypeName = "varchar(256)")]
        public string Mail { get; set; }

        [Column("PHONENUMBER")]
        public int PhoneNumber { get; set; }

        [MaxLength(256)]
        [Column("SKILLSET", TypeName = "varchar(256)")]
        public string SkillSets { get; set; }

        [MaxLength(256)]
        [Column("HOBBY", TypeName = "varchar(256)")]
        public string Hobby { get; set; }
    }
}
