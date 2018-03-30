using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.models
{
    class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Nickname { get; set; }
        public String Password { get; set; }

        [Required]
        public List<Diginote> Diginotes { get; set; }

        [Required]
        public List<Order> Orders { get; set; }
    }
}
