using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.models
{
    class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }


        [Required]
        [ForeignKey("Id")]
        public Order SellOrder { get; set; }

        [Required]
        [ForeignKey("Id")]
        public Order PurchaseOrder { get; set; }
    }
}
