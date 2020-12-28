using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardSystem.Models
{
    public class Note
    {
        [Key]
        public int No { get; set; }
        [Required]
        public string Tilte { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }
}
