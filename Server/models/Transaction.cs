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
        public float Quote { get; set; }

        [Required]
        public int SellOrderId { get; set; }

        [Required]
        public int PurchaseOrderId { get; set; }

        [ForeignKey("SellOrderId")]
        public virtual Order SellOrder { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public virtual Order PurchaseOrder { get; set; }
    }
}
