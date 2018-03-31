using System;
using System.ComponentModel.DataAnnotations;

namespace Server.models
{
    class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Order SellOrder { get; set; }

        [Required]
        public Order PurchaseOrder { get; set; }
    }
}
