using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class User
    {
        public User()
        {
            Diginotes = new HashSet<Diginote>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public String Nickname { get; set; }

        [Required]
        public String Password { get; set; }

        public virtual ICollection<Diginote> Diginotes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
