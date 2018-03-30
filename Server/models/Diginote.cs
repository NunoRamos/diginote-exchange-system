﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.models
{
    class Diginote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float FacialValue { get; set; }

        public Order Order { get; set; }

        [Required]
        public User Owner { get; set; }
    }
}
