using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.models
{
    class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public String Nickname { get; set; }

        public String Password { get; set; }

        public virtual ICollection<Diginote> Diginotes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
