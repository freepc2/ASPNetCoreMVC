using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardSystem.Models
{
    public class User
    {
        /// <summary>
        /// User의 번호(PK)
        /// </summary>
        [Key]
        public int No { get; set; }
        /// <summary>
        /// User ID
        /// </summary>
        [Required]
        public string ID { get; set; }
        /// <summary>
        /// User Password
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// User 이름
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
