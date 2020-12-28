﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardSystem.Models
{
    public class User
    {
        [Key]
        public int No { get; set; }
        [Required]
        public string ID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
