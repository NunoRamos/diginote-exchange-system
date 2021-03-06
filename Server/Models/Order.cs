﻿using Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public abstract class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public float Quote { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public int CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        // public virtual Transaction Transaction { get; set; }

        public Common.Serializable.Order Serialize()
        {
            return new Common.Serializable.Order
            {
                CreatedAt = CreatedAt,
                CreatedById = CreatedById,
                Id = Id,
                Quote = Quote,
                Status = Status
            };
        }
    }
}
