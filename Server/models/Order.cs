using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.models
{
    public enum OrderStatus
    {
        Active, Suspended, Complete
    }

    public enum OrderType
    {
        Sell, Purchase
    }

    class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Quote { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [Required]
        [ForeignKey("Id")]
        public Diginote Diginote { get; set; }

        [Required]
        [ForeignKey("Id")]
        public User CreatedBy { get; set; }

        [ForeignKey("Id")]
        public Transaction Transaction { get; set; }
    }
}
