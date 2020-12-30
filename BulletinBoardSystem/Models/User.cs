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
        [Required(ErrorMessage ="사용자의 아이디를 입력해주세요")]
        public string ID { get; set; }
        /// <summary>
        /// User Password
        /// </summary>
        [Required(ErrorMessage ="사용자의 패스워드를 입력해주세요")]
        public string Password { get; set; }
        /// <summary>
        /// User 이름
        /// </summary>
        [Required(ErrorMessage ="사용자의 이름을 입력해주세요")]
        public string Name { get; set; }
    }
}
