using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.models
{
    class Diginote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float FacialValue { get; set; }
        public int? OrderId { get; set; }
        [Required]
        public int OwnerId { get; set; }

        [ForeignKey("Id")]
        public virtual Order Order { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
    }
}
