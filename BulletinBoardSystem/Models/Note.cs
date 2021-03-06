﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardSystem.Models
{
    public class Note
    {   /// <summary>
        /// PK 번호
        /// </summary>
        [Key]
        public int No { get; set; }
        /// <summary>
        /// 게시판 제목
        /// </summary>
        [Required(ErrorMessage ="제목을 입력하세요")]
        public string Title { get; set; }
        /// <summary>
        /// 게시판 내용
        /// </summary>
        [Required(ErrorMessage = "내용을 입력하세요")]
        public string Contents { get; set; }
        /// <summary>
        /// 게시판 작성자
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }
}
