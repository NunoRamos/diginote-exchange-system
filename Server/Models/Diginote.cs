using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Diginote
    {
        public Diginote()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public float FacialValue { get; set; }
        [Required]
        public int OwnerId { get; set; }


        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
