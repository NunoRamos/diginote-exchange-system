using System;

namespace Common.Serializable
{
    [Serializable]
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public float Quote { get; set; }

        public OrderStatus Status { get; set; }

        public OrderType Type { get; set; }

        public int CreatedById { get; set; }

        public int DiginoteId { get; set; }
    }
}
