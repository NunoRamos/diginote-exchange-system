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

        [ForeignKey("Id")]
        public Order Order { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
    }
}
