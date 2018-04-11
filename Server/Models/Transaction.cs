using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Transaction
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
        public virtual SellOrder SellOrder { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public Common.Serializable.Transaction Serialize()
        {
            return new Common.Serializable.Transaction
            {
                CreatedAt = CreatedAt,
                Id = Id,
                PurchaseOrder = PurchaseOrder.Serialize(),
                Quote = Quote,
                SellOrder = SellOrder.Serialize()
            };
        }
    }
}
