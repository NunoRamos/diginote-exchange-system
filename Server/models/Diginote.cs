using System.ComponentModel.DataAnnotations;

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
